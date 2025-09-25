using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SetiLab.Models;

public partial class Subject
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodeSubject { get; set; }

    public string NameSubject { get; set; } = null!;

    public int CountHours { get; set; }
}
