namespace backend;

public class Tenant
{
    public int Id { get; set; }
    public int LeaseId { get; set; }
    public int PropertyId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Notes { get; set; }
    public Lease Lease { get; set; }
    public Property Property { get; set; }

}
