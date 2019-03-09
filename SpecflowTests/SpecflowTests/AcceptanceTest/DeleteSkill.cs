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
    public class DeleteSkill
    {
        [Given(@"I added a skill under profile page")]
        public void GivenIAddedASkillUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Skills button
            Driver.driver.FindElement(By.XPath("//form/div[1]/a[2]")).Click();
        }

        [When(@"I click on delete button on that skill")]
        public void WhenIClickOnDeleteButtonOnThatSkill()
        {
            //Click on Delete button
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[3]/span[2]/i")).Click();
        }
        
        [Then(@"Message should be displayed and skill should be removed from my listings")]
        public void ThenMessageShouldBeDisplayedAndSkillShouldBeRemovedFromMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill");

                Thread.Sleep(1000);

                bool visibleElement = ElementVisible(Driver.driver, "XPath", "//form/div[3]/div/div[2]/div/table/tbody/tr/td[1]");

                if (visibleElement == false)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added skill has been deleted successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Deleted");
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
