using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitRepository
{
    public interface IGitRepositoryAccess
    {
        int GetNumberOfCommitsForUserOnDate(DateTime date, int userId);

        int GetAverageNumberOfCommitsForUserOnDate(int userId);
    }
}
