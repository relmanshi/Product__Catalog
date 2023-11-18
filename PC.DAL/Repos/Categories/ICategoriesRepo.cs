using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DAL;

public interface ICategoriesRepo
{
    IEnumerable<Categories> GetCategories();

}
