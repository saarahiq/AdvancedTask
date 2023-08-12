using AdvancedTask.JSON_Objects;
using AdvancedTask.PageObjectComponent;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class ManageListings_Tests : CommonDriver
    {
        [SetUp]
        public void NavigationtoManageListingsPage()
        {
            MenuNavigation menuNavigation = new MenuNavigation(driver);
            menuNavigation.GoToManageListingsPage();
        }

        [Test, Order(1), Description("Check if user is able to not delete the first listing by clicking NO on PopUp box")]
        public void TestDeleteListingnotSuccessfull()
        {
            manageListingsPage.DeletelistingCancel();
        }

        [Test, Order(2), Description("Check if user is able to delete the first listing")]
        public void TestDeleteListingSuccessfully()
        {
            manageListingsPage.DeleteFirstlisting();

            //Check if the listing has been deleted
            string[] deletedListing = manageListingsPage.GetFirstListing();
            string checkPopUpMessage = manageListingsPage.GetPopUpmessage();
            Assert.AreEqual(checkPopUpMessage, deletedListing[0] + " has been deleted", "Listing is not deleted");
        }
    }
}
