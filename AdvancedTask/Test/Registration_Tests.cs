using AdvancedTask.Models;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class Registration_Tests : CommonDriver
    {
        public Registration_Tests() : base(false) { }
        public static ICollection<UserModel> ReadRegistrationTests(string[] jsonFiles, bool randomEmail = false)
        {
            var users = new List<UserModel>();
            foreach (var file in jsonFiles)
            {
                UserModel user = ReadTestUser("JSONData\\Registration\\" + file);
                if (randomEmail)
                {
                    int i = user.Email.IndexOf("@");
                    string currentTime = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
                    user.Email = user.Email.Insert(i-1,currentTime);

                }
                users.Add(user);
            }
            return users;
        }
        public static ICollection<UserModel> ReadPositiveTests()
        {
            return ReadRegistrationTests(new string[] { "positiveRegistration_01.json" }, true);
        }

        public static ICollection<UserModel> ReadNegativeTests()
        {
            return ReadRegistrationTests(new string[] {
                "negativeRegistration_01.json",
                "negativeRegistration_02.json",
                "negativeRegistration_03.json",
                "negativeRegistration_04.json",
                "negativeRegistration_05.json",
                "negativeRegistration_06.json",
                "negativeRegistration_07.json",
                "negativeRegistration_08.json",
                "negativeRegistration_09.json"
               });
        }

        [Test, Order(1), Description("Register successfully"), TestCaseSource(nameof(ReadPositiveTests))]
        public void TestRegisterSuccessfully(UserModel user)
        {
            var success = marsLoginPage.Register(user);
            Assert.IsTrue(success);
        }

        [Test, Order(2), Description("Register Failed"), TestCaseSource(nameof(ReadNegativeTests))]
        public void TestRegisterFailed(UserModel user)
        {
            var success = marsLoginPage.Register(user);
            Assert.IsFalse(success);
        }


    }
}
