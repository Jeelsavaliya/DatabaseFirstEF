using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstEF.Models;

public partial class Student
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Standard { get; set; }
    [Required]
    public string? School { get; set; }
    [Required]
    public int? Age { get; set; }
}
