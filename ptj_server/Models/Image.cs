using System;
using System.Text.Json.Serialization;

namespace ptj_server.Models
{
	public class Image
	{
        public int Id { get; set; }
        public string? NameImages { get; set; }
        public int? IdProduct { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}

