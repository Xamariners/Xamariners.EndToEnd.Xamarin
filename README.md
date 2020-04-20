# Introduction 
Xamariners.EndToEnd.Xamarin is a library to help UI test for Xamarin using Specflow and using Gherkin Language.

# Getting Started
You can see the sample how to use it in the `Demo` folder. 
Installation:
1. Create  `Xamarin.UITest Cross Platform Test Project`
2. Ensure that this project targets .NET Framework 4.6.1 or higher
3. Add needed nuget packages. Packages that needs to be installed in your unit test project is
   - `NUnit3TestAdapter`
   - `SpecFlow.Tools.MsBuild.Generation`
4. Add `Local` configuration for project and add `__LOCAL__` on conditional compilation symbols
5. Create an overload for `public static IApp StartApp` on `AppInitializer` to be able to run with configuration file
6. Add `BaseAppInitializer` that inherits from `IBaseAppInitializer`
7. Create `CommonSteps.cs` that inherits from `Xamariners.EndToEnd.Xamarin.SharedSteps.CommonSteps` and bind it to your project with `[Binding]`
8. Copy `NUnitAssemblyHooks.cs` from Demo project
   - This is required to AppCenter be able to finish the tests without crashing, since there will be two or more projects for UI tests
9. Add `specflow.json`
10. Add JSON file to have the tests configuration for local runs
   - On Demo project it's called `testsConfiguration.json`
   - It must follow the model `Xamariners.EndToEnd.Xamarin.Models.`
11. Add `BaseLocalFeature.cs` that will inherit from `Xamariners.EndToEnd.Xamarin.Features.BaseFeature`
   - Initialize `BaseAppInitializer` from constructor
12. Final steps is to write feature and steps for your unit test using Gherkin Language https://cucumber.io/docs/gherkin/reference/
13. Each feature must have a partial class that will inherit from `BaseLocalFeature`
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

# Feature
`Xamariners.EndToEnd.Xamarin` provide some shared steps that you can use to write your BDD Tests.
Some of the shared steps is :
1. Navigation Steps:
   - (Given / When / Then) I navigate back
2. Shared Steps:
   - (Given / When / Then) I am on "string" page
   - (Given / When / Then) I can see "string"
   - (Given / When / Then) I tap on "string" button
   - (Given / When / Then) The label "string" text is "string"
   - (Given / When / Then) I enter "string" on entry "string"
   - (Given / When / Then) I can see a label marked as "string"
   - (Given / When / Then) I can see a label with text "string"
   - (Given / When / Then) The entry "string" text is "string"
   - (Given / When / Then) I can see an entry marked as "string"

For implementations of how this implemented, you can check on `Xamariners.EndToEnd.Xamarin` in `SharedSteps` folder

# Build and Test
For building the project, build the `src` folder.
