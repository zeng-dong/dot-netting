Analyze code, fix bugs, and submit PRs
Review, refactor, and secure the codebase
Generate a code quality report
Write and run an AI-assisted automated test suite

## Understanding Codex
Codex real power lies in its role as a cloud‑based software engineering agent that can write and edit code, fix bugs, and run tests. 

Cloud‑based, this means all the complex processing happens on OpenAI's powerful servers. 

Software engineering
	 Codex goes beyond just writing code. It's designed to assist with the entire engineering lifecycle. 
	 We're going to use it to analyze and understand code, fix bugs, refactor for quality, and even run a security audit, all key parts of a developer's job. 

Agent
	An agent can take a high‑level goal and work towards it. Instead of just suggesting the next line of code, you can give Codex a complex task like review this file for bugs and suggest improvements. It can then analyze, plan, and generate a complete response. You can interact with it conversationally to refine the results. 

## Setting up Your Environment

the messy codebase: https://github.com/pratheerth/Flask-TODO-APP
forked from https://github.com/mohammed97ashraf/Flask-TODO-APP

The project is not very well documented. 
It has absolutely no tests, and it does contain some bugs and potential security issues. 

Before we can ask Codex to analyze the code or fix a single bug, we have to establish a secure and effective connection between the AI agent and our code, which is hosted in a GitHub repository. 

Let's walk through the essential first steps of integrating Codex with the GitHub account. 

This setup process is the foundation for everything we're going to do, so it's important to get it right. 

Let's head on to www.chatgpt.com. This obviously is the interface that we're all thoroughly familiar with at this point. You can see the link to Codex on the top left‑hand side. Let's click on that. This brings us to the doorstep of Codex. Let's click on Get started. You can then basically see the capabilities of Codex outlined by OpenAI. Let's click on Connect to GitHub. If this is the first time you're doing this, you'll then be faced with this screen telling you that MFA, or multi‑factor authentication, is required. MFA, of course, provides a vital second layer of security for your account. It means that even if someone were to learn your password, they couldn't authorize actions without a second piece of information, like a code from an authenticator app on your phone. Let's click on Turn on MFA. The second layer of protection comes from a code on an authenticator app in your phone. There are plenty of such apps that can be downloaded, and using one of them, scan the QR code on your screen. Then use the one‑time code that has popped up on your app and type it in here, and click on Continue. We are now back to the earlier page. Click on Connect to GitHub once more and then click on Continue to GitHub on this pop‑up. We need to install and authorize the ChatGPT connector to connect your GitHub account. We can choose to do it for all repositories or only on select ones. Let's click on Install and authorize. Then, we need to create a starting environment, so we go down the list of our repos and select the TODO‑APP one, and there we go. setup is now comple