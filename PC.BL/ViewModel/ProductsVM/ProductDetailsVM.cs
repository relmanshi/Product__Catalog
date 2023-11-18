using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;

public class ProductDetailsVM
{
    public Guid ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public double Price { get; set; }


    public DateTime CreationDate { get; set; }
    public DateTime StartDate { get; set; }
    public int Duration { get; set; }



    public string ?CreatedBy { get; set; }
    public string Category { get; set; }= string.Empty;
}
