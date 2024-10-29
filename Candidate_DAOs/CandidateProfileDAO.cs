using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbContext;
        private static CandidateProfileDAO instance;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            // xử lí lại cũng chưa có hiểu.
            return dbContext.CandidateProfiles.Include(u => u.Posting).ToList(); 
        }
        public CandidateProfile GetCandidateProfile (string id)
        {
            return dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool AddCandidateProfile (CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate == null)
            {
                dbContext.CandidateProfiles.Add(candidateProfile);
                dbContext.SaveChanges();
                isSuccess = true;   
            }
            return isSuccess;

        }

        public bool DeleteCandidateProfile(string candidateID)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateID);
            if (candidate != null)
            {
                dbContext.CandidateProfiles.Remove(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;

        }


        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate !=null )
            {
                //dbContext.Entry<CandidateProfile>(candidateProfile).State = 
                //    Microsoft.EntityFrameworkCore.EntityState.Modified;
               
                candidate.Fullname = candidateProfile.Fullname;
                candidate.Birthday = candidateProfile.Birthday;
                candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                candidate.ProfileUrl = candidateProfile.ProfileUrl;
                candidate.PostingId = candidateProfile.PostingId;


                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;

        }




    }
}
