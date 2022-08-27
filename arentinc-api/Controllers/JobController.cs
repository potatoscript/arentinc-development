using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApi.Models;
using JobApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        public JobServices _jobservice;
        public JobController(JobServices jobservice)
        {
            _jobservice = jobservice;
        }

        [HttpPost("create-job")]
        public IActionResult CreateJob(Job job)
        {
            _jobservice.CreateJob(job);
            return Ok();
        }

        [HttpGet("read-all-employee-jobs/{employee}")]
        public IActionResult ReadAllJobs(string employee)
        {
            var allJobs = _jobservice.ReadAllEmployeeJobs(employee);

            return Ok(allJobs);
        }

        [HttpGet("read-total-jobs-employee")]
        public IActionResult ReadTotalJobsOfEmployee()
        {
            var allJobs = _jobservice.ReadTotalJobsOfEmployee();

            return Ok(allJobs);
        }

        [HttpPut("update-job-by-id")]
        public IActionResult UpdateJobById(Job job)
        {
            var updateJob = _jobservice.UpdateJobById(job);
            return Ok(updateJob);
        }

        [HttpDelete("delete-job-by-id/{id}")]
        public IActionResult DeleteJobById(int id)
        {
            _jobservice.DeleteJobById(id);
            return Ok();
        }
    }
}