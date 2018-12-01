using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GitRepository.Model;

namespace GitRepository
{
    public interface IGitRepositoryAccess
    {
        string GitUserName
        {
            get;
            set;
        }

        string GitProjectName
        {
            get;
            set;
        }

        IEnumerable<CommitsPerDayPerUser> GetNumberOfCommitsForUsers();

        IEnumerable<AverageNumberOfDailyCommits> GetAverageNumberOfCommitsForUsers();
    }
}
