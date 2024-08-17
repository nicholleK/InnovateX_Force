# InnovateX_Force
# Marketplace Project

Informatics 2B Group Project_'24

## Description

This project is a marketplace platform where students and local residents can buy and sell items. It features user registration, product listings, and a secure transaction process, designed to facilitate a smooth and efficient buying and selling experience.

## Features

- User registration and login
- Product listing and browsing
- Buying and selling of items
- Search and filter functionality
- Secure payment processing
- User profiles and feedback
- Mobile and desktop responsive design

## INSTALLATION and USAGE

## Using Git with VISUAL STUDIO: A Step-by-Step Guide

## 1. Setting Up Your Git Repository
Before you can start working with Git in Visual Studio, make sure your project is linked to a Git repository. If your project is not already under version control, you can create a new repository directly from Visual Studio:

-Initialize Git Repository:
Open your project in Visual Studio.
Go to View > Git Changes.
In the Git Changes window, click on the Initialize Repository button if your project is not yet linked to a Git repository.

-Link to Remote Repository:
To link your local repository to a remote one (e.g., GitHub), go to Git > Manage Remotes.
Click Add, enter the URL of your remote repository, and click OK.

## 2. Pulling Changes
Before you start making changes, it's crucial to pull the latest updates from the remote repository to avoid conflicts:

-Open Git Changes Window:
Go to View > Git Changes to open the Git interface in Visual Studio.

-Pull Latest Changes:
In the Git Changes window, click on the Pull button. This command fetches and integrates the latest changes from the remote repository into your local branch.
If there are any conflicts during the pull, Visual Studio will alert you and help you resolve them (more on this in the merge conflicts section).

## 3. Making and Committing Changes
After pulling the latest changes, you can start working on your code:

-Edit Your Code: 
Make changes to your files as needed.

-Stage Your Changes:
After making changes, go to the Git Changes window. You'll see a list of files that have been modified under the Changes section.
To stage specific changes, right-click on the file and select Stage. To stage all changes, click the Stage All button.

-Commit Your Changes:
In the Git Changes window, enter a descriptive commit message in the text box at the top.
Click the Commit Staged button to commit the staged changes to your local repository.

## 4. Pushing Changes to the Remote Repository
After committing your changes locally, you need to push them to the remote repository so your team can access them:

-Push Changes:
In the Git Changes window, click the Push button. This will push your local commits to the remote repository.
Ensure you have pulled the latest changes before pushing to avoid conflicts.

## 5. Handling Merge Conflicts
Sometimes, when multiple team members are working on the same files, merge conflicts can occur. Visual Studio provides tools to help resolve these conflicts:

-Conflict Notification:
If there is a conflict during a pull or push, Visual Studio will notify you in the Git Changes window.

-Open Conflict Resolution Tool:
Conflicted files will be listed under a Conflicts section in the Git Changes window.
Click on each conflicted file to open the conflict resolution tool.

-Resolve Conflicts:
The conflict resolution tool will show the conflicting changes side by side. You can choose to keep your version, the remote version, or manually edit the file to combine changes.
Once resolved, click Accept Merge to resolve the conflict.

-Stage and Commit Resolved Files:
After resolving the conflicts, stage the resolved files and commit them using the same process as outlined in the "Making and Committing Changes" section.

-Push the Resolved Changes:
Finally, push the resolved changes to the remote repository using the Push button.

## 6. Best Practices for Team Collaboration
-Pull Frequently: Always pull the latest changes before starting work to ensure your local repository is up to date.
-Commit Often: Make small, frequent commits with clear messages to make tracking changes easier.
-Use Branches: For new features or significant changes, create a new branch. This allows you to work independently without affecting the main branch.
-Communicate: Keep in touch with your team about the changes you’re making, especially if you’re working on the same files.

********************************************************************************************************************************************************************************

## Using Git from the TERMINAL: A Step-by-Step Guide

## 1. Setting Up Your Git Repository
  
-Initialize a New Git Repository:
Open your terminal or command prompt.
-Navigate to your project directory using the cd command
  ## cd path/to/your/project  
-Initialize a new Git repository:
  ## git init
-Link to a remote repository
  ## git remote add origin https://github.com/faffynicole/InnovateX_Force.git

## 2.Pulling Changes from the remote repo
-Fetch and Integrate Changes from Remote:
 Ensure you’re on the branch you want to update (e.g., master or main)
   ## git checkout master
-Pull the latest changes from the remote repository:
  ## git pull origin master
-If the histories are unrelated (e.g., if you’re combining two repositories), you may need to use:
  ## git pull origin master --allow-unrelated-histories

## 3. Making and Committing Changes
-Edit Your Code:
Make changes to your files as needed.
-Stage Your Changes:
-To stage all changes:
  ## git add .
-To stage specific files
  ## git add filename
-Commit your changes:
 Commit the staged changes with a descriptive message:
  ## git commit -m "Your commit message here"

## 4. Pushing Changes
-Upload Local Changes to Remote Repository:
Push your commits to the remote repository
  ## git push origin master

## 5. Handling Merge Conflicts
-Resolve Conflicts During Pull or Merge:
If you encounter merge conflicts during a pull or merge, Git will highlight the conflicted files.
Open the conflicted files and manually resolve conflicts by editing the file. Conflicts are marked with:
  ## <<<<<<< HEAD
  ## Your changes
  ##   =======
  ## Incoming changes
  ## >>>>>>> branch-name
  - Remove the conflict markers and make necessary adjustments.
-After resolving conflicts, stage the resolved files:
  ## git add your-resolved-file
-Commit the resolved changes:
  ## git commit -m "Resolved merge conflict"
-Push the resolved changes:
  ## git push origin master

## 6. Creating and Switching Branches
-Create a New Branch:
Create and switch to a new branch:
  ## git checkout -b new-branch-name
-Switch Between Branches:
To switch to an existing branch:
  ## git checkout branch-name


## 7. Viewing History
-View Commit History:
-To see the commit history for your current branch:
  ## git log
-To see a simplified, one-line history:
  ## git log --oneline

## 8. Syncing Your Repository
-Fetch and Merge Changes from Remote:
Fetch changes from the remote repository:
  ## git fetch origin
Merge the fetched changes into your current branch:
  ## git merge origin/master





