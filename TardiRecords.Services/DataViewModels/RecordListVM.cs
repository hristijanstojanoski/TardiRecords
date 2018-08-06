using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardiRecords.Services.DataModels;
using TardiRecords.Services.Helpers;

namespace TardiRecords.Services.DataViewModels
{
    public class RecordListVM
    {
        public RecordListDM Data { get; set; }
        public ActionHandler Success { get; set; }
    }
}
