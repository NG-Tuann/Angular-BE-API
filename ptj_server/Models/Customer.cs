using System;
using System.Text.Json.Serialization;

namespace ptj_server.Models
{
	public class Customer
	{
		public Customer()
		{
            PromotionDetails = new HashSet<PromotionDetail>();
            OrderProducts = new HashSet<OrderProduct>();
            Reviews = new HashSet<Review>();
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
        public string? IdCard { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? ScorePay { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }

        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<PromotionDetail> PromotionDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}

