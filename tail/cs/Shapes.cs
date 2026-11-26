using System.Collections.Generic;
using System.Threading.Tasks;

namespace QaTail
{
    public abstract class Shape
    {
        public abstract double Area();
        public virtual string Describe() => $"Shape area {Area()}";
    }

    public class Circle : Shape
    {
        private readonly double _r;
        public Circle(double r) { _r = r; }
        public override double Area() => 3.14159 * _r * _r;
        public override string Describe() => $"Circle {base.Describe()}";
    }

    public class Box<T>
    {
        private readonly List<T> _items = new();
        public void Add(T item) => _items.Add(item);
        public T Get(int i) => _items[i];
    }

    public static class ShapeOps
    {
        public static async Task<double> TotalAreaAsync(IEnumerable<Shape> shapes)
        {
            await Task.Delay(1);
            double total = 0;
            foreach (var s in shapes) total += s.Area();
            return total;
        }
    }
}
