namespace backend;

public static class LeaseMapper
{

    public static LeaseDto ToLeaseDto(this Lease lease)
    {
        return new LeaseDto
        {
            PropertyId = lease.PropertyId,
            TenantId = lease.TenantId,
            StartDate = lease.StartDate,
            EndDate = lease.EndDate,
            Rent = lease.Rent,
            Deposit = lease.Deposit,
            IsDepositPaid = lease.IsDepositPaid,
            IsDepositReturned = lease.IsDepositReturned,
            IsTerminated = lease.IsTerminated,
            TerminationDate = lease.TerminationDate,
            TerminationReason = lease.TerminationReason,
            Notes = lease.Notes
        };
    }

    public static Lease ToLeaseModel(this LeaseDto leaseDto)
    {
        return new Lease
        {
            PropertyId = leaseDto.PropertyId,
            TenantId = leaseDto.TenantId,
            StartDate = leaseDto.StartDate,
            EndDate = leaseDto.EndDate,
            Rent = leaseDto.Rent,
            Deposit = leaseDto.Deposit,
            IsDepositPaid = leaseDto.IsDepositPaid,
            IsDepositReturned = leaseDto.IsDepositReturned,
            IsTerminated = leaseDto.IsTerminated,
            TerminationDate = leaseDto.TerminationDate,
            TerminationReason = leaseDto.TerminationReason,
            Notes = leaseDto.Notes
        };
    }
}
