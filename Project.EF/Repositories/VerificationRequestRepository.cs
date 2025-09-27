using Project.Data.Entities.verifyRequst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EF.Repositories
{
    public class VerificationRequestRepository: GenericRepository<VerificationRequest>, IVerificationRequestRepository
    {
        public VerificationRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
       

    }
}
