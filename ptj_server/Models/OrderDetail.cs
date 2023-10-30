using System;
namespace ptj_server.Models
{
	public class OrderDetail
	{
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? Quantity { get; set; }
        public int? SalePrice { get; set; }

        public virtual OrderProduct Order { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}

