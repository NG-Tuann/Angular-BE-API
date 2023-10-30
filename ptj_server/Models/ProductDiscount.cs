using System;
namespace ptj_server.Models
{
	public class ProductDiscount
	{
        public int Id { get; set; }
        public int DiscountValue { get; set; }
        public string DiscountUnit { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool Active { get; set; }

        public string? Name { get; set; }

        public int? ProductId { get; set; }
        public int? StoneId { get; set; }
        public int? GemId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Geomancy Geomancy { get; set; }
        public virtual StoneType StoneType { get; set; }
    }
}

