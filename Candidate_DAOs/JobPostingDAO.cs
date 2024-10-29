using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        // DB Context
        private CandidateManagementContext dbContext;
        private static JobPostingDAO instance;

        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        // ctor
        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        // Get all Job Posting
        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();
        }
        // Get Job Posting By ID
        public JobPosting? GetJobPosting(string postingID)
        {
            return dbContext.JobPostings.SingleOrDefault(
                m => m.PostingId.Equals(postingID));
        }
        // Delete Job Posting By ID
        public bool deleteJobPosting(string postingID)
        {
            bool result = false;
            JobPosting jobPosting = GetJobPosting(postingID);
            if (jobPosting != null)
            {
                dbContext.JobPostings.Remove(jobPosting);
                dbContext.SaveChanges();
                result = true;
            }
            return result;
        }
        // Add new Job Posting
        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            // check if already exist in DB
            JobPosting? jobPosting1 = GetJobPosting(jobPosting.PostingId);
            if (jobPosting1 == null)
            {
                // Add and save to DB if not duplicate
                dbContext.JobPostings.Add(jobPosting);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }

        // Update Job Posting
        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            // check if already exist in DB
            JobPosting? jobPosting1 = GetJobPosting(jobPosting.PostingId);
            if (jobPosting1 != null)
            {
                // Auto update and save to DB
                jobPosting1.JobPostingTitle = jobPosting.JobPostingTitle;
                jobPosting1.Description = jobPosting.Description;
                jobPosting1.PostedDate = jobPosting.PostedDate;
                //dbContext.Entry<CandidateProfile>(candidateProfile).State 
                //    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.JobPostings.Update(jobPosting1);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }

    }

}
