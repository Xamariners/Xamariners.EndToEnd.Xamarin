# Introduction 
Xamariners.EndToEnd.Xamarin is a library to help script codeless UI test for Xamarin using Specflow and using Gherkin Language

# Getting Started
You can see the sample how to use it in the `Demo` folder. 

Installation:
1. Create  `Xamarin.UITest Cross Platform Test Project`
2. Ensure that this project targets .NET Framework 4.6. or higher - notcore not supported on appcenter - although supporterd for local runs
3. Add needed nuget packages. Packages that needs to be installed in your unit test project is
   - `NUnit3TestAdapter`
   - `SpecFlow.Tools.MsBuild.Generation`
4. Add a `NUnitAssemblyHooks.cs` as per the demo project
   - This is required to AppCenter be able to finish the tests without crashing, since there will be two or more projects for UI tests
5. Add `App.config` as per the demo project
6. Add JSON file 'TestConfig.json' to have the tests configuration for local runs
7. Final steps is to write feature and steps for your unit test using Gherkin Language https://cucumber.io/docs/gherkin/reference/
8. Each feature must have a partial class that will inherit from `BaseFeature`
   - These classes should be created to have `TestFixture` for Android and iOS and to parse `Platform`

# Setup
## Android
* Create an APK file for your project. You can get that by archiving the project. You don't need to sign the APK file, since the test project will sign it again before deploying.
* Make sure that you have `ANDROID_HOME` environment variable setup on you computer.
* Setup the path for the APK file on JSON config file.

## iOS
* The test project for iOS can run only from Visual Studio for Mac.
* Create an APP file/folder for your project. On Mac computer you can get that by rebuilding the project. You will find it under bin/{device}/{configuration}/device-builds/{deviceType}/{appName}.app.
* For iOS device you need to install the application on the phone, since for devices the test project can't install the application.
* Get the proper device and simulator identifiers and setup on JSON config file. You can get these identifiers on Xcode by clicking on Window -> Devices and Simulators.
* Setup the bundle name and app name on JSON config file. You can get those informations on iOS project properties.

# Features
`Xamariners.EndToEnd.Xamarin` provide some shared steps that you can use to write your BDD Tests.
Some of the shared steps is :
1. Navigation Steps:
   - I navigate back
   - I am on "string" page

2. Check Steps:
   - I can see "string"
   - I can see label "string" text "string"
   - I can see label marked "string"
   - I can see label with text "string"
   - I can see label containing text "string"
   - I can see element "string" disappears
   - I wait for element "string" 

3. Entry Steps
  - I enter "string" on entry "string"
  - I dont clear and enter "string" on entry "string"
  - I can see entry "string" text "string"
  - I can see entry marked "string"
  - I can see entry with text "string"

4. Scroll Steps
- I scroll down to element "string"
- I scroll up to element "string"
- I scroll to element "string"

5. Touch Steps
- I tap on "string" button
- I tap on "string" button at index "int"
- I double tap on "string" button
- I drag from element "string" and drop at element "string"
- I flash element "string"

6. WebView Steps
- I flash webview element "string"
- I scroll webview to coordinates x "float" and y "float"
- I scroll down webview to element "string"
- I scroll up webview to element "string"

For implementations of how this implemented, you can check on `Xamariners.EndToEnd.Xamarin` in `SharedSteps` folder

# Customize
STEPS:
To implement new steps:
Create a new class that inherits 'StepBase' and is decorated with [Binding] attribute
Follow specflow guidelines to bind your steps using regex - (ie.  [Given(@"I am on ""([^""]*)"" page")] or use the specflow or DeveRoom VS extensions to do that for you

SETUP HOOKS
To execute logic before or after features and scenarios and many other niceties (check specflow documentation):
Create a new class, inheriting from 'SetupHooksBase' and is decorated with [Binding] attribute

# Build and Test
For building the project, build the `src` folder.