besides finding defects
sharing patterns, 
sharing knowledge,
increased a sense of mutual ownership
# Code Review Benefits

* Catch bugs
* Catch code quality issues
* A learning opportunity for the
	* Pull Request creator
	* Reviewer
*  An exchange of best practices and experiences
* A chance to synchronize

## but
Code Reviews are an amplifier
They amplify the good and the bad

# Code Review Downsides
## What Code Reviews also amplify:
- Poor company culture
- Difficult personalities
- Unprofessional behavior
## Leads to:
* Unnecessary arguments
* Slows down development
* Decreased morale

### let's assume we have these two out of the way
* establishing a company-wide culture
* dealing with difficult personalities


# Code Review Culture
To improve code quality and foster a constructive exchange of ideas and knowledge


## Code Review is in the center of the intersection of
### Hard Skills
* Writing and reading code
* Design
* Clean code, best practices, patterns
### Soft Skills
* How to comment constructively and with tact
* How to respond to comments
* How to submit a good PR


# # Better Code Reviews FTW! - Tess Ferrandez-Norlander - NDC Copenhagen 2025
[youtube vedio](https://www.youtube.com/watch?v=2vacqx2ISms)

[code with engineering playbook](https://github.com/microsoft/code-with-engineering-playbook)


# widely accepted percentage for code coverage
The "acceptable" level of code coverage varies depending on the project, team, and industry, but **70–90%** is often cited as a common target in many software development contexts. However, **context matters greatly**, and there’s no universal "ideal" percentage. Here’s a breakdown of considerations:

---

### **1. General Guidelines**
- **70–80%**: A pragmatic baseline for many projects.  
  - Balances effort vs. value.  
  - Leaves room for untested edge cases or less critical code (e.g., trivial getters/setters).  
- **80–90%**: Common for mature codebases or safety-critical systems (e.g., finance, healthcare).  
- **90–100%**: Rare and often reserved for mission-critical systems (e.g., aerospace, medical devices).  

---

### **2. Key Factors Influencing Targets**
- **Project Type**:  
  - **Startups**: Might prioritize speed over 100% coverage (e.g., 60–70%).  
  - **Enterprise/Safety-Critical Systems**: Often aim for 90%+ (e.g., banking, avionics).  
- **Code Complexity**:  
  - Complex logic (e.g., algorithms, state machines) demands higher coverage.  
  - Simple CRUD apps may tolerate lower coverage.  
- **Team Maturity**:  
  - Teams with strong testing cultures may enforce stricter coverage.  
- **Regulatory Requirements**:  
  - Industries like healthcare (FDA) or automotive (ISO 26262) often mandate high coverage.  

---

### **3. Why 100% Coverage Is Rarely Practical**  
- **Diminishing Returns**:  
  - The effort to test every edge case (e.g., obscure error handlers) often outweighs the risk.  
- **False Security**:  
  - 100% coverage doesn’t guarantee bug-free code (tests may lack assertions).  
- **Costly Maintenance**:  
  - High coverage requires constant upkeep as code evolves.  

---

### **4. What to Prioritize Over Raw Percentages**  
- **Critical Paths**: Ensure core business logic, security features, and error handling are well-tested.  
- **Test Quality**: Focus on meaningful tests (e.g., validating behavior, not just executing code).  
- **Risk-Based Testing**: Allocate effort to high-risk areas (e.g., payment processing vs. UI labels).  

---

### **5. Industry Examples**  
- **Web Apps**: 70–80% (focus on user flows and APIs).  
- **Fintech/Banking**: 85–95% (due to compliance and risk).  
- **Open-Source Libraries**: 90%+ (reliability for downstream users).  
- **Legacy Systems**: Lower (e.g., 50–60%) if refactoring is impractical.  

---

### **6. Tools & Enforcement**  
- **Enforcement**: Teams often set coverage thresholds in CI/CD pipelines (e.g., fail builds below 80%).  
- **Tools**:  
  - **Coverage.py** (Python), **JaCoCo** (Java), **Istanbul** (JavaScript), **Coverlet** (.NET).  

---

### **7. Red Flags**  
- **High Coverage, Low Confidence**: Tests pass but don’t validate logic.  
- **Ignoring Untestable Code**: Generated code, third-party libraries, or UI frameworks may artificially inflate coverage.  
- **Sacrificing Speed for Coverage**: Slow test suites hurt productivity.  

---

### **Final Advice**  
- **Start Low, Improve Gradually**: Aim for 70% and increase as the codebase matures.  
- **Combine Metrics**: Use code coverage **with** feature coverage, mutation testing, and manual reviews.  
- **Focus on Value**: A 70% coverage with robust tests is better than 95% with brittle, meaningless tests.  

**Rule of Thumb**:  
*“Aim for the highest coverage you can **practically** maintain, prioritizing tests that reduce risk.”*


# our code review guidelines

## benefits

* Catch bugs
* Catch code quality issues
* A learning opportunity for the
	* Pull Request creator
	* Reviewer
*  An exchange of best practices and experiences
* A chance to synchronize

## checklist by sonet 4.5
# Angular Code Review Checklist (zdnote: by sonnet 4.5)

## How to Use This Checklist

- Not every item applies to every PR—use judgment
- **🔴 Critical**: Must be addressed before merge
- **🟡 Important**: Should be addressed or explicitly acknowledged
- **🟢 Nice-to-have**: Suggestions for improvement

---

## 1. Pre-Review (Author Self-Check)

- [ ] Code builds without errors
- [ ] All tests pass locally
- [ ] Linter passes with no warnings
- [ ] PR description clearly explains the change and why
- [ ] Screenshots/videos included for UI changes
- [ ] Self-reviewed the diff before requesting review

---

## 2. Functionality & Correctness

### 🔴 Critical

- [ ] Code does what the PR/ticket describes
- [ ] No obvious bugs or logic errors
- [ ] Edge cases are handled (null, undefined, empty arrays, etc.)
- [ ] Error states are handled appropriately
- [ ] No breaking changes to existing functionality (or documented if intentional)

### 🟡 Important

- [ ] Loading states are shown for async operations
- [ ] User feedback provided for actions (success/error messages)
- [ ] Forms validate properly with clear error messages

---

## 3. Angular Style Guide & Best Practices

### 🔴 Critical

- [ ] **Naming conventions** (Angular Style Guide):
    - Components: `feature.component.ts` (kebab-case)
    - Services: `feature.service.ts`
    - Directives: `feature.directive.ts`
    - Pipes: `feature.pipe.ts`
    - Classes use PascalCase: `FeatureComponent`
    - Files have one component/service/directive per file
- [ ] **No business logic in components** (components orchestrate, services execute)
- [ ] **Proper module organization** (feature modules, shared modules, core module)
- [ ] **Dependency injection used correctly** (no direct instantiation with `new`)

### 🟡 Important

- [ ] **Component structure follows single responsibility**:
    - Presenter components (dumb): only Inputs/Outputs, no business logic
    - Container components (smart): connect to services, manage state
- [ ] **Observable subscriptions handled properly**:
    - Use `async` pipe in templates (preferred), OR
    - Use `takeUntilDestroyed()` or `takeUntil()` pattern, OR
    - Explicitly unsubscribe in `ngOnDestroy`
- [ ] **Change detection strategy**:
    - `OnPush` used where appropriate (presentational components)
    - Not fighting change detection with manual `detectChanges()`
- [ ] **No DOM manipulation in components**:
    - Use `@ViewChild`, `Renderer2`, or directives instead
    - No `document.getElementById` or direct element access
- [ ] **Template syntax**:
    - Avoid complex logic in templates (move to component/pipe)
    - No function calls in templates (causes performance issues)
    - Use trackBy with `*ngFor` for lists

### 🟢 Nice-to-have

- [ ] Components under 400 lines (consider splitting if larger)
- [ ] Template expressions are simple and readable
- [ ] Prefix custom components with app-specific selector (`app-`, `myorg-`)

---

## 4. TypeScript & Type Safety

### 🔴 Critical

- [ ] No use of `any` type (use `unknown` if type is truly unknown, then narrow)
- [ ] No TypeScript errors suppressed with `@ts-ignore` without explanation
- [ ] Function parameters and return types are explicitly typed
- [ ] Interfaces defined for complex objects

### 🟡 Important

- [ ] Types over interfaces for simple shapes (unless extending)
- [ ] Enums used instead of magic strings/numbers
- [ ] Null safety: use optional chaining (`?.`) and nullish coalescing (`??`)
- [ ] Type assertions (`as Type`) are justified and safe

---

## 5. Clean Code Principles

### 🔴 Critical

- [ ] **Meaningful names**: Variables, functions, and classes clearly express intent
    - Boolean variables: `isActive`, `hasPermission`, `canEdit`
    - Functions: verb-noun (`getUser`, `calculateTotal`, `validateForm`)
    - Avoid abbreviations unless universally known
- [ ] **Functions are small and focused** (ideally under 20 lines)
- [ ] **Single Responsibility**: Each class/function does one thing well
- [ ] **No magic numbers**: Use named constants (`const MAX_RETRIES = 3`)

### 🟡 Important

- [ ] **DRY (Don't Repeat Yourself)**:
    - Duplicated logic extracted to functions/services
    - Repeated templates extracted to components
    - Common utilities in shared services
- [ ] **Functions have 3 or fewer parameters** (use options object if more needed)
- [ ] **Early returns** to reduce nesting (avoid arrow anti-pattern)
    
    ```typescript
    // Good
    if (!isValid) return;
    // ... main logic
    
    // Avoid
    if (isValid) {  
	    // ... nested logic
	}
    ```
    
- [ ] **Descriptive variable names over comments**:
    
    ```typescript
    // Good
    const isEligibleForDiscount = age > 65 && membershipYears > 5;
    
    // Avoid
    const x = age > 65 && membershipYears > 5;       // check discount eligibility
    ```
    

### 🟢 Nice-to-have

- [ ] Comments explain "why", not "what" (code should be self-documenting)
- [ ] Dead code removed (no commented-out code)
- [ ] Console.log statements removed

---

## 6. SOLID Principles

### 🔴 Critical

- [ ] **Single Responsibility Principle (SRP)**:
    - Components handle only view logic
    - Services handle only business logic
    - Each class has one reason to change
- [ ] **Dependency Inversion Principle (DIP)**:
    - Depend on abstractions (interfaces) not concretions
    - Services injected via constructor, not instantiated

### 🟡 Important

- [ ] **Open/Closed Principle (OCP)**:
    - Code open for extension, closed for modification
    - Use inheritance, composition, or strategy pattern instead of modifying existing code
- [ ] **Liskov Substitution Principle (LSP)**:
    - Derived classes can replace base classes without breaking functionality
- [ ] **Interface Segregation Principle (ISP)**:
    - Interfaces are small and focused
    - No "fat" interfaces forcing implementations of unused methods

---

## 7. RxJS & Observables

### 🔴 Critical

- [ ] **No nested subscriptions** (use operators like `switchMap`, `mergeMap`, `concatMap`)
- [ ] **Subscriptions cleaned up** to prevent memory leaks
- [ ] **Error handling** in observable chains (`.pipe(catchError())`)

### 🟡 Important

- [ ] **Appropriate operators used**:
    - `switchMap` for dependent requests (cancels previous)
    - `mergeMap` for parallel requests
    - `concatMap` for sequential requests
    - `forkJoin` for multiple parallel requests that all must complete
- [ ] **Subjects used appropriately**:
    - `BehaviorSubject` when consumers need current value
    - `Subject` for event streams
    - Private subject with public observable exposed (`subject$` vs `subject`)
- [ ] **Avoid imperative subscriptions in components** (prefer async pipe)

---

## 8. Performance

### 🔴 Critical

- [ ] No operations in tight loops that could be done once outside
- [ ] No unnecessary API calls (cache where appropriate)
- [ ] Large lists use virtual scrolling or pagination
- [ ] Images optimized and lazy-loaded where appropriate

### 🟡 Important

- [ ] `trackBy` function used with `*ngFor` on dynamic lists
- [ ] `OnPush` change detection strategy for presentational components
- [ ] Expensive computations memoized or moved to pipes
- [ ] Lazy loading used for feature modules

---

## 9. Security

### 🔴 Critical

- [ ] No XSS vulnerabilities (user input sanitized)
- [ ] No sensitive data in console logs or error messages
- [ ] Authentication tokens not stored in localStorage (use httpOnly cookies)
- [ ] No SQL injection risks (using parameterized queries/ORMs)
- [ ] CORS configured properly
- [ ] No hardcoded secrets, API keys, or passwords

### 🟡 Important

- [ ] Forms use proper validation (client and server-side)
- [ ] Authorization checks on all protected routes/actions
- [ ] Sensitive operations require re-authentication

---

## 10. Testing

### 🔴 Critical

- [ ] New features have unit tests
- [ ] Bug fixes include tests that would have caught the bug
- [ ] Critical paths have tests (authentication, payments, data mutations)

### 🟡 Important

- [ ] Tests are readable and well-named (`it('should calculate discount for senior members')`)
- [ ] Tests don't duplicate implementation (test behavior, not internals)
- [ ] Mock external dependencies (HTTP, services)
- [ ] Components test user interactions, not internal state
- [ ] Services test business logic thoroughly

### 🟢 Nice-to-have

- [ ] Test coverage for edge cases
- [ ] Integration tests for complex flows
- [ ] E2E tests for critical user journeys

---

## 11. Accessibility (a11y)

### 🟡 Important

- [ ] Interactive elements keyboard accessible (Enter/Space triggers actions)
- [ ] Proper ARIA labels for screen readers (`aria-label`, `aria-labelledby`)
- [ ] Semantic HTML used (`<button>` not `<div>` for buttons)
- [ ] Form inputs have associated labels
- [ ] Color contrast meets WCAG AA standards (4.5:1 for normal text)
- [ ] Focus states visible for keyboard navigation

---

## 12. Code Organization & Maintainability

### 🟡 Important

- [ ] **Folder structure logical and consistent**:
    
    ```
    src/app/  
	    core/           # Singleton services, guards, interceptors  
	    shared/         # Shared components, pipes, directives  
	    features/       # Feature modules    
		    feature-name/      
			    components/      
			    services/      
			    models/
    ```
    
- [ ] **Imports organized**:
    - Angular imports first
    - Third-party imports second
    - Application imports third
- [ ] **Related code grouped together** (private methods near their callers)
- [ ] **Public methods before private methods**

### 🟢 Nice-to-have

- [ ] Barrel exports (`index.ts`) for cleaner imports
- [ ] README or documentation for complex features

---

## 13. Git & PR Hygiene

### 🟡 Important

- [ ] Commits are logical and atomic (one concern per commit)
- [ ] Commit messages are descriptive (`fix: handle null user in profile component`)
- [ ] No merge commits in feature branches (rebase instead)
- [ ] No debug code, console.logs, or commented-out code
- [ ] No unrelated changes in the PR

---

## Review Attitude Checklist

### For Reviewers

- [ ] I've asked questions rather than made demands where appropriate
- [ ] I've praised good solutions
- [ ] I've distinguished between "must fix" and "suggestion"
- [ ] I've been respectful and constructive

### For Authors

- [ ] I've responded to all comments
- [ ] I've explained my reasoning for controversial choices
- [ ] I've thanked reviewers for their time
- [ ] I've created follow-up tickets for out-of-scope suggestions

---

## When to Escalate

Bring to team discussion if:

- Multiple rounds of review without consensus
- Architectural decisions that affect multiple features
- New patterns that should become team standards
- Performance concerns that need benchmarking

---

## Quick Reference: Common Issues

|Issue|Solution|
|---|---|
|Nested subscriptions|Use `switchMap`/`mergeMap`|
|Memory leaks|Use `async` pipe or `takeUntilDestroyed()`|
|Business logic in component|Move to service|
|Magic strings/numbers|Extract to constants/enums|
|Large components|Split into smaller components|
|Complex template logic|Move to component or pipe|
|Repeated code|Extract to shared function/service|
|`any` type|Use proper types or `unknown`|
|Direct DOM access|Use `@ViewChild` or `Renderer2`|
|Function calls in templates|Use pipes or computed properties|

---

**Remember**: This checklist guides quality, but use judgment. Not everything applies to every PR. Focus on what matters most for your team's context.


I'll help you create a practical code review guideline that works for a small, diverse team. Here's a draft:

---

## Code Review Guidelines  (zdnote: by sonnet 4.5)

### Purpose

Code reviews help us maintain code quality, share knowledge across the team, and catch issues early. For our small team with varied backgrounds, reviews are also a learning opportunity—we grow together by sharing different perspectives and approaches.

### Core Principles

**1. Be Kind and Constructive**

- Assume good intent. We're all trying to build something great.
- Phrase feedback as questions or suggestions, not commands: "Could we extract this into a service?" rather than "This should be a service."
- Praise good solutions. If you see clever code or a nice improvement, say so.
- Remember: criticize the code, not the person.

**2. Everyone Reviews, Everyone Learns**

- Junior developers should review senior code too—fresh eyes catch different things.
- If you don't understand something, ask. "I'm not familiar with this pattern—can you explain?" is a valid review comment.
- Seniors: use reviews as teaching moments, but keep explanations concise.

### What to Look For

**Critical Issues (Must Address)**

- **Functionality**: Does the code do what the PR description says?
- **Bugs**: Logic errors, null/undefined handling, edge cases
- **Security**: XSS vulnerabilities, authentication/authorization issues, sensitive data exposure
- **Breaking changes**: Will this break existing functionality?
- **Performance problems**: Obvious inefficiencies (e.g., operations in tight loops, unnecessary API calls)

**Important Issues (Should Address)**

- **Angular best practices**:
    - Component responsibilities (is business logic in services?)
    - Change detection strategy appropriateness
    - Proper use of observables (subscriptions cleaned up?)
    - Module organization
- **Code clarity**: Is the intent clear? Would someone new understand this in 6 months?
- **Error handling**: Are errors caught and handled appropriately?
- **Testing**: Are there tests? Do they cover the important paths?
- **Accessibility**: Basic ARIA labels, keyboard navigation for interactive elements

**Nice to Have (Suggestions Welcome)**

- Code style consistency (but defer to our linting rules)
- Refactoring opportunities
- Alternative approaches worth considering
- Documentation improvements

### Review Process

**Before Submitting for Review**

- Self-review your own code first
- Ensure it builds and tests pass locally
- Write a clear PR description:
    - What does this change?
    - Why are we making it?
    - Anything tricky or non-obvious?
    - Screenshots/videos for UI changes

**During Review**

- **Response time**: Aim to review within 24 hours (or let the team know if you can't)
- **Required reviewers**: At least one approval needed (two for critical features)
- **Scope**: Keep PRs reasonably sized. If reviewing 1000+ lines, consider asking for it to be split.

**Handling Feedback**

- Author: Respond to all comments—even if just "Done" or "Good catch!"
- For disagreements, discuss in person/call if threading gets long
- If something is out of scope: "Great point—let's create a separate ticket for that"

### What NOT to Do

- **Don't** nitpick formatting that the linter should catch
- **Don't** require your personal preference as mandatory (unless there's a clear technical reason)
- **Don't** approve without actually reviewing ("LGTM" with no comments on a 500-line PR)
- **Don't** let PRs sit for days—blocked PRs hurt everyone
- **Don't** take feedback personally—we're all improving the codebase together

### Angular-Specific Checklist

Quick things to check for Angular code:

- [ ] Components are focused and not doing too much
- [ ] Services handle business logic, not components
- [ ] Observables are properly unsubscribed (async pipe, takeUntil, or takeUntilDestroyed)
- [ ] No direct DOM manipulation (use Renderer2 if needed)
- [ ] Inputs/Outputs are used appropriately for component communication
- [ ] Change detection isn't being fought (misusing ChangeDetectorRef)
- [ ] Dependency injection is used properly
- [ ] Routing guards/resolvers are used where appropriate

### When in Doubt

- **Is this comment worth making?** Ask: "Will this improve the code meaningfully, or am I just expressing a preference?"
- **Can't agree?** Bring it to a team discussion—maybe we need to update our standards.
- **Stuck on something?** Schedule a quick pairing session instead of long comment threads.

### Continuous Improvement

We'll revisit these guidelines quarterly. If something isn't working, speak up—this is a living document.

---

**Remember**: Code review is collaboration, not gatekeeping. We're helping each other ship better software.

---

Would you like me to adjust anything? For example, I could add sections on specific Angular version features (like standalone components if you're on v14+), add more about your particular testing strategy, or include guidelines around TypeScript strictness levels.

# clean code necessity by sonnet 4.5

The major reasonings behind clean code all stem from one fundamental reality: **code is read far more often than it's written**.

Here are the core motivations:

## 1. **Cognitive Load Reduction**

Human working memory is limited (roughly 7±2 items). Clean code minimizes the mental burden of understanding what's happening. When you read `isEligibleForRefund` vs `x` or `flag2`, you don't have to hold extra context in your head. The code itself carries its meaning.

This matters because developers spend 70-90% of their time reading and understanding code, not writing it.

## 2. **Economic Reality**

Software maintenance costs dwarf initial development costs—often 40-80% of total software lifecycle costs. Clean code directly reduces:

- Time to understand existing code
- Time to locate bugs
- Time to add new features
- Onboarding time for new developers
- Risk of introducing bugs during changes

Messy code has compound interest—technical debt accumulates, and every change becomes progressively harder and more expensive.

## 3. **Team Collaboration**

Code is a communication medium between developers (present and future, including your future self). Clean code is:

- **Readable** - Others can understand your intent
- **Predictable** - Follows conventions and patterns the team recognizes
- **Maintainable** - Changes can be made safely without deep archeology

In a team setting, "clever" code that only you understand becomes a liability, not an asset.

## 4. **Reducing Bugs**

Complex, tangled code hides bugs. Clean code makes bugs more obvious through:

- **Simplicity** - Fewer moving parts, fewer places for bugs to hide
- **Explicitness** - Clear logic makes incorrect logic visible
- **Testability** - Small, focused functions are easier to test thoroughly
- **Predictability** - Following principles like single responsibility means changes have localized effects

Studies show that code complexity (cyclomatic complexity, nesting depth) correlates strongly with defect density.

## 5. **Change Enablement**

Requirements change constantly. Clean code embraces this through:

- **Loose coupling** - Changes to one part don't cascade everywhere
- **High cohesion** - Related things are grouped, making changes localized
- **SOLID principles** - Code is open for extension, closed for modification

Rigid, tightly-coupled code resists change. Clean code is flexible and adaptable.

## 6. **Preventing Knowledge Silos**

When code is opaque and complex, only the original author understands it. This creates:

- **Bus factor** problems (what if that person leaves?)
- **Bottlenecks** (only one person can work on that feature)
- **Risk** (critical knowledge locked in one person's head)

Clean code distributes knowledge across the team because anyone can understand it.

## 7. **Professional Craftsmanship**

There's a moral/ethical dimension too. As software increasingly runs critical infrastructure (healthcare, finance, transportation), we have a responsibility to:

- Write code that can be verified as correct
- Make code maintainable so bugs can be fixed quickly
- Enable others to understand and improve our work

This is similar to why doctors follow medical standards or engineers follow safety codes—lives and livelihoods depend on software quality.

## 8. **Speed (Long-term)**

Paradoxically, "going slow to go fast." While clean code might feel slower initially:

- You write less code (DRY, proper abstractions)
- You spend less time debugging
- You make changes faster (no fear of breaking things)
- You don't slow down over time (avoiding technical debt)

Messy code accelerates fast at first, then grinds to a crawl as complexity compounds.

---

## The Counter-Argument (and Why It Fails)

Some argue: "We need to ship fast, we'll clean it up later."

This almost never happens because:

- "Later" never comes (new features always take priority)
- The mess makes future work slower, creating a vicious cycle
- Cleaning up becomes progressively harder as the mess grows

The reality: **you can't go fast for long with messy code**. Clean code is the only sustainable way to maintain velocity.

---

**The bottom line**: Clean code isn't about aesthetics or personal preference. It's about economics, risk management, and treating software development as an engineering discipline rather than a chaotic free-for-all. The reasonings are deeply practical—clean code is simply cheaper and less risky over any meaningful time horizon.