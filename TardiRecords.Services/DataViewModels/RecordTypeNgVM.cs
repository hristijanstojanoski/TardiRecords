using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardiRecords.Services.DataModels;
using TardiRecords.Services.Helpers;

namespace TardiRecords.Services.DataViewModels
{
    public class RecordTypeNgVM
    {
        public List<EnumDropdownListVM> SubtypeList { get; set; }
        public List<RecordTypeTableViewDM> RecordsList { get; set; }
        public ActionHandler Success { get; set; }

        public RecordTypeNgVM()
        {
            Success = new ActionHandler();
        }
    }
}
