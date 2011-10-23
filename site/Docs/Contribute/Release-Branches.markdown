# Release Branches

When preparing for a major release, the NuGet team will create a branch for the release typically called a "release branch". 
For example, when preparing for the 1.0 release of NuGet, we created a 1.0 branch.
This allows general development for the next release (such as 1.1) to continue in the **Default** branch 
while we make any last minute changes for the 1.0 branch can happen in isolation.

If you need to make a bug fix change to a release branch, here's a small tutorial of the process.

A branch is just like a named changeset. To update to the 1.0 branch use `hg up 1.0`. To go back to main use 
`hg up default`.

## Making a Bug Fix to the 1.0 branch

When we start making new changes, default and 1.0 will naturally diverge.

![default and 1.0 diverge](images/default-and-1.0-diverge.jpg)

When you go to make a bug fix that we want for 1.0, update to the 1.0 branch, make the fix and commit it.

![1.0 update to 1.0 branch](images/1.0-update-to-1.0-branch.jpg)

To port a bug to default from 1.0, we first update to default (using `hg up default`), then merge with the 1.0 branch (`hg merge 1.0`). Don't forget to commit the merge.

![merge with 1.0 branch](images/merge-with-1.0-branch.jpg)

We can continue to make changes on default and further bug fixes on the 1.0 branch and merge as necessary.

![further bug fixes on 1.0 branch](images/further-bug-fixes-on-1.0-branch.jpg)

One helpful feature in Tortoise is the branch selection drop down, which hides all the changes that are not in the branch you care about, so you just see one head:

![branch selection drop-down](images/branch-selection-drop-down.jpg)

Click the All radio button on the far left to go back to unfiltered view.