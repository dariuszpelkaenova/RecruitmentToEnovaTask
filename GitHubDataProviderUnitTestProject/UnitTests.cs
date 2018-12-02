using System;
using System.Linq;
using GitRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubDataProviderUnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetAverageNumberOfCommitsForUsers_WithSomeData_ShouldReturnCorrectResult()
        {
            var fakeProvider = new FakeGitHubDataProvider();
            var repository = new GitHubRepository(fakeProvider);
            var list = repository.GetAverageNumberOfCommitsForUsers();
            Assert.AreEqual(2, list.Count());

            var comitsPerDarek = list.FirstOrDefault(m => m.UserName == "Darek");
            Assert.AreEqual(1, comitsPerDarek.NumberOfCommits);

            var comitsPerTadek = list.FirstOrDefault(m => m.UserName == "Tadek");
            Assert.AreEqual(4, comitsPerTadek.NumberOfCommits);
        }

        [TestMethod]
        public void GetNumberOfCommitsForUsers_WithSomeData_ShouldReturnCorrectResult()
        {
            var fakeProvider = new FakeGitHubDataProvider();
            var repository = new GitHubRepository(fakeProvider);
            var list = repository.GetNumberOfCommitsForUsers();
            Assert.AreEqual(3, list.Count());

            var commitsPerDarek = list.Where(m => m.UserName == "Darek");
            Assert.AreEqual(2, commitsPerDarek.Count());

            var commitsPerTadek = list.Where(m => m.UserName == "Tadek");
            var count = commitsPerTadek.Count();
            Assert.AreEqual(1, commitsPerTadek.Count());

            var commitsForTadek = list.FirstOrDefault(m => m.UserName == "Tadek");
            Assert.AreEqual(4, commitsForTadek.NumberOfCommits);
        }
    }
}
