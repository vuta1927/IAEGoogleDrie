﻿using System.Threading.Tasks;
using IAEGoogleDrie.BackgroundJobs;
using IAEGoogleDrie.Configuration;
using IAEGoogleDrie.Dependency;

namespace IAEGoogleDrie.Threading.BackgrodunWorkers
{
    public class BackgroundWorkerStarter : IWantToKnowWhenConfigurationIsDone, ITransientDependency
    {
        private readonly IBackgroundWorkerManager _backgroundWorkerManager;
        private readonly IBackgroundJobManager _backgroundJobManager;

        public BackgroundWorkerStarter(IBackgroundWorkerManager backgroundWorkerManager, IBackgroundJobManager backgroundJobManager)
        {
            _backgroundWorkerManager = backgroundWorkerManager;
            _backgroundJobManager = backgroundJobManager;
        }

        public Task Configured(IConfigure configure)
        {
            if (configure.BackgroundJobs.IsJobExecutionEnabled)
            {
                _backgroundWorkerManager.Start();
                _backgroundWorkerManager.Add(_backgroundJobManager);
            }
            
            return Task.FromResult(0);
        }
    }
}