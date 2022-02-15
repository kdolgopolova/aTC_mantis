using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests : TestBase
    {

        [Test]
        public void AddIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
            };

            IssueData issueData = new IssueData()
            {
                Summary = "summary text",
                Description = "decsription text",
                Category = "General",
            };

            ProjectData project = new ProjectData()
            {
                Id ="9",
            };

            app.Api.CreateNewIssue(account, project, issueData);

        }
    }
}
