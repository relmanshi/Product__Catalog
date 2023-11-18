using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.BL;

public class AddProductVM
{
    [Required(ErrorMessage="This Field is required!")]
    public string ProductName { get; set; }=string.Empty;

    [Required(ErrorMessage = "This Field is required!")]
    [Current(ErrorMessage="Enter the present date")]
    public DateTime StartDate { get; set; }
    [Required(ErrorMessage = "This Field is required!")]
    public int Duration { get; set; }
    [Required(ErrorMessage = "This Field is required!")]
    public double Price { get; set; }
    [Required(ErrorMessage = "This Field is required!")]
    public Guid CategoryId { get; set; }
    
}
