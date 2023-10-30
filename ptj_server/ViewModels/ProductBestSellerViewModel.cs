using System;
using System.ComponentModel.DataAnnotations;

namespace ptj_server.ViewModels
{
    public class ProductBestSellerViewModel
    {
        public int id { get; set; }
        public string? image { get; set; }
        public string? name { get; set; }
        public int? price { get; set; }
        public int? discount_value { get; set; }
        public string? unit { get; set; }
        public bool? active { get; set; }
        public string? dis_name { get; set; }
        public Boolean? is_sold_out { get; set; }

    }
}
