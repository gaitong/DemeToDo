using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Viewmodel
{
    public class ProductInput
    {
        public string Name { get; set; }
        public int MainProductId { get; set; }
        public int Price { get; set; }
    }
}