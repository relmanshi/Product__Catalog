
namespace PC.DAL;

public class Products
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }= DateTime.Now;
    public DateTime StartDate { get;set; }
     public int duration { get; set; }
    public double price { get; set; }


    public string createdBy { get; set; }
    public User User { get; set; }
    public Guid CategoryId { get; set; }
    public Categories Categories { get; set; }
}
