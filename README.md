# Sitecore ImageAnalyzer
The Sitecore Image Analyzer brings the power of Microsofts Cognitive Services to your Sitecore solution! This little extension uses the image analysis feature to automaticly fill up your "Alternative"-Information on each image directly into your content system. 

## Prerequisite
To use this tool, you need a valid Microsoft Azure Subscription and an active `Cognitive Services account (Computer Vision API)`. To create this service, please visit the official Microsoft Site under [https://www.microsoft.com/cognitive-services/en-us/computer-vision-api](https://www.microsoft.com/cognitive-services/en-us/computer-vision-api)

## Installation
Use `Install-Package Namics.Opensource.SitecoreImageAnalyzer` to install the package directly or visit our [Nuget Page](https://www.nuget.org/packages/Namics.Opensource.SitecoreImageAnalyzer/) for more instructions.

## Configuration

After Installation you need to modify your new configuration file called [Namics.Opensource.SitecoreImageAnalyzer.config](https://github.com/daniiiol/SitecoreImageAnalyzer/blob/master/Namics.Opensource.SitecoreImageAnalyzer.Processor/Configs/Namics.Opensource.SitecoreImageAnalyzer.config) and set your personal Visions-API AccessKey under: 

    <setting name="Namics.OpenSource.SitecoreImageAnalyzer.SubscriptionKey" value ="{AddYourKeyHere}" /> 

Finished!

## Demo

![Demo Usage](https://github.com/daniiiol/SitecoreImageAnalyzer/blob/master/docs/demo-usage.gif)