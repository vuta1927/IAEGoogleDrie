using IAEGoogleDrie.Configuration;

namespace IAEGoogleDrie.BackgroundJobs
{
    /// <summary>
    /// Used to configure background job system.
    /// </summary>
    public interface IBackgroundJobConfiguration : IConfigurator
    {
        /// <summary>
        /// Used to enable/disable background job execution.
        /// </summary>
        bool IsJobExecutionEnabled { get; set; }
    }
}