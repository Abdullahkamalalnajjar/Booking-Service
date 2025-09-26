using Microsoft.AspNetCore.Http.HttpResults;
using Project.Data.Dtos;
using Project.Data.Entities.verifyRequst;
using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Implementations
{
    public class VerificationRequestService(IUnitOfWork unitOfWork) : IVerificationRequestService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<string> CreateAsync(VerificationRequest verificationRequest, CancellationToken cancellationToken)
        {
           await _unitOfWork.verificationRequestRepository.AddAsync(verificationRequest, cancellationToken);
           await _unitOfWork.CompeleteAsync();
              return "created";
        }

        public async Task<bool> DeleteAsync(VerificationRequest verificationRequest)
        {
             await _unitOfWork.verificationRequestRepository.Delete(verificationRequest);
             await _unitOfWork.CompeleteAsync();
            return true;
        }

        public Task<string> DeleteByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VerificationRequestDto>> GetAllAsync()
        {
            return await _unitOfWork.verificationRequestRepository.GetTableNoTracking().Select(VerificationRequestDto).ToListAsync();
        }


        public async Task<VerificationRequestDto> GetByServiceIdAsync(int id)
        {
                var service= await  _unitOfWork.verificationRequestRepository.GetTableAsTracking()
                .Where(x => x.Service.Id == id).Select(VerificationRequestDto).FirstOrDefaultAsync();    
                  return service;
            
        }

        public async Task<VerificationRequest> GetByIdAsync(int id)
        {
                var service = await _unitOfWork.verificationRequestRepository.GetTableAsTracking()
               .Where(x => x.Id == id).FirstOrDefaultAsync();
                return service ;
        }

        public async Task<string> UpdateStatusAsync(int id, string status, CancellationToken cancellationToken)
        {
            var request = await _unitOfWork.verificationRequestRepository.GetTableAsTracking()
           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (request == null)
                return "Not found";

            // نحاول نعمل Parse من الـ string للـ Enum
            if (Enum.TryParse<VerificationStatus>(status, out var parsedStatus))
            {
                request.Status = parsedStatus;
                request.VerifiedAt = DateTime.Now;
                await _unitOfWork.CompeleteAsync();
                return "Updated";
            }
            return "Invalid status";
        }

        public async Task<string> UpdateAsync(VerificationRequest verificationRequest, CancellationToken cancellationToken)
        {
             _unitOfWork.verificationRequestRepository.Update(verificationRequest);
             _unitOfWork.CompeleteAsync();
            return "Updated";

        }



        #region  Expression to convert VerificationRequest to VerificationRequestDto
        private static readonly Expression<Func<VerificationRequest, VerificationRequestDto>> VerificationRequestDto = s => new  VerificationRequestDto
        {
            Id = s.Id,
           AddressProofFile = s.AddressProofFile,
           BirthDate = s.BirthDate,
           CommercialRecordImage = s.CommercialRecordImage,
           CommercialRecordIssueDate = s.CommercialRecordIssueDate,
           CommercialRecordNumber = s.CommercialRecordNumber,
           CreatedAt = s.CreatedAt,
           FullName = s.FullName,
           LicenseImage = s.LicenseImage,
           LicenseIssueDate = s.LicenseIssueDate,
           LicenseNumber = s.LicenseNumber,
           NationalIdBackImage = s.NationalIdBackImage,
           NationalIdFrontImage = s.NationalIdFrontImage,
           NationalIdIssueDate = s.NationalIdIssueDate,
           NationalIdNumber = s.NationalIdNumber,
           PassportImage = s.PassportImage,
           PassportIssueDate = s.PassportIssueDate,
           PassportNumber = s.PassportNumber,
           ServiceId = s.ServiceId,
           Status = s.Status,
           VerifiedAt = s.VerifiedAt,
           


        };

        #endregion 



    }
}
