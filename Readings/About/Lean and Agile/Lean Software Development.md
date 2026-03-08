
# The Art of Lean Software Development - O'Reilly
2009

* Lean's origin
* Learn the Lean software development principles and the five most important practices
* Relationship between Lean and Agile
* Incorporating Lean principles
* Hands-on practices: descriptions, benefits, trade-offs, and roadblocks

The Lean approach has been yielding dramatic results in manufacturing for decades, and now Lean is being applied just as successfully to the supply chain, product design, engineering, and even software development! At the same time, the Agile software development methodologies have been proving the value of the very same core practices recommended for Lean software development.

Many people mistakenly think that Lean and Agile are two names for the same thing. Lean and Agile software development have the same goal—to increase quality and productivity— but they take different philosophical approaches to get there. The first part of this book presents the Lean software development principles. We discuss the differences between the Lean and Agile perspectives as well as the similarities.

The second part of this book presents the core practices, ordered by value. 

# chapter 1. Why Lean

The Lean principles and the mindset of Lean thinking have proved remarkably applicable to improving the productivity and quality of just about any endeavor. Lean has been successfully applied to manufacturing, distribution, supply chain, product development, banking, engineering, the back office, and much more. However, only in the last few years have the Lean principles and techniques been applied to software development.

In this chapter we will give you more details on the problems that continue to plague software development, as well as an overview of Agile software development and the origins of Lean and its unique approach to improving any kind of process.

Three significant things came out of the now-famous Snowbird gathering: 
	the decision to use the term “Agile,” 
	the Agile Manifesto, 
	and the Agile Alliance.

## The Agile Manifesto
The Agile Manifesto 
* formally called the Manifesto for Agile Software Development
* is a model of simplicity
* four core value
* the authors of the Agile Manifesto further refined what they meant in those value statements by listing a number of principles that they follow as a direct result of those values

#### MoSCoW rules is used in one of the agile methodology, DSDM:
* M: must-have requirements
* S: should have if at all possible
* C: could have, but not critical
* W: won't have this time, but potentially later

## The Lean Success Story
It wasn’t called Lean back then. It was the Toyota Production System, or Just-In-Time manufacturing. 
James Womack, Daniel Jones, and Daniel Roos coined the term “Lean” in their 1990 book, The Machine That Changed the World (Harper Perennial)

Lean is a mindset, a way of thinking about how to deliver value to the customer more quickly by finding and eliminating waste (the impediments to quality and productivity). This philosophy is expressed in a set of principles that have proven remarkably applicable to a wide range of business activities. The Lean principles have been used successfully in areas as diverse as the supply chain, the office, engineering, and (of course) software development.

First, we’ll take a look at the roots of Lean thinking with a short history of how Lean developed in manufacturing. 
Second, we’ll show you how you can apply Lean thinking to software development and how it differs from Agile.

### A Whirlwind History of Lean
The emergence of Lean production and its derivatives:  it was replacing (or competing with): mass production.

Henry Ford, Model T, 1913. Pros; cons; not suitable in Japan.

Taiichi Ohno described the Toyota Production System as “a system for the absolute elimination of waste.” 
He wasn’t kidding. By the early 1990s, Toyota was 60% more productive with 50% fewer defects than its non-Lean competitors. 
According to Ohno, this striking advantage rested on two pillars: Just-In-Time and autonomation.

#### Just-In-Time
#### Autonomation (Jidoka)
a combination of the words autonomous and automation
#### Waste (Muda)
The overarching goal of Lean production (or any form of Lean) is to deliver value to the customer more quickly, and the primary way to do this is to find and eliminate waste.
##### DOTWIMP: THE SEVEN DEADLY WASTES
Lean has some pretty strict views on waste.
1. Defects Lean focuses on preventing defects instead of the traditional “find and fix” mentality.
2. Overproduction Producing more than is needed, or producing it before it is needed
3. Transportation The unnecessary movement of parts between processes. 
4. Waiting People or parts waiting for the next production step.
5. Inventory Inventory beyond the bare minimum consumes productive floor space and delays the identification of problems (if you’ve got plenty of spares, there’s no incentive to fix quality-related problems).
6. Motion People or equipment moving or walking more than is needed to perform the processing.
7. Processing Overprocessing beyond the standard required by the customer. This adds additional cost without adding additional value.
8. Additional eighth waste: underutilization of people: the underutilization of the worker’s creativity and resourcefulness.

A key Lean activity is to break down a process into a map of its individual steps and identify
which steps add value and which steps do not—the waste. This is known as a value stream
map. The goal, then, is to eliminate the waste (muda) and improve the value-added steps
(kaizen). The waste is further subdivided into two categories: non-value-added but necessary
(given the current state of the system), and pure waste. Pure waste is easy to deal with—it can
be eliminated immediately.

So, there are two key Lean skills: knowing what the customer values, and knowing how to
spot waste.

#### Lean Jargons in Japaness
	Andon
		Means “light” in Japanese. In a Lean environment, it is a visual device (usually a light or a board of lights) that gives the current status of a production system, signaling 
		any problems (typically, green = OK, yellow = needs attention, and red = urgent/production stopped).
	Jidoka
		Autonomation, the ability of a machine to inspect its work and operation and to notify a human if a problem is detected.
	Kaizen
		The continuous, incremental improvement of an activity to create more value with less waste. 
	Kanban
		A signaling system used to signal the need for an item, typically using things like index cards, colored golf balls, or empty carts.
	Muda
		Waste that consumes resources but produces no value.

### Lean Principles
Taiichi Ohno started with Just-In-Time and autonomation, the two pillars of the Toyota Production System. 

Modern-day Lean has settled on five principles and a wide array of practices that have been distilled from the Toyota Production System and the experiences of other companies that have followed Toyota’s lead. 

These five principles are identified as 

Value
	Value is defined by the customer. What does the customer value in the product? You have to understand what is and what is not value in the eye of the customer in order to map the value stream.
Value stream
	Once you know what the customer values in your product, you can create a value stream map that identifies the series of steps required to produce the product. Each step is categorized as either value-added, non-value-added but necessary, or non-value-added waste.
Flow
	The production process must be designed to flow continuously. If the value chain stops moving forward (for any reason), waste is occurring.
Pull
	Let customer orders pull product (value). This pull cascades back through the value stream and ensures that nothing is made before it is needed, thus eliminating most in-process inventory.
Perfection	
	Strive for perfection by continually identifying and removing waste.



# Lean Software Development Fundamentals (Pluralsight, Stephen Haunts)

## 5. Lean Software Development

### overview

We have looked at an overview of traditional waterfall software development and the newer agile methodologies, including extreme programming in Scrum. 
We looked at the history and background of Lean manufacturing with Henry Ford and his Model T automobile and the Toyota production system. 
	This is important to look at, as it shows the origins of Lean thinking and how they are applied to manufacturing. 

Now we look at Lean software developments. 
First, where Lean software development came from
Then the seven principles that underpin Lean software development. 
1. Eliminating waste, this is where you should only spend time working on what adds value to the customer. 
2. Amplifying learning, this is when you have tough problems, you increase feedback. 
3. Decide as late as possible, and this is about keeping your options open as long as practical, but no longer. 
4. Deliver as fast as possible, and this is about delivering value to customers as soon as I ask for it. 
5. Empowering the team, this is letting the people who add value to your customers use their full potential. 
6. Build integrity in, and this is about not trying to tack on integrity and monitoring after the fact, but building it in from the start. 
7. Seeing the whole. This is where you should be aware of temptation to optimize parts of the system at the expense of the whole. 
 
After this module, you'll feel inspired to think differently about how you plan to run your software projects

### The Origins of Lean Software Development

### Eliminate Waste - The 7 Wastes

## 6. Applying Lean Software Development

## 7. Agile vs. Lean

## 8. Software Practices to Support Lean

## 9. Using Kanban
Another software development methodology that goes hand in hand with lean software development, and that is Kanban. 

Kanban is a great way of organizing a lean software project, but it is different to Scrum in how it's operated. 
* the background of Kanban, 
* subjects such as 
	* limiting work in progress, 
	* minimizing cycle time, 
	* efficiency through focus, 
* Scrum versus Kanban.

### ### Kanban Background

As we looked at in our module in lean manufacturing, in the late 1940s, Toyota started studying supermarkets with the idea of applying self‑stocking techniques at the factory floor. In a supermarket, customers generally retrieve what they need at the time required, no more, no less. Furthermore, the supermarket stocks only what it's expected to sell in a given time, and customers take only what they need since future supply is assured. This observation led Toyota to view a process as being a customer of one or more processes and to view the proceeding processes as some kind of store. The customer process goes to the store to get the required components, which in turn causes the store to restock. Originally, as in supermarkets, sign boards guided shopping processes to specific shopping locations within the store. Kanban aligns inventory levels with actual consumption. A signal tells the supplier to produce and deliver a new shipment when material is consumed. These signals are tracked with a replenishment cycle, bringing visibility to the supplier, consumer, and buyer. Kanban uses the rate of demand to control the rate of production, passing demand from the end customer up through the chain of customer store processes. In 1953, Toyota applied this logic to their main plant machine shop. When related to software development, Kanban is a method for managing knowledge work with an emphasis on just‑in‑time delivery while not overloading the team members. This approach presents all participants with a full view of the process from task definition to delivery to a customer. Team members pull work from a queue. Kanban in the context of software development can mean a visual process management system that tells you want to produce, when to produce it, and how much to produce, which is inspired by the Toyota production system and lean manufacturing. Kanban for software teams operates by matching the amount of work in progress to the team's capacity. Kanban gives teams more flexible planning options, faster outputs, clear focus, and transparency throughout the development cycle. The key term here is work in progress, so let's dig into that a little bit further.
## 10. Course Summary
### ### Lean Manufacturing

Lean is a concept first explored in the world of manufacturing, first by Henry Ford of the Ford Motor Company, and then further developed at Toyota with the development of the Toyota production system and the pull system called just‑in‑time manufacturing. 

Just‑in‑time is a system about providing the right material in the right amount at the right time and in the right place. 
According to Taiichi Ohno from Toyota, inventory is waste that costs the company money. Even worse, inventory hides problems in the production system. This includes problems such as inadequate capacity, inflexible equipment, and unreliable equipment. A major contribution of a just‑in‑time system is that it exposes the causes of inventory keeping so they can be addressed. When items are used just in time, they aren't sitting idle and taking up space. This means that they aren't costing you anything to hold on to them, and they're not becoming obsolete or deteriorating. However, without the buffer of having items in stock, you must tightly control your manufacturing process so that parts are ready when you need them.

### ### Lean Principles

The principles from lean manufacturing were first applied to software development by Mary and Tom Poppendieck in their seminal book, Lean Software Development, An Agile Toolkit. 

The book presents the traditional lean principles in a modified form, as well as a set of 22 tools, and compares the tools to agile practices. 

Lean software development is made up of many principles. 
The first is to eliminate waste. Lean philosophy regards anything not adding value to the customer as waste or muda as it is called in Japanese. In order to eliminate waste, you need to be able to recognize it. If some activity could be bypassed or the result could be achieved without it, it is waste. In lean software development, there are seven identified wastes that we need to be aware of. 

The first is defects where any defect in your system is considered a waste as they take time to fix and affect your customers if they make it into production. 

Then we have extra features. Any features that are not specified by the customer are waste. You should resist the urge to add cool features just for the sake of it. 

Then we have handoffs. Handing off any documents between people and teams is a waste, and it takes time to transfer knowledge. And with each handoff, you lose a little bit of knowledge with the people that you hand off to. 

Then we have delays. Any kind of delay on a project is considered waste. For example, if a member of the team has to seek answers to a question, if the people they need to talk to you are not available straightaway, a delay is caused, and this creates a waste. Without getting this correct answer straightaway, the team member may be forced to switch to another task, guess the answer, and risk during rework or trying to research the answer by themselves, which can take up valuable time and may still result in the wrong answer. 

Then we have partially completed work. This is any code that's been started, but not completed. By not completed, we don't just mean code that is left uncompleted. The code could be technically completed by the developer, but it's not been tested yet. 

Then we have task switching. One of the biggest disruptions you can do to a software developer is up and switch tasks. This requires a lot of mental shifting from one train of thought to the other. It takes time for a developer to focus their brain on the task to be effective at problem‑solving. Switching to another task before they are ready restarts the process of them getting started. 

And then finally, we have unneeded processes. This is where you have processes that are in place just for the sake of it. For example, this might be a very complex software release change control process. 

Next, we looked at value stream mapping. This is about documenting the flow of value in your organization. You split the processes into value add a non‑value added time. Value added time is where value is being added to the organization or the customer. Non‑value add time is time that doesn't add value, so it is a waste. The time from the start of the process to the end is called the cycle time. You want to strive for the shortest cycle time you can to give value to your customer. 

The next lean principle to look at is building quality in. Quality issues result in all sorts of waste. There's waste in testing the code more than once, waste logging defects, and waste in fixing them. As a result, lean principles aim to address this point. Agile methodologies, such as Scrum and Extreme Programming, have practices that help you build in quality into your development process. These practices are pair programming and test‑driven development. Pair programming seeks to avoid quality issues by applying the minds of two developers to each task. Test‑driven development avoids quality issues by writing tests before writing code. Both of these practices come from Extreme Programming, and both seek to prevent quality issues from occurring in the first place. The idea is to track quality issues soon before they become an issue later. 

The next lean principle is that of amplifying learning. Software development is a continuous learning process based on iterations when writing code. Software design is a problem‑solving process involving the developers writing the code and what they have learned. Instead of adding more documentation or detail planning, different ideas could be tried by writing code. The process of user requirements gathering could be simplified by presenting screens to an end user and getting their input. The accumulation of defects should be prevented by running tests as soon as the code is written. The learning process is sped up by the usage of short iteration cycles, each one coupled with refactoring and integration testing. Increasing feedback by short feedback sessions with customers helps when determining the current phase of development and adjusting efforts for future improvements. During these short sessions, both customer representatives and the development team learn more about the domain problem and figure out possible solutions for further development. Therefore, the customers better understand their needs based on existing results of development efforts, and the developers learn how better to satisfy those needs. 

The next lean principle we looked at was deciding as late as possible. The best decisions are made when you have the most information available. If you don't have to make a particular decision now, wait until later when you have more knowledge and information. But don't wait too long either. Lack of a decision should not hold up other aspects of the project. Wait until the last responsible moment to make an irreversible decision. 

The next principle we looked at was deliver as fast as possible. In the era of rapid technology evolution, it is not the biggest that survives, but the fastest. The sooner the end product is delivered without major defects, the sooner feedback can be received and incorporated into the next iteration. The shorter the iterations, the better the learning and communication within the team. With speed, decisions can be delayed. Speed assures the fulfilling of the customers present needs and not what they required yesterday. This gives then the opportunity to delay making up their minds about what they really require until they gain better knowledge. Customers value rapid delivery of a quality product. 

The next lean principle we looked at was empowering the team. It's been a traditional belief in most businesses about decision‑making in the organization when the managers tell the developers had to do their job. When practicing lean software development, the roles are turned where the managers listen to the developers so they can explain better what actions might be taken, as well as providing suggestions for improvements. The lean approach favors the approach of finding good people and letting them do their job and not dictating to them how to do their job. This encourages progress, catches errors, and helps remove impediments stopping the team from working effectively. 

The final lean principal we covered was seeing the whole. One of the big shifts to lean thinking from a mass production mentality is discarding the belief that you need to optimize each step of a value stream. Instead, to increase efficiency of the production process, look at optimizing the flow of value from the beginning of the production cycle to the end. Thinking back to the analogy of a production line, getting each machine to work as efficiently as possible does not work as well as maximizing efficiency in the production flow in its entirety. Focus on the whole process from the beginning concept to the consumption by the customer.

### ### Agile vs. Lean

We also looked at the question of should you use Agile or Lean? When you look from the outside in, there's not much difference. Both of these methodologies are about improving the quality of the software for the end customer and improving the productivity of the development process. They also encourage and embrace changes in requirements and processes, but most importantly, they are both about delivering value quickly to the end user and customer. 

Agile methodologies like Scrum primarily concern themselves with the practice of developing software and any activities that surround the developing of the software. 

Lean, on the flipside, can be applied to any scope from the development of the software itself to the entire business domain where the software development is just one small piece. 

The main focus of Agile software development is to focus on the customer collaboration and the quick delivery of software. 

Lean software development also sees that as an importance, but its main focus is on the elimination of waste as we have been discussing at length in this course. 

Scrum is a very popular methodology to use when trying to apply lean thinking as it is relatively lightweight and easy to learn and adopt. 

A good way of thinking of this is Scrum and Agile is a value drive for software development framework, whereas Lean helps you to optimize its process. You cannot do Lean, you use Lean to improve your processes.

### ### Software Practices to Support Lean

It's essential to use a source control repository to allow you to effectively work in a team tracking changes, creating working branches, and merging those changes. You can even use a centralized repository, like Team Foundation Server or Subversion, or a distributed repository like Git or Material. A distributed system gives you the ability to clone your entire repository locally and work completely disconnected from the server. Whereas if we have a centralized system, you need a connection to the source control service to be able to check code in or out. 

We also looked at continuous integration and delivery. This is where you have a pipeline that when you're checking code, a build is triggered on the build server that compiles a code, runs any static code analysis, executes unit tests, and then packages upper deployments. Then using this pipeline, you can automatically push your changes to test servers and production. A pipeline like this is very important for lean and Agile, as it enables you to deploy good quality and well‑tested solutions to your customers regularly. 

The final practice we looked at was automated testing, where we touched on different types of testing, like unit testing, integration testing, automated UI testing, and performance testing. 

All of these tools and practices are crucial to being able to deliver quality products.

### Using Kanban
Kanban is a very popular technique for people who want to practice lean principles. 

Kanban is a method of managing knowledge work with an emphasis on just‑in‑time delivery, while not overloading the team members. This approach presents all participants with a full view of the process, from task definition to delivery. Team members pull work from a queue. This work flows for a set of states on the Kanban board, like in progress, code review, QA, and then done. Each of these states on the column has a work in progress limit to stop blockages and bottlenecks appearing. The team has to ensure that each column doesn't exceed its work in progress limits, but instead focuses on areas where work is building up, like an excess of work needing code reviewing, for example.


## Understanding Lean and Value-driven Delivery

### Lean Software Development and Value Stream Analysis

#### Lean Software Development Methodology

#### Lean Software Development Principles

#### Value Stream Analysis
The value stream is the entire collection of activities necessary to produce and deliver a product or service. 

Value stream analysis separates those activities that contribute value creation from activities that create waste, and identifies opportunities for improvement. 

This topic is very much related to the area of lean software development because you would use a value stream analysis to go through an entire process and identify the portions that provide value and the portions that do not provide value and could be trimmed or eliminated. 

The idea of a value stream analysis originated in a manufacturing environment with lean manufacturing, and the general concept can also be applied to a software development environment. 

Value stream mapping is an essential element of value stream analysis and is a lean management method for analyzing the current state and designing a future state for a series of events that take a product or service from its beginning through to the customer. 

At Toyota, it is known as "material and information flow mapping." 

A value stream analysis can either be a rigorous and detailed analysis of a process or a more higher‑level analysis of a process, depending on the situation. 

In a typical agile project, you wouldn't typically find highly detailed processes that would lend themselves to an elaborate value stream analysis. But the principles behind doing a value stream analysis would be very worthwhile for a more higher‑level analysis of the process. You're more likely to find a rigorous and detailed analysis of a process in processes that are much more stable and well‑defined. The most important purpose of value stream mapping is to visualize how a process works to make it easier to see waste in the process in order to highlight problems and develop proposed countermeasures. However, beyond that, a value stream map provides a holistic, interconnected customer perspective of how a process works that helps everyone involved in the process align their efforts around a common purpose and goal. It also serves as a useful management tool for continuously measuring, analyzing, improving, and controlling the interrelated processes in a value stream. This slide shows an outline of the steps for creating a value stream map. The first step is to select the process to map. Next, there is a need to bound the process by clearly defining the endpoints. Normally, a value stream map is done from a customer perspective and the endpoints or customer events. Usually a cross‑functional team that is responsible for the process defines the process steps that take place in the process from end to end. The next steps are to add information flows and collect process data that is relevant to the process, such as the cycle time required for each step in the process. All the previous steps are done to create what is called the current state map. No attempt is made to improve the process at this point. The final step is to identify wastes and inefficiencies and to define the future state or the ideal state that will implement improvements in the process to correct the wastes and inefficiencies. This slide shows an example of what a current state value stream map might look like. It maps the flow of the process from the time a customer requests a new feature until the time that feature is released to production. At this point, the goal is to simply map the process as is without attempting to improve it. Once the current state has been defined, more effort will be applied to identify the sources of waste in the process and to identify opportunities for improvement to be implemented in the future state. A useful technique for identifying waste in a value stream map is called the "Five Why's." It involves asking the question of why something is done repeatedly, up to five times, if necessary, to understand the reason why something is really done. Here's an example. In the value stream map I just showed you, you might ask the question of, "Why does the project manager create a plan and schedule?" And the immediate answer might be, "Because it is required for the business sponsor to approve it." A good value stream analysis wouldn't accept an answer like that at face value, and you might want to probe further and ask the question as to, "Well, why does the business sponsor need to improve it?" And the answer might be, "Because the business sponsor has not delegated authority to the Product Owner to make that decision." Probing still further, you might ask the question, "Well, why hasn't the business sponsor delegated authority to the Product Owner to make that decision?" And the answer might be, "Because the business sponsor likes to have tight control over everything in the process." That indicates a potential major opportunity for improvement. If we can convince the business sponsor to give up tight control over everything in the process, there's a big opportunity to eliminate all the steps associated with developing a formal project plan and having it reviewed and approved by the business sponsor. The future state diagram might look something like this after the approval process by the business sponsor is eliminated. I'm sure that there are other improvements that could also be made in this process, and the analysis would continue as far as necessary to further optimize it. This is a relatively simple example, but it's probably somewhat typical of what you might find in a software development process. In a manufacturing process, a value stream analysis would likely be much more detailed and much more rigorous and include a lot of data, such as the average cycle time in each step of the process. In the next lesson, we're going to start a new module on value‑driven delivery, and the first lesson in that module is an overview of value‑driven delivery.

### Value-driven Delivery


