using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PC.BL;

public class RegisterVM
{
    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Alphabets Only")]
    [Required(ErrorMessage="Required")]
    public string FirstName { get; set; }=string.Empty;


    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Alphabets Only")]
    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Required")]
    [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+" +
        "(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@" +
        "(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9]" +
        "(?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Invalid Email")]
    public string Email=string.Empty;

    [Required(ErrorMessage = "Required")]
    public string Password = string.Empty;

}
