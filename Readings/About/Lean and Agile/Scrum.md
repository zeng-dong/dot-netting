## Derek Davidson

https://www.scrum.org/derek-davidson
Derek is a Professional Scrum Trainer (PST) with Scrum.org. He is also a Certified Scrum Trainer (CST) with the Scrum Alliance, the first Scrum Trainer in Europe dual-certified by both the Scrum Alliance and Scrum.org

## The Daily Scrum and Empiricism

-- from # 18 Paragraphs That Will Make Your Daily Scrum Better[https://turboscrum.com/better-daily-scrum/#more-3858]  

You may recall that Scrum is founded on empirical process control. Empiricism asserts that knowledge comes from experience and making decisions based on what is known.

The pillars of empiricism are transparency, inspection and adaptation. Every event in Scrum is a formal opportunity for inspection and adaptation and the Scrum Guide makes it very clear what is inspected and adapted in the Daily Scrum:

> The purpose of the Daily Scrum is to inspect progress toward the Sprint Goal and adapt the Sprint Backlog as necessary, adjusting the upcoming planned work.


### hero dysfunction
In Malignant Hero Dysfunction this person thinks they're a god and that the rules no longer apply to them, so here are some of the things that start to go wrong. Everything's written with unit tests. "Fuggedaboudit! " Everything's compiled as part of an automated build. Never mind. No patches are made directly against production servers. Everything passes code review? Don't even worry about it. Definition of Done, does it comply with Definition of Done? Nah, don't even worry about it, forget about it, so this starts to become a bit of a problem because well, Hero dysfunction in any form starts to kill self-organization. This one here is pretty effective at killing team-orientation. Tends to kill team morale because well, no one gets to do anything anymore. This hero jumps in and does all the cool stuff. Now the downside is that because this person is above the law, as they stop paying attention to the Definition of Done, and they start making shortcuts to make this stuff all happen, it can tend to introduce quality problems, and if they're not following the full Definition of Done you're almost, well you're literally by definition introducing technical debt into your system, and that technical debt is going to become a problem, so as a Scrum Master you really have to look out for this particular flavor of hero dysfunction, and my advice with this one is that there's something that this person needs. This is ego driven. You have to find a way to stroke their ego and make it okay for them to hang back. Maybe coach them to be more of a mentor role than a straight up hero role, but whatever it is, notice that it's happening because it can wreck your self-organizing team if you're not careful. Next up, let's talk about the changing Sprint Length dysfunction.

#### from Derek Davidson
Next, we have the hero developer anti‑pattern. High‑functioning organizations don't need heroes. Great team players are vital; heroes are not. Heroes almost always ignore quality. Tests, documentation, automation, these are rarely a priority for them. A hero culture is a broken culture. Needing a hero means the overall system is fundamentally broken. And heroes crave attention. They resist Scrum because the focus moves to the team and away from them. This is possibly one of the hardest anti‑patterns to resolve. The task is to encourage the hero to become a part of the team and for them to invest in that team. This can require deft handling.
# acceptance criteria
```
Okay, the user is asking if a single developer on a Scrum team can define acceptance Criteria (AC) for a Product Backlog Item (PBI) without involving other developers. Let me break this down.

First, I remember that in Scrum, the Product Owner typically owns the backlog and AC, but the team collaborates. The user's previous question was about an individual developer, maybe a solo context. Now, they're in a team setting but want to exclude others. That might be a problem.

I need to address the roles in Scrum. The Product Owner is responsible for the backlog, but the team works together. If a developer writes AC alone, without input, it could lead to misunderstandings. For example, maybe they missed a requirement or the AC are too technical, not user-focused.

The user might be thinking about efficiency. Maybe they feel involving everyone takes too long. But collaboration is key in Agile. I should explain the risks of not involving others: like incomplete AC, lack of shared understanding, or technical debt.

Also, the team's ownership of the work. If one person defines AC, others might not feel committed. It could cause friction or silos. I should mention how collaboration improves quality and shared responsibility.

But maybe there are scenarios where a developer can draft AC first. Like if they're working on a specific technical task. Then, others review it. So I should offer best practices: draft AC individually but get team feedback, use refinement sessions, involve the PO, etc.

I should also highlight the importance of AC being user-centric and testable. If a developer writes AC alone, they might focus on code rather than user needs. Examples would help here. Maybe compare good vs bad AC.

In conclusion, while possible, it's not advisable. The answer should balance acknowledging that technically a developer can write AC, but emphasizing the need for collaboration in a Scrum team to ensure quality and alignment.
```

In a **multi-developer Scrum team**, an individual developer **can technically define acceptance criteria (AC) for a PBI without involving others**, but doing so **violates Agile principles** and risks creating inefficiencies, misalignment, or quality gaps. Here’s why:

---

### **Key Risks of Not Involving the Team**
1. **Lack of Shared Understanding**:
   - AC define the "done" criteria for a PBI. If one developer writes AC in isolation, other team members may misinterpret requirements, leading to rework or conflict.
   - Example: A developer defines AC for an API endpoint but misses edge cases another developer would have identified (e.g., rate limiting, error handling).

2. **Undermines Collaboration**:
   - Scrum emphasizes **collective ownership** and cross-functional collaboration. Siloing AC creation erodes trust and shared responsibility.
   - Developers may feel excluded or resentful if their expertise isn’t leveraged.

3. **Narrow Focus**:
   - A single developer might prioritize technical implementation over user value (e.g., "Use X library" vs. "User can upload files under 10MB").
   - Non-functional requirements (security, performance) or integration points may be overlooked.

4. **Product Owner Misalignment**:
   - The Product Owner (PO) owns the backlog and AC. If a developer unilaterally defines AC without PO input, the work may not align with business goals.

---

### **When Is It Acceptable?**
A developer **might draft AC alone** only in these scenarios:
1. **Temporary Drafting**: Creating a *starting point* for team refinement (e.g., during Sprint Planning or Backlog Refinement).
2. **Simple/Technical PBIs**: For low-complexity tasks with clear requirements (e.g., "Add logging for X feature").
3. **Hybrid Roles**: If the developer is also acting as the PO or proxy (e.g., in small teams with role overlap).

**Even then**, the AC should be **validated by the team and PO** before finalization.

---

### **Best Practices for AC in Multi-Developer Teams**
1. **Collaborate During Refinement**:
   - Use backlog refinement sessions to collectively define AC with the PO, developers, and testers.
   - Ask: *“What does ‘done’ look like for everyone?”*

2. **Leverage Team Expertise**:
   - Developers bring unique perspectives (e.g., frontend vs. backend concerns). Use their input to catch gaps or risks early.

3. **Use a Template**:
   - Structure AC with user-centric language (e.g., BDD’s *Given-When-Then*):
     ```
     Given a user is logged in,
     When they click "Delete Account",
     Then they receive a confirmation email,
     And their data is removed within 24 hours.
     ```

4. **PO Approval**:
   - Ensure the PO reviews and signs off on AC to confirm alignment with business goals.

5. **Avoid Ambiguity**:
   - Write testable, specific criteria (e.g., “Response time < 2 seconds under 1,000 concurrent users”).

---

### **Example of Poor vs. Effective AC**
**PBI**: *"Improve login page performance."*  
❌ **Poor (Siloed AC)**:
- “Use React.memo to optimize rendering.” (Focuses on implementation, not outcome.)  
✅ **Effective (Collaborative AC)**:
- “Login page loads in < 1.5 seconds on 3G networks (Lighthouse score ≥ 90).”  
- “User can submit credentials without UI freezing.”  

---

### **Conclusion**
While an individual developer **can** write AC alone, **they shouldn’t** in a Scrum team without collaboration. Agile thrives on shared ownership, transparency, and collective intelligence. By involving the team and PO, you ensure AC are:  
- Aligned with user/business needs,  
- Technically feasible,  
- Free of blind spots.  

If time constraints exist, draft AC as a starting point—but always refine them with the team.

# scrum backlog: what vs how
```
Okay, so I need to figure out why a Scrum backlog shouldn't define how to do things. Let me start by recalling what a Scrum backlog is. From what I know, the Product Backlog is a list of features, enhancements, bugs, etc., that need to be addressed in the product. It's prioritized by the Product Owner.

Now, the question is asking why the backlog shouldn't specify the "how." So, maybe it's about not dictating the technical details or methods. Let me think about Scrum principles. Scrum is part of Agile, which values individuals and interactions over processes and tools, and responding to change over following a plan. So, if the backlog starts prescribing how to do things, maybe that's against these principles.

The team is self-organizing, right? So they should decide the best way to tackle the work. If the Product Backlog items (PBIs) are too prescriptive, that might take away the team's autonomy. For example, if a user story says "Implement the login feature using OAuth 2.0," that's specifying the how. But maybe the team has a better or more efficient method. By not specifying, the team can innovate or adapt based on their expertise.

Also, the Product Owner is responsible for the "what" and the "why," while the Development Team handles the "how." So if the PO starts dictating the how, it could blur those responsibilities. The PO focuses on value and priorities, while the team focuses on delivering that value effectively.

Another angle is that the backlog is meant to be adaptable. If you define the how upfront, changes become harder. The team might be locked into a specific approach, which could be problematic if new information comes up during the Sprint. Agile is all about adapting, so the how should emerge during the Sprint as the team works through the PBIs.

Also, too much detail in the backlog could lead to micromanagement. The team might feel disempowered if every task is spelled out in detail. It could slow them down if they have to follow strict instructions instead of using their own judgment. Plus, the backlog might become too bulky and hard to maintain if every item includes detailed technical steps.

But wait, aren't there times when some technical details are necessary? Like, maybe non-functional requirements or constraints. For example, if the product must use a specific API for compliance reasons. So maybe the "how" is acceptable when it's a constraint rather than a method. But in general, the team should decide the implementation details.

Also, splitting the what and the how allows for better collaboration. The team can discuss the best approach during Sprint Planning or refinement meetings. This collaboration can lead to better solutions than if the approach was predetermined.

Another thought: if the how is defined in the backlog, it might not account for the team's current context. For example, their skills, past experiences, or existing tech debt. The team is in the best position to assess what approach is feasible and effective given their unique situation.

So putting this all together, the main reasons are respecting the team's autonomy, maintaining role clarity between PO and team, keeping the backlog flexible, avoiding micromanagement, allowing adaptation, and leveraging the team's expertise. The backlog should focus on the value and outcomes, not the implementation specifics.
```

The Scrum Product Backlog should avoid defining the "how" to uphold Agile principles and empower the team. Here's a structured breakdown of the reasoning:

1. **Self-Organizing Teams**: 
   - Scrum trusts the Development Team to determine the best technical approach. Prescribing methods undermines their autonomy and stifles innovation, as they are closest to the work and understand the practical constraints.

2. **Role Clarity**:
   - The Product Owner focuses on the "what" (priorities) and "why" (value), while the Development Team owns the "how." Blurring these roles risks inefficiency and conflicts, as it encroaches on the team's responsibilities.

3. **Flexibility and Adaptability**:
   - Agile emphasizes responding to change. Detailed "how" specifications in the Backlog create rigidity, making it harder to adapt to new insights or feedback during Sprints. Solutions should emerge iteratively.

4. **Avoiding Micromanagement**:
   - Overly prescriptive Backlog items can demotivate the team, reducing ownership and creativity. Trusting the team fosters engagement and leverages their expertise for better outcomes.

5. **Focus on Value, Not Implementation**:
   - The Backlog should articulate user-centric outcomes (e.g., "Users can securely log in") rather than technical steps (e.g., "Use OAuth 2.0"). This keeps the focus on delivering value, allowing the team to choose the most efficient path.

6. **Collaboration and Context**:
   - Teams can factor in their unique context (skills, tech debt, tools) during Sprint Planning. Predefined solutions might ignore these nuances, leading to suboptimal results.

**Exceptions**: 
- Non-functional requirements (e.g., compliance, performance standards) or organizational constraints (e.g., mandated tools) may necessitate specifying some "how" details, but these should be minimal and justified.

In summary, separating the "what" from the "how" respects the team’s expertise, maintains agility, and aligns with Scrum’s core values of collaboration and adaptability.
# Functional Review

## functional requirements
<thoughts>
Okay, the user is asking about functional requirements in software engineering. Let me start by recalling what functional requirements are. They define what the software should do, right? So, the user probably wants a clear explanation of what these requirements are, maybe examples, and how they differ from non-functional ones.

First, I should define functional requirements. They are specific behaviors or functions that the system must perform. For example, in a login system, a functional requirement might be allowing users to reset their password. I need to make sure the explanation is straightforward.

Then, I should provide examples. Maybe break them down into categories like user requirements, system functions, business rules, and data handling. That structure will help the user understand different contexts where functional requirements apply.

Next, I should explain how functional requirements are different from non-functional. Non-functional are about how the system works, like performance or security, while functional are about what the system does. Including a comparison table would make this distinction clear.

The user might also be interested in why functional requirements are important. So, I should mention aspects like guiding development, ensuring alignment with user needs, and serving as a basis for testing. It's crucial to highlight their role in the development lifecycle.

I should also think about how these requirements are documented. Use cases, user stories, and functional specifications are common methods. Providing examples of each, like a user story format, can be helpful.

Maybe include best practices too. Things like being specific, traceable, and avoiding technical jargon. This helps the user understand how to write effective functional requirements.

Wait, the user is asking for "functional requirements for software engineering." Are they a student, a new developer, or someone involved in project management? The answer should be accessible to someone without deep technical knowledge but thorough enough to be useful.

Also, check if there are any common mistakes people make when defining functional requirements, like being too vague. Including pitfalls to avoid would add value.

Let me organize this: definition, examples, differences from non-functional, importance, documentation methods, best practices, and common pitfalls. That structure should cover the topic comprehensively.

I need to make sure the language is clear and avoid unnecessary jargon. Use bullet points and tables where possible for readability. Including real-world examples, like an e-commerce system, can make the concepts more concrete.

Double-check that all information is accurate. For example, functional requirements vs. non-functional: functional is about what, non-functional about how well. Examples of each are correct. The documentation methods like use cases and user stories are appropriate.

Also, mention that functional requirements are part of the Software Requirements Specification (SRS) document. That ties it into standard practices.

Finally, wrap it up with a key takeaway to reinforce the main points. Make sure the answer is thorough but not overwhelming, balancing depth with clarity.
</thoughts>

### **1. What Are Functional Requirements?**
Functional requirements specify **actions the system must perform** to deliver value to users. They answer questions like:
- What tasks should the system accomplish?
- How should the system respond to specific inputs?
- What outputs or results are expected?

**Example**:  
For an e-commerce app, functional requirements might include:  
- Users can search for products by name or category.  
- Users can add items to a shopping cart.  
- The system calculates taxes and shipping costs during checkout.  

---

### **2. Key Components of Functional Requirements**
Functional requirements typically describe:  
- **User interactions** (e.g., login, data entry, reporting).  
- **Business rules** (e.g., discounts apply only to orders over $50).  
- **Data handling** (e.g., how data is stored, retrieved, or validated).  
- **System integrations** (e.g., connecting to payment gateways or APIs).  
- **Workflows** (e.g., order approval steps for a manager).  

---

### **3. Examples of Functional Requirements**
| **Category**          | **Example**                                                                 |
|------------------------|-----------------------------------------------------------------------------|
| **User Actions**       | "The user can upload a profile photo in JPEG or PNG format."                |
| **Data Validation**    | "The system must validate email addresses using regex before submission."   |
| **Business Logic**     | "A 10% discount is applied if the user spends over $100."                   |
| **Reporting**          | "Generate a monthly sales report in PDF format."                            |
| **Integration**        | "The app must integrate with PayPal for payment processing."                |

---

### **4. Functional vs. Non-Functional Requirements**
| **Functional Requirements**                     | **Non-Functional Requirements**                      |  
|--------------------------------------------------|------------------------------------------------------|  
| Define **what** the system does.                 | Define **how well** the system performs.             |  
| Focus on **features and behaviors**.             | Focus on **quality attributes** (e.g., speed, security). |  
| Example: "Users can reset passwords via email."  | Example: "The system must load pages in under 2 seconds." |  

---

### **5. Why Are Functional Requirements Important?**
- **Guide Development**: Provide clear instructions for developers and testers.  
- **Align Stakeholders**: Ensure everyone agrees on what the system should do.  
- **Basis for Testing**: Enable test cases to verify if the system meets expectations.  
- **Reduce Ambiguity**: Prevent scope creep or misunderstandings during development.  

---

### **6. How Are Functional Requirements Documented?**
They are often captured in:  
- **Use Cases**: Scenarios describing user-system interactions (e.g., "Place Order").  
- **User Stories**: Agile-style statements like:  
  *"As a customer, I want to filter products by price so I can find affordable items."*  
- **Software Requirements Specification (SRS)**: A formal document detailing all requirements.  
- **Wireframes/Mockups**: Visual representations of features (e.g., UI layouts).  

---

### **7. Best Practices for Writing Functional Requirements**
- **Be Specific**: Avoid vague terms like "user-friendly" (e.g., "The search bar must autocomplete after 3 keystrokes").  
- **Use Active Voice**: "The system **shall** validate user input" instead of passive phrasing.  
- **Prioritize**: Rank requirements (e.g., "must-have" vs. "nice-to-have").  
- **Ensure Traceability**: Link requirements to design, code, and test cases.  

---

### **8. Common Pitfalls to Avoid**  
- **Overlooking Edge Cases**: Failing to define how the system handles errors or unusual inputs.  
- **Mixing with Non-Functional**: Confusing performance goals (e.g., "fast") with functionality.  
- **Ambiguity**: Using terms like "support" without clarity (e.g., "support mobile devices" vs. "optimized for iOS and Android").  

---

### **Key Takeaway**  
Functional requirements are the **backbone of software development**. They translate user needs into actionable specifications, ensuring the final product delivers the right features and behaviors. Without them, teams risk building a system that fails to meet expectations or solve real-world problems.


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

## Functional Requirements Review in Software Engineering
A **Functional Requirements Review (FRR)** in software engineering is a structured evaluation process where stakeholders assess and validate the documented functional requirements of a system to ensure they are **clear, complete, feasible, and aligned with user needs and business goals**. It is a critical checkpoint in the software development lifecycle (SDLC) to minimize misunderstandings, gaps, or errors before development begins.

---

### **Key Objectives of an FRR**
1. **Verify Completeness**: Ensure all user needs and system behaviors are captured.  
2. **Clarify Ambiguities**: Resolve vague or conflicting requirements (e.g., "The system shall process transactions quickly").  
3. **Validate Feasibility**: Confirm requirements are technically achievable within constraints (time, budget, technology).  
4. **Ensure Testability**: Define criteria that QA can validate (e.g., "User login must succeed within 2 seconds").  
5. **Align Stakeholders**: Get consensus among developers, testers, product owners, and end-users.  

---

### **Who Participates?**
- **Business Analysts/Product Owners**: Define and prioritize requirements.  
- **Developers**: Assess technical feasibility.  
- **QA/Test Engineers**: Ensure requirements are testable.  
- **End-Users/Clients**: Validate alignment with real-world needs.  
- **Project Managers**: Ensure requirements fit timelines and resources.  

---

### **Steps in a Functional Requirements Review**
1. **Preparation**:  
   - Gather requirements documents (e.g., Software Requirements Specification [SRS], user stories, use cases).  
   - Distribute materials to reviewers in advance.  

2. **Review Meeting**:  
   - Walk through each requirement line-by-line.  
   - Discuss ambiguities, contradictions, or missing details.  
   - Use checklists to ensure consistency and completeness.  

3. **Document Updates**:  
   - Revise requirements based on feedback (e.g., clarify vague terms like "user-friendly").  
   - Log unresolved issues for follow-up.  

4. **Sign-Off**:  
   - Formal approval from stakeholders to proceed to design/development.  

---

### **What to Evaluate During an FRR**
| **Aspect**                | **Key Questions**                                                                 |  
|----------------------------|-----------------------------------------------------------------------------------|  
| **Clarity**                | Is the requirement free of jargon and ambiguity? (e.g., "fast" vs. "response time <1s"). |  
| **Consistency**            | Do requirements conflict with each other or with non-functional requirements?      |  
| **Completeness**           | Are all user scenarios, edge cases, and error conditions covered?                 |  
| **Testability**            | Can QA design test cases to verify the requirement?                               |  
| **Traceability**           | Is the requirement linked to business goals or user stories?                     |  
| **Feasibility**            | Can this be implemented with current resources and technology?                   |  

---

### **Example Scenario**  
**Requirement**: *"Users can filter search results by price range."*  
**FRR Feedback**:  
- Ambiguity: What happens if no results match the price range?  
- Missing Edge Case: How are decimal values or currency conversions handled?  
- Testability: Add acceptance criteria like, "Display 'No results found' if filters return empty."  

---

### **Benefits of an FRR**
- **Reduces Rework**: Catch errors early to avoid costly fixes later.  
- **Improves Collaboration**: Aligns developers, testers, and business teams.  
- **Enhances Quality**: Clear requirements lead to fewer defects and better user satisfaction.  
- **Mitigates Risks**: Identifies gaps in security, scalability, or compliance early.  

---

### **Common Pitfalls & Solutions**  
| **Pitfall**                | **Solution**                                                                 |  
|-----------------------------|------------------------------------------------------------------------------|  
| Vague requirements          | Replace subjective terms (e.g., "fast") with measurable metrics.            |  
| Missing stakeholders        | Involve end-users, QA, and architects upfront.                              |  
| Overlooking edge cases      | Use techniques like *example mapping* to explore "what-if" scenarios.       |  
| Scope creep                 | Stick to a pre-defined agenda and defer out-of-scope ideas to future phases. |  

---

### **FRR in Agile/Scrum**  
In Agile teams, FRR is often integrated into:  
- **Backlog Refinement**: Breaking down epics into user stories with clear acceptance criteria.  
- **Sprint Planning**: Ensuring selected stories are well-defined and testable.  
- **Three Amigos Meetings**: Collaborative sessions (BA, developer, tester) to clarify requirements.  

---

### **Tools to Support FRR**  
- **Requirements Management Tools**: Jira, Confluence, IBM DOORS.  
- **Traceability Matrices**: Link requirements to tests, code, and business objectives.  
- **Checklists**: Standardize review criteria (e.g., "Is the requirement atomic?").  

---

### **Key Takeaway**  
A Functional Requirements Review is **not a formality**—it’s a **strategic step** to ensure the software solves the right problem, in the right way. By rigorously validating requirements, teams avoid building the wrong features, reduce wasted effort, and deliver higher-value solutions.  

**Without an FRR**, you risk:  
- Building features users don’t need.  
- Costly mid-development requirement changes.  
- A final product that fails to meet business goals.


## how to conduct functional requirements review in Scrum
```code
Okay, the user is asking how to conduct a Functional Requirements Review (FRR) in Scrum. Let me start by recalling what I know about Scrum and FRRs.

Scrum is an Agile framework with roles like Product Owner, Scrum Master, and Development Team. FRR is a process where stakeholders review functional requirements to ensure they're clear, complete, and feasible. But in Scrum, the terminology might be a bit different. Instead of traditional "requirements," they use Product Backlog Items (PBIs) like user stories.

The user probably wants to integrate FRR into Scrum events without disrupting the Agile flow. They might be a Scrum team member trying to ensure their user stories are well-defined before development. Common challenges here could be vague acceptance criteria or misalignment between stakeholders.

I need to explain how FRR fits into Scrum ceremonies. Let's break down the Scrum events where FRR can be incorporated. Backlog Refinement is key here. Also, Sprint Planning, Sprint Review, and maybe even Daily Standups. The Three Amigos technique (BA, developer, tester) could be useful.

I should outline steps for each Scrum event. For example, during Backlog Refinement, the team can review user stories, clarify acceptance criteria, and identify gaps. In Sprint Planning, they ensure selected items are ready. In the Sprint, continuous collaboration happens.

Also, the user might need practical examples, like a sample user story with acceptance criteria before and after FRR. Including best practices and common pitfalls would help them avoid mistakes. Tools like Jira or Confluence could be mentioned for tracking.

I need to make sure the answer is structured, easy to follow, and actionable. Highlighting the roles involved and how they collaborate is important. Emphasize that FRR in Scrum is iterative and integrated into the process rather than a separate phase.

Let me check if there's anything I'm missing. Oh, maybe mention the Definition of Ready (DoR) as part of ensuring PBIs are review-complete. Also, how to handle feedback from Sprint Reviews to update the backlog.

Alright, structuring the answer with sections for each Scrum event, roles, examples, best practices, and tools should cover it. Keep it conversational but informative.
```
Conducting a **Functional Requirements Review (FRR)** in **Scrum** requires integrating the review process into Agile ceremonies and collaboration frameworks. Here’s how to do it effectively without disrupting the Scrum flow:

---

### **1. Align FRR with Scrum Events**
In Scrum, functional requirements are captured as **Product Backlog Items (PBIs)** like user stories, epics, or features. FRR is not a standalone phase but a continuous, collaborative effort embedded in:

#### **A. Backlog Refinement (Grooming)**  
- **When**: Ongoing (ideally 1-2 times per sprint).  
- **Goal**: Ensure PBIs are **clear**, **testable**, and **ready** for sprint planning.  
- **Activities**:  
  - Break down epics into smaller user stories.  
  - Define **acceptance criteria** with the Three Amigos (Product Owner, Developer, Tester).  
  - Identify gaps (e.g., missing edge cases, unclear workflows).  
  - Use **example mapping** to explore scenarios (Given/When/Then).  

**Example**:  
- **User Story**: *"As a user, I can filter products by price range."*  
- **Refinement Session**:  
  - Clarify: *"What’s the minimum/maximum price range?"*  
  - Add acceptance criteria: *"Display ‘No results’ if no products match the filter."*  

---

#### **B. Sprint Planning**  
- **When**: Start of each sprint.  
- **Goal**: Confirm selected PBIs are **well-understood** and **actionable**.  
- **Activities**:  
  - Review acceptance criteria for sprint-ready PBIs.  
  - Flag ambiguities (e.g., *"How should the system handle decimal prices?"*).  
  - Split stories into tasks (e.g., *"Implement price filter UI component"*).  

---

#### **C. Daily Scrum**  
- **When**: Daily 15-minute standup.  
- **Goal**: Address emerging functional questions during sprint execution.  
- **Activities**:  
  - Developers/QA raise clarifications (e.g., *"How should error messages display for invalid filters?"*).  
  - Update acceptance criteria if needed.  

---

#### **D. Sprint Review**  
- **When**: End of each sprint.  
- **Goal**: Validate delivered functionality against requirements.  
- **Activities**:  
  - Demo the increment to stakeholders.  
  - Gather feedback to refine/update PBIs (e.g., *"Add a ‘reset filters’ button"*).  

---

### **2. Roles & Responsibilities**  
| **Role**                | **FRR Contribution**                                                                 |  
|--------------------------|-------------------------------------------------------------------------------------|  
| **Product Owner**        | Clarifies business goals, prioritizes PBIs, and defines "why" a feature is needed.   |  
| **Development Team**     | Assesses technical feasibility and breaks down requirements into tasks.              |  
| **QA/Testers**           | Ensures acceptance criteria are testable and covers edge cases.                      |  
| **Scrum Master**         | Facilitates collaboration and removes blockers during refinement.                    |  

---

### **3. Key Practices for FRR in Scrum**  
#### **A. Use the "Definition of Ready" (DoR)**  
Define a checklist for PBIs to be considered **ready** for sprint planning:  
- Acceptance criteria are clear and testable.  
- Dependencies are identified.  
- UX/UI mockups are available (if applicable).  

#### **B. Three Amigos Collaboration**  
Hold informal sessions with **Product Owner**, **Developer**, and **Tester** to:  
- Clarify requirements.  
- Explore edge cases.  
- Write acceptance criteria in BDD (Behavior-Driven Development) format:  
  ```gherkin  
  Scenario: Filter products by price  
    Given a user is on the product page  
    When they set the price range to $50-$100  
    Then only products within $50-$100 are displayed  
  ```  

#### **C. Automate Requirements Traceability**  
Use tools like **Jira** or **Azure DevOps** to link PBIs to:  
- Acceptance criteria.  
- Test cases.  
- Code commits.  

---

### **4. Example Workflow**  
1. **Backlog Refinement**:  
   - PO presents a user story: *"As a user, I can save items to a wishlist."*  
   - Team asks:  
     - *"How many items can be saved?"*  
     - *"Can users share wishlists?"*  
   - Updated story:  
     - Acceptance criteria: *"Wishlist supports up to 100 items. Sharing is Phase 2."*  

2. **Sprint Planning**:  
   - Team selects the refined story for the sprint.  
   - Tasks created: *"Design wishlist UI," "Implement backend storage."*  

3. **Sprint Execution**:  
   - Daily Scrum: QA asks, *"How are duplicate items handled?"* → Answer: *"Show a warning."*  

4. **Sprint Review**:  
   - Demo wishlist functionality.  
   - Stakeholder feedback: *"Add a ‘move to cart’ button."* → New PBI added.  

---

### **5. Tools to Support FRR in Scrum**  
- **Jira/Confluence**: Track PBIs, acceptance criteria, and decisions.  
- **BDD Tools** (e.g., Cucumber): Automate test scenarios based on acceptance criteria.  
- **Miro/Mural**: Visual collaboration for example mapping or user story mapping.  

---

### **6. Common Pitfalls & Solutions**  
| **Pitfall**                     | **Solution**                                                                 |  
|----------------------------------|------------------------------------------------------------------------------|  
| Vague acceptance criteria        | Use BDD-style examples (Given/When/Then).                                   |  
| Overlooking non-functional needs | Pair FRR with non-functional reviews (e.g., performance, security).         |  
| Siloed reviews                   | Involve the whole Scrum Team (devs, QA, PO) in refinement.                  |  

---

### **Key Takeaway**  
In Scrum, **Functional Requirements Review** is **not a one-time event** but a **continuous, collaborative process** woven into:  
- Backlog refinement to clarify PBIs.  
- Sprint planning to confirm readiness.  
- Daily scrums to resolve ambiguities.  
- Sprint reviews to validate outcomes.  

By integrating FRR into Scrum rituals, teams ensure they build the **right features**, with **clear expectations**, and **minimize rework**. The goal is to foster a culture where **shared understanding** drives quality.




![[Pasted image 20250221102657.png]]




```



# if a company have some implicit processes and engineering models do these considered agile practice? (sonnet 4.5)
**Not inherently, no.** Having implicit processes doesn't make something Agile—in fact, **implicit/undocumented processes often work against Agile principles**.

Here's why:

## The Problem with Implicit Processes

### 1. **They Create Knowledge Silos**

When processes are implicit (unwritten, "just how we do things"):

- New team members can't learn them easily
- Only veterans know "the real process"
- People make mistakes because they don't know the unwritten rules
- **This violates**: "Individuals and interactions over processes and tools"—you need both, but if the process is secret knowledge, interactions suffer

### 2. **They Can't Be Inspected and Adapted**

Agile's core is **empiricism**: inspect and adapt. If your processes are implicit:

- You can't discuss them in retrospectives
- You can't measure if they're working
- You can't improve them systematically
- Different people follow different interpretations

**This violates the Scrum pillar of transparency.**

### 3. **They Often Become Rigid Traditions**

Implicit processes become "the way we've always done it" without anyone questioning why:

- "We just know to do code reviews this way"
- "We always deploy on Fridays" (even if it causes problems)
- "Senior devs review junior code, not the other way"

**This violates**: "Responding to change over following a plan"—you can't respond to change if you can't even articulate what you're doing.

## When Implicit Processes Might Be "Agile-ish"

There are scenarios where implicit processes can coexist with Agile:

### ✅ **Team Autonomy That Works**

If a small, experienced team has:

- Strong trust and communication
- Shared understanding from working together
- Ability to adapt quickly
- Good outcomes

Then their implicit processes might be working **despite** being undocumented, not **because** of it.

**Example**: A 3-person startup team that "just knows" how they work together—they're nimble and effective.

**But even here**: As soon as they hire person #4, those implicit processes become a liability.

### ✅ **Lightweight Over Heavy Documentation**

Agile values "working software over comprehensive documentation." So:

- ✅ Having a simple, shared understanding is better than 100-page process manuals
- ✅ Face-to-face communication is better than rigid written procedures
- ❌ But "implicit" often means "not discussed at all"—that's different from "lightweight"

## What Agile Actually Looks Like

Agile processes should be:

### 1. **Explicit Enough to Improve**

You need to know what you're doing before you can improve it:

- "Our definition of done is: code reviewed, tests pass, deployed to staging"
- "Our team agreement: we pair program on complex features"
- "Our retrospective format: start-stop-continue"

These are **explicit** but **lightweight**—just enough to have a shared understanding.

### 2. **Visible and Transparent**

Everyone should know:

- What the workflow is (Kanban board, sprint board, etc.)
- What the team agreements are (working agreements)
- What "done" means
- How decisions get made

### 3. **Owned by the Team**

The team creates and evolves their own processes:

- Not imposed from above
- Regularly inspected in retrospectives
- Changed when they're not working

### 4. **Minimal and Just Enough**

Not bureaucratic, but not invisible either:

- Clear enough for new members to understand
- Flexible enough to adapt
- Documented just enough (team wiki, shared doc, board)

## Engineering Models: Same Story

"Implicit engineering models" have the same problems:

### ❌ **Implicit Architecture**

- "We just know how to structure our code"
- New developers break patterns accidentally
- No one can explain why things are organized this way
- Refactoring becomes guesswork

### ✅ **Explicit (but Lightweight) Architecture**

- "We use feature modules in Angular"
- "Services handle business logic, components handle view logic"
- "We follow SOLID principles"
- Documented in README or architecture decision records (ADRs)

## The Agile Approach to Processes

Here's what Agile teams actually do:

### **Make Implicit → Explicit → Improvable**

1. **Surface implicit processes**
    
    - "Hey team, I notice we always do X. Should we write that down?"
    - Retrospective question: "What unwritten rules do we follow?"
2. **Document minimally**
    
    - Team working agreements (1 page)
    - Definition of Done checklist
    - Architecture diagrams (simple)
    - Code review guidelines (your checklist is perfect for this!)
3. **Review and adapt regularly**
    
    - "Is this process still serving us?"
    - "What should we change?"
    - Update documentation when practices change

## Real-World Example

**Implicit (Problematic)**:

- Team "just knows" to test manually before code review
- New dev submits PR without testing
- Senior dev frustrated: "You should have tested first!"
- New dev: "No one told me that"

**Explicit but Agile**:

- Team creates "PR Checklist" (1 page)
- ☑ Tests pass locally
- ☑ Self-reviewed the diff
- ☑ Updated relevant documentation
- New dev follows checklist
- Team reviews checklist quarterly in retro: "Is this still useful?"

The second approach is:

- ✅ Transparent (everyone knows expectations)
- ✅ Improvable (can be adapted in retros)
- ✅ Lightweight (just a simple checklist)
- ✅ Agile (responds to team needs)

## Uncle Bob's Take

Uncle Bob would say implicit processes are **unprofessional**:

- Professionals have explicit standards
- Professionals can articulate their practices
- Professionals document just enough to maintain quality
- But professionals avoid bureaucracy

He'd argue: **Discipline requires clarity. You can't be disciplined about something you've never defined.**

## Your Situation

If your company has implicit processes, ask:

### 🔴 **Red Flags (Anti-Agile)**:

- "That's just how we do things here" (no explanation)
- New people struggle because nothing is written down
- Processes can't be questioned or improved
- Different teams interpret processes differently
- Tribal knowledge is power/status

### 🟢 **Green Flags (Could Be Agile)**:

- Team has strong shared understanding
- Can articulate processes when asked
- Willing to document when it helps
- Regularly discusses and improves practices
- Lightweight, not bureaucratic

## The Bottom Line

**Implicit processes are not Agile practices**—they're often the opposite:

- Agile requires **transparency** (one of Scrum's three pillars)
- You can't **inspect and adapt** what's invisible
- **Team collaboration** suffers when expectations are unclear

**The Agile approach**:

- Make processes explicit enough to discuss and improve
- Keep them lightweight (not bureaucratic)
- Review and adapt them regularly
- Let teams own and evolve their processes

**Action for your team**: In your next retrospective, ask:

> "What unwritten rules do we follow? Should we write some of them down so we can improve them?"

This is how you move from implicit (problematic) to explicit-but-agile (healthy).


# if a company have some implicit processes and engineering models which some scrum teams ask the developers to find these processes/models out, do these considered agile practice?  (sonnet 4.5)

**No, this is actively anti-Agile and borders on dysfunction.**

Making developers "find out" implicit processes is not a practice—it's a **failure of leadership and team collaboration**. Let me explain why this is problematic at multiple levels:

---

## Why This Is Anti-Agile

### 1. **Violates Transparency (Core Scrum Pillar)**

Scrum has three pillars: Transparency, Inspection, Adaptation.

If processes are hidden and developers must "discover" them:

- ❌ **No transparency** - Critical information is obscured
- ❌ **Can't inspect** - How do you inspect what you can't see?
- ❌ **Can't adapt** - How do you improve invisible processes?

This breaks the foundation of Scrum/Agile entirely.

### 2. **Violates "Individuals and Interactions"**

The Agile Manifesto values "individuals and interactions over processes and tools."

But if developers must hunt for processes rather than receiving clear communication:

- **Individuals suffer** - Unnecessary stress, wasted time, fear of mistakes
- **Interactions break down** - No collaboration, just archaeological research
- **Trust erodes** - "Why won't they just tell me?"

### 3. **Creates Waste (Lean Principle)**

Making developers figure out implicit processes is **pure waste**:

- Time spent searching for information
- Mistakes made from not knowing
- Rework when they guess wrong
- Onboarding takes months instead of weeks

**Lean/Agile principle**: Eliminate waste. This creates massive waste.

### 4. **Perpetuates Knowledge Silos**

This approach:

- Rewards those who "figured it out" (often through painful trial and error)
- Creates an insider/outsider dynamic
- Makes knowledge a source of power/status
- Punishes newcomers

**Agile principle**: Cross-functional, collaborative teams. This does the opposite.

---

## Why Teams Might Do This (And Why They're Wrong)

### Excuse #1: "Developers Should Be Self-Organizing"

**What they think**: "Agile teams are self-organizing, so developers should figure things out."

**Why this is wrong**:

- **Self-organizing ≠ isolated guessing**
- Self-organizing means the team decides **how** to work, not that they must discover **secret rules**
- Self-organization requires **information transparency**, not information hiding

**What real self-organization looks like**:

- Team has access to all necessary information
- Team decides together how to approach work
- Team creates their own working agreements
- Team adapts practices based on outcomes

### Excuse #2: "It Builds Resilience/Initiative"

**What they think**: "Struggling to find processes builds character and makes developers more resourceful."

**Why this is wrong**:

- This is hazing, not professional development
- **Wasted time** ≠ learning valuable skills
- Creates learned helplessness ("don't ask, just figure it out")
- Drives good people away

**What real professional development looks like**:

- Clear onboarding with documentation
- Mentorship and pairing
- Gradual increase in responsibility
- Learning through doing real work, not archeology

### Excuse #3: "Documentation Is Overhead"

**What they think**: "Agile values working software over documentation, so we don't document processes."

**Why this is wrong**:

- The manifesto says "while there is value in the items on the right"—documentation still has value
- **Working software over comprehensive documentation** doesn't mean zero documentation
- Spending weeks trying to figure out undocumented processes is MORE overhead than writing a 2-page guide

**What appropriate documentation looks like**:

- Team working agreements (1 page)
- Architecture decision records (ADRs)
- README files
- Code review guidelines (like you created!)
- "Just enough" to enable the team

### Excuse #4: "Processes Evolve, Hard to Document"

**What they think**: "Our processes change, so documenting is futile."

**Why this is wrong**:

- If processes evolve, document the current state
- Update documentation when processes change (like living code)
- Use lightweight formats (wikis, markdown)
- **Evolving processes need MORE documentation**, not less—how else does everyone stay aligned?

---

## What This Actually Is

Let's call this what it is:

### **Organizational Dysfunction Masquerading as Agile**

This pattern indicates:

**🚩 Poor Leadership**

- Leaders haven't clarified expectations
- Leaders don't understand Agile principles
- Leaders confuse "self-organization" with "sink or swim"

**🚩 Toxic Culture**

- Information hoarding
- "Figure it out yourself" mentality
- No psychological safety
- Trial by fire onboarding

**🚩 Failed Knowledge Management**

- No documentation practices
- Tribal knowledge is accepted/encouraged
- No investment in team infrastructure

**🚩 Misunderstanding of Agile**

- "Agile means no documentation" (wrong)
- "Agile means no process" (wrong)
- "Agile means every person for themselves" (completely wrong)

---

## Real-World Consequences

### For Developers:

- ❌ **Weeks/months of confusion** trying to understand "how things work"
- ❌ **Fear of making mistakes** (will I violate some unwritten rule?)
- ❌ **Imposter syndrome** ("Everyone else seems to know, what's wrong with me?")
- ❌ **Wasted time** that could be spent delivering value
- ❌ **Burnout** from constant uncertainty

### For The Team:

- ❌ **Inconsistent practices** (everyone interprets implicit rules differently)
- ❌ **Slower delivery** (time wasted on process archaeology)
- ❌ **Quality issues** (people don't know the standards)
- ❌ **High turnover** (good developers leave)
- ❌ **Can't scale** (every new person repeats the same struggle)

### For The Company:

- ❌ **Expensive onboarding** (takes months to get productive)
- ❌ **Lost productivity** (developers reinventing wheels)
- ❌ **Knowledge loss** when people leave
- ❌ **Competitive disadvantage** (slower than companies with clear processes)

---

## What ACTUAL Agile Looks Like

### Scenario: New Developer Joins

**❌ Anti-Agile (Your Company)**:

- "Here's your laptop. The codebase is in GitHub. Figure out how we work."
- Developer spends weeks asking "Is this how we do X?" and getting vague answers
- Makes mistakes, gets corrected: "We don't do it that way"
- Eventually pieces together implicit processes through trial and error

**✅ Agile (Functional Teams)**:

- **Day 1**: "Here's our team working agreement, our definition of done, and our code review guidelines"
- **Pairing**: New dev pairs with experienced dev for first few tickets
- **Living documentation**: Team wiki with architecture decisions, common patterns
- **Transparent**: All processes visible and discussable
- **Week 1**: New dev is contributing (with support)
- **Month 1**: New dev is productive and knows how to find answers

### Scenario: Process Needs to Change

**❌ Anti-Agile**:

- Process changes happen implicitly
- Some developers follow old pattern, some follow new
- Confusion and inconsistency
- No one knows what the "current" process is

**✅ Agile**:

- Team discusses in retrospective: "Our current deployment process causes delays"
- Team agrees on new process together
- Team updates documentation
- Everyone follows new process
- Team reviews in next retro: "Is the new process working?"

---

## What You Should Do

If you're in this situation, here's how to address it:

### 1. **Surface the Problem (Tactfully)**

In a retrospective:

> "I've noticed we have some implicit processes that aren't documented. I've spent [X hours/days] trying to figure out [specific process]. Could we document our key processes so everyone has clarity?"

Or in a one-on-one with your Scrum Master:

> "I want to be effective quickly, but I'm struggling to understand how we do things here. Could we create some lightweight documentation for common processes?"

### 2. **Start Documenting (Be the Change)**

You don't need permission to help:

- Create a team wiki page: "How We Work"
- Document as you discover: "Here's what I learned about our deployment process"
- Share in team chat: "I documented the code review process—feedback welcome!"
- Over time, build a knowledge base

**This is very Agile**: Taking initiative, collaborating, creating transparency.

### 3. **Propose Team Working Agreements**

In a retrospective, suggest creating explicit agreements:

- "What are our must-follow practices?"
- "What does 'done' mean for our team?"
- "What are our code quality standards?"

Write them down (1-2 pages max). Review quarterly.

### 4. **Question the "Figure It Out" Culture**

If someone says "you should figure it out":

> "I'm happy to be resourceful, but I want to make sure I'm learning the right patterns. Could you point me to where this is documented, or could we document it together?"

This is assertive but collaborative.

### 5. **Escalate If Necessary**

If the team/leadership refuses to provide clarity:

- Talk to your manager: "I'm struggling to be effective because processes aren't documented"
- Talk to Scrum Master: "This violates Scrum's transparency pillar"
- Consider if this is the right team/company for you (seriously—this is a red flag)

---

## What Leadership SHOULD Do

If you're in a leadership position:

### **Immediate Actions**:

1. **Acknowledge the problem**: "We haven't been clear about our processes. That's on us."
2. **Create lightweight documentation**: Working agreements, definition of done, key processes
3. **Make information accessible**: Team wiki, shared docs, onboarding guide
4. **Assign mentors**: Pair new developers with experienced ones
5. **Review in retrospectives**: "Is our documentation helping? What's missing?"

### **Cultural Shift**:

- **From**: "Figure it out" mentality
    
- **To**: "We help each other succeed" mentality
    
- **From**: Information hoarding
    
- **To**: Information sharing
    
- **From**: Implicit tribal knowledge
    
- **To**: Explicit, improvable practices
    

---

## Uncle Bob's Perspective

Uncle Bob would call this **unprofessional**:

> "Professionals have explicit standards. Professionals document their practices. Professionals don't make newcomers guess at standards through trial and error. That's not 'Agile self-organization'—that's organizational negligence."

He'd argue:

- **Professionalism requires clarity**
- **Craftsmanship requires shared standards**
- **Teams need explicit definitions of quality**
- **'Figure it out' is hazing, not mentorship**

---

## The Bottom Line

**Making developers "find out" implicit processes is:**

- ❌ Not Agile
- ❌ Not professional
- ❌ Not effective
- ❌ Not sustainable
- ✅ A sign of organizational dysfunction

**Real Agile practices:**

- ✅ Transparent processes
- ✅ Lightweight documentation
- ✅ Collaborative knowledge sharing
- ✅ Continuous improvement of explicit practices
- ✅ Psychological safety to ask questions

**Your next step**: In your next retrospective, raise this issue. If your team values Agile principles, they'll recognize the problem and work to fix it. If they don't, that tells you something important about the organization.

Remember: **Agile is about collaboration, transparency, and continuous improvement—not archaeology and guesswork.**


# When a relatively small company gets acquired by another company, we sometimes hear people tell Scrum team "hey here at the hosting company" we do thing like this. How can this unsynchronized approaches be better incorporated into agile practice?
This is a **classic post-acquisition challenge** that tests whether both companies truly understand Agile principles. The tension is between standardization (efficiency, consistency) and team autonomy (agility, context-specific practices).

Here's how to handle this in a genuinely Agile way:

---

## The Core Problem

**What's happening:**

- Acquired company (you): Has working practices, team autonomy, established rhythms
- Acquiring company: Has their own practices, wants consistency across teams
- Result: "Do it our way" mandate that ignores context

**Why this feels wrong:**

- Violates **team self-organization** (Agile principle)
- Assumes one-size-fits-all (ignores context)
- Top-down imposition (not collaborative)
- May break what's already working

**But there's nuance:**

- Some standardization makes sense (security, legal, infrastructure)
- Completely independent teams create chaos at scale
- The acquiring company has reasons for their practices (even if not always good ones)

---

## The Agile Approach: Principled Integration

### 1. **Distinguish Types of "Alignment"**

Not all standards are created equal. Categorize them:

#### **A. Non-Negotiable (Legal/Safety/Security)**

These you **must** adopt:

- Security protocols (authentication, data handling)
- Legal compliance (GDPR, SOX, industry regulations)
- Financial/audit requirements
- Critical infrastructure (company-wide tools, SSO, etc.)

**Agile response**: "We understand these are mandatory. Help us implement them effectively for our context."

#### **B. Enabling Standards (Makes Life Better)**

These create genuine value:

- Shared CI/CD pipelines (faster deployments)
- Common monitoring/observability tools (easier support)
- Unified authentication (better user experience)
- Shared design system (consistent UI)

**Agile response**: "We see the value. Let's adopt these but adapt implementation to our needs."

#### **C. Process/Ceremony (Questionable Value)**

These might be cargo cult:

- "You must use Jira configured exactly this way"
- "All teams must have 2-week sprints" (even if 1-week works for you)
- "You must follow our exact meeting structure"
- "Use our code review template" (even if yours is better)

**Agile response**: "Help us understand the principle behind this. Can we achieve the same goal differently?"

#### **D. Preferences/Politics (No Real Value)**

Pure "that's how we do it here":

- "We use Angular, you must migrate from React"
- "We name branches feature/X, not feat/X"
- "Our standup is at 9am, yours must be too"

**Agile response**: "What problem does this solve? Is there room for team autonomy here?"

---

## 2. **Use Agile Principles as Negotiation Framework**

When told "do it our way," respond with Agile values:

### **Framework for Conversation:**

```
Them: "Here at [Company], we do [X]"

You: "Thanks for sharing. Help me understand:
1. What problem does [X] solve?
2. Is this legally required, enabling, or preference?
3. Is there flexibility in how we implement it?
4. What outcomes are you optimizing for?"
```

This shifts from **compliance** to **collaboration**.

### **Example Dialogue:**

**Scenario**: "All teams must use Jira with our workflow template"

**❌ Poor Response**:

- "That won't work for us" (defensive, no collaboration)
- "Whatever you say" (passive, resentment builds)

**✅ Agile Response**:

```
"Help us understand:
- What problem does standardizing Jira solve? 
  (Cross-team visibility? Reporting? Portfolio management?)
- We currently use [tool] effectively. Could we:
  - Keep our tool but integrate with your reporting?
  - Use Jira but adapt the workflow to our context?
  - Pilot Jira for one sprint and evaluate?

Our goal is to maintain velocity while meeting your 
needs for visibility/consistency. How can we achieve both?"
```

This is **collaborative problem-solving**, not defiance.

---

## 3. **Propose an Integration Model**

Rather than accept or reject wholesale, propose a **principled integration approach**:

### **The "Inspect and Adapt" Integration Model**

**Phase 1: Understanding (Sprint 0)**

- Document both companies' practices
- Identify overlaps, conflicts, and gaps
- Categorize: mandatory, enabling, negotiable, preference
- Hold joint workshops (not mandates)

**Phase 2: Experimentation (2-3 Sprints)**

- Pilot hosting company practices where they add value
- Keep your practices where they work better
- Run both in parallel where feasible
- Measure outcomes (velocity, quality, satisfaction)

**Phase 3: Adaptation (Ongoing)**

- Retrospectives to evaluate what's working
- Create hybrid approaches where beneficial
- Standardize on what genuinely helps
- Maintain team autonomy where context matters

### **Example: Code Review Standards**

Your company has a great code review checklist (the one we created!). Hosting company says "use our process."

**Agile Integration**:

```
Sprint 1-2: 
- Review both checklists side-by-side
- Identify best practices from each
- Create merged checklist with best of both
- Try it for 2 sprints

Sprint 3:
- Retrospective: What's working? What's not?
- Refine the merged approach
- Share with other teams (maybe they learn from you!)

Result: Better than either original, co-created
```

---

## 4. **Build Alliances and Show Results**

### **Find Champions in Hosting Company**

Not everyone at the acquiring company is rigid. Find:

- Agile coaches who understand principles over practices
- Engineering leaders open to learning
- Teams who also chafe at rigid standards

**Strategy**: "We'd love to share what's worked for us. Could we do a show-and-tell?"

### **Demonstrate Value Through Outcomes**

Actions speak louder than arguments:

**Instead of**: "Our way is better"

**Do this**:

- Continue delivering at high velocity
- Maintain quality metrics
- Show team satisfaction scores
- Share innovations with other teams

**Then**: "We've maintained our delivery pace using [practice]. Here's our data. Would other teams benefit from trying this?"

### **Offer to Experiment**

**Proposal**:

> "We appreciate the hosting company's practices. Could our team be a pilot for trying hybrid approaches? We'll:
> 
> - Adopt [mandatory standards]
> - Experiment with [your suggestion] for integration
> - Share learnings with other teams
> - Measure outcomes objectively
> 
> This helps everyone learn what works best."

This positions you as **collaborative innovators**, not resisters.

---

## 5. **Escalate Constructively When Needed**

If you face rigid "just do it our way" mandates:

### **Escalation Path:**

**Step 1: Team Level**

- Raise in retrospective
- Document impact on velocity/morale
- Propose alternatives

**Step 2: Scrum Master / Agile Coach**

- "This violates team self-organization principle"
- "We're seeing negative impacts on [metric]"
- "Can you help us navigate this?"

**Step 3: Engineering Leadership**

- Present data: "Since adopting [practice], our velocity dropped X%, quality issues increased Y%"
- Propose: "Could we try [alternative] for one quarter?"
- Frame as: "How can we maintain our strengths while integrating?"

**Step 4: Appeal to Agile Principles**

```
"The Agile Manifesto values:
- Individuals and interactions over processes and tools
- Responding to change over following a plan
- Customer collaboration over contract negotiation

We want to be good corporate citizens, but we also want 
to maintain the agility that made our product successful. 
How can we balance these?"
```

---

## 6. **Know When to Adapt vs. When to Hold Ground**

### **Adapt When:**

- ✅ It's legally required
- ✅ It genuinely improves collaboration
- ✅ It solves a real problem you have
- ✅ The cost of fighting exceeds the cost of adapting
- ✅ You can adapt implementation to your context

### **Hold Ground When:**

- 🛑 It will significantly harm delivery
- 🛑 It violates core Agile principles for no good reason
- 🛑 It's pure preference/politics with no business value
- 🛑 Your approach is demonstrably better
- 🛑 It destroys team morale and autonomy

**But always frame as**: "Help us find a solution that works for everyone," not "we refuse."

---

## 7. **Create Team Working Agreements Explicitly**

Post-acquisition is the perfect time to make implicit → explicit:

### **Working Agreement Workshop**

Bring together teams from both companies:

**Agenda**:

1. Share: "Here's what worked for us"
2. Share: "Here's what worked for you"
3. Discuss: "What problems are we solving?"
4. Co-create: "What standards serve us all?"
5. Document: Explicit, improvable agreements
6. Review: Quarterly retrospectives

**Output**: A **negotiated, explicit, team-owned** set of practices, not a mandate.

This is **textbook Agile**: collaboration, transparency, continuous improvement.

---

## Real-World Examples

### **Example 1: Sprint Length**

**Situation**: Your team uses 1-week sprints (high cadence, fast feedback). Hosting company mandates 2-week sprints for "consistency."

**❌ Poor Response**:

- Just switch (lose your advantage)
- Refuse (create conflict)

**✅ Agile Response**:

```
"We understand you want consistency. Help us understand:
- Why 2 weeks? (Reporting? Coordination?)
- What if we keep 1-week sprints but report biweekly?
- Could we run a 3-month experiment and compare outcomes?

Our 1-week sprints give us competitive advantage in 
[metric]. Can we maintain this while meeting your needs?"
```

**Possible Outcomes**:

- Option A: You keep 1-week sprints, align reporting
- Option B: Hybrid: 2-week sprints with mid-sprint check-ins
- Option C: Demonstrate value, other teams adopt 1-week
- Option D: You adapt to 2-week, but negotiate other flexibility

### **Example 2: Code Review Process**

**Situation**: Your team has rigorous code review (your checklist!). Hosting company has minimal reviews ("we trust developers").

**Agile Response**:

```
"We've found thorough code reviews catch issues early and 
share knowledge. Here are our metrics [quality, bugs caught].

Could we:
- Share our approach with other teams?
- Keep our reviews but adapt to your tooling?
- Run a joint workshop on code quality?"
```

**Outcome**: You might **teach** the hosting company, not the other way around.

### **Example 3: Technology Stack**

**Situation**: You use Angular 19. Hosting company uses Angular 15. They say "standardize on 15."

**Agile Response**:

```
"We understand standardization benefits. However:
- Angular 19 gives us [performance/features]
- Downgrading would cost [X] weeks and lose [Y]
- Angular 15 is nearing end-of-support

Could we instead:
- Stay on 19, share learnings for upgrades?
- Help host company plan 15→19 migration?
- Create upgrade guide for all teams?"
```

**Outcome**: Host company might follow your lead (especially if 15 is obsolete soon).

---

## 8. **The Cultural Integration Challenge**

This isn't just about practices—it's about **culture**.

### **Two Cultural Extremes:**

**Rigid Standardization Culture**:

- "One way to do everything"
- Top-down mandates
- Efficiency through uniformity
- Risk-averse

**Extreme Autonomy Culture**:

- "Every team does their own thing"
- Zero standardization
- Innovation through diversity
- Chaos at scale

**Healthy Agile Culture (Target)**:

- **Aligned on principles, flexible on practices**
- **Standardize what matters, autonomy where context matters**
- **Continuous improvement through experimentation**
- **Balance efficiency and innovation**

### **Your Role: Bridge Builder**

You can help create this healthy middle ground:

- Show hosting company the value of team autonomy
- Show your team the value of some standardization
- Be the example of principled, collaborative integration

---

## 9. **What Great Acquisitions Do**

Companies that integrate acquisitions well using Agile principles:

### **Amazon's "Two-Pizza Teams"**

- Maintain team autonomy
- Standardize on **mechanisms** (APIs, data formats)
- Freedom in **implementation**

### **Atlassian's "Team Playbook"**

- Shared practices library (not mandates)
- Teams choose what works for them
- Continuous contribution from all teams

### **Spotify's "Squads Model"** (before it became cargo cult):

- Squads (teams) have autonomy
- Chapters/guilds share practices
- Alignment on principles, not processes

**Common theme**: **Principle-based alignment, not practice-based compliance.**

---

## 10. **Your Action Plan**

Here's what to do starting Monday:

### **Week 1: Assess**

- [ ] List all "do it our way" mandates you've received
- [ ] Categorize: Mandatory / Enabling / Negotiable / Preference
- [ ] Document current practices and their outcomes
- [ ] Identify which hosting company practices might actually help

### **Week 2: Engage**

- [ ] Schedule meeting with hosting company Agile coach/leadership
- [ ] Frame as: "How can we integrate while maintaining velocity?"
- [ ] Propose pilot/experiment approach
- [ ] Share your successful practices (like code review checklist)

### **Week 3: Negotiate**

- [ ] For mandatory items: "How can we implement effectively?"
- [ ] For enabling items: "Let's adopt, with context-appropriate implementation"
- [ ] For negotiable items: "Can we experiment and measure?"
- [ ] For preferences: "Can we maintain team autonomy here?"

### **Ongoing: Demonstrate**

- [ ] Continue delivering value at high velocity
- [ ] Share metrics showing your approaches work
- [ ] Collaborate generously with other teams
- [ ] Be open to learning from hosting company
- [ ] Run retrospectives on integration itself

---

## The Bottom Line

**The situation**: Post-acquisition "do it our way" mandates

**The anti-Agile response**:

- Blindly comply (lose your strengths)
- Rigidly resist (create conflict)

**The Agile response**:

- ✅ **Understand the "why"** behind standards
- ✅ **Distinguish** mandatory from negotiable
- ✅ **Collaborate** to find hybrid approaches
- ✅ **Experiment** and measure outcomes
- ✅ **Maintain** team autonomy where context matters
- ✅ **Standardize** what genuinely enables
- ✅ **Demonstrate** value through results
- ✅ **Continuous improvement** through retrospectives

**Remember**: Agile isn't about refusing standards—it's about **principle-driven, context-aware, collaborative** creation of practices that serve actual goals.

**Your opportunity**: This acquisition could make both companies better if approached with genuine Agile principles. Be the bridge builder who shows how.

**Quote to remember**:

> "The Agile Manifesto says 'individuals and interactions over processes and tools'—let's have real interactions about which processes and tools serve us best, rather than mandates."

Good luck. You're in a position to demonstrate what Agile really means. 🤝

# Who should do the principle integration? Should individual scrum team do it alone or even individual scrum team member do it?
**Excellent question.** This gets to the heart of organizational dynamics and Agile at scale.

**Short answer**: No, individual Scrum teams or team members **should not** do this alone. This is an **organizational-level challenge** requiring **cross-level collaboration**.

Here's why and who should do what:

---

## Why Teams/Individuals Shouldn't Do This Alone

### 1. **Wrong Level of Authority**

**Problem**: Individual teams lack:

- Authority to negotiate company-wide standards
- Visibility into broader organizational needs
- Context on why acquiring company does things their way
- Power to make binding decisions

**Result**:

- Teams spend energy fighting battles they can't win
- Inconsistent approaches across teams (some comply, some resist)
- Frustration and wasted time
- Possible career consequences for individuals who push back

### 2. **Coordination Problem**

If each team negotiates individually:

- ❌ 10 teams → 10 different conversations → 10 different outcomes
- ❌ Acquiring company gets frustrated: "Why can't you just align?"
- ❌ No collective voice or leverage
- ❌ Duplication of effort (every team researches same issues)
- ❌ Some teams get exceptions, others don't (unfairness)

### 3. **Asymmetric Power**

**Reality**: The acquiring company has more power:

- They control budgets, resources, decisions
- They can impose mandates
- Individual teams have little leverage

**Single team pushing back** = "difficult team" **Coordinated organizational discussion** = "legitimate negotiation"

### 4. **Burnout and Distraction**

If teams/individuals take this on:

- Massive distraction from actual work (building product)
- Emotional toll of constant pushback
- Developer burnout fighting organizational battles
- Loss of focus on delivering value

**Developers should code, not play corporate politics.**

---

## Who SHOULD Handle This

### **Multi-Level Approach** (Required)

Integration requires coordinated action at **four levels**:

---

### **Level 1: Engineering Leadership** (Primary Driver)

**Who**: VPs, Directors, Engineering Managers from both companies

**Their Role**:

- **Negotiate high-level alignment** between companies
- **Protect team autonomy** where appropriate
- **Make decisions** on mandatory vs. negotiable standards
- **Communicate clearly** to all teams
- **Provide air cover** for teams during transition

**What They Should Do**:

#### A. Create Integration Working Group

```
Members:
- Engineering leaders from both companies
- Agile coaches
- Architect(s)
- Product leadership
- Operations/DevOps leads

Charter:
- Define integration principles
- Categorize standards (mandatory/enabling/negotiable)
- Create timeline and approach
- Empower teams with clear guidance
```

#### B. Communicate Clear Framework

```
To all teams:

"Here's what's mandatory (and why):
- [Security standards] - legal requirement
- [SSO migration] - user experience
- [Infrastructure] - cost/scale

Here's what we're standardizing (benefits):
- [CI/CD platform] - faster deployments
- [Observability tools] - better support

Here's where teams have autonomy:
- Sprint length (within reason)
- Internal tooling choices
- Team processes (with alignment on outcomes)

Here's the process for questions/exceptions:
- [Point of contact]
- [Decision framework]
- [Timeline for experimentation]"
```

#### C. Shield Teams from Whiplash

```
❌ Don't: "Team A, comply with all 47 standards by next sprint"

✅ Do: "We're phasing integration over 6 months:
- Q1: Mandatory security/infrastructure
- Q2: Enabling standards (CI/CD, monitoring)
- Q3: Process alignment (with team input)
- Ongoing: Retrospectives and adjustment"
```

---

### **Level 2: Agile Coaches / Scrum Masters** (Facilitators)

**Who**: Agile coaches, Scrum Masters from both companies

**Their Role**:

- **Facilitate conversations** between teams and leadership
- **Surface impediments** created by integration conflicts
- **Protect Agile principles** in integration process
- **Coach leadership** on Agile approaches to change
- **Help teams navigate** change productively

**What They Should Do**:

#### A. Create Safe Communication Channels

```
- Hold "integration retrospectives" with all Scrum Masters
- Aggregate team concerns/feedback
- Present patterns to leadership
- Ensure team voices are heard
```

#### B. Coach Leadership

```
To leadership: "Mandating practices without input violates 
self-organization. Let's create a collaborative process."

To teams: "Here's how to engage constructively rather than 
resist reflexively."
```

#### C. Design Integration Process

```
Not: "Here are new rules, follow them"

Instead: "Here's a 3-sprint pilot. We'll retrospect and adjust."
```

#### D. Facilitate Cross-Company Communities

```
- Set up "Community of Practice" groups
- Code review standards group
- Testing practices group  
- Architecture group

These groups co-create standards, not receive mandates.
```

---

### **Level 3: Scrum Teams** (Implementers & Feedback Providers)

**Who**: The actual development teams

**Their Role**:

- **Implement** integration decisions
- **Provide feedback** on what's working/not working
- **Experiment** with new approaches
- **Maintain delivery** during transition
- **Contribute** to Communities of Practice

**What Teams SHOULD Do**:

#### A. Focus on Delivery First

```
❌ Don't: Spend 50% of sprint fighting standards
✅ Do: Implement clear mandates, flag unclear ones via proper channels
```

#### B. Provide Data-Driven Feedback

```
❌ Don't: "This new process sucks"
✅ Do: "Since adopting [X], our velocity dropped 20% and bug 
        rate increased 15%. Here's the data. Can we discuss?"
```

#### C. Engage Through Proper Channels

```
Team → Scrum Master → Leadership
Not: Team → Individual complaints → Resentment
```

#### D. Participate in Communities of Practice

```
If invited to code review standards group:
- Share what works for your team
- Learn from other teams
- Co-create solutions
- Don't just defend your way
```

#### E. Run Integration Retrospectives

```
Retrospective question: "How is the integration affecting us?"
- What's working well?
- What's blocking us?
- What do we need from leadership?

Scrum Master escalates patterns to leadership.
```

**What Teams Should NOT Do**:

❌ **Negotiate individually** with acquiring company ❌ **Ignore mandates** without proper escalation ❌ **Fight battles** that leadership should handle ❌ **Suffer in silence** (speak up through channels) ❌ **Create exceptions** without coordination

---

### **Level 4: Individual Developers** (Focus on Craft)

**Who**: Individual team members

**Their Role**:

- **Focus on building great software**
- **Provide input** when asked
- **Flag issues** to their team/Scrum Master
- **Stay professional** during transition
- **Trust** the process (if one exists)

**What Individuals Should Do**:

#### A. Voice Concerns Constructively

```
In team retrospective: "The new code review process adds 
2 hours per PR. Can we discuss?"

To Scrum Master: "I'm confused about [standard]. Can you help clarify?"
```

#### B. Participate When Invited

```
If asked to join working group or Community of Practice:
- Share your expertise
- Be collaborative
- Focus on solving problems, not winning arguments
```

#### C. Document and Share

```
"I figured out how to use [new tool] effectively. Here's a guide."
This helps everyone adapt faster.
```

#### D. Maintain Professionalism

```
❌ Don't: Complain constantly, resist everything, become toxic
✅ Do: Voice concerns constructively, suggest solutions, focus on work
```

**What Individuals Should NOT Do**:

❌ **Take on organizational change alone** (burnout path) ❌ **Become the "resistance fighter"** (career limiting) ❌ **Bypass team processes** to complain to upper management ❌ **Quit without giving leadership a chance** to address issues

---

## The Proper Integration Process

Here's what a **well-run integration** looks like:

### **Phase 0: Leadership Alignment (Week 1-2)**

**Engineering leaders from both companies meet**:

```
1. Understand each other's context
   - Why do we do things this way?
   - What problems do our practices solve?
   - What are we optimizing for?

2. Define integration principles
   - Maintain velocity during transition
   - Respect what's working well
   - Standardize where it genuinely helps
   - Allow experimentation and adaptation

3. Create framework
   - Mandatory standards (with rationale)
   - Enabling standards (with flexibility)
   - Negotiable areas (team autonomy)
   - Process for exceptions/questions

4. Form working groups
   - Cross-company representation
   - Clear charters and timelines
   - Authority to make recommendations
```

### **Phase 1: Discovery & Communication (Week 3-4)**

**Agile coaches facilitate**:

```
1. All-hands meetings
   - Share integration framework
   - Answer questions
   - Set expectations

2. Team listening sessions
   - What are your concerns?
   - What works well for you now?
   - What do you need from us?

3. Document current state
   - Both companies' practices
   - Rationale for each
   - Data on effectiveness
```

### **Phase 2: Co-Creation (Month 2-3)**

**Communities of Practice work**:

```
Code Review Standards Group:
- 2 developers from acquired company
- 2 developers from acquiring company  
- 1 Agile coach (facilitator)
- 1 engineering manager (sponsor)

Process:
1. Share current approaches (your checklist vs. theirs)
2. Identify best practices from each
3. Co-create merged approach
4. Pilot with 2-3 teams for 2 sprints
5. Gather feedback
6. Refine and recommend

Output: "Here's the standard we recommend and why"
```

### **Phase 3: Piloting (Month 3-4)**

**Selected teams experiment**:

```
- 2-3 teams pilot new integrated approaches
- Daily/weekly feedback loops
- Scrum Masters coordinate and support
- Adjustment as needed
- Measurement: velocity, quality, satisfaction
```

### **Phase 4: Rollout (Month 5-6)**

**Gradual adoption**:

```
- Share pilot results with all teams
- Phase rollout (not big bang)
- Training and support provided
- Continued feedback and adjustment
- Retrospectives at team and org level
```

### **Phase 5: Continuous Improvement (Ongoing)**

**Never stop adapting**:

```
- Quarterly integration retrospectives
- Update standards as needed
- Celebrate what's working
- Fix what's not
```

---

## Your Specific Situation: What You Should Do

Based on your role:

### **If You're a Developer on a Team:**

**Do**:

1. ✅ Focus on your work and deliver value
2. ✅ Share concerns in team retrospectives
3. ✅ Participate if invited to working groups
4. ✅ Help teammates adapt to changes
5. ✅ Trust your Scrum Master to escalate issues

**Don't**:

1. ❌ Try to negotiate with acquiring company alone
2. ❌ Take on organizational change as personal mission
3. ❌ Burn yourself out fighting battles above your level
4. ❌ Become toxic or constantly negative

**Your voice matters, but through proper channels.**

### **If You're a Scrum Master:**

**Do**:

1. ✅ Aggregate team concerns and escalate patterns
2. ✅ Shield team from whiplash and confusion
3. ✅ Facilitate integration retrospectives
4. ✅ Coach leadership on Agile integration approaches
5. ✅ Create Communities of Practice
6. ✅ Ensure team voices are heard

**Don't**:

1. ❌ Let teams negotiate individually (coordinate instead)
2. ❌ Accept "just comply" without questioning impact
3. ❌ Stay silent when principles are violated

**You're the bridge between teams and leadership.**

### **If You're in Engineering Leadership:**

**Do**:

1. ✅ Take ownership of integration process
2. ✅ Create clear framework (mandatory/enabling/negotiable)
3. ✅ Form cross-company working groups
4. ✅ Protect team autonomy where appropriate
5. ✅ Communicate clearly and often
6. ✅ Provide air cover during transition

**Don't**:

1. ❌ Push all decisions down to teams
2. ❌ Accept all mandates without negotiation
3. ❌ Let integration happen chaotically

**This is YOUR job, not your teams' job.**

---

## Red Flags: When Integration Is Broken

Watch for these signs that integration is being handled poorly:

🚩 **Individual teams negotiating separately** with acquiring company 🚩 **No clear communication** about what's mandatory vs. negotiable 🚩 **"Just figure it out"** mentality from leadership 🚩 **Constant changing** of requirements without retrospection 🚩 **No forums** for team input or feedback 🚩 **Asymmetric treatment** (some teams get exceptions, others don't) 🚩 **Developers spending** more time on integration than coding 🚩 **Leadership absent** from integration discussions 🚩 **No phased approach** (everything changes at once) 🚩 **Metrics ignored** (no measurement of integration impact)

If you see these, escalate to leadership: **"Our integration process isn't working. Can we discuss a better approach?"**

---

## The Nuclear Option: When to Push Back Hard

Most integration issues can be resolved collaboratively. But if:

- Leadership refuses to engage
- Mandates are clearly harmful (data proves it)
- Agile principles completely abandoned
- Team morale collapsing
- Turnover increasing

**Then leadership needs to hear**:

```
"We're experiencing significant negative impact from 
integration mandates. Here's the data: [velocity, quality, 
satisfaction]. We risk losing key people and delivery capacity.

Can we schedule an urgent discussion about our approach?"
```

This is a **leadership responsibility** to deliver, not individual developers.

---

## The Bottom Line

**Who should do principle integration?**

|Level|Role|Responsibility|
|---|---|---|
|**Engineering Leadership**|**Primary Driver**|Negotiate, decide, communicate, protect|
|**Agile Coaches/SMs**|**Facilitators**|Bridge teams and leadership, design process|
|**Scrum Teams**|**Implementers & Feedback**|Deliver, experiment, provide data|
|**Individual Developers**|**Focus on Craft**|Build software, voice concerns constructively|

**Not**: Individual teams or developers alone **Yes**: Coordinated, multi-level, leadership-driven approach

**Key principle**: **Push decisions up to the appropriate level**

- Teams shouldn't handle organizational change
- Leadership shouldn't ignore team input
- Everyone has a role in their appropriate sphere

**Your immediate action**: If your company hasn't created this structure, raise it:

> "Our integration is happening ad-hoc. Can we create a coordinated approach with clear roles and communication?"

**This is what Agile at scale looks like**: Not chaos, not rigid mandates, but **structured collaboration at appropriate levels**.


# If I am a running back I think the play calling is so poor so I go grab the headset and take over, I am just trying to "go above and beyond", and since I have such a passion for winning, a love for the team, my intension is so good, should I do that?

**Absolutely not.** And this is a **perfect analogy** for what happens in dysfunctional Scrum teams.

Let me break down why this is problematic, both in football and in software teams:

---

## Why the Running Back Shouldn't Call Plays

### 1. **Wrong Role, Wrong Responsibility**

**Football**:

- Running back's job: Execute the play
- Offensive coordinator's job: Call the play
- Each role requires different information, perspective, and authority

**Scrum team equivalent**:

- Developer's job: Build the software
- Product Owner's job: Prioritize what to build
- Scrum Master's job: Facilitate the process

**When you step outside your role**:

- ❌ You abandon your actual responsibilities
- ❌ You undermine the person whose job it is
- ❌ You create confusion about who's responsible for what
- ❌ You don't have the full context/information for that role

### 2. **Good Intentions ≠ Good Outcomes**

**Your motivation might be pure**:

- ✅ Passion for winning
- ✅ Love for the team
- ✅ Desire to help

**But the impact is destructive**:

- ❌ Undermines coach's authority
- ❌ Creates chaos (who's actually in charge?)
- ❌ Other players confused (do we follow RB or coach?)
- ❌ RB doesn't have full information (coach knows the game plan, tendencies, etc.)
- ❌ Sets terrible precedent (now everyone grabs headset when frustrated)

**Agile lesson**: **Impact matters more than intent.**

### 3. **You Don't Have the Full Picture**

**The running back knows**:

- What's happening in his position
- What he's experiencing on the field
- His perspective of the game

**The running back DOESN'T know**:

- Overall game strategy
- What coaches see from booth (full field view)
- Opponent tendencies from film study
- Personnel matchups across all positions
- Time management considerations
- Long-term game plan

**Similarly, a developer might know**:

- Their code and immediate problems
- Technical details
- Their team's situation

**But might not know**:

- Business strategy and market forces
- Customer research and feedback
- Budget and resource constraints
- Legal/compliance requirements
- Cross-team dependencies
- Executive commitments

**Making decisions without full context = bad decisions.**

### 4. **Breaks Team Structure**

**What happens when RB grabs headset**:

- Quarterback confused: "Who do I listen to?"
- Offensive line confused: "What protection scheme?"
- Coach's authority eroded
- Team cohesion breaks down
- Everyone starts freelancing

**Scrum equivalent**: When a developer starts:

- Reprioritizing backlog (PO's job)
- Changing team processes (should be team decision)
- Negotiating with stakeholders directly (PO's job)
- "Managing" other developers (no managers in Scrum)

**Result**: Chaos, confusion, breakdown of trust.

---

## What the Running Back SHOULD Do

### **Option 1: Provide Input Through Proper Channels**

**Football**:

```
After drive: "Coach, I'm seeing the safety bite on play-action. 
We could exploit that with [specific play]."

At halftime: "Their linebacker is overpursuing. I think 
cutback runs would work."

During timeout: "I'm getting hit before the line. We need 
better blocking or different plays."
```

**This is**:

- ✅ Sharing valuable field-level information
- ✅ Respecting roles and authority
- ✅ Collaborative problem-solving
- ✅ Influencing without overstepping

**Scrum equivalent**:

```
Sprint Planning: "Based on last sprint, I think we should 
prioritize the API work before the UI."

Retrospective: "Our deployment process is slowing us down. 
Can we address this?"

To PO in 1-on-1: "I'm hearing customer pain points about 
[feature]. Should we consider prioritizing it?"
```

### **Option 2: Request a Timeout/Meeting**

**Football**:

```
To coach: "Can we talk about the game plan? I have concerns."

Or through captain: "Team needs to discuss play calling."
```

**Scrum equivalent**:

```
"Can we schedule time to discuss sprint planning approach? 
I have ideas to share."

Or in retrospective: "I think our prioritization process 
needs discussion."
```

### **Option 3: Execute Brilliantly in Your Role**

**Football**:

```
Even with "bad" play calls, run them as well as possible.
Make the play work through excellence in execution.
Then you earn credibility to influence future calls.
```

**Scrum equivalent**:

```
Even with questionable priorities, deliver high-quality work.
Build trust through excellent execution.
Then your input carries more weight.
```

### **Option 4: Build Trust to Expand Influence**

**Football**:

```
Consistently execute well → Coach trusts your input
→ "What do you see out there?"
→ Running back becomes advisor, not usurper
```

**Scrum equivalent**:

```
Consistently deliver value → Earn trust and credibility
→ Your voice matters in planning
→ Invited into strategic discussions
```

---

## When Grabbing the Headset IS Appropriate

**There ARE rare situations**:

### **Emergency/Crisis**

**Football**: Coach collapses, coordinator unconscious, literally no one else can call plays.

**Scrum**: Product Owner quits suddenly, customer emergency, someone must step up temporarily.

**Key**: This is **crisis response**, not normal operation.

### **Explicitly Asked**

**Football**: "RB, you're seeing something I'm not. What do you think we should call?"

**Scrum**: "Developer, you're closest to this. What do you recommend we prioritize?"

**Key**: You were **invited** into that role.

### **Team Agreement**

**Football**: Team has agreed RB has input on certain situations.

**Scrum**: Team working agreements explicitly give developers input on prioritization (healthy teams do this).

**Key**: It's **agreed process**, not freelancing.

---

## The Real Problem: Why Do You Want the Headset?

**If you're tempted to grab the headset, ask**:

### **Is the play calling actually poor?**

- Or do you just disagree?
- Do you have information the coach doesn't?
- Are results actually bad, or just not what you'd choose?

**Often**: We assume our perspective is complete when it's not.

### **Have you communicated your concerns?**

- Did you tell the coach what you're seeing?
- Did you escalate through proper channels?
- Or did you jump straight to takeover?

**Often**: We haven't actually tried to influence properly first.

### **Are you suited for that role?**

- Do you have the skills/knowledge?
- Do you have the full context?
- Do you have the time (while also playing RB)?

**Often**: We overestimate our readiness for roles we don't fully understand.

### **Is this about ego?**

- "I know better than the coach"
- "I should be calling plays"
- "I'm the smartest person here"

**Often**: It's about wanting control or recognition, not genuinely helping.

---

## Real-World Scrum Scenarios

### **Scenario 1: Developer Reprioritizes Backlog**

**Situation**: Developer thinks PO is prioritizing wrong, starts working on different items.

**Why it's like grabbing the headset**:

- Developer doesn't see: customer commitments, business strategy, market timing
- Undermines PO authority
- Creates confusion (rest of team following plan, one person freelancing)
- Breaks Sprint Goal coherence

**Better approach**:

```
Sprint Planning: "I think [other item] is higher priority 
because [technical reason]. Can we discuss?"

Or to PO: "Help me understand why we're prioritizing X over Y? 
I see risks with this order."
```

### **Scenario 2: Developer Changes Team Process**

**Situation**: Developer thinks daily standup is wasteful, stops attending or changes format unilaterally.

**Why it's problematic**:

- Process changes should be team decisions
- One person's action affects whole team
- Creates precedent for everyone to freelance
- Breaks team agreements

**Better approach**:

```
Retrospective: "I find standups aren't valuable for [reason]. 
Can we experiment with [alternative]?"

Team discussion: "What if we tried async standups for 2 weeks?"
```

### **Scenario 3: Developer Negotiates with Stakeholders**

**Situation**: Stakeholder asks developer for feature, developer commits without PO.

**Why it's problematic**:

- PO doesn't know about commitment
- Might conflict with roadmap
- Stakeholder bypasses proper channels
- Creates hidden work

**Better approach**:

```
To stakeholder: "That's interesting. Let me connect you with 
our Product Owner to discuss prioritization."

To PO: "Stakeholder X mentioned wanting [feature]. Should 
we add it to backlog for consideration?"
```

---

## The Core Scrum Principle

**Scrum is built on clear roles and responsibilities**:

### **Product Owner**

- **What** to build (prioritization)
- **Why** we're building it (value, goals)
- **When** it's done (accepting work)

### **Developers**

- **How** to build it (technical decisions)
- **Who** does what (self-organizing)
- **Delivering** working software

### **Scrum Master**

- **Facilitating** the process
- **Removing** impediments
- **Coaching** the team

**When everyone respects these boundaries**:

- ✅ Clear accountability
- ✅ Right people making right decisions
- ✅ Efficient decision-making
- ✅ Trust and collaboration

**When people cross boundaries**:

- ❌ Confusion and conflict
- ❌ Duplicated effort
- ❌ Poor decisions (missing context)
- ❌ Eroded trust

---

## The Maturity Curve

### **Immature Response**: "Play calling sucks, I'll fix it myself"

- Grabs headset
- Creates chaos
- Gets benched

### **Developing Response**: "Play calling sucks, I'll complain loudly"

- Doesn't grab headset, but undermines coach
- Creates negativity
- Loses trust

### **Mature Response**: "I see issues, let me contribute constructively"

- Shares observations: "I'm seeing X"
- Asks questions: "What are you seeing that I'm not?"
- Offers input: "Have you considered Y?"
- Executes excellently regardless
- Builds trust and influence over time

### **Wise Response**: "Maybe I don't have the full picture"

- Assumes coach has good reasons
- Seeks to understand strategy
- Provides field-level input
- Trusts the process while staying engaged
- **And if truly convinced it's wrong, escalates properly**

---

## When the Play Calling IS Actually Bad

**Sometimes the coach really is making bad calls. Then what?**

### **Escalation Path**:

1. **Communicate directly**: "Coach, I'm seeing [issue]. Can we discuss?"
    
2. **Provide evidence**: "We've tried [play] 5 times, lost yards every time. What if we try [alternative]?"
    
3. **Escalate to captain/team**: "Team, are others seeing this? Should we address it?"
    
4. **Go to higher authority**: Talk to head coach, GM (in Scrum: talk to leadership about dysfunction)
    
5. **Accept or leave**: If nothing changes and you're truly convinced it's wrong, you can:
    
    - Accept it (sometimes you're wrong)
    - Request a trade (leave the team)

**What you DON'T do**: Mutiny by grabbing the headset.

### **Scrum Equivalent**:

If PO is truly making bad prioritization decisions:

1. **Discuss with PO**: Share your concerns, understand their reasoning
2. **Provide data**: "This approach is causing [measurable problem]"
3. **Raise in retrospective**: "Our prioritization process isn't working"
4. **Escalate to leadership**: "PO decisions are undermining product success"
5. **Accept or leave**: Stay and work within the system, or find a better team

**What you DON'T do**: Start prioritizing backlog yourself.

---

## The Ultimate Test

**Ask yourself**:

> "If everyone on the team did what I'm about to do, would the team function better or worse?"

**If running back grabs headset**:

- What if QB also grabs it?
- What if WR grabs it?
- What if entire team freelances?

**Result**: Complete chaos. No one would do this.

**Similarly in Scrum**:

- What if every developer reprioritized themselves?
- What if everyone changed processes unilaterally?
- What if everyone negotiated directly with stakeholders?

**Result**: No coherent product, no team, no process.

---

## The Bottom Line

**Your football analogy is perfect because**:

❌ **Just like grabbing the headset is wrong**, stepping outside your Scrum role is wrong—even with good intentions

✅ **Just like providing input to the coach is right**, providing input within Scrum is right

**Key lessons**:

1. **Good intentions don't justify role violations**
2. **You don't have the full context** you think you do
3. **There are proper channels** to influence decisions
4. **Respect for roles** enables team function
5. **Earn influence** through excellence in your role
6. **If truly dysfunctional**, escalate properly or leave

**The Agile/Scrum version**:

> "I'm a developer and I think the Product Owner's priorities are poor, so I'll just reprioritize the backlog myself. I'm trying to 'go above and beyond,' and since I have such a passion for the product and love for users, my intention is good—should I do that?"

**Answer**: **No.** Same reasons as the football analogy.

**Instead**: Be the best developer you can be, provide thoughtful input, build trust, influence through excellence—and if the system is truly broken, escalate through proper channels or find a better team.

**Your role matters. Stay in your lane while contributing fully to the team's success.** 🏈


# If I am a running back I think the play calling is so poor. Since I have such a passion for winning, a love for the team, my intension is so good, and I have already constructively expressed my play calling opinions but they do not listen. Can I go lobbying head coach to force offensive coordinator to take my better callings? Or can go lobbying the owner to put pressure on the head coach?

**No. This is even worse than grabbing the headset.**

Now you're not just violating your role—you're **undermining trust, creating political warfare, and destroying team cohesion**. This is how teams implode.

---

## Why This Is Destructive

### 1. **You're Creating a Toxic Political Environment**

**What you're doing**:

- Going around people instead of working with them
- Using organizational hierarchy as a weapon
- Creating pressure through back-channels
- Forcing outcomes through power plays

**What this creates**:

- ❌ **Destroyed trust** - Coordinator knows you're trying to get them overruled/fired
- ❌ **Toxic culture** - Everyone starts politicking instead of collaborating
- ❌ **Fractured team** - Players take sides, creates factions
- ❌ **Fear-based environment** - Everyone worried about being undermined
- ❌ **Focus lost** - More energy on politics than winning games

**This is organizational cancer.** It spreads and kills teams.

### 2. **You're Burning Bridges You'll Need**

**Immediate consequences**:

- Offensive coordinator will never trust you again
- Head coach sees you as divisive, not a team player
- Other coaches become wary of you
- Teammates see you as self-serving politician
- You become "that guy" no one wants to work with

**Career consequences**:

- Labeled as "locker room problem"
- Teams won't want to trade for you
- Coaches won't want to coach you
- Your reputation is damaged permanently

**In football**: "He's talented but brings drama" = career killer

**In software**: "He's skilled but creates political chaos" = blacklisted

### 3. **You're Assuming You're Right (You Might Not Be)**

**Your perspective**:

- "I'm right, they're wrong"
- "If only they'd listen to me, we'd win"
- "My play calls are obviously better"

**Reality check**:

- Maybe you're wrong (you don't have all the information)
- Maybe your ideas have flaws you don't see
- Maybe they tried your approach and it didn't work
- Maybe there are constraints you don't understand
- Maybe your ideas are good but not implementable right now

**Humility question**: "What if I'm the one who's missing something?"

### 4. **You're Violating Chain of Command**

**Military/sports principle**: Chain of command exists for a reason.

**Going over people's heads**:

- ❌ Undermines authority structure
- ❌ Creates chaos (who's really in charge?)
- ❌ Prevents direct communication and problem-solving
- ❌ Sets precedent for others to do the same
- ❌ Makes you untrustworthy

**Even if you're right**, the method is so destructive that you lose anyway.

### 5. **You're Making It About You, Not the Team**

**What you think you're doing**: "Helping the team win"

**What you're actually doing**:

- "I want my ideas implemented"
- "I want to be proven right"
- "I want control over play calling"
- "I want recognition as the smart one"

**True team player**: Works within the system, even when frustrated

**Selfish player**: Breaks the system to get their way

### 6. **You're Creating Precedent for Chaos**

**If head coach sides with you**:

- Quarterback goes to owner about head coach decisions
- Wide receiver goes to owner about offensive coordinator
- Defensive end goes to owner about defensive coordinator
- **Everyone** starts lobbying owner
- Owner can't run a business because constantly mediating player disputes
- Team becomes uncoachable

**No functional organization can operate this way.**

---

## What Actually Happens When You Do This

### **Scenario 1: Head Coach Sides With You**

**You think**: "Great! I won! My ideas will be implemented!"

**What actually happens**:

1. Offensive coordinator is humiliated, loses authority
2. Coordinator either quits or is resentful and undermines you subtly
3. Other coaches see you as threat, become defensive
4. Teammates lose respect for you (you went behind coach's back)
5. You're now responsible for outcomes - if plays fail, it's on you
6. You've created enemy in coaching staff
7. Team chemistry destroyed

**Even if your plays work**, you've poisoned the environment.

### **Scenario 2: Head Coach Sides With Coordinator**

**More likely outcome**:

1. Head coach sees you as insubordinate and divisive
2. "Running back tried to get coordinator fired? Bench him."
3. You lose playing time
4. Labeled as "locker room cancer"
5. Traded to another team (if lucky) or cut (if not)
6. Reputation damaged across the league

**Your career suffers** even if you were technically right about plays.

### **Scenario 3: Owner Gets Involved**

**Absolute worst case**:

1. Owner now micromanaging football operations
2. Head coach's authority completely undermined
3. Coaches can't coach (anyone can go over their heads)
4. Players have learned: "Don't like a decision? Call the owner!"
5. Organization becomes dysfunctional circus
6. **Team loses** because structure has collapsed
7. Eventually owner, coach, coordinator, AND you all get blamed

**Everyone loses**, including you.

---

## The Scrum Equivalent

**Your situation**:

```
"I'm a developer and I think the Product Owner's prioritization 
is terrible. I've expressed my opinions constructively but they 
don't listen. Can I:

A) Go to the VP of Engineering to force PO to take my priorities?
B) Go to the CEO to put pressure on the VP and PO?"
```

### **What This Creates:**

**If you go around PO to VP**:

- PO will never trust you again
- Other developers see you as political operator
- VP sees you as someone who can't work within team structure
- You're now "that developer" no one wants on their team
- Even if VP sides with you, PO is undermined and team chemistry destroyed

**If you go to CEO**:

- Absolutely career-limiting move
- Shows you don't understand organizational boundaries
- CEO will likely tell VP "handle your people"
- VP will likely tell PO "handle this difficult developer"
- You get pushed out (directly or indirectly)

**Real-world outcome**: You'll be labeled "brilliant but difficult" and managed out.

---

## What You SHOULD Do Instead

Since you've already tried constructive communication and it didn't work, you have **four mature options**:

### **Option 1: Escalate Once, Properly, Then Let Go**

**The one acceptable escalation**:

**To head coach** (in appropriate setting, like one-on-one):

```
"Coach, I need to be honest. I've shared concerns about play 
calling with the coordinator multiple times. I'm seeing [specific 
issues] leading to [specific negative outcomes]. 

I respect the chain of command, and this is the last I'll bring 
it up. But I wanted you to know my perspective before I drop it. 

After this conversation, I'll execute whatever plays are called 
100%. I just needed to make sure my concerns were heard at the 
highest level they should be heard."
```

**Key elements**:

- ✅ Respectful of hierarchy
- ✅ Evidence-based (not just opinion)
- ✅ One time only (not repeated lobbying)
- ✅ Commitment to execute regardless of outcome
- ✅ No ultimatum or pressure

**Then**: Drop it completely. You've made your case. Accept the decision.

**Scrum equivalent**:

```
One-on-one with Engineering Manager:

"I've raised concerns with our PO about prioritization multiple 
times. I'm seeing [specific problems] affecting [specific outcomes]. 
I respect the PO role and this is the last I'll bring it up, but 
I wanted to escalate this once since I think it's significant.

Whatever the decision, I'll continue delivering excellent work. 
I just needed to ensure leadership was aware of my concerns."
```

### **Option 2: Execute Brilliantly Anyway**

**Make the "bad" plays work through excellence.**

**Why**:

- Maybe the plays aren't as bad as you think
- Maybe your execution has been the weak point
- Excellence builds credibility for future input
- Demonstrates professionalism
- Proves you're a team player

**Example**:

- Barry Sanders made bad plays look good through talent
- Tom Brady executed offense perfectly even when he disagreed
- Result: Coaches trusted their input MORE, not less

**Paradox**: The less you fight for control, the more influence you gain.

**Scrum equivalent**:

```
Even if you disagree with priorities, deliver exceptional quality.
- Write clean code
- Thorough testing
- Great documentation
- Help teammates

Result: Your voice carries MORE weight in future discussions.
```

### **Option 3: Document and Wait**

**If you're truly convinced you're right**:

1. **Document your concerns** (privately, professionally)
2. **Continue executing** well in your role
3. **Wait for results** to prove you right or wrong
4. **If results prove you right**: Leadership will eventually notice
5. **If results prove you wrong**: You learn something

**This is the patient, mature approach.**

**Why this works**:

- Reality is the ultimate arbiter
- If coordinator's plays fail repeatedly, leadership will notice
- Your professionalism during this time builds credibility
- If you're wrong, you learn without having burned bridges

**Scrum equivalent**:

```
If PO's priorities lead to product failure:
- Leadership will eventually notice
- Data will show the problem
- Your professionalism positions you as part of solution

If PO's priorities succeed:
- You learn you were wrong
- You're glad you didn't burn bridges
```

### **Option 4: Leave Professionally**

**If the situation is truly untenable**:

```
"Coach, I respect you and this organization. But I fundamentally 
disagree with our offensive approach, and I don't see that changing. 
Rather than create division, I think it's best if I request a trade. 
I hope we can make this transition smoothly and professionally."
```

**This is the honorable exit.**

**Why this is respectable**:

- ✅ Honest about the mismatch
- ✅ Doesn't burn bridges
- ✅ Doesn't create drama
- ✅ Allows both sides to move on cleanly
- ✅ Preserves your reputation

**Better to leave** than to poison the environment.

**Scrum equivalent**:

```
"I don't think this team's approach aligns with how I work best. 
I'd like to transition to another team/company. Let's make this 
as smooth as possible."

This is professional and mature.
```

---

## The Hard Truth You Need to Hear

### **You Might Be Wrong**

**Possibilities you may not be considering**:

1. **Information asymmetry**: Coach knows things you don't
    
    - Injuries you're not aware of
    - Game plan for next opponent
    - Personnel limitations
    - Long-term strategy vs. short-term wins
2. **Your ideas might have flaws**:
    
    - Work in theory, not practice
    - Require skills team doesn't have
    - Have downsides you don't see
    - Already tried and failed before you arrived
3. **Timing might be wrong**:
    
    - Good ideas, but can't implement now
    - Will implement later
    - Need other pieces in place first
4. **You're measuring wrong outcomes**:
    
    - You're focused on yards, coach is focused on time of possession
    - You're focused on features, PO is focused on market positioning
    - Different goals = different decisions

**Humility check**: "What if I'm not seeing the full picture?"

### **Even If You're Right, You Might Still Be Wrong**

**Sometimes being "right" doesn't matter**:

- Being right but destroying team chemistry = net negative
- Being right but creating political warfare = net negative
- Being right but becoming uncoachable = net negative
- Being right but losing teammates' respect = net negative

**Wisdom**: Sometimes it's better to be harmonious than right.

**Pick your battles**: Is this the hill you want to die on?

---

## When Lobbying IS Appropriate (Rare Cases)

**There ARE rare situations where escalation is necessary**:

### **Ethical/Legal Issues**

**Football**:

- Coach asking you to injure opponents
- Covering up concussions
- Violating league rules
- Abuse or discrimination

**Scrum**:

- Unethical business practices
- Legal violations (fraud, discrimination)
- Safety issues being ignored
- Harassment or abuse

**These should be escalated** to highest levels or reported externally.

### **True Emergency/Crisis**

**Football**:

- Coach is incapacitated
- Clear immediate danger to players

**Scrum**:

- Product about to ship with critical security flaw
- Company about to make catastrophic decision

**Time-sensitive** situations where normal channels are too slow.

### **Explicit Organizational Encouragement**

**Some organizations explicitly want input**:

- "We have an open-door policy"
- "Skip-level meetings welcome"
- "We want to hear concerns"

**But even then**:

- Do it openly, not sneakily
- Frame as raising concern, not lobbying
- One time, not repeated campaigning

---

## The Sports History Lesson

**Examples of players who lobbied/politicked**:

### **Bad Outcomes**:

- **Terrell Owens**: Brilliant player, constant drama, teams gave up on him
- **Antonio Brown**: Elite talent, burned bridges everywhere, career ended prematurely
- **Many others**: Talented players out of league because "not worth the headache"

### **Good Approaches**:

- **Tom Brady**: Questioned things, but always executed, earned massive influence
- **Ray Lewis**: Led by example, influenced through respect, not politics
- **Peyton Manning**: Collaborated with coaches, earned right to call audibles

**Pattern**: Influence through excellence and respect, not politics and lobbying.

---

## What Great Leaders Do

**If you truly believe you should be calling plays**:

### **Earn It The Right Way**:

1. **Execute perfectly** in your current role
2. **Build trust** through consistency
3. **Show judgment** by picking right moments to speak
4. **Demonstrate wisdom** by understanding when you're wrong
5. **Earn respect** from coaches and teammates
6. **Eventually**: "What do you think we should run here?"

**Result**: You're given influence because you've earned it, not demanded it.

**Example path**:

```
Year 1: Execute plays perfectly, occasionally offer input
Year 2: Coach starts asking your opinion
Year 3: Regular input in game planning
Year 4: Coach trusts you to audible at line
Year 5: Transition to coaching role

This is how running backs become coaches.
```

**Scrum equivalent**:

```
Year 1: Deliver excellent work, build trust
Year 2: Invited into more planning discussions
Year 3: Significant influence on roadmap
Year 4: Mentoring other developers
Year 5: Transition to tech lead or Product Owner role

This is how developers become leaders.
```

---

## The Ultimate Question

**Ask yourself honestly**:

> "Am I lobbying because I genuinely believe it's best for the team, or because I want to be proven right and have control?"

**Honest answers might be**:

- "I'm frustrated they won't listen to me" (ego)
- "I want recognition for my ideas" (ego)
- "I think I'm smarter than them" (ego)
- "I want control over decisions" (control)
- "I'm right and they're wrong" (arrogance)

**If any of these**: Your motivations aren't as pure as you think.

**True team-first thinking**:

- "How can I help us win within my role?"
- "Am I executing my part excellently?"
- "What am I missing that they see?"
- "How can I be part of the solution?"

---

## The Bottom Line

### **Should you lobby head coach/owner?**

**No. Absolutely not.**

**Why**:

1. ❌ Destroys trust and team cohesion
2. ❌ Creates toxic political environment
3. ❌ Violates chain of command
4. ❌ Damages your reputation permanently
5. ❌ Even if you "win," you lose
6. ❌ Makes you uncoachable and unemployable
7. ❌ You might be wrong anyway

### **What to do instead**:

**The four mature options**:

1. **Escalate once properly** to head coach, then drop it
2. **Execute brilliantly** in your role regardless
3. **Document and wait** for results to prove right/wrong
4. **Leave professionally** if truly untenable

**What NOT to do**:

- ❌ Lobby repeatedly
- ❌ Go around people's backs
- ❌ Create political pressure
- ❌ Force outcomes through hierarchy
- ❌ Burn bridges
- ❌ Make it about ego

### **The Hard Truth**:

**Sometimes in life, you don't get to call the plays.**

You can:

- ✅ Provide input respectfully
- ✅ Execute brilliantly
- ✅ Earn influence over time
- ✅ Leave if misaligned

You cannot:

- ❌ Force your will through politics
- ❌ Undermine leadership
- ❌ Demand control you haven't earned

**Maturity is knowing the difference.**

**Final advice**: Drop the lobbying idea entirely. Either execute within the system, or leave professionally. There's no third path that doesn't destroy you and the team.

🏈 **Stay in your lane. Master your role. Earn influence through excellence, not politics.**


# Thanks
You're welcome!

Those were some really thoughtful questions that got at the heart of how teams actually function—both in sports and in software development. The running back analogy was perfect for highlighting how important it is to respect roles and work within proper channels, even when we're passionate and think we know better.

Good luck with your Angular migration, your code review guidelines, and navigating the post-acquisition dynamics. It sounds like you're thinking deeply about how to be both effective and professional in complex team situations. That self-awareness will serve you well.

Feel free to come back anytime you want to discuss Agile practices, technical challenges, or team dynamics! 👍