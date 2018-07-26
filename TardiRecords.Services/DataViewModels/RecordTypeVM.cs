using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardiRecords.Services.DataModels;
using TardiRecords.Services.Helpers;

namespace TardiRecords.Services.DataViewModels
{
    public class RecordTypeVM
    {
        public RecordTypeDM Data { get; set; }
        public ActionHandler Success { get; set; }
    }
}
