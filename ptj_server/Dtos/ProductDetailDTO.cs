using System;
namespace ptj_server.Dtos
{
	public class ProductDetailDTO
	{
        public int? Id { get; set; }
        public int? ImportQuantity { get; set; }
        public ProductPriceDTO? ProductPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Size { get; set; }
        public int? SalePrice { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ProductDTO Product { get; set; }
    }
}

