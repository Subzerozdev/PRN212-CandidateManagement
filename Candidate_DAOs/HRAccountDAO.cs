using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;

        private static HRAccountDAO instance = null;

        public HRAccountDAO()
        {
            context = new CandidateManagementContext();
        }

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();

                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(String email)
        {
            return context.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }
        public List <Hraccount>   GetHraccounts ()
        {
            return context.Hraccounts.ToList();
        }
    }
}
