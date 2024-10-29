using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return JobPostingDAO.Instance.AddJobPosting(jobPosting);
        }

        public bool deleteJobPosting(string postingID)
        {
            return JobPostingDAO.Instance.deleteJobPosting(postingID);
        }

        public JobPosting? GetJobPosting(string postingID)
        {
           return JobPostingDAO.Instance.GetJobPosting(postingID);
        }

        public List<JobPosting> GetJobPostings()
        {
           return JobPostingDAO.Instance.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
          return JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
        }
    }
}
