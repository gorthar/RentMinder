namespace backend;

public class Property
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }

    public List<Lease> Leases { get; set; }
    public Owner Owner { get; set; }

}
