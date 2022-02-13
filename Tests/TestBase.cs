using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;
        public static Random R = new Random();

        public static string GenerateRandomString(int maxLength)
        {
            int length = Convert.ToInt32(R.NextDouble() * maxLength);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(Convert.ToChar(32 + Convert.ToInt32(R.NextDouble() * 65)));
            }
            return sb.ToString();
        }


        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
