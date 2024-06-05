using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class UserDTO
{
    public int UserId { get; set; }
   [Required, EmailAddress(ErrorMessage ="Invalid email address")]
    public string Email { get; set; } = null!;
   [Required, MaxLength(20,ErrorMessage ="first name must be less than 20 characters long")]
    public string FirstName { get; set; } = null!;
   [Required, MaxLength(20, ErrorMessage = "last name must be less than 20 characters long")]
    public string LastName { get; set; } = null!;
   [Required]
    public string Password { get; set; } = null!;





}

