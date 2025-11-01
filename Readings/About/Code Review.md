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