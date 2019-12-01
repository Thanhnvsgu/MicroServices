using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountService.Models.EF
{
    public class Pokemon
    {
        public int id { get; set; }

        public string name { get; set; }

        public string species { get; set; }

        public string height { get; set; }

        public string weight { get; set; }

        public string hp { get; set; }

        public string attack { get; set; }

        public string defense { get; set; }

        public string spatk { get; set; }

        public string spdef { get; set; }

        public string speed { get; set; }

        public string image { get; set; }


    }
}