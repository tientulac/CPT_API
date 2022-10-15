using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPT_Sutures.Models
{
    public class ProductModel : Product
    {
        public string CategoryName { get; set; }
        public string TypeName { get; set; }
        public double FromPrice { get; set; }
        public double ToPrice { get; set; }
    }
}