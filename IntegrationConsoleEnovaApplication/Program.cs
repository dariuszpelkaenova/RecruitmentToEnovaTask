using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GitRepository;
using Newtonsoft.Json;

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
            var json = JsonConvert.SerializeObject(commitsListPerDay);
            Console.WriteLine(json);

            Console.WriteLine("GetAverageNumberOfCommitsForUsers");
            var averageNumberOfCommitsListPerDay = gitRepository.GetAverageNumberOfCommitsForUsers();
            json = JsonConvert.SerializeObject(averageNumberOfCommitsListPerDay);
            Console.WriteLine(json);

            Console.ReadLine();
        }
    }
}
