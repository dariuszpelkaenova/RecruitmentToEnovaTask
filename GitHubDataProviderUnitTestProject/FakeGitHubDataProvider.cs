using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GitRepository
{
    public class FakeGitHubDataProvider : IGitHubDataProvider
    {
        public string GetBranches(string gitUserName, string gitProjectName)
        {
            return "[{\"name\": \"Branch-1\",\"commit\": {\"sha\": \"1a\",\"url\": \"1\" }} , {\"name\": \"Branch-2\",\"commit\": {\"sha\": \"2b\",\"url\": \"2\" }}]";
        }

        public string GetCommits(string gitUserName, string gitProjectName, string branchId)
        {
            if(branchId == "1a")
            return @"[
            {
                ""sha"": ""1"",
                ""node_id"": ""a="",
                ""commit"": {
                    ""author"": {
                        ""name"": ""Darek"",
                        ""email"": ""darek @wp.pl"",
                        ""date"": ""2018 -11-30T17:19:09Z""
                    },
                },
             },
            {
                ""sha"": ""2"",
                ""node_id"": ""a="",
                ""commit"": {
                    ""author"": {
                        ""name"": ""Tadek"",
                        ""email"": ""tadek @wp.pl"",
                        ""date"": ""2018 -11-29T17:19:09Z""
                    },
                },
             },
            {
                ""sha"": ""3"",
                ""node_id"": ""a="",
                ""commit"": {
                    ""author"": {
                        ""name"": ""Tadek"",
                        ""email"": ""tadek @wp.pl"",
                        ""date"": ""2018 -11-29T17:19:09Z""
                    },
                },
             },
            ]";
            if (branchId == "2b")
                return @"[
            {
                ""sha"": ""4"",
                ""node_id"": ""a="",
                ""commit"": {
                    ""author"": {
                        ""name"": ""Tadek"",
                        ""email"": ""tadek @wp.pl"",
                        ""date"": ""2018 -11-29T17:19:09Z""
                    },
                },
             },
            {
                ""sha"": ""5"",
                ""node_id"": ""a="",
                ""commit"": {
                    ""author"": {
                        ""name"": ""Tadek"",
                        ""email"": ""tadek @wp.pl"",
                        ""date"": ""2018 -11-29T17:19:09Z""
                    },
                },
             },
            {
                ""sha"": ""6"",
                ""node_id"": ""a="",
                ""commit"": {
                    ""author"": {
                        ""name"": ""Darek"",
                        ""email"": ""darek @wp.pl"",
                        ""date"": ""2018 -11-27T17:19:09Z""
                    },
                },
             },
            ]";

            return "";
        }
    }
}
