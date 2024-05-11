using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

public class Payment
{
    public int Id { get; set; }
    public int LeaseId { get; set; }
    public DateTime PaymentDate { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }
    public string PaymentType { get; set; }
    public string Notes { get; set; }
    public Lease Lease { get; set; }
}
