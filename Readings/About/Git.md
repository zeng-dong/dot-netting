
# commands

## basics
git init
git add
git status
git commit
git config
git log
git diff

## branches
git branch
git checkout
git merge

## remote repositories
git clone
git remote
git push
git pull
git fetch

## undoing changes
git revert
git reset

曾东
## how to stash
1. simply run git stash
2. git status: working tree clean
3. now you can run other command: git checkout feature/nextbigthing
4. see the most recent stashed content: git stash show
5. see more stashed content: git stash list, and then git stash show stash@{yourIndex}
6. git stash apply; git stash pop
7. git stash drop yourIndex
8. git stash clear