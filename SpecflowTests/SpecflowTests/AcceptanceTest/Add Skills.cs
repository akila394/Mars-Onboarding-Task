using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using static SpecflowPages.CommonMethods;
using RelevantCodes.ExtentReports;
using System.Collections.Generic;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkills 
    {
        List<string> skill = new List<string> { "C#", "Java", "Selenium" };
        List<string> skillLevel = new List<string> { "Beginner", "Expert", "Expert" };
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

            foreach (string s in skill)
            {
                for(int i=0; i <= skillLevel.Count;i++)
                {
                    
                    if (i == skill.IndexOf(s))
                    {
                        
                        Thread.Sleep(1000);
                        Console.WriteLine(skillLevel[i]);

                        //Click on Add new skill button
                        Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();

                        Console.WriteLine("-----------------");

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
        
        [Then(@"skill should be displayed on my listings")]
        public void ThenSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a skill");

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
