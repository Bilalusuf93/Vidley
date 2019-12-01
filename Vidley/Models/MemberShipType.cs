using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SighnUpFee { get; set; }
        public byte DurationMonths { get; set; }
        public short Discount { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayasYouGo = 1;


    }
}