using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddDescription
    {
        [Given(@"I clicked on the Description tab under Profile page")]
        public void GivenIClickedOnTheDescriptionTabUnderProfilePage()
        {
            //click on description tab
            Driver.driver.FindElement(By.XPath("//h3[1]/span/i")).Click();
            Thread.Sleep(200);
        }
        
        [When(@"I add a new description and click save button")]
        public void WhenIAddANewDescriptionAndClickSaveButton()
        {
            //Clear current description
            Driver.driver.FindElement(By.Name("value")).Clear();

            Thread.Sleep(300);

            //Add description
            Driver.driver.FindElement(By.Name("value")).SendKeys("IT graduate with 5 years of experience in software testing");

            //Click on save button
            Driver.driver.FindElement(By.XPath("//form[1]/div/div[1]/div[2]/button")).Click();
        }
        
        [Then(@"that description should be displayed in profile")]
        public void ThenThatDescriptionShouldBeDisplayedInProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Description");

                Thread.Sleep(1000);
                string ExpectedValue = "IT graduate with 5 years of experience in software testing";
                string ActualValue = Driver.driver.FindElement(By.XPath("//section[2]/div/div/div/div[3]/div/div/div/span")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Description Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Description Added");
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
