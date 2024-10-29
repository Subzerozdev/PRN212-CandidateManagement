using Candidate_BusinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.AddJobPosting(jobPosting);

        }

        public bool deleteJobPosting(string postingID)
        {
           return  jobPostingRepo.deleteJobPosting(postingID);
        }

        public JobPosting? GetJobPosting(string postingID)
        {
          return jobPostingRepo.GetJobPosting(postingID);
        }

        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.UpdateJobPosting(jobPosting);
        }
    }
}
