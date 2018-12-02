using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GitRepository;
using Newtonsoft.Json;
using SimpleInjector;

namespace IntegrationConsoleEnovaApplication
{
    class Program
    {
        public static Container SetupIoc()
        {
            var container = new Container();
            //container.Register(typeof(IGitHubDataProvider), typeof(GitHubDataProvider), Lifestyle.Singleton);
            //var gitHubDataProvider = (IGitHubDataProvider)container.GetInstance(typeof(IGitHubDataProvider));
            container.RegisterInstance<IGitRepositoryAccess>(new GitHubRepository(new GitHubDataProvider()));
            container.Verify();
            return container;
        }

        static void Main(string[] args)
        {
            var container = SetupIoc();
            string gitUserName = "dariuszpelkaenova";
            string gitProjectName = "SampleProject";
            //var gitHubDataProvider = (IGitHubDataProvider) container.GetInstance(typeof(IGitHubDataProvider));
            var gitRepository = (IGitRepositoryAccess)container.GetInstance(typeof(IGitRepositoryAccess));
            gitRepository.GitUserName = gitUserName;
            gitRepository.GitProjectName = gitProjectName;
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
