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
    public class AddHours
    {
        [Given(@"I clicked on the hours tab under Profile page")]
        public void GivenIClickedOnTheHoursTabUnderProfilePage()
        {
            //Click on Hours
            Driver.driver.FindElement(By.XPath("//div[3]/div/div[3]/div/span/i")).Click();
        }
        
        [When(@"I select hours from drop down list")]
        public void WhenISelectHoursFromDropDownList()
        {
            //Select Hours from dropdown list
            SelectElement hours = new SelectElement(Driver.driver.FindElement(By.XPath("//div[3]/div/div[3]/div/span/select")));
            hours.SelectByValue("2");
        }
        
        [Then(@"that hours should be displayed in profile")]
        public void ThenThatHoursShouldBeDisplayedInProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Hours");

                Thread.Sleep(1000);
                string ExpectedValue = "As needed";
                string ActualValue = Driver.driver.FindElement(By.XPath("//div[3]/div/div[3]/div/span")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added number of hours");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Hours Added");
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
