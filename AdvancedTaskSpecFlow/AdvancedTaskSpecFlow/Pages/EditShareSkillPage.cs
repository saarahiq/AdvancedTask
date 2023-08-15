using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoIt;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using MongoDB.Bson;
using AdvancedTaskSpecFlow.Models;

namespace AdvancedTask.Pages
{
    public class EditShareSkillPage
    {
        readonly IWebDriver driver;
        public EditShareSkillPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement Title => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
        private IWebElement Description => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
        private IWebElement CategoryDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select"));
        private IWebElement SubCategoryDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));
        private IWebElement Tags => driver.FindElement(By.ClassName("ReactTags__tagInputField"));
        private IWebElement StartDateDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
        private IWebElement EndDateDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
        private IWebElement CreditAmount => driver.FindElement(By.Name("charge"));
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[2]"));

        public void editShareSkill(string title, string description, string category, string subCategory, List<string> tagsToRemove, List<string> tagsToAdd, string serviceType, string locationType, AvailableDaysModel availableDays, string skillTrade, string credit, List<String> skillExchangeTagsToRemove, List<String> skillExchangeTagsToAdd, string workSampleFilename, string active)
        {
            Thread.Sleep(1500);
            Title.SendKeys(Keys.Control + "A");
            Title.SendKeys(Keys.Backspace);
            Title.SendKeys(title);

            Description.SendKeys(Keys.Control + "A");
            Description.SendKeys(Keys.Backspace);
            Description.SendKeys(description);

            SetCategoryAndSubCategory(category, subCategory);
            SetTags(tagsToRemove, tagsToAdd);

            IWebElement serviceTypeRadioButton = driver.FindElement(By.XPath($"//input[@name='serviceType' and following-sibling::label[text()='{serviceType}']]"));
            serviceTypeRadioButton.Click();

            IWebElement locationTypeRadioButton = driver.FindElement(By.XPath($"//input[@name='locationType' and following-sibling::label[text()='{locationType}']]"));
            locationTypeRadioButton.Click();

            SetAvailableDays(availableDays);
            SetSkillTradeOptions(skillTrade, credit, skillExchangeTagsToRemove, skillExchangeTagsToAdd);

            SetFileToUpload(workSampleFilename);

            IWebElement activeRadioButton = driver.FindElement(By.XPath($"//input[@name='isActive' and following-sibling::label[text()='{active}']]"));
            activeRadioButton.Click();

            Thread.Sleep(500);
        }

        private void SetFileToUpload(string workSampleFilename)
        {
            // Upload Work 
            if (workSampleFilename != string.Empty)
            {
                IWebElement workSample = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
                workSample.Click();
                AutoItX.WinActivate("Open"); // Window name to select a file 
                Thread.Sleep(1000);
                AutoItX.Send(workSampleFilename); // file path 
                AutoItX.Send("{Enter}");
                Thread.Sleep(1000);
            }
        }

        private void SetSkillTradeOptions(string skillTrade, string credit, List<string> skillExchangeTagsToRemove, List<string> skillExchangeTagsToAdd)
        {
            IWebElement skillTradeRadioButton = driver.FindElement(By.XPath($"//input[@name='skillTrades' and following-sibling::label[text()='{skillTrade}']]"));
            skillTradeRadioButton.Click();

            // If skillTrade is "Skill-exchange", go inside the IF.
            if (skillTrade == "Skill-exchange")
            {
                // If skillTrade is "Skill-exchange" we want to first check if there are skill exchanges to remove first. Like above with the tags to remove and add.

                // If there are tags we want to remove then let's go ahead and remove them from the website
                if (skillExchangeTagsToRemove.Count >= 1)
                {
                    foreach (var tagToRemove in skillExchangeTagsToRemove)
                    {
                        if (tagToRemove != String.Empty)
                        {
                            try
                            {
                                IWebElement individualTagToRemove = driver.FindElement(By.XPath($"//span[@class='ReactTags__tag' and text()='{tagToRemove}']/a[@class='ReactTags__remove']"));
                                individualTagToRemove.Click();
                            }
                            catch (Exception ex)
                            {
                                Assert.Fail($"Unable to find the tag {tagToRemove} to remove it.");
                            }
                        }
                    }
                }
                // After that, I have to add the skills I want to Exchange
                if (skillExchangeTagsToAdd.Count >= 1)
                {
                    foreach (var skill in skillExchangeTagsToAdd)
                    {
                        if (skill != String.Empty)
                        {
                            SkillExchange.Click();
                            SkillExchange.SendKeys(skill);
                            SkillExchange.SendKeys(Keys.Return);
                        }
                    }
                }
            }
            else if (skillTrade == "Credit")
            {
                // I click on the Credit option so I have to add the Credit
                CreditAmount.Click(); CreditAmount.SendKeys(credit);
            }
        }

        private void SetAvailableDays(AvailableDaysModel availableDays)
        {
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(Keys.Delete + Keys.ArrowRight + Keys.Delete + Keys.ArrowRight + Keys.Delete + Keys.ArrowLeft + Keys.ArrowLeft + Keys.ArrowLeft);
            StartDateDropDown.SendKeys(availableDays.startDate);

            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(Keys.Delete + Keys.ArrowRight + Keys.Delete + Keys.ArrowRight + Keys.Delete + Keys.ArrowLeft + Keys.ArrowLeft + Keys.ArrowLeft);
            EndDateDropDown.SendKeys(availableDays.endDate);

            foreach (var dayAndTimes in availableDays.days)
            {

                var day = dayAndTimes.Key;

                var startTime = dayAndTimes.Value.startTime;

                var endTime = dayAndTimes.Value.endTime;

                var availableDayRow = driver.FindElement(By.XPath($"//div[@class='fields']//label[text()='{day}']/ancestor::div[@class='fields']"));

                var dayCheckBox = availableDayRow.FindElement(By.Name("Available"));

                if (dayCheckBox.Selected != true)
                {
                    // Run this line only if it's not checked already.
                    dayCheckBox.Click();
                }

                // Here we're just setting the start and end times for each Day we want selected.
                availableDayRow.FindElement(By.Name("StartTime")).SendKeys(startTime);
                availableDayRow.FindElement(By.Name("EndTime")).SendKeys(endTime);
            }
        }

        private void SetTags(List<string> tagsToRemove, List<string> tagsToAdd)
        {
            if (tagsToRemove.Count >= 1)
            {
                foreach (var tag in tagsToRemove)
                {
                    if (tag != String.Empty)
                    {
                        try
                        {

                            IWebElement tagToRemoveFromWebsite = driver.FindElement(By.XPath($"//span[@class='ReactTags__tag' and text()='{tag}']/a[@class='ReactTags__remove']"));
                            tagToRemoveFromWebsite.Click();
                        }
                        catch (Exception ex)
                        {

                            Assert.Fail($"Unable to find the tag {tag} to remove it.");
                        }
                    }
                }
            }
            if (tagsToAdd.Count >= 1)
            {

                foreach (var tag in tagsToAdd)
                {
                    if (tag != String.Empty)
                    {

                        Tags.Click();

                        Tags.SendKeys(tag);

                        Tags.SendKeys(Keys.Return);
                    }
                }
            }
        }

        private void SetCategoryAndSubCategory(string category, string subCategory)
        {
            if (category != "")
            {
                CategoryDropDown.Click();
                SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@name ='categoryId']")));
                select.SelectByText(category);
            }
            if (subCategory != "")
            {
                SubCategoryDropDown.Click();
                SelectElement selectSubCategory = new SelectElement(driver.FindElement(By.XPath("//select[@name ='subcategoryId']")));
                selectSubCategory.SelectByText(subCategory);
            }
        }

        public void saveEditShareSkill()
        {
            // Click on Save
            Save.Click();
        }

        public void cancelEditShareSkill()
        {
            CancelButton.Click();
        }

        public void verifyInvalidTitle(string titleErrorMessage)
        {
            IWebElement titleError = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div"));
            Assert.AreEqual(titleErrorMessage, titleError.Text, "Actual and expected title error message do not match ");
        }

        public void verifyInvalidTags(string tagsErrorMessage)
        {
            IWebElement tagsError = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div[2]"));
            Assert.AreEqual(tagsErrorMessage, tagsError.Text, "Actual and expected tags error message do not match");
        }

        public void verifyInvalidDescription(string descriptionErrorMessage)
        {
            IWebElement descriptionError = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[2]/div"));
            Assert.AreEqual(descriptionErrorMessage, descriptionError.Text, "Actual and expected description error message do not match");
        }

        public void verifyInvalidStartDateError(string startDateErrorMessage)
        {
            IWebElement startDateError = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div[2]"));
            Assert.AreEqual(startDateErrorMessage, startDateError.Text, "Actual and expected description error message do not match");
        }

        public void verifyInvalidEndDateError(string endDateErrorMessage)
        {
            IWebElement endDateError = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div[3]"));
            Assert.AreEqual(endDateErrorMessage, endDateError.Text, "Actual and expected description error message do not match");
        }
    }
}