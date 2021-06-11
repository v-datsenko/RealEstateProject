using ApplicationCore.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationCore.Services
{
    public class ValidationPersonService : IValidationService<Person>
    {
        public bool Valid(Person obj)
        {
            Regex rgx = new Regex("^[A-Z][a-zA-Z]*$");
            if (!Regex.Match(obj.FirstName, "^[A-Z][a-zA-Z]*$").Success)
                return false;
            if (!Regex.Match(obj.SecondName, "^[A-Z][a-zA-Z]*$").Success)
                return false;
            if (!Regex.Match(obj.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z").Success)
                return false;
            return true;
        }
    }
}
