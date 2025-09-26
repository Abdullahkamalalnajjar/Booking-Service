using Org.BouncyCastle.Asn1.Pkcs;
using Project.Core.Features.VerificationRequests.Commands.Models;
using Project.Data.Entities.verifyRequst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.VerificationRequests.Commands.Handlers
{
    public class VerificationRequestCommandHandler(IVerificationRequestService verificationRequestService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : ResponseHandler,
        IRequestHandler<CreateVerificationRequestCommand, Response<string>>,
        IRequestHandler<UpdateVerificationRequestCommand, Response<string>>,
        IRequestHandler<UpdateVerificationRequestStatusCommand, Response<string>>
    {
        private readonly IVerificationRequestService _verificationRequestService = verificationRequestService;
        private readonly IMapper _mapper = mapper;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        # region CreateVerificationRequestCommand
        public async Task<Response<string>> Handle(CreateVerificationRequestCommand request, CancellationToken cancellationToken)
        {
            var verificationRequest = _mapper.Map<VerificationRequest>(request);
            #region Saveimages 
            // نحفظ الصور يدوي
            verificationRequest.NationalIdFrontImage = FileHelper.SaveFile(request.NationalIdFrontImage, "Verification", _httpContextAccessor);
            verificationRequest.NationalIdBackImage = FileHelper.SaveFile(request.NationalIdBackImage, "Verification", _httpContextAccessor);
            verificationRequest.PassportImage = FileHelper.SaveFile(request.PassportImage, "Verification", _httpContextAccessor);
            verificationRequest.CommercialRecordImage = FileHelper.SaveFile(request.CommercialRecordImage, "Verification", _httpContextAccessor);
            verificationRequest.LicenseImage = FileHelper.SaveFile(request.LicenseImage, "Verification", _httpContextAccessor);
            verificationRequest.AddressProofFile = FileHelper.SaveFile(request.AddressProofFile, "Verification", _httpContextAccessor);
            #endregion
            var result = await _verificationRequestService.CreateAsync(verificationRequest, cancellationToken);
                 return result == "created"
                ? Success("Verification request created successfully.")
                : BadRequest<string>("Failed to create verification request.");
        }
        #endregion

        #region UpdateVerificationRequest
        public async Task<Response<string>> Handle(UpdateVerificationRequestStatusCommand request, CancellationToken cancellationToken)
        {
            await _verificationRequestService.UpdateStatusAsync(request.Id ,request.Status, cancellationToken);
            return Success("Verification request status updated successfully.");
        }
      
        public async Task<Response<string>> Handle(UpdateVerificationRequestCommand request, CancellationToken cancellationToken)
        {
            var oldVerificationRequest = await _verificationRequestService.GetByIdAsync(request.Id);
            if (oldVerificationRequest == null) return NotFound<string> ("Verification Request Not Found");
            try
            {
                // ✅ تحديث النصوص لو اتبعتت
                if (!string.IsNullOrEmpty(request.FullName))
                    oldVerificationRequest.FullName = request.FullName;

                if (!string.IsNullOrEmpty(request.NationalIdNumber))
                    oldVerificationRequest.NationalIdNumber = request.NationalIdNumber;

                if (!string.IsNullOrEmpty(request.PassportNumber))
                    oldVerificationRequest.PassportNumber = request.PassportNumber;

                if (!string.IsNullOrEmpty(request.CommercialRecordNumber))
                    oldVerificationRequest.CommercialRecordNumber = request.CommercialRecordNumber;

                if (!string.IsNullOrEmpty(request.LicenseNumber))
                    oldVerificationRequest.LicenseNumber = request.LicenseNumber;

                // ✅ تحديث التواريخ لو اتبعتت
                if (request.BirthDate.HasValue)
                    oldVerificationRequest.BirthDate = request.BirthDate.Value;

                if (request.NationalIdIssueDate.HasValue)
                    oldVerificationRequest.NationalIdIssueDate = request.NationalIdIssueDate.Value;

                if (request.PassportIssueDate.HasValue)
                    oldVerificationRequest.PassportIssueDate = request.PassportIssueDate.Value;

                if (request.CommercialRecordIssueDate.HasValue)
                    oldVerificationRequest.CommercialRecordIssueDate = request.CommercialRecordIssueDate.Value;

                if (request.LicenseIssueDate.HasValue)
                    oldVerificationRequest.LicenseIssueDate = request.LicenseIssueDate.Value;

                // ✅ تحديث الملفات لو اتبعتت
                if (request.NationalIdFrontImage != null)
                    oldVerificationRequest.NationalIdFrontImage = FileHelper.SaveFile(request.NationalIdFrontImage, "Verification", _httpContextAccessor);

                if (request.NationalIdBackImage != null)
                    oldVerificationRequest.NationalIdBackImage = FileHelper.SaveFile(request.NationalIdBackImage, "Verification", _httpContextAccessor);

                if (request.PassportImage != null)
                    oldVerificationRequest.PassportImage = FileHelper.SaveFile(request.PassportImage, "Verification", _httpContextAccessor);

                if (request.CommercialRecordImage != null)
                    oldVerificationRequest.CommercialRecordImage = FileHelper.SaveFile(request.CommercialRecordImage, "Verification", _httpContextAccessor);

                if (request.LicenseImage != null)
                    oldVerificationRequest.LicenseImage = FileHelper.SaveFile(request.LicenseImage, "Verification", _httpContextAccessor);

                if (request.AddressProofFile != null)
                    oldVerificationRequest.AddressProofFile = FileHelper.SaveFile(request.AddressProofFile, "Verification", _httpContextAccessor);

                // ✅ تحديث وقت آخر تعديل
                oldVerificationRequest.VerifiedAt = DateTime.UtcNow;

                var result = await _verificationRequestService.UpdateAsync(oldVerificationRequest, cancellationToken);

                  return result == "Updated"
                    ? Success("Verification request updated successfully.")
                    : BadRequest<string>("Failed to update verification request.");

            }
            catch (Exception ex) {

                return BadRequest<string>($"Error while updating: {ex.Message}");
            }
 
        }
        #endregion
    }
}
