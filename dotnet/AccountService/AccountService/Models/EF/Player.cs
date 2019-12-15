using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountService.Models.EF
{
    public class Player
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public Nullable<DateTime> birthday { get; set; }
        public Nullable<long> sex { get; set; } = null;
        public string national { get; set; } = "";
    }
}