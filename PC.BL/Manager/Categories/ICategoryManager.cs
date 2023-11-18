using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;

public interface ICategoryManager
{
    IEnumerable<ReadCategoriesVM> GetAllCategories();
}
