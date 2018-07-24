using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TardiRecords.Services.DataViewModels;

namespace TardiRecords.Services.Helpers
{
    public class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null) return String.Empty;

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static List<EnumDropdownListVM> GetAllRecordSubTypeEnumInList()
        {
            List<EnumDropdownListVM> returnList = new List<EnumDropdownListVM>();
            try
            {
                foreach (Enum item in Enum.GetValues(typeof(Enums.RecordSubTypeEnum)))
                {
                    EnumDropdownListVM SSLM = new EnumDropdownListVM();
                    SSLM.Name = GetEnumDescription(item);
                    SSLM.Id = ((int)Enum.Parse(typeof(Enums.RecordSubTypeEnum), item.ToString()));
                    returnList.Add(SSLM);
                }
            }
            catch (Exception ex)
            { }
            return returnList;
        }
    }
}
