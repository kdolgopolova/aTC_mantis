using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        protected string baseURL;
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public LoginHelper Login { get; set; }
        public ManageMenuHelper Menu { get; set; }
        public ProjectManageHelper Project { get; set; }

        public AdminHelper Admin { get; set; }
        public IWebDriver Driver { get => driver; set => driver = value; }
        public APIHelper Api { get; set; }

        private static readonly ThreadLocal<ApplicationManager> App = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost/mantisbt-2.25.2";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Login = new LoginHelper(this);
            Menu = new ManageMenuHelper(this);
            Project = new ProjectManageHelper(this);
            Admin = new AdminHelper(this, baseURL);
            Api = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!App.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                App.Value = newInstance;
            }
            return App.Value;
        }
    }
}
