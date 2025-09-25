using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SetiLab.Models;

public partial class Lector
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodeLector { get; set; }

    public string NameLector { get; set; } = null!;

    public string Science { get; set; } = null!;

    public string Post { get; set; } = null!;

    public DateOnly Date { get; set; }
}
