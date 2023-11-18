using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;

public class ReadCategoriesVM
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
