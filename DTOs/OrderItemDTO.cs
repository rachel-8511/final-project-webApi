using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

public partial class OrderItemDTO
{
    public int OrderItemId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int Quantity { get; set; }

}
