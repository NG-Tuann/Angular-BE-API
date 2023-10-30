
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ptj_server.Models;

public partial class    User
{
    public User()
    {
        OrderProducts = new HashSet<OrderProduct>();
    }
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Fullname { get; set; }
    public DateTime Dob { get; set; }
    public string Phone { get; set; }
    public string IdCard { get; set; }
    public int? IdRole { get; set; }

    //[JsonIgnore]
    public virtual Role Role { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; set; }
}