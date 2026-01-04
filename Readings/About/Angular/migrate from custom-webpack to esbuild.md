
I'll help you create a step-by-step migration guide from custom-webpack to Angular 19's esbuild-based application builder.Now I'll create a comprehensive migration guide based on the information I found:I've created a comprehensive step-by-step migration guide for moving from custom-webpack to Angular 19's ESBuild-based build system. The guide covers:

**Key sections:**

1. **Pre-Migration Checklist** - Understanding your current setup
2. **Three Migration Paths** - Native builder (recommended), custom-esbuild, or staying on webpack
3. **Automated Migration** - Using Angular's built-in schematic
4. **Manual Migration** - Detailed steps for custom webpack users, including:
    - Environment variable injection alternatives
    - Module resolution/aliases
    - Index.html transformations
    - Custom file handling
5. **Common Issues & Solutions** - Practical fixes for typical migration problems
6. **Verification & Testing** - Ensuring everything works
7. **Performance Comparison** - Measuring improvements

**The guide includes two main approaches:**

- **Option A**: Migrate to the native `@angular-devkit/build-angular:application` builder (best performance, recommended)
- **Option B**: Use `@angular-builders/custom-esbuild` if you still need build customization

**Key things to know:**

- ESBuild is 5-10x faster than webpack
- You'll need to convert webpack-specific features (DefinePlugin, resolve.fallback, loaders) to ESBuild equivalents
- Stylesheet imports need to drop the `~` and `^` prefixes
- The output directory structure changes slightly

The guide provides concrete examples for each migration scenario. Would you like me to elaborate on any specific part, such as handling a particular webpack feature you're using, or provide more details about testing strategies?

# Angular 18→19: Custom-Webpack to ESBuild Migration Guide

## Overview

This guide walks you through migrating from `@angular-builders/custom-webpack` to Angular 19's native ESBuild-based build system. The migration requires understanding what your custom webpack config does and finding ESBuild/Angular equivalents.

---

## Pre-Migration Checklist

### 1. Understand Your Current Setup

Before starting, document what your custom webpack configuration does:

- [ ] **Environment variable injection** (DefinePlugin)
- [ ] **Module resolution** (resolve.fallback, aliases)
- [ ] **Custom loaders** (file-loader, etc.)
- [ ] **Plugins** (CopyPlugin, etc.)
- [ ] **Index.html transformations**
- [ ] **Polyfills/shims** (stream, vm, etc.)
- [ ] **Build optimizations**
- [ ] **Other webpack-specific features**

**Action**: Create a backup branch

```bash
git checkout -b backup/pre-esbuild-migration
git push origin backup/pre-esbuild-migration
git checkout -b feature/esbuild-migration
```

---

## Migration Paths

You have **three options**:

### Option 1: Native Angular Application Builder (Recommended)

- ✅ Full feature set (SSR, prerendering, modern features)
- ✅ Best performance
- ⚠️ More migration effort
- ⚠️ No direct webpack customization

### Option 2: @angular-builders/custom-esbuild

- ✅ Allows ESBuild plugin customization
- ✅ Less breaking changes than Option 1
- ✅ Familiar pattern if you used custom-webpack
- ⚠️ Additional dependency

### Option 3: Stay on Webpack (Interim)

- ✅ Zero migration effort
- ⚠️ Slower builds
- ⚠️ Will eventually be deprecated

**This guide covers Option 1 (recommended) and Option 2 (if you need customization).**

---

## Part 1: Automated Migration Attempt

Angular CLI provides an automated migration schematic that handles most common cases.

### Step 1: Update to Angular 19

```bash
# First, ensure you're on Angular 18
ng version

# Update to Angular 19
ng update @angular/core@19 @angular/cli@19
```

### Step 2: Run the Migration Schematic

```bash
ng update @angular/cli --name use-application-builder
```

**What this does**:

- Converts `browser` or `browser-esbuild` targets to `application` builder
- Removes webpack-specific syntax from stylesheets (`~`, `^` in imports)
- Merges `tsconfig.server.json` with `tsconfig.app.json`
- Updates `angular.json` configuration
- Removes old SSR builders

### Step 3: Test the Build

```bash
# Try building
ng build

# Try serving
ng serve

# Run tests
ng test
```

**If everything works**: Congratulations! Skip to [Part 4: Cleanup](https://claude.ai/chat/104d2fb5-6281-411a-9427-a25ccb16204b#part-4-cleanup).

**If you get errors**: Continue to manual migration steps below.

---

## Part 2: Manual Migration (For Custom Webpack Users)

Since you're using `@angular-builders/custom-webpack`, the automated migration likely failed. Here's how to migrate manually.

### Step 1: Analyze Your Custom Webpack Config

Open your `extra-webpack.config.js` (or whatever you named it) and identify what it does.

**Common patterns and their ESBuild equivalents**:

#### A. Environment Variable Injection (DefinePlugin)

**Webpack (custom-webpack.config.js)**:

```javascript
const webpack = require('webpack');

module.exports = {
  plugins: [
    new webpack.DefinePlugin({
      'process.env.API_URL': JSON.stringify(process.env.API_URL),
      'process.env.VERSION': JSON.stringify(require('./package.json').version)
    })
  ]
};
```

**ESBuild Equivalent** - Two approaches:

**Approach 1: Use Angular environments (Recommended)**

```typescript
// src/environments/environment.ts
export const environment = {
  production: false,
  apiUrl: 'http://localhost:3000',
  version: '1.0.0'
};

// src/environments/environment.prod.ts
export const environment = {
  production: true,
  apiUrl: 'https://api.production.com',
  version: require('../../package.json').version
};
```

In `angular.json`:

```json
{
  "configurations": {
    "production": {
      "fileReplacements": [
        {
          "replace": "src/environments/environment.ts",
          "with": "src/environments/environment.prod.ts"
        }
      ]
    }
  }
}
```

**Approach 2: Use custom ESBuild plugin** (if you need `process.env`):

Create `esbuild-plugins/define-env.mjs`:

```javascript
export default function defineEnv() {
  return {
    name: 'define-env',
    setup(build) {
      const options = build.initialOptions;
      options.define = options.define || {};
      options.define['process.env.API_URL'] = JSON.stringify(process.env.API_URL || 'http://localhost:3000');
      options.define['process.env.VERSION'] = JSON.stringify(require('../package.json').version);
    }
  };
}
```

Then use `@angular-builders/custom-esbuild` (see Step 2B below).

#### B. Module Resolution / Aliases

**Webpack**:

```javascript
module.exports = {
  resolve: {
    alias: {
      '@app': path.resolve(__dirname, 'src/app'),
      '@shared': path.resolve(__dirname, 'src/app/shared')
    },
    fallback: {
      "stream": require.resolve("stream-browserify"),
      "vm": require.resolve("vm-browserify")
    }
  }
};
```

**ESBuild Equivalent**:

For **aliases**, use `tsconfig.json`:

```json
{
  "compilerOptions": {
    "paths": {
      "@app/*": ["src/app/*"],
      "@shared/*": ["src/app/shared/*"]
    }
  }
}
```

For **polyfills/fallbacks**, install browser polyfills and import them:

```bash
npm install stream-browserify vm-browserify
```

In `src/polyfills.ts` (or `src/main.ts`):

```typescript
// Polyfills for Node.js modules
import 'stream-browserify';
import 'vm-browserify';
```

Or configure in `angular.json`:

```json
{
  "architect": {
    "build": {
      "options": {
        "polyfills": [
          "zone.js",
          "stream-browserify",
          "vm-browserify"
        ]
      }
    }
  }
}
```

#### C. Index.html Transformation

**Webpack** (with indexTransform):

```javascript
// index-html-transform.js
module.exports = (targetOptions, indexHtml) => {
  const transformed = indexHtml.replace(
    '</head>',
    `<script>window.BUILD_TIME = '${new Date().toISOString()}';</script></head>`
  );
  return transformed;
};
```

**ESBuild Equivalent** - Two approaches:

**Approach 1: Direct modification in index.html**

```html
<!-- src/index.html -->
<!DOCTYPE html>
<html>
<head>
  <!-- Angular will inject build-time values -->
  <script>
    window.BUILD_TIME = '${BUILD_TIME}'; // Replace at build time
  </script>
</head>
<body>
  <app-root></app-root>
</body>
</html>
```

**Approach 2: Use @angular-builders/custom-esbuild with indexHtmlTransformer** (see Step 2B).

#### D. Custom File Handling

**Webpack**:

```javascript
module.exports = {
  module: {
    rules: [
      {
        test: /\.svg$/,
        use: ['@svgr/webpack']
      }
    ]
  }
};
```

**ESBuild**: Most modern file handling is built-in. For SVGs:

```typescript
// Use Angular's built-in asset handling
// angular.json
{
  "assets": [
    "src/favicon.ico",
    "src/assets",
    {
      "glob": "**/*.svg",
      "input": "src/assets/icons",
      "output": "assets/icons"
    }
  ]
}
```

For inline SVG as components, use a library like `angular-svg-icon` or import directly:

```typescript
import iconSvg from './icon.svg?raw'; // ESBuild handles this
```

---

### Step 2A: Migrate to Native Application Builder

#### 1. Update angular.json

**Before** (with custom-webpack):

```json
{
  "projects": {
    "your-app": {
      "architect": {
        "build": {
          "builder": "@angular-builders/custom-webpack:browser",
          "options": {
            "customWebpackConfig": {
              "path": "./extra-webpack.config.js"
            },
            "outputPath": "dist/your-app",
            "index": "src/index.html",
            "main": "src/main.ts",
            "polyfills": ["zone.js"],
            "tsConfig": "tsconfig.app.json",
            "assets": ["src/favicon.ico", "src/assets"],
            "styles": ["src/styles.css"],
            "scripts": []
          }
        },
        "serve": {
          "builder": "@angular-builders/custom-webpack:dev-server",
          "options": {
            "buildTarget": "your-app:build"
          }
        }
      }
    }
  }
}
```

**After** (application builder):

```json
{
  "projects": {
    "your-app": {
      "architect": {
        "build": {
          "builder": "@angular-devkit/build-angular:application",
          "options": {
            "outputPath": "dist/your-app",
            "index": "src/index.html",
            "browser": "src/main.ts",
            "polyfills": ["zone.js"],
            "tsConfig": "tsconfig.app.json",
            "assets": ["src/favicon.ico", "src/assets"],
            "styles": ["src/styles.css"],
            "scripts": []
          },
          "configurations": {
            "production": {
              "budgets": [
                {
                  "type": "initial",
                  "maximumWarning": "500kB",
                  "maximumError": "1MB"
                }
              ],
              "outputHashing": "all"
            },
            "development": {
              "optimization": false,
              "extractLicenses": false,
              "sourceMap": true
            }
          },
          "defaultConfiguration": "production"
        },
        "serve": {
          "builder": "@angular-devkit/build-angular:dev-server",
          "options": {
            "buildTarget": "your-app:build"
          },
          "configurations": {
            "production": {
              "buildTarget": "your-app:build:production"
            },
            "development": {
              "buildTarget": "your-app:build:development"
            }
          },
          "defaultConfiguration": "development"
        }
      }
    }
  }
}
```

**Key changes**:

- `builder`: Changed to `@angular-devkit/build-angular:application`
- `main` → `browser`
- Removed `customWebpackConfig`
- Added explicit `configurations` for production/development

#### 2. Update tsconfig files

If you had `tsconfig.server.json`, merge it with `tsconfig.app.json`:

**tsconfig.app.json**:

```json
{
  "extends": "./tsconfig.json",
  "compilerOptions": {
    "outDir": "./out-tsc/app",
    "types": ["node"]
  },
  "files": [
    "src/main.ts"
  ],
  "include": [
    "src/**/*.d.ts"
  ]
}
```

#### 3. Remove Webpack Dependencies

```bash
npm uninstall @angular-builders/custom-webpack webpack webpack-cli
```

Remove any webpack-specific packages you installed:

```bash
npm uninstall ts-loader file-loader svg-loader # etc.
```

#### 4. Update Stylesheet Imports

ESBuild doesn't support `~` or `^` for node_modules imports.

**Before**:

```scss
@import '~bootstrap/scss/bootstrap';
@import '^@angular/material/prebuilt-themes/indigo-pink.css';
```

**After**:

```scss
@import 'bootstrap/scss/bootstrap';
@import '@angular/material/prebuilt-themes/indigo-pink.css';
```

Or use the full path:

```scss
@import '../node_modules/bootstrap/scss/bootstrap';
```

#### 5. Test the Build

```bash
npm install
ng build
ng serve
```

---

### Step 2B: Migrate to @angular-builders/custom-esbuild (If You Need Customization)

If you need ESBuild plugins or custom configuration:

#### 1. Install custom-esbuild

```bash
npm install --save-dev @angular-builders/custom-esbuild
```

#### 2. Create ESBuild Plugin Files

**esbuild-plugins/define-env.mjs**:

```javascript
export default function defineEnv(options) {
  return {
    name: 'define-env',
    setup(build) {
      const buildOptions = build.initialOptions;
      buildOptions.define = buildOptions.define || {};
      
      // Inject environment variables
      buildOptions.define['process.env.API_URL'] = JSON.stringify(
        options.apiUrl || process.env.API_URL || 'http://localhost:3000'
      );
      buildOptions.define['process.env.VERSION'] = JSON.stringify(
        require('../package.json').version
      );
    }
  };
}
```

**esbuild-plugins/index-html-transformer.js** (if needed):

```javascript
module.exports = async (indexHtml) => {
  const buildTime = new Date().toISOString();
  return indexHtml.replace(
    '</head>',
    `<script>window.BUILD_TIME = '${buildTime}';</script></head>`
  );
};
```

#### 3. Update angular.json

```json
{
  "projects": {
    "your-app": {
      "architect": {
        "build": {
          "builder": "@angular-builders/custom-esbuild:application",
          "options": {
            "plugins": [
              {
                "path": "./esbuild-plugins/define-env.mjs",
                "options": {
                  "apiUrl": "http://localhost:3000"
                }
              }
            ],
            "indexHtmlTransformer": "./esbuild-plugins/index-html-transformer.js",
            "outputPath": "dist/your-app",
            "index": "src/index.html",
            "browser": "src/main.ts",
            "polyfills": ["zone.js"],
            "tsConfig": "tsconfig.app.json",
            "assets": ["src/favicon.ico", "src/assets"],
            "styles": ["src/styles.css"],
            "scripts": []
          },
          "configurations": {
            "production": {
              "plugins": [
                {
                  "path": "./esbuild-plugins/define-env.mjs",
                  "options": {
                    "apiUrl": "https://api.production.com"
                  }
                }
              ]
            }
          }
        },
        "serve": {
          "builder": "@angular-builders/custom-esbuild:dev-server",
          "options": {
            "buildTarget": "your-app:build"
          }
        }
      }
    }
  }
}
```

#### 4. Test

```bash
npm install
ng build
ng serve
```

---

## Part 3: Common Migration Issues & Solutions

### Issue 1: "Cannot find module 'stream'" or similar

**Problem**: Webpack polyfills are missing.

**Solution**: Install and import browser polyfills:

```bash
npm install stream-browserify buffer process
```

In `src/polyfills.ts`:

```typescript
import { Buffer } from 'buffer';
import process from 'process';

(window as any).Buffer = Buffer;
(window as any).process = process;
```

### Issue 2: "process is not defined"

**Problem**: ESBuild doesn't inject `process` global.

**Solution A**: Use ESBuild define:

```javascript
// esbuild-plugin
buildOptions.define['process.env.NODE_ENV'] = JSON.stringify('production');
```

**Solution B**: Import and assign:

```typescript
import process from 'process';
window.process = process;
```

### Issue 3: Stylesheet imports broken

**Problem**: `~` imports don't work.

**Solution**: Remove `~` prefix:

```scss
// Before
@import '~bootstrap/scss/bootstrap';

// After
@import 'bootstrap/scss/bootstrap';
```

### Issue 4: Asset paths changed

**Problem**: Assets not found after migration.

**Solution**: Check `outputPath` structure. ESBuild uses different output structure.

**Before** (Webpack):

```
dist/
  └── your-app/
      ├── index.html
      ├── main.js
      └── assets/
```

**After** (ESBuild with application builder):

```
dist/
  └── your-app/
      └── browser/
          ├── index.html
          ├── main.js
          └── assets/
```

Update deployment scripts accordingly.

### Issue 5: Third-party library errors

**Problem**: Libraries expecting webpack-specific features.

**Solution**: Check library documentation for ESBuild compatibility or find alternatives.

### Issue 6: Moment.js locale issues

**Problem**: All moment.js locales included in bundle (large size).

**Solution**: Import only needed locales:

```typescript
// In main.ts or app initialization
import moment from 'moment';
import 'moment/locale/en-ca';
import 'moment/locale/fr';
// ESBuild's tree-shaking will exclude unused locales
```

Or migrate to `date-fns` (recommended, moment.js is in maintenance mode):

```bash
npm uninstall moment
npm install date-fns
```

### Issue 7: Bundle analyzer not working

**Problem**: `webpack-bundle-analyzer` doesn't work with ESBuild.

**Solution**: Use ESBuild-compatible tools:

```bash
# Generate stats
ng build --stats-json

# Use esbuild-visualizer
npm install -g esbuild-visualizer
esbuild-visualizer --metadata dist/your-app/stats.json
```

---

## Part 4: Cleanup

### 1. Remove Webpack Files

```bash
# Remove webpack config files
rm extra-webpack.config.js
rm webpack.config.js

# Remove webpack dependencies from package.json manually or:
npm uninstall @angular-builders/custom-webpack webpack
```

### 2. Update Scripts in package.json

Remove any webpack-specific scripts:

**Before**:

```json
{
  "scripts": {
    "build": "ng build",
    "build:stats": "ng build --stats-json && webpack-bundle-analyzer dist/stats.json"
  }
}
```

**After**:

```json
{
  "scripts": {
    "build": "ng build",
    "build:stats": "ng build --stats-json"
  }
}
```

### 3. Update .gitignore

Remove webpack-specific entries:

```
# Remove these if present
webpack.config.js
stats.json
```

### 4. Update CI/CD

If your CI/CD pipeline has webpack-specific steps, update them:

**Before**:

```yaml
- run: npm run build:prod
- run: webpack-bundle-analyzer dist/stats.json --no-open
```

**After**:

```yaml
- run: npm run build -- --configuration production
```

---

## Part 5: Verification & Testing

### 1. Build All Configurations

```bash
# Development build
ng build --configuration development

# Production build
ng build --configuration production

# Check output
ls -la dist/your-app/
```

### 2. Serve Locally

```bash
ng serve
```

Visit `http://localhost:4200` and verify everything works.

### 3. Run Tests

```bash
ng test
ng e2e  # if you have e2e tests
```

### 4. Check Bundle Size

```bash
ng build --configuration production --stats-json

# Check main bundle size
ls -lh dist/your-app/browser/*.js
```

Compare with your previous webpack build to ensure sizes are similar or better.

### 5. Test in Production-Like Environment

Deploy to staging and verify:

- [ ] All pages load
- [ ] API calls work
- [ ] Assets load correctly
- [ ] No console errors
- [ ] Performance is improved

---

## Part 6: Performance Comparison

After migration, measure improvements:

### Build Time Comparison

**Before (Webpack)**:

```bash
time ng build --configuration production
# Example: real 2m30s
```

**After (ESBuild)**:

```bash
time ng build --configuration production
# Example: real 0m15s  (10x faster!)
```

### Dev Server Startup

**Before**: 30-60 seconds **After**: 3-5 seconds

### Hot Module Replacement (HMR)

**Before**: 2-5 seconds per change **After**: Instant (< 100ms)

---

## Troubleshooting

### Build Fails with "Unknown option: --configuration"

**Problem**: Using old Angular CLI version.

**Solution**:

```bash
ng version  # Check version
npm install -g @angular/cli@19
```

### "Builder @angular-devkit/build-angular:application not found"

**Problem**: Angular devkit not updated.

**Solution**:

```bash
npm install --save-dev @angular-devkit/build-angular@19
```

### Tests fail after migration

**Problem**: Karma configuration might need updates.

**Solution**: Check `karma.conf.js` - ESBuild-based tests use different plugins.

Ensure you have:

```javascript
plugins: [
  require('karma-jasmine'),
  require('karma-chrome-launcher'),
  require('karma-jasmine-html-reporter'),
  require('karma-coverage'),
  require('@angular-devkit/build-angular/plugins/karma')
],
```

---

## Migration Checklist Summary

- [ ] Backed up project
- [ ] Documented custom webpack features
- [ ] Updated to Angular 19
- [ ] Ran automated migration
- [ ] Migrated custom webpack config to ESBuild equivalents
- [ ] Updated `angular.json`
- [ ] Updated `tsconfig.json`
- [ ] Removed webpack dependencies
- [ ] Fixed stylesheet imports
- [ ] Tested development build
- [ ] Tested production build
- [ ] Ran all tests
- [ ] Updated CI/CD pipeline
- [ ] Verified in staging environment
- [ ] Measured performance improvements
- [ ] Cleaned up webpack files
- [ ] Updated documentation

---

## Additional Resources

- [Official Angular Migration Guide](https://angular.dev/tools/cli/build-system-migration)
- [ESBuild Documentation](https://esbuild.github.io/)
- [@angular-builders/custom-esbuild](https://www.npmjs.com/package/@angular-builders/custom-esbuild)
- [Angular ESBuild Known Issues](https://angular.dev/tools/cli/build-system-migration#known-issues)

---

## Need Help?

Common places to get help:

1. Angular Discord/Slack
2. Stack Overflow (tag: angular, esbuild)
3. GitHub Issues:
    - [Angular CLI Issues](https://github.com/angular/angular-cli/issues)
    - [custom-esbuild Issues](https://github.com/just-jeb/angular-builders/issues)

---

**Good luck with your migration! ESBuild will significantly improve your build times and development experience.** 🚀