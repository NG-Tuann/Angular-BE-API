using System;
namespace ptj_server.Models
{
	public class Cart
	{
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
        public int? ProductDetailId { get; set; }
        public bool? Is_Check { get; set; }
        public int? SavePrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual OrderProduct Order { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}

