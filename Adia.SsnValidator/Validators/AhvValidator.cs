﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Adia.SsnValidator.Validators
{
    internal sealed class AhvValidator : IValidator
    {
        public ValidationResult Validate(string ahv)
        {
            if (ahv == null)
            {
                throw new ArgumentNullException(nameof(ahv));
            }

            var regex = new Regex(@"^756\.\d{4}\.\d{4}\.\d{2}$");
            if (!regex.IsMatch(ahv))
            {
                return ValidationResult.InvalidFormat;
            }

            var ahv13 = ahv.Where(char.IsDigit).ToArray();
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

            var isChecksumCorrect = checksumDigit == int.Parse(ahv.Last().ToString());
            return isChecksumCorrect ? ValidationResult.Valid : ValidationResult.InvalidChecksum;
        }
    }
}
