# This fork is using PowerMill function extract() to significantly improve the APIs reading speed.
- Forked from Autodesk/PowerShapeAndPowerMillAPI. 
- PowerMill only -> use CustomSoftwareCorePowerMillOnly.sln only.
- The original CustomSoftwareCore.sln and all files are still in this repository.
- Modified to work with SharpDevelop IDE.
- Unit testing updated to NUnit.3.13.2 linked with projects and included  into repository UnitTest/NUnit.3.13.2
- The UnitTest framework and tests code updated and successfully run with SharpDevelop (CustomSoftwareCorePowerMillOnly.sln only).
- Unit tests should be running without any additional setups after cloning this repository and using SharpDevelop IDE (CustomSoftwareCorePowerMillOnly.sln only).
- Reverting to use VisuaStudio IDE and the original CustomSoftwareCore.sln for any other sub forks is possible. 

---------------------------------------------------------------------------------



![Banner](Banner.png)

# PowerShape and PowerMill API
Welcome to the Autodesk PowerShape and PowerMill API, this API provides the ability to automate both PowerShape and PowerMill. The API is full of useful libraries to allow handling a wide variety of PowerShape and PowerMill tasks using macro commands. 

To learn more about PowerShape and PowerMill API visit the forum [here](https://forums.autodesk.com/t5/powershape-and-powermill-api/getting-started-with-powershape-and-powermill-api/td-p/6868839)

To Contribute please see [Contribute.md](Contribute.md). 

The extension is distributed under the MIT license. See [LICENSE.txt](LICENSE.txt).

## Get started
Should be very simple:

1) Open Github for windows and clone the repo

2) Open solution (with Visual Studio 2015 with at least Update 2)

3) Microsoft .NET Framework 4 and 4.5

4) Build

## Test Data
Test data is stored in git lfs and there are some large files so be prepared for a longer checkout.
PowerShape and PowerMill tests will require a version of the product installed to run the tests.

## Contributions
In order to clarify the intellectual property license granted with Contributions from any person or entity, Autodesk must have a Contributor License Agreement ("CLA") on file that has been signed by each Contributor to this Open Source Project (the “Project”), indicating agreement to the license terms. This license is for your protection as a Contributor to the Project as well as the protection of Autodesk and the other Project users; it does not change your rights to use your own Contributions for any other purpose. There is no need to fill out the agreement until you actually have a contribution ready. Once you have a contribution you simply fill out and sign the applicable agreement (see the contributor folder in the repository) and send it to us at the address in the agreement.

