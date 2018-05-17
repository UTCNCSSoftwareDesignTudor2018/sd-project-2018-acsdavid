using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikePortalWebApp.Models.ViewModel
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public ArticleViewModel Article { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
    }
}