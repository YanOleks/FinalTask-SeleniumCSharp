namespace Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Edge;
    using System;

    public static class Driver
    {
        private static readonly ThreadLocal<IWebDriver?> webDriver = new();

        public static IWebDriver? GetDriver()
        {
            return webDriver.Value;
        }

        public static void InitDriver(BrowserType browser = BrowserType.Chrome, bool headless = false, bool maximize = true)
        {
            if (webDriver.Value == null)
            {
                IWebDriver driver = browser switch
                {
                    BrowserType.Chrome => InitChromeDriver(headless),
                    BrowserType.Firefox => InitFirefoxDriver(headless),
                    BrowserType.Edge => InitEdgeDriver(headless),
                    _ => throw new ArgumentException("Unsupported browser"),
                };

                webDriver.Value = driver;

                if (maximize)
                {
                    driver.Manage().Window.Maximize();
                }
            }
        }

        private static ChromeDriver InitChromeDriver(bool headless)
        {
            var options = new ChromeOptions();
            if (headless) options.AddArgument("--headless=new");
            return new ChromeDriver(options);
        }

        private static FirefoxDriver InitFirefoxDriver(bool headless)
        {
            var options = new FirefoxOptions();
            if (headless) options.AddArgument("--headless");
            return new FirefoxDriver(options);
        }

        private static EdgeDriver InitEdgeDriver(bool headless)
        {
            var options = new EdgeOptions();
            if (headless) options.AddArgument("--headless");
            return new EdgeDriver(options);
        }

        public static void QuitDriver()
        {
            webDriver.Value?.Quit();
            webDriver.Value?.Dispose();
            webDriver.Value = null;
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }

}
