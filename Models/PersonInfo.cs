using System;
using System.Collections.Generic;

#nullable disable

namespace CrudBoard.Models
{
    public partial class PersonInfo
    {
        public int Personid { get; set; }
        public string Name { get; set; }
        public string Phoneno { get; set; }
        public string Address { get; set; }
        public int? Pincode { get; set; }
    }
}
