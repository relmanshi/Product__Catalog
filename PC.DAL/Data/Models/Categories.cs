
namespace PC.DAL;

public class Categories
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }=string.Empty;
    public IEnumerable<Products> Products { get; set; } = new HashSet<Products>();
}
