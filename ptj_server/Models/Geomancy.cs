namespace ptj_server.Models;

public partial class Geomancy
{
    public Geomancy()
    {
        Products = new HashSet<Product>();
        ProductDiscounts = new HashSet<ProductDiscount>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
}