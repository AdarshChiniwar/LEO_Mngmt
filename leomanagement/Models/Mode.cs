using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leomanagement.Models
{
    public class ApplicationModel
    {
        public ModeEnum Mode { get; set; }
        public string Link { get; set; }
        public string EncData { get; set; }

    }

    public enum ModeEnum
    {
        Bussiness,
        Kiosk
    }

    public class ApplicationLink
    {
        public const string BussinessLink = "https://portal.leosalonsoftware.com?login={0}";
        public const string KioskLink = "https://m.leosalonsoftware.com/CheckIn?key={0}";
    }
}
