using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitRepository.Model
{
    public class CommitsPerDayPerUser
    {
        public string UserName { get; set; }

        public int NumberOfCommits { get; set; }

        public DateTime OnDate { get; set; }
    }
}
