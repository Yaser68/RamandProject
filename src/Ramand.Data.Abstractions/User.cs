namespace Ramand.Data.Abstractions;

/// <summary>
/// A model defined for User.
/// </summary>
public class User
{
    public long Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;

}
