using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GitRepository;

namespace IntegrationConsoleEnovaApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string gitUserName = "dariuszpelkaenova";
            string gitProjectName = "SampleProject";
            var gitRepository = new GitHubRepository(gitUserName, gitProjectName);
            Console.WriteLine("GetNumberOfCommitsForUsers");
            var commitsListPerDay = gitRepository.GetNumberOfCommitsForUsers();
            Console.WriteLine(commitsListPerDay.ToList().ToString());
            Console.WriteLine("GetAverageNumberOfCommitsForUsers");
            var averageNumberOfCommitsListPerDay = gitRepository.GetAverageNumberOfCommitsForUsers();
            Console.WriteLine(averageNumberOfCommitsListPerDay.ToList().ToString());
        }
    }
}
