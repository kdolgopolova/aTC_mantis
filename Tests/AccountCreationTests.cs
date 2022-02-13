using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]

        public void setUpConfig()
        {
            string localPath = TestContext.CurrentContext.TestDirectory + @"\config_inc.php";
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(localPath, FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }     
        }

        public static Random r = new Random();

        [Test]
        public void TestAccontRegistration() 
        {
            int uniqueNumber = r.Next(0, 999);
            AccountData account = new AccountData()
            {
                Name = $"testuser{uniqueNumber}",
                Password = "password",
                Email = $"testuser{uniqueNumber}@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
