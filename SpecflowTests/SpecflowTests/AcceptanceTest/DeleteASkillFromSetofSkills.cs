using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class DeleteASkillFromSetofSkills
    {
        List<string> skill = new List<string> { "C#", "Java", "Selenium" };
        string skillToBeDelete = "Java";
        
        [When(@"I click on delete button of given skill")]
        public void WhenIClickOnDeleteButtonOfGivenSkill()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Skills button
            Driver.driver.FindElement(By.XPath("//form/div[1]/a[2]")).Click();
            var xpathSkills = Driver.driver.FindElements(By.XPath("//i[@class='remove icon']"));
            for(int i =0; i<=skill.Count; i++)
             {
                if(skill[i] == skillToBeDelete)
                {
                    xpathSkills[i].Click();
                    break;
                }
             }
        }
        
        [Then(@"Given skill should be removed from the list and other should be displayed on my listings\.")]
        public void ThenGivenSkillShouldBeRemovedFromTheListAndOtherShouldBeDisplayedOnMyListings_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill");
                var noOfSkills = Driver.driver.FindElements(By.XPath("//tbody/tr"));

                Thread.Sleep(1000);

               

                    if (noOfSkills.Count == (skill.Count-1))
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
