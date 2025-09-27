using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.VerificationRequests.Commands.Models
{
    public class CreateVerificationRequestCommand:IRequest<Response<string>>
    {
        public int ServiceId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string NationalIdNumber { get; set; } = string.Empty;
        public DateTime NationalIdIssueDate { get; set; }

        // ملفات الصور بدل من string
        public IFormFile NationalIdFrontImage { get; set; } = null!;
        public IFormFile NationalIdBackImage { get; set; } = null!;

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
