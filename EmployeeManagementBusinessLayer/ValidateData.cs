using EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EmployeeManagementBusinessLayer
{
    public class ValidateData : IValidateData
    {
        /// <summary>
        /// validate data
        /// </summary>
        /// <param name="employeedetail"></param>
        /// <returns></returns>
        public bool Validate(EmployeeDetailsEntity employeedetail)
        {

            employeedetail._Name = ConvertTitlecase(employeedetail._Name);
            if (employeedetail._Name == null)
                return false;

            employeedetail.Gender = ConvertTitlecase(employeedetail.Gender);
            if (!employeedetail.Gender.Equals("Male") && !employeedetail.Gender.Equals("Female"))
                return false;

            if (!ValidateEMailId(employeedetail.Email))
                return false;

            if (!ValidatePhoneNo(employeedetail.ContactNumber))
                return false;

            if (!ValidateDOB(employeedetail.DOB))
                return false;

            if (employeedetail.Salary < 0)
                return false;

            return true;

        }

        private string ConvertTitlecase(string name)
        {
            if (name.Any(char.IsDigit))
                return null;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            name = textInfo.ToTitleCase(name);
            return name;
        }


        private static bool ValidatePhoneNo(string mobileNo)
        {
            Regex regex = new Regex(@"^([\+]?91[-]?|[0])?[1-9][0-9]{9}$");

            if (regex.IsMatch(mobileNo))
                return true;
            return false;
        }

        private static bool ValidateEMailId(string emailId)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (regex.IsMatch(emailId))
                return true;
            return false;
        }

        private static bool ValidateDOB(string date)
        {
            string[] formats = { "dd/MM/yyyy" };
            DateTime parsedDateTime;
            return DateTime.TryParseExact(date, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
        }
        
    }
}
