using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class CategoryDTO
{
    public int CategoryId { get; set; }
    [Required,MaxLength(30,ErrorMessage = "name must be less than 20 characters long")]
    public string CategoryName { get; set; } = null!;

}
