using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardiRecords.Services.DataModels
{
    public class UsersDM
    {
        public Guid AppUserId { get; set; }
        public string AspNetUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
        public DateTime LastChangedOn { get; set; }
        public string LastChangedBy { get; set; }
        public string Position { get; set; }
    }
}
