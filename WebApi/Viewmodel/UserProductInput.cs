using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Viewmodel
{
    public class UserProductInput
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}