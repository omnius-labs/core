namespace Omnix.Base.Helpers
{
    internal static class MathHelper
    {
        public static ulong Roundup(ulong value, ulong unit)
        {
            if (value % unit == 0)
            {
                return value;
            }
            else
            {
                return ((value / unit) + 1) * unit;
            }
        }
    }
}
