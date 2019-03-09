using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddAvailability
    {
        [Given(@"I clicked on the availability tab under Profile page")]
        public void GivenIClickedOnTheAvailabilityTabUnderProfilePage()
        {
            //Click on avalability tab
            Driver.driver.FindElement(By.XPath("//div[3]/div/div[3]/div/span/i")).Click();
        }
        
        [When(@"I select availability from drop down list")]
        public void WhenISelectAvailabilityFromDropDownList()
        {
            //Select availability from dropdown list
            SelectElement availability = new SelectElement(Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/span/select")));
            availability.SelectByValue("0");
        }
        
        [Then(@"that availability should be displayed in profile")]
        public void ThenThatAvailabilityShouldBeDisplayedInProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Availability");

                Thread.Sleep(1000);
                string ExpectedValue = "Part Time";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/span")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added the Availability");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Availability Added");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}
