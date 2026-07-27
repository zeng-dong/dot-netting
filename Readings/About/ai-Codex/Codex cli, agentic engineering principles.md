# what is Codex CLI

the mental model 
what problem it solves

a terminal-first, sandboxed, open-source coding agent that reads your repository, runs your tests, makes commits, and follows project-specific instructions in a plain Markdown file.

## learning objectives
* Explain the difference between autocomplete, chat-based, and agentic AI coding assistance to a colleague or team lead
* Place Codex CLI on a map of the current tool landscape, with an un-derstanding of what distinguishes it from Claude Code, Cursor, GitHub Copilot, Cline, and the cloud-hosted agents
* Articulate the four capabilities, read repo, run tests, make commits, follow AGENTS.md, that define Codex CLI’s core proposition

## Before Codex: A Brief History
### The Codex model (2021)
Two properties of that original model shaped everything that followed.

First, it was generative, producing code token-by-token from a prompt, which meant it could complete partial functions, translate between languages, and explain its own output in natural language. 

Second, it was optimised around a completion metaphor: you gave it a docstring and it returned an implemen-tation. That interaction model defined the first commercial era of AI-assisted coding.

### GitHub Copilot and the autocomplete paradigm (June 2021)

On 29 June 2021, GitHub launched GitHub Copilot as a technical preview, powered by the Codex model.

### The ChatGPT shift (November 2022)
ChatGPT was not designed as a coding tool, but it surfaced something the autocomplete paradigm had obscured: the model was capable of multi-step reasoning, constraint application, and task decomposition. 

It just needed an interface that allowed the conversation to span multiple exchanges. 

The era of chat-based coding assistance had begun, and it would last until the next paradigm shift: agency.

## The Problem with Autocomplete

Autocomplete operates on a single context window at a single moment in time

This is not a model capability problem; it is an interface problem. A model sophisticated enough to reason about multi-file systems and iterative test feedback cannot exercise those capabilities when the interface only allows it to see one file at one moment and produce one completion.

The shift from autocomplete to chat helped, because chat interfaces allow multi-turn reasoning. But chat still requires a human to copy-paste error messages, fetch relevant file contents, and relay test results.
The human bridges the model and the development environment.

The agentic pattern eliminates that bridge.

Instead of relaying information, you give the model tools to access the environment directly: read this file, run this command, write this output, commit this change. The model can then complete a multi-step task, read the failing test, find the implementation, fix the bug, run the test again, commit if it passes, without a human relay at each step.

What does ‘agentic’ mean in this context? 
The model has agency: the ability to take actions in the real environment rather than merely suggesting text for a human to act on. 
An agentic tool reads files, executes shell commands, observes outputs, and decides what to do next, all within a single session. 
The human sets the goal; the agent pursues it.

‘Agentic’ does not mean ‘autonomous and unsupervised.’ 
Codex CLI supports multiple approval modes, including interactive modes that require your confirmation before any write or command. The agentic pattern gives the model the capability to access the environment; it
does not remove human oversight from the loop.

## The 2026 Agentic Landscape
The landscape divides into three categories based on where the agent lives: inside the editor, inside the terminal, or in the cloud.

### Category 1: IDE-integrated agents

### Category 2: Terminal agents

### Cloud and hosted agents

