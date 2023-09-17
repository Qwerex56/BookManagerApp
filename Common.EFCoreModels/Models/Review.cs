using System;
using System.Collections.Generic;

namespace Common.EFCore.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public string Reviewer { get; set; } = null!;

    public string ReviewText { get; set; } = null!;

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }
}
