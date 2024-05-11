using System.ComponentModel.DataAnnotations.Schema;

namespace backend;

public class Lease
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int TenantId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Rent { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Deposit { get; set; }
    public bool IsDepositPaid { get; set; }
    public bool IsDepositReturned { get; set; }
    public bool IsTerminated { get; set; }
    public DateTime? TerminationDate { get; set; }
    public string TerminationReason { get; set; }
    public string Notes { get; set; }

    public Property Property { get; set; }
    public List<Payment> Payments { get; set; }

}
