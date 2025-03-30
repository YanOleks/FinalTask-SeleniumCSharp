using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;

namespace Pages.Specs
{
    [Binding]
    public static class Hooks
    {
        [AfterScenario]
        public static void AfterScenario()
        {
            WebDriverManager.Instance.QuitDriver();
        }
    }
}
