using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
 public    interface IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting? GetJobPosting(string postingID);
        
        public bool deleteJobPosting(string postingID);
       
        public bool AddJobPosting(JobPosting jobPosting);
        
        public bool UpdateJobPosting(JobPosting jobPosting);


    }
}
