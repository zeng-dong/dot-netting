
# Refactor and optimize code

## identifying refactoring opportunities

Github Copilot VS Code Extension



Open Chat

type # to attach context
use @ to chat with extensions
type / to use commands

examples:
/fix the problems in my code
/tests add unit tests for my code
/explain how the selected code works

for OrderService.cs
* Please review this class and suggest refactoring ideans => o4  (I used gpt 5-mini)
* You are an expert senior programmer, please review this code and provide suggestions for making it more maintainable and following best practices => o3-mini
* Please review this code for resilience issues - does it handle errors appropriately => Claude 3.5 Sonnet

**Adage**‌
Give a man a fish, and you feed him for a day; teach a man to fish, and you feed him for a lifetime.
It's better to teach someone a skill than to give them charity.
Empowering others with knowledge is more valuable than providing temporary aid.

- _"Give a man a fish, he eats for a day; show him how to catch fish, he eats for a lifetime."_

## refactoring with Inline Chat



# Code Review

## importance
A code review is a structured process in which developers examine code changes before merging them into a shared branch.

they provide feedback on the logic, ensuring that your code changes are correct, but they also check readability and performance, and that there are no security risks, this ensures that the code is functional, well structured, and secure. 

So code reviews are important not only for the correctness of the code, but also to ensure that the code is maintainable and follow the project's coding standards. 

But you might be thinking, is it really that important to do code reviews, can't we just all trust each other to keep our code clean? Well, in the long run, it will make a big difference. It reduces bugs and technical debt. In code reviews, mistakes are often detected, so you will have fewer issues later. It also ensures that every developer uses best practices, keeping the code high quality and consistent in the project. Performance and maintainability will also be checked. Well structured and efficient code is easier to work with and scale. A good code review isn't about pointing out mistakes, it's also about helping each other improve the code base. If you are a junior or even a senior developer, every developer can learn from another, and code reviews can help with this, they can help spread the expertise across the team, improving collaboration. Now that we agree on why code reviews are important, the next question then becomes how are they really done, in other words, what steps should we follow to make sure the review is thorough and effective? Let's break it down. When reviewing code, we should follow these key steps. First, we need to understand the context of the changes, this is hopefully described in the pull request. We need to know which problem is solved, how it fits into the project, and if there are any points that the author asks us to focus on specifically. Next, we review the structure and the code consistency. Does the code follow the project guidelines? Is it formatted and structured in a way that makes sense? Then we check the code quality and maintainability, is the code easy to read and understand? Will future developers be able to work with it? Does the code have the required commands to understand it in, let's say, a few months? We will also check the code for edge cases and performance. Are the unhappy parts covered, or will the code fail when the flow doesn't go as expected? Is the code optimized for efficiency, or do you see any performance issues? Are there enough tests written to ensure that the new code behaves as expected? Also, here we check if the edge cases are covered. For all the potential issues we see, we provide constructive feedback. Don't just point out problems, but also suggest improvements. A code review shouldn't be a checklist, we need to think of it as a conversation about code changes. And lastly, improve or request changes. If everything looks good, the changes can be approved and merged into the shared branch. If you have discovered some issues or something is not clear for you, request changes in a constructive, clear, and actionable way, and follow up on the changes until you can approve the pull request. And, if you are not sure about something, you can always add an extra review to the pull request. All right, you are aligned. We now know that we need code reviews, and we know what we need to do to perform them. What we will do as mentioned, using GitHub Copilot, is a code review from two perspectives. Assume first, you're the developer who has written the code, and so before having someone else look at the code, we will look at it ourselves in a critical way. Instead of waiting for a reviewer to catch issues, we can use GitHub Copilot to already take a first look at our code, that's what we will look at in this module is the code review of our own code. Once we are done with that and we're pretty sure things can be reviewed by other developer, we will create a pull request. In the next module, we will look at how GitHub Copilot can help with that and also how it can help with the actual review, but then from the perspective of the good reviewer.

# review with copilot

### directly apply change
1. select the code (for example, GetEventsExportQueryHanlder.cs)
2. ctrl i and type "review": this will cause copilot to review and make changes without explanations
### review and explain
1. select the code (for example, GetEventsExportQueryHanlder.cs)
2. instead of "ctrl i and type "review"", right click to bring out context menu and select Copilot => Review and Commant
3. later versions of VS Code context menu changed: select code => right click to bring out context menu => Generate Code => Review
4. open a terminal window and go to "comments" tab, all review comments are there and can be navigated

### make copilot to use custom code styles (use custom instructions)
1. ctrl + shift + p => Preferences: Open Workspace Settings (JSON)
2. in here we can add custom instructions, for example 
 ```json
   {
    // "github.copilot.chat.codeGeneration.useInstructions": [
    //     {
    //         "file": "copilot/coding-styles.md"
    //     }
    // ],

    "github.copilot.chat.codeGeneration.useInstructionFiles": true,

    "github.copilot.chat.reviewSelection.instructions": [
        {
            "file": "copilot/coding-styles.md"
        }
    ] 
}
   ```
   3. create a folder under project: "copilot" and create a file: "code-styles.md"
   4. add some instructions in the code styles md file
   5. save
   6. now "review and explain" 
   7. we can see copilot apply our custom instructions

### review with chat
the above techniques are not using Github Copilot Chat 
1. Open Chat
2. type command: review code changes in #file:GetEventsExpo9rtQueryHandler.cs
3. pick a model, for example, Claude 3.7 Sonnet



## create a PR

"Generate commit message"

create a file: copilot/commit-messages.md
add to settings.json:


# Debug and Troubleshoot Code
* understanding and fixing errors
* diagnosing bugs and troubleshooting logic issues
* performance, concurrency, and legacy code troubleshooting
* create a bug report and unit tests

https://github.com/vriesmarcel/copilot_debug.git
<zdnote: to run all the services and app, need a sqlserver up and running, I used a docker container, I updated the password in the connection string>

## configure models, selecting your model

## troubleshooting
* explaining compiler and runtime errors
* analyzing stack traces
* getting targeted fixes for common c# , EF Core exceptions
* writing prompts to identify root causes
* 