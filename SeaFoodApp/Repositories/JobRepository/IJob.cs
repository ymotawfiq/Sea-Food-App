using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.JobService
{
    public interface IJob
    {
        Job AddJob(Job job);
        Job EditJob(Job job);
        Job GetJobById(Guid jobId);
        Job DeleteJobById(Guid jobId);
        IEnumerable<Job> GetAllJobs();
    }
}
