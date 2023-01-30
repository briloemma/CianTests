using AuthorizationCianPageTests.Environment;
using AuthorizationCianPageTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;

namespace AuthorizationCianPageTests.Tests
{
    [TestFixture]
    public class Serealize
    {
        private const string _jsonFileName = "EnvironnmentConstants.json";
        protected EnvironmentConstants environmentConstant;
        public void WriteDown()
        {
            var enviromentCostants = new EnvironmentConstants();
            string objectSeriallized = JsonSerializer.Serialize(enviromentCostants);
            File.WriteAllText("EnvironnmentConstants.json", objectSeriallized);
        }
        public void Provide(out EnvironmentConstants environmentConstantObject)
        {
            string objectJsonFile = File.ReadAllText(_jsonFileName);
            environmentConstantObject = JsonSerializer.Deserialize<EnvironmentConstants>(objectJsonFile);
        }
        private void InitializeData()
        {
            Provide(out EnvironmentConstants environmentConstantObject);
            environmentConstant = environmentConstantObject;
        }

       [Test]
       public void Serialize()
       {
            WriteDown();
       }
       [Test]
       public void Deserialize()
       {
            InitializeData();
            Console.WriteLine(environmentConstant.Name);
       }
    }
}