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
    public class AddFewLanguges
    {
        [Given(@"I clicked on the Language tab under profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

        }

        [When(@"i add (.*) and (.*)")]
        public void WhenIAddAnd(string p0, string p1)
        {
            var noOfLanguages = Driver.driver.FindElements(By.XPath("(//table[@class='ui fixed table'])[1]/tbody"));
            if (noOfLanguages.Count < 4)
            {
                Thread.Sleep(300);
                //Click on Add New button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

                //Add Language
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")).SendKeys(p0);

                //Select Skill Level
                SelectElement skillLevel = new SelectElement(Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown']")));
                skillLevel.SelectByValue(p1);

                //Click on Add button
                Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
            }
            else
                Console.WriteLine("Maximum no of languages for the profile reached");
            
        }
        
      

        [Then(@"that (.*) should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings(string p0)
        {
            var noOfLanguages = Driver.driver.FindElements(By.XPath("(//table[@class='ui fixed table'])[1]/tbody"));
            if (noOfLanguages.Count < 4)
            {
                try
                {
                    //Start the Reports
                    CommonMethods.ExtentReports();
                    Thread.Sleep(1000);
                    CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                    Thread.Sleep(1000);
                    string ExpectedValue = p0;
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language Added");
                    }

                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

                }
                catch (Exception e)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                }
            }
            else
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language can't add. Maximum language count reached");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Language Added");
                Console.WriteLine("Language can't be able to added");
            }

        }

    }
}
