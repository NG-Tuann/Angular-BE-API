using System;
namespace ptj_server.Models
{
	public partial class CustomerType
	{
		public CustomerType()
		{
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string CustomerTypeName { get; set; }
        public int? DiscountValue { get; set; }
        public string DiscountUnit { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

