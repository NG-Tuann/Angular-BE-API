using System;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace ptj_server.Models
{
	public class Product
	{
        public Product()
        {
            Images = new HashSet<Image>();
            ProductDetails = new HashSet<ProductDetail>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            Reviews = new HashSet<Review>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? GeomancyId { get; set; }
        public string Image { get; set; }
        public string? Color { get; set; }
        public string? Note { get; set; }
        public bool BestSeller { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public int? CatId { get; set; }
        public int? MainStoneId { get; set; }
        public int? SubStoneId { get; set; }

        public virtual CategoryProduct Cat { get; set; }
        public virtual Geomancy Geomancy { get; set; }
        public virtual StoneType MainStone { get; set; }
        public virtual StoneType SubStone { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

