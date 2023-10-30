using System;
namespace ptj_server.Dtos
{
	public class UserDTO
	{
		public UserDTO()
		{
		}

        public int Id { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Fullname { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string IdCard { get; set; }
        public int? IdRole { get; set; }
    }
}

