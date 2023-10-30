using System;
using ptj_server.Dtos;
using ptj_server.Models;

namespace ptj_server.Interfaces
{
	public interface IOrderProductService
	{
		public Task<int> processNonCustomerPaypalSuccess(NonCustomerPaypalSuccess result);
	}
}

