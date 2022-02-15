using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        public static Random r = new Random();

        [Test]
        public void ProjectRemovalTest()
        {
            AccountData account = new AccountData("administrator", "root");

            //Adds a project if nothing to remove at the start of the test
            ProjectData project = new ProjectData()
            {
                Name = $"Created automatically {r.Next(0, 999)}",
                Description = "Via aTC",
            };

            app.Login.Login(account);
            app.Menu.OpenProjectMenu();

            if (app.Project.GetProjectCount(account) == 0)
            {
                //app.Project.Create(project);
                app.Api.Create(project, account);
            }

            List<ProjectData> oldData = app.Project.GetProjectList(account);
            ProjectData projectToRemove = oldData[0];

            app.Project.Remove();

            List<ProjectData> newData = app.Project.GetProjectList(account);

            Assert.AreEqual(oldData.Count - 1, newData.Count);

            oldData.Remove(projectToRemove);

            oldData.Sort();
            newData.Sort();

            Assert.AreEqual(oldData, newData);
        }
    }
}
