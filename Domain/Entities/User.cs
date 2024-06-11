namespace Domain;

public class User : Entity
{
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public ICollection<Payment> Payments { get; private set; }
}