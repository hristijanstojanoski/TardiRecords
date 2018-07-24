using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardiRecords.Services.Enums
{
    public enum RecordSubTypeEnum
    {
        [Description("No Subtype")] NoSubType = 0,
        [Description("Subtype 1")] SubType = 1,
    }
}
