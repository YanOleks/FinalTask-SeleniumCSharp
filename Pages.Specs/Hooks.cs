using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Reqnroll;

namespace Pages.Specs
{
    [Binding]
    public class Hooks
    {
        [AfterScenario]
        private static void AfterScenario()
        {
            WebDriverManager.Instance.QuitDriver();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var driver = WebDriverManager.Instance.GetDriver()!;
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                screenshot.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath);
            }
            WebDriverManager.Instance.QuitDriver();
        }
    }
}
