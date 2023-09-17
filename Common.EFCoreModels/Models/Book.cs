using System;
using System.Collections.Generic;

namespace Common.EFCore.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int? Year { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
