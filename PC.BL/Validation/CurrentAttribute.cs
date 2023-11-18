using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;

public class CurrentAttribute:ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateTime date)
        {
            return date >= DateTime.Now;
        }
        return true;
    }
}
