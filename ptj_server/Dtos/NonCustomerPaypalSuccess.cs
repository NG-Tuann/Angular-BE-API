using System;
namespace ptj_server.Dtos
{
	public class NonCustomerPaypalSuccess
	{
		public CartSession[] Cart { get; set; }
        public ShippingInfo ShipInfo { get; set; }
    }
}

