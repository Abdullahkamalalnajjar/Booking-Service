using Project.Data.Entities.verifyRequst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Abstracts
{
    public interface IVerificationRequestService
    {
        Task<string> CreateAsync(VerificationRequest  verificationRequest, CancellationToken cancellationToken);
        Task<string> UpdateAsync(VerificationRequest verificationRequest, CancellationToken cancellationToken);
        Task<VerificationRequestDto> GetByServiceIdAsync(int id);
        Task<IEnumerable<VerificationRequestDto>> GetAllAsync();
        Task<string> UpdateStatusAsync(int id, string status, CancellationToken cancellationToken);
         Task<bool> DeleteAsync(VerificationRequest verificationRequest);
        Task<string> DeleteByUserIdAsync(int userId, CancellationToken cancellationToken);
        Task<VerificationRequest> GetByIdAsync(int id);
        
    }
}
