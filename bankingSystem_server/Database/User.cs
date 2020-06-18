using System;
using System.Collections.Generic;

namespace bankingSystem_server.Database
{
    public partial class User
    {
        public User()
        {
            TradeLogTlReceivedUserIndexNavigation = new HashSet<TradeLog>();
            TradeLogTlUserIndexNavigation = new HashSet<TradeLog>();
        }

        public int UsrIndex { get; set; }
        public string UsrName { get; set; }
        public int UsrAccount { get; set; }
        public string UsrPassword { get; set; }
        public int UsrAmount { get; set; }

        public virtual ICollection<TradeLog> TradeLogTlReceivedUserIndexNavigation { get; set; }
        public virtual ICollection<TradeLog> TradeLogTlUserIndexNavigation { get; set; }
    }
}
