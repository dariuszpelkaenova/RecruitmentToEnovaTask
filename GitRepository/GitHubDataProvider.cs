using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GitRepository
{
    public class GitHubDataProvider : IGitHubDataProvider
    {
        public string GetBranches(string gitUserName, string gitProjectName)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            var client = new WebClient();
            client.Headers.Add("user-agent", "CustomApp");
            var url = $"https://api.github.com/repos/{gitUserName}/{gitProjectName}/branches";
            var response = client.DownloadString(url);
            return response;
        }

        public string GetCommits(string gitUserName, string gitProjectName, string branchId)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            var client = new WebClient();
            client.Headers.Add("user-agent", "CustomApp");
            var url = $"https://api.github.com/repos/{gitUserName}/{gitProjectName}/commits?sha={branchId}";
            var response = client.DownloadString(url);
            return response;
        }
    }
}
