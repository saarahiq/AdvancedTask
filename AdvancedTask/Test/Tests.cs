using AdvancedTask.JSON_Objects;
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
    public class Tests:CommonDriver
    {
        [Test, Order(1), Description("Dummy test")]
        public void TestDummy()
        {
            Console.WriteLine("Signin successfully.");
        }
        
        
    }
}
