
# thinking
We are migrating from a custom Webpack configuration to Angular 19's built-in build tool (likely using esbuild).  
Angular 19 has improved support for using esbuild as the build tool, and it might be the default or at least a supported option.

Steps:

1. **Update Angular CLI and Core to version 19**
    
    - Check the current version of Angular and update to v19.
        
    - This might involve updating `@angular/core`, `@angular/cli`, and other Angular packages.
        
2. **Remove custom Webpack configuration**
    
    - If you were using `@angular-builders/custom-webpack` or similar, you can remove it.
        
    - Also remove any `webpack.config.js` or similar files.
        
3. **Adjust angular.json to use the new build tool**
    
    - In Angular 19, the build tool might be specified in the `angular.json` file.
        
    - Look for the `builder` property in the `build` and `serve` targets.
        
    - The new builder might be `"@angular-devkit/build-angular:application"` (for standalone apps) or `"@angular-devkit/build-angular:browser"` (for module-based apps) but note that in Angular 19, the `application` builder is the default for new projects and uses esbuild.
        
4. **Handle any custom Webpack configuration**
    
    - If you had custom Webpack configuration, you need to find equivalent options in the new build tool.
        
    - For example:
        
        - If you had custom loaders, you might need to find a way to integrate them or replace them with esbuild plugins.
            
        - If you had custom aliases, you can set them in the `tsconfig.json` or in the `angular.json` under the `options` for the build target.
            
5. **Check for breaking changes**
    
    - Angular 19 might have breaking changes. Check the official update guide for Angular 19.
        
6. **Test the build**
    
    - Run `ng build` and `ng serve` to see if everything works.
        
7. **Update any third-party libraries**
    
    - Some libraries might have been relying on the Webpack configuration. Check for updates or alternative ways to integrate them.
        
8. **Consider using esbuild plugins**
    
    - If you had complex Webpack configurations, you might need to write esbuild plugins to achieve the same functionality.
        

Let's break down the steps in detail:

Step 1: Update Angular to version 19

Update your `package.json` to have the following versions (or higher) of Angular packages:

text

"dependencies": {
  "@angular/animations": "^19.0.0",
  "@angular/common": "^19.0.0",
  "@angular/compiler": "^19.0.0",
  "@angular/core": "^19.0.0",
  // ... other dependencies
},
"devDependencies": {
  "@angular-devkit/build-angular": "^19.0.0",
  "@angular/cli": "^19.0.0",
  "@angular/compiler-cli": "^19.0.0",
  // ... other dev dependencies
}

Then run `npm install` or `yarn install`.

Step 2: Remove custom Webpack packages and configuration

If you were using `@angular-builders/custom-webpack`, remove it:

text

npm uninstall @angular-builders/custom-webpack

Also, remove any `webpack.config.js` or `custom-webpack.config.js` files.

Step 3: Adjust angular.json

In your `angular.json`, update the `builder` for the `build` and `serve` targets.

For a standalone app (if you are using the new standalone API by default in Angular 19), you might use:

text

"architect": {
  "build": {
    "builder": "@angular-devkit/build-angular:application",
    "options": {
       // ... other options
    }
  },
  "serve": {
    "builder": "@angular-devkit/build-angular:dev-server",
    "options": {
       // ... other options
    }
  }
}

For a module-based app, you might use:

text

"architect": {
  "build": {
    "builder": "@angular-devkit/build-angular:browser",
    "options": {
       // ... other options
    }
  }
}

However, note that the `application` builder is the default for new projects in Angular 19 and uses esbuild. It is recommended to use the `application` builder if you are building a standalone app.

Step 4: Handle custom Webpack configuration

If you had custom Webpack configuration, you need to map them to the new build tool.

Example 1: Aliases

In Webpack, you might have had:

javascript

resolve: {
  alias: {
    '@app': path.resolve(__dirname, 'src/app/')
  }
}

In the new build tool, you can set aliases in the `tsconfig.json` (or `tsconfig.app.json`):

json

{
  "compilerOptions": {
    "baseUrl": "./",
    "paths": {
      "@app/*": ["src/app/*"]
    }
  }
}

Example 2: Custom loaders/plugins

If you had custom loaders or plugins, you might need to write an esbuild plugin. However, note that the new Angular build tool does not expose esbuild plugins directly in the `angular.json`. You might need to use the `build-angular` tool's plugin system if available, or consider if the functionality is already provided by the new build tool.

For example, if you were using a Webpack plugin for SVG icons, you might now use Angular's built-in SVG template support or find an alternative.

Step 5: Check for breaking changes

Read the Angular 19 update guide for any breaking changes that might affect your application.

Step 6: Test the build

Run:

text

ng build
ng serve

Step 7: Update third-party libraries

Some libraries might have been relying on Webpack. Check their documentation for Angular 19 support.

Step 8: Esbuild plugins

If you must have some custom build step, you might need to create a custom builder that extends the Angular build process. However, this is advanced and might not be necessary for most cases.

Additional note: Angular 19 might have a different way of handling polyfills. If you were including polyfills via Webpack, check the new way of including polyfills (might be in the `angular.json` or in a separate polyfills file).

Let me know if you have specific custom Webpack configurations that you are unsure how to migrate.


# Step-by-Step Guide: Migrating from Custom Webpack to Angular 19's Built-in Build Tool

## **Step 1: Assess Your Current Setup**

### Before starting, identify what your custom Webpack configuration does:
1. **Check `angular.json`** for custom builder configuration:
```json
"architect": {
  "build": {
    "builder": "@angular-builders/custom-webpack:browser",
    "options": {
      "customWebpackConfig": {
        "path": "./webpack.config.js"
      }
    }
  }
}
```

2. **Review your `webpack.config.js`** and note:
   - Custom loaders/plugins
   - Path aliases/resolve configurations
   - Environment-specific configurations
   - Bundle optimizations
   - Polyfills or shims

## **Step 2: Update Angular to Version 19**

```bash
# Update Angular CLI globally
npm install -g @angular/cli@19

# Update project dependencies
ng update @angular/core@19 @angular/cli@19

# Or update package.json manually
{
  "dependencies": {
    "@angular/core": "^19.0.0",
    // other Angular packages...
  },
  "devDependencies": {
    "@angular/cli": "^19.0.0",
    "@angular-devkit/build-angular": "^19.0.0",
    // remove custom webpack builders
  }
}
```

## **Step 3: Remove Custom Webpack Dependencies**

```bash
# Remove custom webpack dependencies
npm uninstall @angular-builders/custom-webpack
npm uninstall webpack-merge @types/webpack

# Clean up unused webpack plugins/loaders
npm uninstall [your-specific-webpack-plugins]
```

## **Step 4: Restore Default Angular Builder**

### Update `angular.json`:
```json
{
  "projects": {
    "your-project": {
      "architect": {
        "build": {
          "builder": "@angular-devkit/build-angular:application", // For new standalone apps
          // OR for module-based apps (if not migrated yet):
          // "builder": "@angular-devkit/build-angular:browser",
          
          "options": {
            // Remove customWebpackConfig section
            "outputPath": "dist/your-app",
            "index": "src/index.html",
            "main": "src/main.ts",
            
            // Add any specific configurations needed
            "polyfills": ["zone.js"],
            "tsConfig": "tsconfig.app.json",
            "assets": ["src/favicon.ico", "src/assets"],
            "styles": ["src/styles.css"]
          },
          
          "configurations": {
            "production": {
              "budgets": [
                {
                  "type": "initial",
                  "maximumWarning": "500kb",
                  "maximumError": "1mb"
                }
              ],
              "outputHashing": "all"
            },
            "development": {
              "optimization": false,
              "sourceMap": true,
              "extractLicenses": false,
              "namedChunks": true
            }
          },
          
          "defaultConfiguration": "production"
        },
        
        "serve": {
          "builder": "@angular-devkit/build-angular:dev-server",
          "configurations": {
            "production": {
              "buildTarget": "your-project:build:production"
            },
            "development": {
              "buildTarget": "your-project:build:development"
            }
          },
          "defaultConfiguration": "development"
        }
      }
    }
  }
}
```

## **Step 5: Replace Common Webpack Configurations**

### A. **Path Aliases** → Move to `tsconfig.json`
```json
// tsconfig.json or tsconfig.app.json
{
  "compilerOptions": {
    "baseUrl": "./",
    "paths": {
      "@app/*": ["src/app/*"],
      "@core/*": ["src/app/core/*"],
      "@shared/*": ["src/app/shared/*"],
      "@env/*": ["src/environments/*"]
    }
  }
}
```

### B. **Environment Variables** → Use `environment.ts` files
```typescript
// src/environments/environment.ts
export const environment = {
  production: false,
  apiUrl: 'http://localhost:3000/api',
  // other variables...
};

// src/environments/environment.prod.ts
export const environment = {
  production: true,
  apiUrl: 'https://api.yourdomain.com/api',
  // other variables...
};
```

### C. **Polyfills** → Configure in `angular.json` or `src/polyfills.ts`
```json
// angular.json
"options": {
  "polyfills": [
    "zone.js",
    "src/polyfills.ts"  // if you have custom polyfills
  ]
}
```

## **Step 6: Handle Specific Webpack Plugins/Loaders**

### Common replacements:

#### 1. **SASS/SCSS** → Built-in support
```json
// angular.json
"options": {
  "stylePreprocessorOptions": {
    "includePaths": ["src/styles"]
  }
}
```

#### 2. **Bundle Analyzer** → Use Angular CLI command
```bash
# Install analyzer
npm install -D webpack-bundle-analyzer

# Add script to package.json
{
  "scripts": {
    "analyze": "ng build --stats-json && webpack-bundle-analyzer dist/your-app/stats.json"
  }
}
```

#### 3. **Compression** → Use Angular CLI optimization
```json
// angular.json - production configuration
"configurations": {
  "production": {
    "optimization": true,
    "outputHashing": "all",
    "sourceMap": false,
    "namedChunks": false,
    "extractLicenses": true,
    "vendorChunk": false,
    "buildOptimizer": true,
    "fileReplacements": [
      {
        "replace": "src/environments/environment.ts",
        "with": "src/environments/environment.prod.ts"
      }
    ]
  }
}
```

#### 4. **Custom Loaders** → Alternative approaches:
- **Raw loader**: Use Angular's asset loading
- **SVG/Sprite loaders**: Use Angular's `templateUrl` or inline SVG
- **Custom file types**: Configure in `angular.json`

```json
// angular.json
"options": {
  "assets": [
    "src/favicon.ico",
    "src/assets",
    {
      "glob": "**/*",
      "input": "src/static-files",
      "output": "/static"
    }
  ]
}
```

## **Step 7: Configure Build Optimizations**

### In `angular.json`:
```json
"configurations": {
  "production": {
    "optimization": {
      "scripts": true,
      "styles": {
        "minify": true,
        "inlineCritical": true
      },
      "fonts": true
    },
    "outputHashing": "all",
    "sourceMap": {
      "scripts": false,
      "styles": false,
      "hidden": false,
      "vendor": false
    },
    "namedChunks": false,
    "extractLicenses": true,
    "vendorChunk": false,
    "buildOptimizer": true,
    "budgets": [
      {
        "type": "initial",
        "maximumWarning": "2mb",
        "maximumError": "5mb"
      },
      {
        "type": "anyComponentStyle",
        "maximumWarning": "6kb",
        "maximumError": "10kb"
      }
    ]
  }
}
```

## **Step 8: Test the Migration**

### Create a test build:
```bash
# Test development build
ng build --configuration development

# Test production build
ng build --configuration production

# Serve application
ng serve

# Run tests
ng test
ng e2e
```

## **Step 9: Handle Edge Cases**

### If you need custom transformations:
1. **Create custom builders** (advanced):
```typescript
// builders/custom-builder.ts
import { BuilderContext, createBuilder } from '@angular-devkit/architect';
import { executeBrowserBuilder } from '@angular-devkit/build-angular';

export default createBuilder(async (options, context) => {
  // Add custom logic here
  return executeBrowserBuilder(options, context);
});
```

2. **Use `postcss` for CSS transformations**:
```bash
npm install -D postcss postcss-preset-env
```

Create `postcss.config.js`:
```javascript
module.exports = {
  plugins: [
    require('postcss-preset-env')({
      stage: 3,
      features: {
        'nesting-rules': true
      }
    })
  ]
};
```

3. **For runtime configuration**:
```typescript
// Use APP_INITIALIZER
import { APP_INITIALIZER } from '@angular/core';

export function initializeApp(configService: ConfigService) {
  return () => configService.load();
}

@NgModule({
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [ConfigService],
      multi: true
    }
  ]
})
export class AppModule {}
```

## **Step 10: Performance Comparison**

### After migration, compare:
1. **Build times**: Should be faster with esbuild
2. **Bundle sizes**: Check with `source-map-explorer`
```bash
npm install -D source-map-explorer
ng build --source-map
npx source-map-explorer dist/your-app/main*.js
```

3. **Runtime performance**: Ensure no regressions

## **Common Pitfalls and Solutions**

### Problem: Missing polyfills
**Solution**: Add to `src/polyfills.ts`:
```typescript
// Add any third-party library polyfills here
import 'core-js/features/array/flat-map';
import 'core-js/features/object/from-entries';
```

### Problem: Module resolution errors
**Solution**: Verify `tsconfig.json` paths:
```json
{
  "compilerOptions": {
    "baseUrl": "./",
    "paths": {
      // Your path mappings
    }
  },
  "angularCompilerOptions": {
    "strictTemplates": true
  }
}
```

### Problem: Missing assets or files
**Solution**: Check `angular.json` assets configuration and ensure all necessary files are included.

## **Final Cleanup**

1. **Remove old files**:
```bash
rm webpack.config.js
rm -rf webpack/  # if you had a webpack directory
```

2. **Update package.json scripts**:
```json
{
  "scripts": {
    "ng": "ng",
    "start": "ng serve",
    "build": "ng build",
    "watch": "ng build --watch --configuration development",
    "test": "ng test",
    "build:prod": "ng build --configuration production",
    "analyze": "ng build --stats-json && webpack-bundle-analyzer dist/your-app/stats.json"
  }
}
```

3. **Verify everything works**:
```bash
# Clean install
rm -rf node_modules package-lock.json
npm install

# Build and serve
ng build
ng serve
```

## **Benefits of Migration**
1. ✅ **Faster builds** (esbuild is significantly faster)
2. ✅ **Official Angular support** (better compatibility)
3. ✅ **Simplified configuration**
4. ✅ **Automatic optimizations**
5. ✅ **Better tree-shaking**

This migration leverages Angular 19's enhanced build system using **esbuild** for faster builds while maintaining compatibility with most use cases.