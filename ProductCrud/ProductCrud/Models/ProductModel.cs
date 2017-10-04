using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCrud.Models
{
    public class ProductModel
    {
        public long Id
        {
            get;
            set;
        }

        public DateTime DateInput
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public eCategory Category
        {
            get;
            set;
        }
    }
}