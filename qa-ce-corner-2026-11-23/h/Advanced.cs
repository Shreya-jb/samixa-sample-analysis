using System;
using System.Threading.Tasks;

namespace QaH
{
    public delegate void LynxHandler(string msg);

    public static class LynxExtensions
    {
        public static string Shout(this string s) => s.ToUpper();
    }

    public class LynxService
    {
        public event LynxHandler Changed;

        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; Changed?.Invoke("count"); }
        }

        public int this[int i] => i * 2;

        public static LynxService operator +(LynxService a, LynxService b) => new LynxService { Count = a.Count + b.Count };

        public async Task<int> LoadAsync()
        {
            await Task.Delay(1);
            return Helper(3);

            int Helper(int x) => x + Count;
        }

        public string Name() => "lynx".Shout();
    }
}
