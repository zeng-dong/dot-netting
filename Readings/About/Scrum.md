## Derek Davidson

https://www.scrum.org/derek-davidson
Derek is a Professional Scrum Trainer (PST) with Scrum.org. He is also a Certified Scrum Trainer (CST) with the Scrum Alliance, the first Scrum Trainer in Europe dual-certified by both the Scrum Alliance and Scrum.org

## The Daily Scrum and Empiricism

-- from # 18 Paragraphs That Will Make Your Daily Scrum Better[https://turboscrum.com/better-daily-scrum/#more-3858]  

You may recall that Scrum is founded on empirical process control. Empiricism asserts that knowledge comes from experience and making decisions based on what is known.

The pillars of empiricism are transparency, inspection and adaptation. Every event in Scrum is a formal opportunity for inspection and adaptation and the Scrum Guide makes it very clear what is inspected and adapted in the Daily Scrum:

> The purpose of the Daily Scrum is to inspect progress toward the Sprint Goal and adapt the Sprint Backlog as necessary, adjusting the upcoming planned work.


## how to do functional analysis in scrum

```
Okay, the user is asking about how to do functional analysis in Scrum. Let me start by recalling what functional analysis entails. Functional analysis in software development usually refers to breaking down a system's functions into components to understand what the system should do. Now, integrating that into Scrum, which is an Agile framework, I need to think about how that fits into the Scrum process.

First, I should consider the roles in Scrum. The Product Owner is responsible for the product backlog, which contains user stories and requirements. The Development Team works on delivering increments each sprint. Functional analysis would probably involve the Product Owner and the team working together to clarify requirements.

In Scrum, the main artifacts are the product backlog, sprint backlog, and the increment. Functional analysis might be part of refining the product backlog. Backlog refinement is when the team reviews and clarifies items in the product backlog to prepare for upcoming sprints. So, during refinement, the team could perform functional analysis by breaking down user stories into smaller, more manageable pieces and understanding the functionality required.

User stories are a big part of Scrum. They are short descriptions of a feature from the user's perspective. Functional analysis would involve decomposing these user stories into tasks, identifying acceptance criteria, and ensuring that the team understands the functional requirements. Acceptance criteria are conditions that a product must satisfy to be accepted by the user, so they are crucial for functional analysis.

I should also think about the Definition of Ready. This is a set of criteria that a user story must meet before it can be pulled into a sprint. Part of functional analysis would be ensuring that user stories meet the Definition of Ready, meaning they are well-understood, estimated, and have clear acceptance criteria.

Another aspect is collaboration. In Scrum, the team works collaboratively, so functional analysis should involve discussions between the Product Owner, developers, testers, and other stakeholders. Techniques like user story mapping or example mapping might be used to visualize and analyze the functionality.

Testing is also part of functional analysis. The team needs to ensure that each user story is testable. This could involve creating test cases during backlog refinement or sprint planning to validate the functionality.

I should mention the importance of continuous refinement. Since Scrum is iterative, functional analysis isn't a one-time activity. It happens continuously as the product backlog evolves and as the team gains more understanding of the product.

Also, tools like behavior-driven development (BDD) or acceptance test-driven development (ATDD) might be relevant here. These practices encourage defining acceptance criteria upfront, which is part of functional analysis.

Finally, I need to outline practical steps. For example, during backlog refinement, the team can break down user stories, define acceptance criteria, create tasks, and ensure everyone understands the functionality. In sprint planning, they can further analyze the selected stories to plan the work. Daily stand-ups can address any emerging questions about functionality, and sprint reviews can validate that the functionality meets the users' needs.

Wait, but I should make sure not to conflate functional analysis with other Scrum events. The key is to integrate functional analysis into existing Scrum ceremonies and artifacts without adding extra steps. Emphasize that it's part of the team's collaborative process during refinement and sprint planning.

Also, maybe mention that functional analysis in Scrum is about ensuring that each increment delivers the right functionality by continuously clarifying and validating requirements through collaboration and iterative development.
```

**Functional analysis in Scrum** involves breaking down product requirements into actionable, testable components to ensure the team delivers valuable, user-centric functionality. Here's how to integrate functional analysis into Scrum practices effectively:

---

### **1. Align with Scrum Roles & Events**
- **Product Owner (PO)**: Drives functional analysis by clarifying requirements and prioritizing the Product Backlog.
- **Development Team**: Collaborates to dissect user stories, define acceptance criteria, and identify technical tasks.
- **Scrum Events**: Conduct analysis during **Backlog Refinement**, **Sprint Planning**, and **Daily Scrum**.

---

### **2. Steps to Perform Functional Analysis in Scrum**
#### **A. During Backlog Refinement**  
1. **Break Down Epics/Features**:  
   - Split large requirements (epics) into smaller, testable **user stories** (e.g., "As a user, I can reset my password via email").  
   - Use **user story mapping** to visualize workflows and dependencies.  

2. **Define Acceptance Criteria**:  
   - Specify conditions for a story to be "done" (e.g., "Password reset email is sent within 2 minutes").  
   - Collaborate with stakeholders to ensure clarity.  

3. **Identify Dependencies & Risks**:  
   - Highlight technical or functional dependencies (e.g., integration with an external API).  

#### **B. During Sprint Planning**  
4. **Select Stories for the Sprint**:  
   - Choose user stories aligned with the Sprint Goal and team capacity.  

5. **Decompose Stories into Tasks**:  
   - Break stories into technical tasks (e.g., "Implement email service for password reset").  
   - Use **example mapping** to explore edge cases (e.g., "What if the user enters an invalid email?").  

6. **Clarify Functional Details**:  
   - Resolve ambiguities through team discussion or **Three Amigos** sessions (PO, developer, tester).  

#### **C. During Sprint Execution**  
7. **Continuous Collaboration**:  
   - Use **Daily Scrum** to address emerging functional questions (e.g., "How should error messages display?").  
   - Pair programming or mob programming to align on implementation.  

8. **Test-Driven Development (TDD)**:  
   - Write automated tests based on acceptance criteria before coding to validate functionality.  

#### **D. During Sprint Review**  
9. **Demo Functionality**:  
   - Showcase the increment to stakeholders and validate it meets their functional expectations.  

10. **Gather Feedback**:  
   - Adjust the Product Backlog based on stakeholder input (e.g., "Add SMS as a password reset option").  

---

### **3. Tools & Techniques**  
- **User Story Mapping**: Visualize user journeys to prioritize and analyze functionality.  
- **Behavior-Driven Development (BDD)**: Define acceptance criteria in a structured format (e.g., Gherkin syntax).  
- **Definition of Ready (DoR)**: Ensure stories are well-analyzed before sprint inclusion (e.g., "Acceptance criteria agreed").  
- **Traceability Matrix**: Link user stories to tests and requirements to ensure coverage.  

---

### **4. Example: Password Reset Feature**  
11. **User Story**:  
   - *"As a user, I can reset my password via email so I can regain access to my account."*  

12. **Acceptance Criteria**:  
   - Email is sent within 2 minutes of request.  
   - Link expires after 24 hours.  
   - System logs failed attempts.  

13. **Tasks**:  
   - Integrate email service (e.g., SendGrid).  
   - Implement token-based expiration.  
   - Write unit tests for token validation.  

---

### **5. Benefits of Functional Analysis in Scrum**  
- **Reduces Ambiguity**: Clear requirements minimize rework.  
- **Improves Quality**: Testable criteria ensure functionality aligns with user needs.  
- **Accelerates Delivery**: Smaller, well-understood stories enable faster iteration.  

---

### **6. Common Pitfalls & Solutions**  
| **Pitfall**                       | **Solution**                                      |  
|-----------------------------------|---------------------------------------------------|  
| Vague acceptance criteria         | Use BDD-style examples (Given/When/Then).         |  
| Overlooking edge cases            | Conduct example mapping with the Three Amigos.    |  
| Analysis paralysis                | Timebox refinement sessions (e.g., 1 hour/week). |  

---

### **Key Takeaway**  
Functional analysis in Scrum is **not a phase**—it’s a **continuous, collaborative process** embedded in Scrum events. By breaking down requirements iteratively, defining clear acceptance criteria, and validating functionality early, teams deliver increments that truly meet user needs.