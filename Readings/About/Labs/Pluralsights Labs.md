
# Completing the AI Pipeline

## Lab Overview

Bring the Smart Support Ticket pipeline online by adding its compute and AI layers to the storage and Cosmos DB resources you provisioned earlier. You'll create the Microsoft Foundry resource with a deployed gpt-5-mini model, provision the Azure Function App, wire up the environment variables that connect every service, deploy the Python function code, and watch the full pipeline run end to end as a ticket file uploaded to blob storage is classified by the model and persisted to Cosmos DB. By the end of this lab, you'll have a working AI pipeline you can trigger, monitor, and inspect.

## What to Expect

- **Environment**: You will work directly in the Azure Portal and a virtual machine(s) via terminal access to complete the objectives in your lab.
- **Access**: We will provide you with secure, temporary credentials to a cloud account as well as credentials for a virtual machine(s) and an instant terminal to log in and use during your lab.
- **Modes**: This lab is available to take in Guided Mode with step-by-step instructions.
- **Progress**: Your progress is not saved if you quit the lab or the lab times out.

1. Provision the Foundry resource and deploy a gpt-5-mini model to it
	* Create the Microsoft Foundry resource in the same region as your existing storage and Cosmos DB resources. 
	* Deploy the gpt-5-mini model and capture the endpoint and deployment name your function code will need. 
	* Scenario: This is the AI layer of the pipeline. The endpoint and deployment name you create here will feed directly into the function app's environment variables in a later step.
2. Provision the Azure Function App that will host the pipeline code
	* Create a Python Function App in the same region as the rest of the pipeline. 
	* Confirm the Function App's Application Insights instance is wired up for later observability. 
	* Scenario: The Function App is the compute layer that connects blob storage to the model and Cosmos DB. You'll create the host first, then deploy code into it.
3. Understand the function app code before deploying it
	* Walk through the blob trigger entry point, the Azure OpenAI client call, the Pydantic model that enforces the structured output shape, and the Cosmos DB upsert. 
	* Identify where each environment variable is read and how the values you just configured map to the code. 
	* Scenario: With the resources provisioned and the environment variables in place, this is the moment to study the code that ties them together. The review sets up what you're about to deploy.
4. Deploy the function app code from the local development environment
	* Optionally use the supplied virtual machine with Visual Studio Code preconfigured, or use your own local environment. 
	* Deploy the function code to the Function App and confirm the blob trigger registers successfully. 
	* Scenario: You'll deploy the same code you just reviewed. The supplied VM exists for learners who'd rather not configure a local Python and Functions Core Tools setup.
5. Configure the Function App's environment variables to connect every component of the pipeline.
	* Supply the storage connection string, the Foundry endpoint and deployment name, the Cosmos DB connection details, and the Application Insights connection string. 
	* Confirm each value matches the resource it points to before deploying code.
	* Scenario: Every service the function talks to is referenced through an environment variable. Getting these right is what turns a collection of resources into a working pipeline.
6. Run the pipeline end to end and trace a ticket throught every stage
	* Upload a sample email text file to the inbound blob container. 
	* Watch the function execute in real time using the Function App's log stream, then review the invocation history. 
	* Use Application Insights to inspect the end-to-end trace for the run. 
	* Open the Cosmos DB container and confirm the structured document the model produced has landed correctly. 
	* Scenario: This is the payoff. A single file upload triggers the full pipeline, and you'll follow it through every layer—function logs, Application Insights, and finally the document that lands in Cosmos DB.



# Implement Generative AI Workflows in Angular

## Lab Overview

In this Code Lab, learners build an Angular feature that connects user prompts to a generative AI workflow, streams model output into the interface, and enriches responses with application context. They manage AI interaction state, route model access through a secure server-mediated boundary, and handle structured and non-deterministic AI outputs in a way that supports a clear and resilient user experience. The lab focuses on practical implementation of generative AI workflows in Angular applications.

## What to Expect:

- **Environment:** You will work directly in the IDE integrated into the browser.
- **Modes:** This lab is available with step-by-step instructions and validation for tasks as needed.
- **Progress:** Your progress is saved if you exit or the lab times out.

1. Implement an angular workflow
		Implement an Angular prompt-and-response workflow that sends user input to a generative AI service and renders streamed results in the UI.
2. Manage AI interaction
		Manage AI interaction state in Angular, including request lifecycle, partial responses, completion, and error handling.
3. Integrate application data
		Integrate application data or tool-backed context into the AI workflow through a secure server-mediated boundary that protects credentials and orchestration logic.
4. Handle AI outputs
		Handle structured and non-deterministic AI outputs in a way that keeps the user experience clear, reactive, and resilient.


