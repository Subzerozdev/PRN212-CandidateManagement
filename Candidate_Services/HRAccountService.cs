using Candidate_BusinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class HRAccountService : IHRAccountServices
    {

        private IHRAcccountRepo iAccountRepo;

        public HRAccountService() { 
         
            iAccountRepo = new HRAccountRepo(); 
        }   
        public Hraccount GetHraccountByEmail(string email)
        {
           return iAccountRepo.GetHraccountByEmail(email);  
        }

        public List<Hraccount> GetHraccounts()
        {
            return iAccountRepo.GetHraccounts();    
        }
    }
}
