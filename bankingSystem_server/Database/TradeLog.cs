using System;
using System.Collections.Generic;

namespace bankingSystem_server.Database
{
    public partial class TradeLog
    {
        public int TlIndex { get; set; }
        public int TlUserIndex { get; set; }
        public int TlType { get; set; }
        public string TlContent { get; set; }
        public int? TlReceivedUserIndex { get; set; }
        public DateTime TlCreatedTime { get; set; }

        public virtual User TlReceivedUserIndexNavigation { get; set; }
        public virtual User TlUserIndexNavigation { get; set; }
    }
}
