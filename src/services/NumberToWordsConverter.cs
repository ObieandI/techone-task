using System;
using System.Collections.Generic;

public class NumberToWordsConverter
{
    private static readonly string[] units = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
    private static readonly string[] teens = { "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
    private static readonly string[] tens = { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

    public string Convert(string number)
    {
        if (!decimal.TryParse(number, out decimal amount))
        {
            throw new ArgumentException("Invalid number format");
        }

        int dollars = (int)Math.Floor(amount);
        int cents = (int)Math.Round((amount - dollars) * 100);

        string result = ConvertDollars(dollars);
        if (cents > 0)
        {
            result += " AND " + ConvertCents(cents);
        }

        return result.Trim();
    }

    private string ConvertDollars(int dollars)
    {
        if (dollars == 0)
        {
            return "ZERO DOLLARS";
        }

        List<string> parts = new List<string>();

        if (dollars >= 1000000)
        {
            int millions = dollars / 1000000;
            parts.Add(ConvertHundreds(millions) + " MILLION");
            dollars %= 1000000;
        }

        if (dollars >= 1000)
        {
            int thousands = dollars / 1000;
            parts.Add(ConvertHundreds(thousands) + " THOUSAND");
            dollars %= 1000;
        }

        if (dollars > 0)
        {
            parts.Add(ConvertHundreds(dollars));
        }

        return string.Join(" ", parts) + " DOLLARS";
    }

    private string ConvertCents(int cents)
    {
        return ConvertTens(cents) + " CENTS";
    }

    private string ConvertHundreds(int number)
    {
        List<string> parts = new List<string>();

        if (number >= 100)
        {
            parts.Add(units[number / 100] + " HUNDRED");
            number %= 100;

            if (number > 0)
            {
                parts.Add("AND");
            }
        }

        if (number > 0)
        {
            parts.Add(ConvertTens(number));
        }

        return string.Join(" ", parts);
    }

    private string ConvertTens(int number)
    {
        if (number < 10)
        {
            return units[number];
        }
        else if (number < 20)
        {
            return teens[number - 10];
        }
        else
        {
            string result = tens[number / 10];
            if (number % 10 > 0)
            {
                result += "-" + units[number % 10];
            }
            return result;
        }
    }
}
