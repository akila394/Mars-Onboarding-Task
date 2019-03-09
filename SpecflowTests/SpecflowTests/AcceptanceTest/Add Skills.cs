using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using static SpecflowPages.CommonMethods;
using RelevantCodes.ExtentReports;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkills 
    {
        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Click on Skills button
            Driver.driver.FindElement(By.XPath("//form/div[1]/a[2]")).Click();

            //Click on Add new skill button
            Driver.driver.FindElement(By.XPath("//form/div[3]/div/div[2]/div/table/thead/tr/th/div")).Click();

            //Add the Skill
            Driver.driver.FindElement(By.XPath("//form/div[3]/div/div[2]/div/div/div/input")).SendKeys("C#");

            //Select Skill Level
            SelectElement skillLevel = new SelectElement(Driver.driver.FindElement(By.XPath("//form/div[3]/div/div[2]/div/div/div[2]/select")));
            skillLevel.SelectByValue("Intermediate");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//form/div[3]/div/div[2]/div/div/span/input[1]")).Click();

            
        }
        
        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "C#";
                string ActualValue = Driver.driver.FindElement(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Added");
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
