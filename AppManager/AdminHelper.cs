using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;
        public AdminHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogIn();
            driver.Url = baseUrl + $"/manage_user_edit_page.php";
            IList<IWebElement> elements = driver.FindElements(By.TagName("tr"));

            foreach (var element in elements)
            {
                IWebElement link = element.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id,
                });
            }
            return accounts;

        }

        public void DeleteAccount(AccountData account)
        {

            IWebDriver driver = OpenAppAndLogIn();
            driver.Url = baseUrl + $"/manage_user_edit_page.php?user_id={account.Id}";
            driver.FindElement(By.XPath("//input[@value='Delete User']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Account']")).Click();
        }

        private IWebDriver OpenAppAndLogIn()
        {
            IWebDriver driver = new SimpleBrowserDriver();

            driver.Url = baseUrl + "/login_page.php";
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

            return driver;
        }
    }
}
