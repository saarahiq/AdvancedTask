﻿using AdvancedTask.Models;
using AdvancedTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    public class ShareSkillPage
    {
        readonly IWebDriver driver;
        public ShareSkillPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Click on Manage Listings Button
        private IWebElement ManageListings => driver.FindElement(By.LinkText("Manage Listings"));
        private IWebElement EditButton => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));

        //Enter the Title in textbox
        private IWebElement Title => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));

        //Enter the Description in textbox
        private IWebElement Description => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));

        //Click on Category Dropdown        
        private IWebElement CategoryDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select"));

        //Click on SubCategory Dropdown        
        private IWebElement SubCategoryDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));

        //Enter Tag names in textbox        
        private IWebElement Tags => driver.FindElement(By.ClassName("ReactTags__tagInputField"));

        //Click on Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));

        //Click on End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));

        //Enter Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));

        //Enter the amount for Credit
        private IWebElement CreditAmount => driver.FindElement(By.Name("charge"));


        //Click on Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));

        //PopUp Message
        private IWebElement PopUpMessage => driver.FindElement(By.XPath("/html/body/div[1]/div"));

        //Title required Error Message
        private IWebElement TitleErrorMessage => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div"));

        //Description required
        private IWebElement DescriptionErrorMessage => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[2]/div"));

        //Category required Error Message
        private IWebElement CategoryErrorMessage => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div[2]"));

        //SubCategory required Error Message
        private IWebElement SubCategoryErrorMessage => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[2]/div"));

        //Tags required Error Message
        private IWebElement TagsErrorMessage => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div[2]"));

        //Skill-Exchange Tags required Error Message
        private IWebElement SkillExchangeErrorMessage => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div[2]"));

        public void goToManageListingsPage()
        {
            Wait.WaitToBeClickable(driver, "LinkText", "Manage Listings", 10);
            ManageListings.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i", 10);
            EditButton.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input", 10);
        }
        public void editShareSkill(string title, string description, string category, string subCategory, List<string> tagsToRemove, List<string> tagsToAdd, string serviceType, string locationType, AvailableDaysModel availableDays, string skillTrade, string credit, List<String> skillExchangeTagsToRemove, List<String> skillExchangeTagsToAdd, string workSampleFilename, string active)
        {
            Title.Clear();
            Title.SendKeys(title);

            Description.Clear();
            Description.SendKeys(description);

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


            // If there are tags we want to remove for the "Tags" section then let's go ahead and remove them from the website.
            // We want to first check if there are any tags in the "tagsToRemove" key in the JSON file by counting the number of items in that list. 
            // If the list has a length of 1 or more, then we have Tags we want to remove.
            if (tagsToRemove.Count >= 1)
            {
                // Now we want to go through each tag in the list of "tagsToRemove"
                foreach (var tag in tagsToRemove)
                {
                    // We use try/catch here to handle the possibility that the Tag we want to remove may not exist which will result in an Exception when Selenium tries to find the tag.
                    // In the case it can't find it, let's just fail the test because we are expecting there to be a tag so we can remove it.
                    // So for each of those tags we want to remove in the list of "tagsToRemove" do the following: 
                    try
                    {
                        // Here, we try to find the tag we want to remove by the content of the tag using XPath.
                        IWebElement tagToRemoveFromWebsite = driver.FindElement(By.XPath($"//span[@class='ReactTags__tag' and text()='{tag}']/a[@class='ReactTags__remove']"));
                        // When we have successfully found that tag, we want to click on the little x icon.
                        tagToRemoveFromWebsite.Click();
                    }
                    catch (Exception ex)
                    {
                        // It will only go here when there is an issue with the driver.FindElement inside the try { }.
                        Assert.Fail($"Unable to find the tag {tag} to remove it.");
                    }
                }
            }

            // Now we want to check if there are tags we want to Add for the "Tags" section.
            // We want to first check if there are any tags in the "tagsToAdd" key in the JSON file by counting the number of items in that list. 
            // If the list has a length of 1 or more, then we have Tags we want to add.
            if (tagsToAdd.Count >= 1)
            {
                // Now we want to go through each tag in the list of "tagsToAdd"
                foreach (var tag in tagsToAdd)
                {
                    // For each of those tags, in the "tagsToAdd" list,
                    // We want to click on the Tags input section:
                    Tags.Click();
                    // Enter the content of the tag. 
                    Tags.SendKeys(tag);
                    //Save the tag.
                    Tags.SendKeys(Keys.Return);
                }
            }


            IWebElement serviceTypeRadioButton = driver.FindElement(By.XPath($"//input[@name='serviceType' and following-sibling::label[text()='{serviceType}']]"));
            serviceTypeRadioButton.Click();

            IWebElement locationTypeRadioButton = driver.FindElement(By.XPath($"//input[@name='locationType' and following-sibling::label[text()='{locationType}']]"));
            locationTypeRadioButton.Click();

            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(availableDays.startDate);

            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(availableDays.endDate);


            // We want to go through each Day and its times from the JSON file under the "availableDays" -> "days" key.
            foreach (var dayAndTimes in availableDays.days)
            {
                // For every day e.g. Mon, Tue.. and it's start and end time, do the following:


                // Store the day e.g. Mon, Tue, Wed into a variable.
                var day = dayAndTimes.Key;

                // Store the relevant start time into a variable. This will be the start time for the day we have given e.g. If we want to tick Mon, then this is the start time for Mon
                var startTime = dayAndTimes.Value.startTime;

                // This will be the corresponding end time for Mon or whatever day we have selected.
                var endTime = dayAndTimes.Value.endTime;

                // Now based on the Day e.g. Mon or Tue, find the whole row. We want the whole row because inside the row, we will have access to the checkbox and start and end time input fields.
                var availableDayRow = driver.FindElement(By.XPath($"//div[@class='fields']//label[text()='{day}']/ancestor::div[@class='fields']"));

                // Here we store the 'checkbox' (for Mon, Tue etc) in a variable.
                var dayCheckBox = availableDayRow.FindElement(By.Name("Available"));

                // Because we stored the variable, we want to first check if it has already been checked.
                // E.g. Because we're editing, there could be an instance where the day checkbox could have already been checked.
                // In that case, we don't want to click it again because it will uncheck it.

                // Here we're checking if it's NOT selected.
                if (dayCheckBox.Selected != true)
                {
                    // Run this line only if it's not checked already.
                    dayCheckBox.Click();
                }

                // Here we're just setting the start and end times for each Day we want selected.
                availableDayRow.FindElement(By.Name("StartTime")).SendKeys(startTime);
                availableDayRow.FindElement(By.Name("EndTime")).SendKeys(endTime);
            }

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

                // After that, I have to add the skills I want to Exchange
                if (skillExchangeTagsToAdd.Count >= 1)
                {
                    foreach (var skill in skillExchangeTagsToAdd)
                    {
                        SkillExchange.Click();
                        SkillExchange.SendKeys(skill);
                        SkillExchange.SendKeys(Keys.Return);
                    }
                }
            }
            else if (skillTrade == "Credit")
            {
                // I click on the Credit option so I have to add the Credit
                CreditAmount.Click(); CreditAmount.SendKeys(credit);
            }

            // Upload Work 
            if (workSampleFilename != string.Empty)
            {
                //IWebElement workSample = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
                //workSample.Click();
                //AutoItX.WinActivate("Open"); // Window name to select a file 
                //Thread.Sleep(1000);
                //AutoItX.Send(@"C:\Users\saara\OneDrive\Documents\Mars Competition Task-2\Test Upload File.txt"); // file path 
                //AutoItX.Send("{Enter}");
                //Thread.Sleep(1000);
            }

            IWebElement activeRadioButton = driver.FindElement(By.XPath($"//input[@name='isActive' and following-sibling::label[text()='{active}']]"));
            activeRadioButton.Click();

            // Click on Save
            Save.Click();
            Thread.Sleep(500);
        }
    }
}