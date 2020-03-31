using System;
using System.Linq;

namespace Adia.SsnValidator.Validators
{
    public class AhvValidator : IValidator
    {
        public bool Validate(string ahv)
        {
            var ahv13 = ahv.Where(char.IsDigit).ToArray();
            if(ahv13.Count() != 13)
            {
                return false;
            }

            var ahv12 = ahv13.Take(12).Reverse().ToArray();
            var totalChecksum = 0;
            for (var i = 0; i < 12; i++)
            {
                var number = int.Parse(ahv12[i].ToString());
                if (i % 2 == 0)
                {
                    totalChecksum += 3 * number;
                }
                else
                {
                    totalChecksum += number;
                }
            }

            var nextTimesTen = Math.Ceiling(totalChecksum / 10.0) * 10;
            var checksumDigit = (int)nextTimesTen - totalChecksum;

            return checksumDigit == int.Parse(ahv.Last().ToString());
        }
    }
}