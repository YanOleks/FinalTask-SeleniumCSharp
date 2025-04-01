namespace Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Edge;
    using Serilog;
    using System;

    public class WebDriverManager
    {
        private static readonly Lazy<WebDriverManager> instance = new(() => new WebDriverManager());
        private readonly ThreadLocal<IWebDriver?> webDriver = new();
        private readonly Serilog.Core.Logger log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/webdriver.log")
            .CreateLogger();

        public static WebDriverManager Instance => instance.Value;

        private WebDriverManager() 
        {
        }

        public IWebDriver? GetDriver() => webDriver.Value;

        public IWebDriver InitDriver(BrowserType browser = BrowserType.Chrome, bool headless = false, bool maximize = true)
        {
            
            if (webDriver.Value == null)
            {
                log.Information(
                    "Initiating webdriver with {Browser} browser with headless:{Headless} and maximize:{Max}", 
                    browser,
                    headless,
                    maximize
                    );
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
                log.Information("Webdriver initiated");
            }
            return webDriver.Value;
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

        public void QuitDriver()
        {
            log.Information("Quitting webdriver");
            webDriver.Value?.Quit();
            webDriver.Value?.Dispose();
            webDriver.Value = null;
            Log.CloseAndFlush();
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge
    }

}
