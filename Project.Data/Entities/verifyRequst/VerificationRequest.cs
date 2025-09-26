using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities.verifyRequst
{
    public class VerificationRequest
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public ServiceEntity Service { get; set; }
        // البيانات الشخصية
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        // بيانات بطاقة الهوية
        public string NationalIdNumber { get; set; } = string.Empty;
        public DateTime NationalIdIssueDate { get; set; }
        public string NationalIdFrontImage { get; set; } = string.Empty;
        public string NationalIdBackImage { get; set; } = string.Empty;

        // بيانات جواز السفر (اختياري)
        public string? PassportNumber { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public string? PassportImage { get; set; }

        // بيانات السجل التجاري (اختياري)
        public string? CommercialRecordNumber { get; set; }
        public DateTime? CommercialRecordIssueDate { get; set; }
        public string? CommercialRecordImage { get; set; }

        // بيانات الرخصة (اختياري)
        public string? LicenseNumber { get; set; }
        public DateTime? LicenseIssueDate { get; set; }
        public string? LicenseImage { get; set; }

        // إثبات العنوان
        public string? AddressProofFile { get; set; }

        // حالة التوثيق
        public VerificationStatus Status { get; set; } = VerificationStatus.Pending;

        // التواريخ
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? VerifiedAt { get; set; }
    }
}
