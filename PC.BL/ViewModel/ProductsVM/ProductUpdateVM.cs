using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;

public class ProductUpdateVM
{
    public Guid ProductId { get; set; }
    [Required (ErrorMessage ="This field is Required!")]
    public string ProductName { get; set; } = string.Empty;
    [Required(ErrorMessage = "This field is Required!")]
    public double Price { get; set; }
    [Required(ErrorMessage = "This field is Required!")]
    [Current (ErrorMessage ="Enter the present date")]
    public DateTime StartDate { get; set; }
    [Required(ErrorMessage = "This field is Required!")]
    public int Duration { get; set; }
    [Required(ErrorMessage = "This field is Required!")]
    public Guid CategoryId { get; set; }
}
