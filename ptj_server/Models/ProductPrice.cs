using System;
namespace ptj_server.Models
{
	public class ProductPrice
	{
        public ProductPrice()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }
        public int Id { get; set; }
        public int BasePrice { get; set; }
        public int SalePrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? InActive { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}

