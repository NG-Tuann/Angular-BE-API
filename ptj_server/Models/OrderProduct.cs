using System;
namespace ptj_server.Models
{
	public class OrderProduct
	{
        public OrderProduct()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CustomerId { get; set; }
        public string AddressDelivery { get; set; }
        public DateTime? DatePay { get; set; }
        public string PayType { get; set; }
        public decimal? TotalPay { get; set; }
        public string OrderState { get; set; }
        public string PhoneNonAccount { get; set; }
        public string NameCusNonAccount { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? ShipFee { get; set; }
        public int? IdUser { get; set; }
        public string MailNonCus { get; set; }
        public int? PromotionId { get; set; }
        public int? CustomerTypeId { get; set; }
        public string OrderProductId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Promotion Promotion{ get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

