using System;
using System.Collections.Generic;

namespace QaF.Billing
{
    public enum InvoiceState { Draft, Sent, Paid }

    public interface ITaxRule
    {
        decimal Apply(decimal amount);
    }

    public record LineItem(string Sku, decimal Price, int Qty);

    public partial class Invoice : ITaxRule
    {
        public const decimal KoalaLateFeeRate = 0.07m;
        public string Number { get; set; } = "";
        public InvoiceState State { get; private set; } = InvoiceState.Draft;
        private readonly List<LineItem> _items = new();

        public void Add(LineItem item) => _items.Add(item);

        public void Add(string sku, decimal price) => Add(new LineItem(sku, price, 1));

        public decimal Subtotal()
        {
            decimal sum = 0;
            foreach (var i in _items) sum += i.Price * i.Qty;
            return sum;
        }

        public decimal Apply(decimal amount) => amount * 1.18m;

        public decimal Total() => Apply(Subtotal()) + LateFee(Subtotal());

        public T Pick<T>(Func<Invoice, T> selector) => selector(this);

        public class Audit
        {
            public static string Describe(Invoice inv) => $"{inv.Number}:{inv.Total()}";
        }
    }
}
