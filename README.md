<div align="center">


 ![HierarchyRenamer](https://github.com/byeoon/HierarchyRenamer/assets/47872200/3b85e9ff-692f-4f38-bcb7-3da7aebe87be)
**Mass renames items in an asset hierarchy to make rigging bones and organizing your project easier.**


</div>

# 🌐 Installation and Setup
There are two ways you can download HierarchyRenamer. If you use the VRChat Creator Companion, you want to (TBD). If you are using normal Unity, download the unitypackage from Releases.
<!--
## 🚇 Migrating Assets Package
Full details at [Converting Assets to a VPM Package](https://vcc.docs.vrchat.com/guides/convert-unitypackage)

## ✏️ Working on Your Package

* Delete the "Packages/com.vrchat.demo-template" directory or reuse it for your own package.
  * If you reuse the package, don't forget to rename it!
* Update the `.gitignore` file in the "Packages" directory to include your package.
  * For example, change `!com.vrchat.demo-template` to `!com.username.package-name`.
  * `.gitignore` files normally *exclude* the contents of your "Packages" directory. This `.gitignore` in this template show how to *include* the demo package. You can easily change this out for your own package name.
* Open the Unity project and work on your package's files in your favorite code editor.
* When you're ready, commit and push your changes.
* Once you've set up the automation as described below, you can easily publish new versions.

## 🤖 Setting up the Automation

Create a repository variable with the name and value described below.
For details on how to create repository variables, see [Creating Configuration Variables for a Repository](https://docs.github.com/en/actions/learn-github-actions/variables#creating-configuration-variables-for-a-repository).
Make sure you are creating a **repository variable**, and not a **repository secret**.

* `PACKAGE_NAME`: the name of your package, like `com.vrchat.demo-template`.

Finally, go to the "Settings" page for your repo, then choose "Pages", and look for the heading "Build and deployment". Change the "Source" dropdown from "Deploy from a branch" to "GitHub Actions".

That's it!
Some other notes:
* We highly recommend you keep the existing folder structure of this template.
  * The root of the project should be a Unity project.
  * Your packages should be in the "Packages" directory.
  * If you deviate from this folder structure, you'll need to update the paths that assume your package is in the "Packages" directory on lines 24, 38, 41 and 57.

## 🎉 Publishing a Release

You can make a release by running the [Build Release](.github/workflows/release.yml) action. The version specified in your `package.json` file will be used to define the version of the release.

## 📃 Rebuilding the Listing

Whenever you make a change to a release - manually publishing it, or manually creating, editing or deleting a release, the [Build Repo Listing](.github/workflows/build-listing.yml) action will make a new index of all the releases available, and publish them as a website hosted fore free on [GitHub Pages](https://pages.github.com/). This listing can be used by the VPM to keep your package up to date, and the generated index page can serve as a simple landing page with info for your package. The URL for your package will be in the format `https://username.github.io/repo-name`.

## 💻 Technical Stuff

You are welcome to make your own changes to the automation process to make it fit your needs, and you can create Pull Requests if you have some changes you think we should adopt. Here's some more info on the included automation:

### Build Release Action
[release.yml](/.github/workflows/release.yml)

This is a composite action combining a variety of existing GitHub Actions and some shell commands to create both a .zip of your Package and a .unitypackage. It creates a release which is named for the `version` in the `package.json` file found in your target Package, and publishes the zip, the unitypackage and the package.json file to this release.

### Build Repo Listing
[build-listing.yml](.github/workflows/build-listing.yml)

This is a composite action which builds a vpm-compatible [Repo Listing](https://vcc.docs.vrchat.com/vpm/repos) based on the releases you've created. In order to find all your releases and combine them into a listing, it checks out [another repository](https://github.com/vrchat-community/package-list-action) which has a [Nuke](https://nuke.build/) project which includes the VPM core lib to have access to its types and methods. This project will be expanded to include more functionality in the future - for now, the action just calls its `BuildRepoListing` target.
-->
