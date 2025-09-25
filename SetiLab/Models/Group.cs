using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SetiLab.Models;

public partial class Group
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CodeGroup { get; set; }

    public string NameGroup { get; set; } = null!;

    public int NumCourse { get; set; }

    public string NameSpeciality { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
