using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Classes
{
    public class Validation
    {
        public Validation() { }

        public bool IsEmail(string possibleEmail)
        {
           //check if empty
           if (IsEmpty(possibleEmail))
            {
                return false;
            }
            string email = possibleEmail;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool ValidateCreditCard(string creditCardNumber)
        {
            //check if empty
            if (IsEmpty(creditCardNumber))
            {
                return false;
            }
            //Strip any non-numeric values
            creditCardNumber = Regex.Replace(creditCardNumber, @"[^\d]", "");

            //Build your Regular Expression
            Regex expression = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");

            //Return if it was a match or not
            return expression.IsMatch(creditCardNumber);
        }

        //check if valid expiration date
        public bool IsExpirationDate(string expiryDate)
        {
            Regex expression = new Regex(@"/^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$/");
            return expression.IsMatch(expiryDate);
        }

        //check for all numbers
        public bool IsNumeric(string text)
        {
            //check if empty
            if (IsEmpty(text))
            {
                return false;
            }
            int i = 0;
            bool result = int.TryParse(text, out i);
            return result;
        }

        //check for all letters
        public bool IsAlphabetic(string text)
        {
            //check if empty
            if (IsEmpty(text))
            {
                return false;
            }
            return Regex.IsMatch(text, @"^[a-zA-Z]+$");
        }

        //check empty
        public bool IsEmpty(string text)
        {
            if (text == "")
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}
