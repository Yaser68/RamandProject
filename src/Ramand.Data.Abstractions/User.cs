namespace Ramand.Data.Abstractions;

public class User
{
    public long Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;

}
