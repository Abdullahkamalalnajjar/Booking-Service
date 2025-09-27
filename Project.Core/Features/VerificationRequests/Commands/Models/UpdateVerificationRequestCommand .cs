using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.VerificationRequests.Commands.Models
{
    public class UpdateVerificationRequestCommand : IRequest<Response<string>> 
    {
        public int Id { get; set; }
        public string? FullName { get; set; } 
        public DateTime? BirthDate { get; set; }
        public string? NationalIdNumber { get; set; } 
        public DateTime? NationalIdIssueDate { get; set; }

        // ملفات الصور بدل من string
        public IFormFile? NationalIdFrontImage { get; set; } 
        public IFormFile? NationalIdBackImage { get; set; } 

        // الحقول الاختيارية
        public string? PassportNumber { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public IFormFile? PassportImage { get; set; }

        public string? CommercialRecordNumber { get; set; }
        public DateTime? CommercialRecordIssueDate { get; set; }
        public IFormFile? CommercialRecordImage { get; set; }

        public string? LicenseNumber { get; set; }
        public DateTime? LicenseIssueDate { get; set; }
        public IFormFile? LicenseImage { get; set; }

        public IFormFile? AddressProofFile { get; set; }
    }
}
