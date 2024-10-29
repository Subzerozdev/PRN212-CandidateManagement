using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IHRAcccountRepo
    {

        public Hraccount GetHraccountByEmail(String email);

        public List<Hraccount> GetHraccounts();
      
    }
}
