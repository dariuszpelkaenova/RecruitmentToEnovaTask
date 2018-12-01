using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitRepository.Model
{
    public class GitCommit
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime Created { get; set; }

        public string CommitId { get; set; }
    }
}
