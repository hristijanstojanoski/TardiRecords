using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardiRecords.Services.DataModels;
using TardiRecords.Services.Helpers;

namespace TardiRecords.Services.DataViewModels
{
    public class RecordListNgVM
    {
        public List<RecordListTableViewDM> RecordsList { get; set; }
        public ActionHandler Success { get; set; }

        public RecordListNgVM()
        {
            Success = new ActionHandler();
        }
    }
}
