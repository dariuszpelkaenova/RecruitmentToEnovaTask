using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitRepository
{
    public interface IGitHubDataProvider
    {
        string GetBranches(string gitUserName, string gitProjectName);

        string GetCommits(string gitUserName, string gitProjectName, string branchId);
    }
}
