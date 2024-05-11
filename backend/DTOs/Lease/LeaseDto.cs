namespace backend;

public class LeaseDto
{

    public int PropertyId { get; set; }
    public int TenantId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Rent { get; set; }
    public decimal Deposit { get; set; }
    public bool IsDepositPaid { get; set; }
    public bool IsDepositReturned { get; set; }
    public bool IsTerminated { get; set; }
    public DateTime? TerminationDate { get; set; }
    public string TerminationReason { get; set; }
    public string Notes { get; set; }


}
