using HospitalApi.PaymentTypes;

namespace HospitalApi.Payments;
public class Payment
{
    public int Id { get; set; }
    public PaymentType PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public string IsSuccess { get; set; }
}
