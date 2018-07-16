using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_cf_webui.Services
{
    public class Product
    {
        public Product( int id , String text ) {
            Id = id ;
            Text = text ;
        }
        public int Id { get; set; }
        public string Text { get; set; }
    }
}