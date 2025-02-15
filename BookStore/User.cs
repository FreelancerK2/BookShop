using System;
using System.Collections.Generic;

namespace BookStore;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
    public string Password { get; internal set; }
}
