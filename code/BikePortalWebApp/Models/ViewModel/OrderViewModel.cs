using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikePortalWebApp.Models.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public IList<OrderItemViewModel> OrderedArticles { get; set; }
    }
}