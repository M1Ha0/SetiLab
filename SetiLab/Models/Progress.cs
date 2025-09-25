using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SetiLab.Models;

public partial class Progress
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodeProgress { get; set; }

    public int CodeStud { get; set; }

    public int CodeSubject { get; set; }

    public int CodeLector { get; set; }

    public DateOnly DateExam { get; set; }

    public int Estimate { get; set; }
}
