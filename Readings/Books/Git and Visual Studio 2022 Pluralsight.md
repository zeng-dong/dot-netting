# Configure Git in VS
Git -> Settings -> Source Control -> Git Global Settings
User name
Email
Git uses these two for each commit

# Create a local git repo for our console app
once a solution/project is loaded, several ways to create a local repo:
- Git -> Crate Git Repository ...
- use the bottom status bar: Add to Source Control -> select Git: and it brings up the dialog, fill the fields -> Create and Push (or select Local Only and then Create)

## configure Git in Visual Studio
to config default main branch name on a machine level:
git config --global init.defaultbranch main

to list config:
git config --global -l

## pushing local repo to remote GitHub
in visual studio status bar, bring out Git Changes -> Push 
this bring up the Create a Git repository window, we can select GitHub or Azure DevOps, or existing remote

## clone a repo from GitHub
from the start window: Clone a repository -> input location, directory
You can browse your repos by clicking the GitHub link.

# Committing and Synchronizing Changes
