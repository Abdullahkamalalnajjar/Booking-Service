using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project.Data.Dtos
{
    public class VerificationRequestDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ServiceId { get; set; }
        public string FullName { get; set; } = null!; // الاسم بالكامل
        public DateTime BirthDate { get; set; }       // تاريخ الميلاد
        public string NationalIdNumber { get; set; } = string.Empty;   // رقم البطاقة
        public DateTime NationalIdIssueDate { get; set; }     // تاريخ إصدار البطاقة
        public string NationalIdFrontImage { get; set; } = string.Empty; // صورة وجه البطاقة
        public string NationalIdBackImage { get; set; } = string.Empty; // صورة ظهر البطاقة

        // بيانات جواز السفر (اختياري)
        public string? PassportNumber { get; set; }          // رقم الجواز
        public DateTime? PassportIssueDate { get; set; }     // تاريخ إصدار الجواز
        public string? PassportImage { get; set; }           // صورة الجواز

        // بيانات السجل التجاري (اختياري)
        public string? CommercialRecordNumber { get; set; }      // رقم السجل التجاري
        public DateTime? CommercialRecordIssueDate { get; set; } // تاريخ إصدار السجل
        public string? CommercialRecordImage { get; set; }       // صورة السجل التجاري

        // بيانات الرخصة المهنية أو القيادة (اختياري)
        public string? LicenseNumber { get; set; }        // رقم الرخصة
        public DateTime? LicenseIssueDate { get; set; }   // تاريخ إصدار الرخصة
        public string? LicenseImage { get; set; }         // صورة الرخصة

        // إثبات العنوان (فاتورة مرافق أو عقد إيجار إلخ)
        public string? AddressProofFile { get; set; }

        // حالة طلب التوثيق (بانتظار المراجعة / مقبول / مرفوض)
        // 👇 هنا هيتحول الـ Enum إلى String تلقائيًا في JSON
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VerificationStatus Status { get; set; } = VerificationStatus.Pending;

        // التواريخ
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // تاريخ إنشاء الطلب
        public DateTime? VerifiedAt { get; set; }       // تاريخ المراجعة (لو اتوافق أو اترفض)
    }
}
