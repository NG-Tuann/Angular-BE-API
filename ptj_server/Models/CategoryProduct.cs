using System;
using System.Text.Json.Serialization;

namespace ptj_server.Models
{
	public class CategoryProduct
	{
        public CategoryProduct()
        {
            InverseParent = new HashSet<CategoryProduct>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        
        public virtual CategoryProduct Parent { get; set; }
        [JsonIgnore]
        public virtual ICollection<CategoryProduct> InverseParent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}

