using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_cf_webui.Models
{
    public class Product
    {
        public Product( int id , String text, String image ) {
            Id = id;
            Text = text;
            Image = image;
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }

    }
}