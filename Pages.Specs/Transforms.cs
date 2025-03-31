using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;

namespace Pages.Specs
{
    [Binding]
    class Transforms
    {
        [StepArgumentTransformation]
        public BrowserType TransformBrowser(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => BrowserType.Chrome,
                "edge" => BrowserType.Edge,
                "firefox" => BrowserType.Firefox,
                _ => throw new ArgumentException($"Unsupported browser: {browser}")
            };
        }
    }
}
