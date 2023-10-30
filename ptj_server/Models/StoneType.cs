using System;
namespace ptj_server.Models
{
	public class StoneType
	{
        public StoneType()
        {
            ProductMainStones = new HashSet<Product>();
            ProductSubStones = new HashSet<Product>();
            ProductDiscounts = new HashSet<ProductDiscount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> ProductMainStones { get; set; }
        public virtual ICollection<Product> ProductSubStones { get; set; }
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
    }
}

