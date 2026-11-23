namespace QaF.Billing
{
    public partial class Invoice
    {
        public decimal LateFee(decimal amount) => amount * KoalaLateFeeRate;

        public void MarkSent()
        {
            if (Subtotal() <= 0) throw new System.InvalidOperationException("empty invoice");
            State = InvoiceState.Sent;
        }
    }
}
