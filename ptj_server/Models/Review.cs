using System;
namespace ptj_server.Models
{
	public class Review
	{
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Rate { get; set; }
        public DateTime? Created_Date { get; set; }
        public bool? Is_Update { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}

