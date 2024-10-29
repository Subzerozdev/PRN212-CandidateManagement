using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class HRAccountRepo : IHRAcccountRepo
    {
        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email); 
      

        public List<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
       
    }
}
