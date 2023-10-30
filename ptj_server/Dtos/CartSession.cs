using System;
namespace ptj_server.Dtos
{
	public class CartSession
	{
		public int? Id { get; set; }
        public int? Quantity { get; set; }
        public int? ProductDetailId { get; set; }
        public Boolean? IsCheck { get; set; }
        public double? SavePrice { get; set; }
        public string? Thumbnail { get; set; }
        public int? Size { get; set; }
        public string? Name { get; set; }
        public double? SalePrice { get; set; }


    }
}

