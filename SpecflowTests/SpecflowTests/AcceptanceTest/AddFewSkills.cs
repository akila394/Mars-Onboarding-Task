using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    public class AddFewSkills
    {
        List<string> skill = new List<string> { "C#", "Java", "Selenium" };
        List<string> skillLevel = new List<string> { "Beginner", "Expert", "Expert" };
        [When(@"I add few skills")]
        public void WhenIAddFewSkills()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Skills button
            Driver.driver.FindElement(By.XPath("//form/div[1]/a[2]")).Click();

            foreach (string s in skill)
            {
                for (int i = 0; i <= skillLevel.Count; i++)
                {

                    if (i == skill.IndexOf(s))
                    {

                        Thread.Sleep(1000);
                        
                        //Click on Add new skill button
                        Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();

                        //Add the Skill
                        Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(s);

                        //Select Skill Level
                        SelectElement skillLevelselect = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")));
                        skillLevelselect.SelectByValue(skillLevel[i]);

                        //Click on Add button
                        Driver.driver.FindElement(By.XPath("//input[@class='ui teal button ']")).Click();
                
                    }

                }
            }

        }

        [Then(@"All added skills should be displayed on my listings")]
        public void ThenAllAddedSkillsShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add  skills");
                var xpathSkills = Driver.driver.FindElements(By.XPath("//tbody/tr/td[3]/span[2]/i"));
                
                
                for (int i = 0; i <= 2; i = i + 1)
                {

                    Thread.Sleep(500);
                    if (xpathSkills[i].Enabled)
                    {

                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a "+skill[i]+ " skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "Skill Added");
                    }

                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");


                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

       
    }
}
