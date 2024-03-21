using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.JobService;

namespace SeaFoodApp.Controllers
{

    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class JobController : Controller
    {
        private readonly IJob _jobRepository;

        public JobController(IJob _jobRepository)
        {
            this._jobRepository = _jobRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllJobTitles()
        {

            var jobs = _jobRepository.GetAllJobs();

            return View(jobs);
        }

        [HttpGet("[action]")]
        public IActionResult AddJob()
        {
            var job = new Job();
            return View(job);
        }

        [HttpPost("[action]")]
        public IActionResult AddJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return View(job);
            }
            var job1 = _jobRepository.AddJob(job);
            if (job1 == null)
            {
                return View(job1);
            }
            ViewBag.Added = true;
            return View();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult EditJob(Guid id)
        {
            Job job = _jobRepository.GetJobById(id);
            return View(job);
        }

        [HttpPost("[action]")]
        public IActionResult EditJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return View(job);
            }
            _jobRepository.EditJob(job);
            ViewBag.edited = true;
            return View();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteJob(Guid id)
        {
            _jobRepository.DeleteJobById(id);
            ViewBag.deleted = true;
            return RedirectToAction("GetAllJobTitles");
        }

    }
}

