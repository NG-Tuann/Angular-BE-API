using System;
namespace ptj_server.Dtos
{
	public class ProductPriceDTO
	{
        public int? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? BasePrice { get; set; }
        public int? SalePrice { get; set; }
        public bool? InActive { get; set; }
    }
}

