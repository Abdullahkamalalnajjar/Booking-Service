using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Enum
{
    public enum VerificationStatus
    {
        Pending =1,   // قيد المراجعة
        Approved =2,  // تم التوثيق بنجاح
        Rejected =3  // تم رفض التوثيق
    }
}
