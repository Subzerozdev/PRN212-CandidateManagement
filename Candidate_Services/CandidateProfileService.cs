using Candidate_BusinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService {
        private readonly ICandidateProfileRepo profileRepo;

        public CandidateProfileService ()
        {
            profileRepo = new CandidateProfileRepo ();
        }
    
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
           return profileRepo.AddCandidateProfile (candidateProfile);   
        }

        public bool DeleteCandidateProfile(string candidateID)
        {
            return profileRepo.DeleteCandidateProfile (candidateID);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
           return profileRepo.GetCandidateProfile (id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
           return profileRepo.GetCandidateProfiles();
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
           return profileRepo.UpdateCandidateProfile (candidateProfile);    
        }
    }
}
