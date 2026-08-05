[Creating Developer Documentation with GitHub Copilot](https://app.pluralsight.com/library/courses/creating-developer-documentation-github-copilot)
[Navigating and Analyzing Codebases with GitHub Copilot](https://app.pluralsight.com/library/courses/navigating-analyzing-codebases-github-copilot)
[GitHub Copilot Code Review](https://app.pluralsight.com/library/courses/github-copilot-code-review)
[Debug and Troubleshoot Code with GitHub Copilot](https://app.pluralsight.com/library/courses/debug-troubleshoot-code-github-copilot)
[Secure Development with GitHub Copilot](https://app.pluralsight.com/library/courses/secure-development-github-copilot)
[Writing Tests with GitHub Copilot](https://app.pluralsight.com/library/courses/writing-tests-github-copilot)
[Refactor and Optimize Code with GitHub Copilot](https://app.pluralsight.com/library/courses/refactor-optimize-code-github-copilot)
[CI/CD Integration with GitHub Copilot](https://app.pluralsight.com/library/courses/ci-cd-integration-github-copilot)

## Building Production AI Agents with Microsoft Foundry


## Agentic AI Fundamentals in the Microsoft Ecosystem


## GH-300: GitHub Copilot: Using GitHub Copilot Features


## GitHub Copilot Fundamentals: AI Agents
Aaron Stewart

## Building Agents with Microsoft Agent Framework

by Muhammad Sajid

## GH-300: GitHub Copilot: Understanding GitHub Copilot Data and Architecture
by Praveenkumar Bouna

### Understanding data handling and flow

#### Copilot data handling overview

What data is GitHub Copilot actually processing, and where does it go after your session ends? 

How Copilot handles your prompts, your code, and your organization's information across every service where it operates. 

The foundation, a data handling overview. 

GitHub Copilot processes four distinct categories of data. 
##### The first two categories are the most visible. 
1. Input data is everything you send to Copilot, your prompts, attached files, workspace code, and conversation history. 
2. Output data is everything Copilot sends back, the code suggestions, completions, and chat responses you see in your editor. 
 
	These two categories move together in every interaction, regardless of which service you use. 

##### The third and fourth categories are less visible, but equally important for compliance purposes. 
3. User engagement data captures anonymized records of how you interact with Copilot, which completions you accepted or dismissed, any errors that surfaced, and usage metrics that reflect how the tool is being used across your team. 
4. The fourth category, feedback data, covers the real‑time reactions you provide, a thumbs up or thumbs down on a response, optional comments, or a support ticket you raise. 
 
This data flows across every service where Copilot is available.
	inline code suggestions in your editor, 
	Copilot Chat, 
	the Copilot CLI, 
	the GitHub mobile app  
	directly on GitHub.com. 
The same four categories apply consistently. Regardless of which service you use, the same types of data are in play. 

Not all four categories follow the same retention rules. 
By default, your input and output data, your prompts and Copilot's responses, are not retained by default after your session. 
GitHub may hold them for a limited period for investigation and security purposes. 

User engagement data, by contrast, is kept for 2 years. 

Feedback data is stored for as long as it serves its intended use. 

The question of AI model training is where the distinction between Copilot plans matters most. If your organization is on Copilot Business or Enterprise, your input and output data is covered under GitHub's data protection agreement, which explicitly prohibits using that data to train AI models without your authorization. Individual subscribers operate under a different arrangement. Their prompt data may contribute to model improvement, though they retain the ability to opt out of that sharing. For example, imagine a company like Globomantics that builds e‑commerce applications. Their development teams use GitHub Copilot Business or Enterprise, which means every prompt a developer sends, every piece of checkout logic, every API call they ask Copilot to complete is covered by the data protection agreement. What the Globomantics team should still account for is the limited retention window GitHub holds for security and investigation purposes. Their data does not feed back into AI model training. That addresses one of the most common compliance concerns teams raise before rolling Copilot out at scale.