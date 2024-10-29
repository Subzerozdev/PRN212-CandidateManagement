using Candidate_Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagementAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        private ICandidateProfileService profileService;

        public CandidateController()
        {
            profileService = new CandidateProfileService(); 
        }

        [HttpGet(Name = "GetCandidates")]
        public IActionResult GetAllCandidate()
        {
            return Ok(profileService.GetCandidateProfiles().ToList());
        }
    }
}
