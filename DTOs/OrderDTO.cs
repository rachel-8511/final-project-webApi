using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    [Required, DataType("dd-mm-yyyy")]

    public DateTime OrderDate { get; set; }
    [Required]

    public double OrderSum { get; set; }
    [Required]

    public int UserId { get; set; }

    public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

}
