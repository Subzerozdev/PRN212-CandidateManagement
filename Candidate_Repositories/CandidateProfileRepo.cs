using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);
        

        public bool DeleteCandidateProfile(string candidateID)  => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateID);
       

        public CandidateProfile GetCandidateProfile(string id)  => CandidateProfileDAO.Instance.GetCandidateProfile(id);
       

        public List<CandidateProfile> GetCandidateProfiles()   =>  CandidateProfileDAO.Instance.GetCandidateProfiles();
        

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)  => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);    
        
    }
}
