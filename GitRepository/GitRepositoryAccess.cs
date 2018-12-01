using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitRepository
{
    public class GitRepositoryAccess : IGitRepositoryAccess
    {
        public int GetNumberOfCommitsForUserOnDate(DateTime date, int userId)
        {
            //CSharp.GitHub.Api.Impl.
            return 0;
        }

        public int GetAverageNumberOfCommitsForUserOnDate(int userId)
        {
            return 0;
        }
    }
}
