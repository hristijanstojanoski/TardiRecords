using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardiRecords.Services.DataModels
{
    public class RecordTypeDM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SubType { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
