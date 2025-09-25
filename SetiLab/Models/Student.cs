using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SetiLab.Models;

public partial class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodeStud { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Lastname { get; set; }

    public DateOnly Birthday { get; set; }

    public decimal Phone { get; set; }

    public int CodeGroup { get; set; }

    public virtual Group CodeGroupNavigation { get; set; } = null!;
}
