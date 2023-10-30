using System;
namespace ptj_server.Dtos
{
	public class CategoryProductDTO
	{
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}

