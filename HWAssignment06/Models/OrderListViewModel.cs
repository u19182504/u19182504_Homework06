using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWAssignment06.Models
{
    public class OrderListViewModel
    {
        public Orders currentOrder { get; set; }

        public List<OrderItems> OrderItems = new List<OrderItems>();
    }
}