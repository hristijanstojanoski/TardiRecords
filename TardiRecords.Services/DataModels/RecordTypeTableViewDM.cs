using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardiRecords.Services.DataModels
{
    public class RecordTypeTableViewDM
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public string SubtypeName { get; set; }
        public int SubtypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
