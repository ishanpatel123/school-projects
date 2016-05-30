using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditSystem.MessageClasses
{
    public class MessageEnums
    {
        public enum MessageType
        {
            START,
            EMAIL,
            MASS_EMAIL,
            SPECIFIC_EMAIL,
            ASSESSMENT,
            STANDARD_ASSESSMENT,
            SPECIALIZED_ASSESSMENT,
            REPORT,
            ACTIVITY_REPORT,
            MONTHLY_REPORT,
            SUMMARY_REPORT,
            NONE,
            END
        };
    }
}
