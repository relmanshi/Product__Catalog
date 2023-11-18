using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;

public class ReadProductsVM
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Category { get; set; }= string.Empty;
}
