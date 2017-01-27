# Sitecore ImageAnalyzer

## Prerequisite
To use this tool, you need a valid Microsoft Azure Subscription and an active `Cognitive Services account (Computer Vision API)`. To create this service, please visit the official Microsoft Site under [https://www.microsoft.com/cognitive-services/en-us/computer-vision-api](https://www.microsoft.com/cognitive-services/en-us/computer-vision-api)

## Installation
Use `Install-Package Namics.Opensource.SitecoreImageAnalyzer` to install the package directly or visit our [Nuget Page](https://www.nuget.org/packages/Namics.Opensource.SitecoreImageAnalyzer/) for more instructions.

## Configuration

After Installation you need to modify your new configuration file called `Namics.Opensource.SitecoreImageAnalyzer.config` and set your personal API access key under: 

    <setting name="Namics.OpenSource.SitecoreImageAnalyzer.SubscriptionKey" value ="{AddYourKeyHere}" /> 

Finished!

## Demo

![Demo Usage](https://github.com/daniiiol/SitecoreImageAnalyzer/blob/master/docs/demo-usage.gif)