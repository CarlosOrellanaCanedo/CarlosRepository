# CarlosRepository

# Blazor Automation Framework

Blazor Automation framework was created to test selenium on an example web page created with Blazor technology.

The test cases were executed using 2 formats, Unit Test and Specflow.

As a report manager, Extent Report was used in its community version, which allows us to generate a basic report, 
in which we can list the test cases and detail the steps that were executed, at the same time being able to take photos 
on the screen when it exists. an error and record the complete execution of the test case

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Download
* Chrome Browser version 81.
* Microsoft Expression Encoder 4 => link: https://www.microsoft.com/es-es/download/details.aspx?id=27870 (English languaje)

Execute the following command on: Tool > NuGet Package Manager > Package Manager Console if the package is does not exist on your Visual Studio
* Install-Package Microsoft.Expression.Encoder -Version 4.0.4276.3 => link: https://www.nuget.org/packages/Microsoft.Expression.Encoder/4.0.4276.3

Possible Errors:

A common error when starting the framework is not configuring the driver, and you can see the following error when executing a test case:

OpenQA.Selenium.DriverServiceNotFoundException : The file \\Blazor.UnitTest\bin\Debug\Drivers\chromedriver.exe does not exist. The driver can be downloaded at http://chromedriver.storage.googleapis.com/index.html

Solution: 
Go to Blazor Solution > Blazor.Core > expand Drivers folder
Right click on chromedriver.exe
Click properties, a Properties windows is displayed
Select 'Copy always' option, on Copy to Output Directory.
```

### Installing

* Go to Download file and execute Encoder_en.exe
* The installation doesn't required a Product Key, only click on next.
* When complete the installation the framework is already to execute test cases.

## Running the tests


To Execute the Acceptance test case for Unit Test or Specflow on Visual Studio IDE:
* Go to Test > Test Explorer, All test cases should be displayey in the Text Explorer window.
* Select any test cases and run.
* When the test cases complete the execution a Folder C:\Results will be created.
* On C:\Results\ folder you will be able to access to:
  - ImagesAndVideos folder: All videos and image are saved here.
  - BlazorFailedTestAndMessage.txt file contains a detail of all failed test cases and error message
  - BlazorFailedTest.txt file contains a list with all failed test cases name
  - BlazorReportTest.html file contains a list with all test cases executed, steps and status. Also Image and video link.
  - Logs-YYYYMMDD.txt file contains a logs per day of all test cases and steps executed.
   

### And coding style tests

## Deployment

## Built With

## Contributing

* Carlos Orellana

## Versioning

* GitHub

## Authors

* **Carlos Orellana** - *POC - Blazor* 

## License

## Acknowledgments

