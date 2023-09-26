using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.EFCore.Models;

public partial class Book
{
    public int BookId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Author { get; set; } = null!;

    public int? Year { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
