using System;
using System.Collections.Generic;

namespace WebApi.Models.Entity;

public partial class Stuednt
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Gender { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PicturePath { get; set; } = null!;
}
