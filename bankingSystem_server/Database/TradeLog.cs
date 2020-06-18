using System;
using System.Collections.Generic;

namespace bankingSystem_server.Database
{
    public partial class TradeLog
    {
        public int TlIndex { get; set; }
        public int ItUserIndex { get; set; }
        public int TlType { get; set; }
        public string TlContent { get; set; }
        public int? TlReceivedUserIndex { get; set; }
        public DateTime TlCreatedTime { get; set; }

        public virtual User ItUserIndexNavigation { get; set; }
        public virtual User TlReceivedUserIndexNavigation { get; set; }
    }
}
