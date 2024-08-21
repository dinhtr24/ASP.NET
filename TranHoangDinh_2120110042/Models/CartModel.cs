using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranHoangDinh_2120110042.Context;

namespace TranHoangDinh_2120110042.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
