using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        public static Random r = new Random();

        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData("administrator", "root");

            ProjectData project = new ProjectData()
            {
                Name = $"Created automatically {r.Next(0, 999)}",
                Description = "Via aTC",
            };

            app.Login.Login(account);
            app.Menu.OpenProjectMenu();

            List<ProjectData> oldData = app.Project.GetProjectList();

            app.Project.Create(project);

            List<ProjectData> newData = app.Project.GetProjectList();

            Assert.AreEqual(oldData.Count + 1, newData.Count);

            oldData.Add(project);

            oldData.Sort();
            newData.Sort();

            Assert.AreEqual(oldData, newData);
        }
    }
}
