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