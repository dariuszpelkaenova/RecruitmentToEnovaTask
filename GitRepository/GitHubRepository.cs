using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using GitRepository.Model;
using Newtonsoft.Json.Linq;

namespace GitRepository
{
    public class GitHubRepository : IGitRepositoryAccess
    {
        private string _gitUserName = "";
        private string _gitProjectName = "";

        public string GitUserName
        {
            get
            {
                return _gitUserName;
            }

            set
            {
                _gitUserName = value;
            }
        }

        public string GitProjectName
        {
            get
            {
                return _gitProjectName;
            }
            set
            {
                _gitProjectName = value;
            }
        }

        private IGitHubDataProvider _dataProvider;

        public GitHubRepository(IGitHubDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public GitHubRepository(string gitUserName, string gitProjectName)
        {
            _gitUserName = gitUserName;
            _gitProjectName = gitProjectName;
        }

        public IEnumerable<CommitsPerDayPerUser> GetNumberOfCommitsForUsers()
        {
            var list = GetAllCommits();
            var result = list.GroupBy(m => new { m.UserName, m.Created.Value.Date })
                .Select(m => new CommitsPerDayPerUser() { UserName = m.Key.UserName, NumberOfCommits = m.Count(), OnDate = m.Key.Date})
                .ToList();
            return result;
        }

        public IEnumerable<AverageNumberOfDailyCommits> GetAverageNumberOfCommitsForUsers()
        {
            var list = GetNumberOfCommitsForUsers();
            var result = list.GroupBy(m => new {m.UserName, m.OnDate})
                .Select(m => new AverageNumberOfDailyCommits() { UserName = m.Key.UserName, NumberOfCommits = (int)m.Average(n => n.NumberOfCommits)})
                .ToList();
            return result;
        }
        
        private IEnumerable<GitCommit> GetAllCommits()
        {
            var allCommits = new List<GitCommit>();
            var branchesIds = GetAllBranchesIds();

            foreach (var branchId in branchesIds)
            {
                var commits = GetAllCommitsFromBranch(branchId);
                allCommits.AddRange(commits);
            }

            return allCommits;
        }

        private IEnumerable<string> GetAllBranchesIds()
        {
            List<string> result = new List<string>();
            try
            {
            /*ServicePointManager.SecurityProtocol =   (SecurityProtocolType)3072;
            var client = new WebClient();
            client.Headers.Add("user-agent", "CustomApp");
            var url = $"https://api.github.com/repos/{GitUserName}/{GitProjectName}/branches";
            var response = client.DownloadString(url);
            */

            var response = _dataProvider.GetBranches(GitUserName, GitProjectName);
            dynamic json = JToken.Parse(response);

            foreach (dynamic item in json)
            {
                result.Add(item.commit.sha.ToString());
            }
            }
            catch(Exception exc)
            {
                ;//Dodać logowanie
                throw new Exception("Problem z pobraniem informacji o branchach");
            }

            return result;
        }

        private IEnumerable<GitCommit> GetAllCommitsFromBranch(string branchSha)
        {
            List<GitCommit> result = new List<GitCommit>();

            try
            {
                /*ServicePointManager.SecurityProtocol = (SecurityProtocolType) 3072;
                var client = new WebClient();
                client.Headers.Add("user-agent", "CustomApp");
                var url = $"https://api.github.com/repos/{GitUserName}/{GitProjectName}/commits?sha={branchSha}";
                var response = client.DownloadString(url);
                */
                var response = _dataProvider.GetCommits(GitUserName, GitProjectName, branchSha);
                dynamic json = JToken.Parse(response);

                foreach (dynamic item in json)
                {
                    var a = item.commit.author.date;
                    if (!DateTime.TryParse(item.commit.author.date.ToString(),
                        CultureInfo.GetCultureInfo("en-US"),
                        DateTimeStyles.None, out DateTime dateCreated))
                    {
                        dateCreated = DateTime.MinValue;
                    }

                    var commit = new GitCommit()
                    {
                        UserName = item.commit.author.name.ToString(),
                        Created = (dateCreated == DateTime.MinValue ? default(DateTime) : dateCreated),
                        CommitId = item.sha.ToString()
                    };
                    result.Add(commit);
                }
            }
            catch
            {
                ;//Dodać logowanie
                throw new Exception("Problem z pobraniem informacji o commitach");
            }

            return result;
        }
    }
}
