using System;
using System.Runtime.Serialization;

namespace ptj_server.Models
{
	public class ProductDetail
	{
        public ProductDetail()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? ImportQuantity { get; set; }
        public int? ProductPriceId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Size { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductPrice ProductPrice { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

