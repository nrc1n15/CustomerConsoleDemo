//2.- In a separate file create a Customer class with the following properties:
//	Id(integer): Unique identifier for the customer.
//	Name (string): Name of the customer.
//	Age (integer): Age of the customer.
//	Email (string): Email address of the customer.


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsole;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int Age { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;


}
