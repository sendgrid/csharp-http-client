We kindly ask you to follow this PR template so we can make the process easier. 

## Branch Workflow
We are using GitFlow as our Workflow, so we ask you to use our branch naming pattern. Basically, it consists on 2 main branchs and 2 name patterns: 
- We have the "master" branch, which is the production branch and the one that is available for using;
- We also have the "development" branch, where all the new features are implemented and tested before going to a release to the "master" branch;
- If you want to create a new feature, please fork from the "development" branch, create a new one using the pattern "feature/#number_of_the_issue" (e.g. "feature/#70") and make your normal pull request;
- If you want to fix a bug that is already in production, create a new branch using the pattern "hotfix/#number_of_the_feature" (e.g. "hotfix/#90").

If you want to learn more about the GitFlow, just access [this website here](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow). Just notice that we use "development" instead of "develop" as the branch's name. The "release" branchs we'll be made by the projects' maintainers.

## Pull Request
Please refer the issue that the PR is related to on its title and, for the message, explain briefly what you did. For example, if I wanted to make a Pull Request for Issue #75, which is a "bug" and has "Document new Git workflow in CHANGELOG" as title, my branch's name should be "hotfix/#75" and the PR must have this aspects:

**Title**: "#75: Document new Git workflow in CHANGELOG"

**Message**: "Changed the 'CONTRIBUTING' to talk about Branch Flow and created the 'PULL_REQUEST_TEMPLATE' to talk about how the PR should look like."