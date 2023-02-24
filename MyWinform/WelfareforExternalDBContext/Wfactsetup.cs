using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MyWinform.WelfareforExternalDBContext
{
    public partial class Wfactsetup
    {
        public long SerialNo { get; set; }
        public string ActYear { get; set; }
        public DateTime ActStartDate { get; set; }
        public DateTime ActEndDate { get; set; }
        public string ActCode { get; set; }
        public string AcerDealCode { get; set; }
        public string Amount { get; set; }        
    }
}
