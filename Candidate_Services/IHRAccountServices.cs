using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
 public   interface IHRAccountServices
    {

        public List<Hraccount> GetHraccounts();

        public Hraccount GetHraccountByEmail(String email);
    }
}
