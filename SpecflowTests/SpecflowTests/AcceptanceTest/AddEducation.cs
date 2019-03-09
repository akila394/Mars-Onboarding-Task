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
    public class AddEducation
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            // Click on Education tab
            Driver.driver.FindElement(By.XPath("//form/div[1]/a[3]")).Click();


        }

        [When(@"I add a new Education")]
        public void WhenIAddANewEducation()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            //Select Country of College 
            SelectElement country = new SelectElement(Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")));
            country.SelectByValue("Australia");

            //Enter Colege/University
            Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")).SendKeys("University of Melbourne");

             //Select Title 
            SelectElement title = new SelectElement(Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/div/div[2]/div/select")));
            title.SelectByValue("B.Sc");

            //Enter Degree
            Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")).SendKeys("Statistics");

            //Select Year of graduation 
            SelectElement yearOfGraduation = new SelectElement(Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")));
            yearOfGraduation.SelectByValue("2015");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("(//form/div[4]/div/div[2]/div/div/div[3]/div/input)[1]")).Click();

        }

        [Then(@"that Education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "University of Melbourne";
                string ActualValue = Driver.driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Education record Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Education Added");
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
