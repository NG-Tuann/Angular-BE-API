using System;
namespace ptj_server.Dtos
{
	public class ProductDTO
	{
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? GeomancyId { get; set; }
        public string? Color { get; set; }
        public string? Note { get; set; }
        public bool BestSeller { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public int? CatId { get; set; }
        public int? MainStoneId { get; set; }
        public int? SubStoneId { get; set; }

        public IFormFile? File { get; set; }
        public IFormFile[]? Files { get; set; }
    }
}

