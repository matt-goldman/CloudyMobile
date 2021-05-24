using System;

namespace _2_gt4.Domain.Exceptions
{
    public class UnsupportedColourException : Exception
    {
        public UnsupportedColourException(string code)
            : base($"Colour \"{code}\" is unsupported.")
        {
        }
    }
}
