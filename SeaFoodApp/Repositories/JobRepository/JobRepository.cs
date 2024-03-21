using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.JobService
{
    public class JobRepository : IJob
    {
        private readonly ApplicationDbContext _dbContext;

        public JobRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public Job AddJob(Job job)
        {
            _dbContext.Job.Add(job);
            _dbContext.SaveChanges();
            return job;
        }

        public Job DeleteJobById(Guid jobId)
        {
            Job job = GetJobById(jobId);
            if (job == null)
            {
                return null;
            }
            _dbContext.Job.Remove(job);
            _dbContext.SaveChanges();
            return job;
        }

        public Job EditJob(Job job)
        {
            Job job1 = GetJobById(job.Id);
            if (job1 == null)
            {
                return null;
            }
            job1.Title = job.Title;
            _dbContext.SaveChanges();
            return job1;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            IEnumerable<Job> jobs = _dbContext.Job.ToList();
            return jobs;
        }

        public Job GetJobById(Guid jobId)
        {
            Job job = _dbContext.Job.FirstOrDefault(p => p.Id == jobId);
            return job;
        }
    }
}
