using System;
namespace ptj_server.Models
{
	public class PromotionDetail
	{
        public int Id { get; set; }
        public int? PromotionId { get; set; }
        public int? CustomerId { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}

