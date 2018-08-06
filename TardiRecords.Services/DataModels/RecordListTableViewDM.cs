using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardiRecords.Services.DataModels
{
    public class RecordListTableViewDM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Guid RecordTypeId { get; set; }
    }
}
