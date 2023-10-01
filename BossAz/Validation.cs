using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BossAz
{
     public static class Validation
    {
        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception.
        /// </summary>
        /// <param name="name">The input string value (considered for a name or surname).</param>
        /// <returns>Returns true if the name is at least 3 characters long; otherwise, it throws an exception.</returns>
        /// <exception cref="ArgumentException">Thrown when the name is less than 3 characters long.</exception>
        public static bool CheckName(string? name)
        {
            if (name?.Trim().Length < 3)
                throw new ArgumentException("Name must be at least 3 characters long.");
            return true;
        }


        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception.
        /// </summary>
        /// <param name="age">The input int value (considered for an age).</param>
        /// <returns>Returns true if the age is between 18 and 100 (inclusive); otherwise, it throws an exception.</returns>
        /// <exception cref="ArgumentException">Thrown when the age is not within the specified range.</exception>
        public static bool CheckAge(int age)
        {
            if (!(age >= 18 && age <= 100))
                throw new ArgumentException("Age must be between 18 and 100.");
            return true;
        }



        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception.
        /// </summary>
        /// <param name="salary">The input double value (considered for a salary).</param>
        /// <returns>Returns true if the salary is greater than or equal to zero; otherwise, it throws an exception.</returns>
        /// <exception cref="ArgumentException">Thrown when the salary is less than zero.</exception>
        public static bool CheckSalary(double salary)
        {
            if (salary < 0)
                throw new ArgumentException("Salary must be greater than or equal to zero.");
            return true;
        }



        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met (null or not null); otherwise, it throws an exception.
        /// </summary>
        /// <param name="temp">The input value of any data type (considered for all references).</param>
        /// <returns>Returns true if the input value is not null; otherwise, it throws an exception.</returns>
        /// <exception cref="ArgumentException">Thrown when the input value is null.</exception>
        public static bool CheckNull(dynamic? temp)
        {
            if (temp == null)
                throw new ArgumentException("This object is null");
            return true;
        }



        /// <summary>
        /// Checks the length of the provided phone number. The phone number must consist of 10 digits.
        /// </summary>
        /// <param name="phone">The phone number to be checked.</param>
        /// <returns>Returns true if the phone number is valid; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Throws an exception if the phone number length is not equal to 10 digits.</exception>
        public static bool CheckPhoneNumber(string? phone)
        {
            if (phone?.Trim().Length != 10)
                throw new ArgumentException("Phone must be 10 numbers");
            return true;
        }



        /// <summary>
        /// This function checks the provided LinkedIn profile link and returns true if the link is valid; otherwise, it throws an exception.
        /// </summary>
        /// <param name="linkedinLink">The LinkedIn profile link to be checked.</param>
        /// <returns>Returns true if the LinkedIn profile link is valid; otherwise, it throws an exception.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided LinkedIn link is not valid.</exception>
        public static bool CheckLinkedInLink(string? linkedinLink)
        {
            if (IsValidLinkedInLink(linkedinLink))
                return true;
            throw new ArgumentException("Invalid LinkedIn profile link.");
        }



        /// <summary>
        /// Checks if the provided LinkedIn profile link is valid.
        /// </summary>
        /// <param name="linkedinLink">The LinkedIn profile link to be validated.</param>
        /// <returns>Returns true if the LinkedIn profile link is valid; otherwise, false.</returns>
        private static bool IsValidLinkedInLink(string? linkedinLink)
        {
            if (string.IsNullOrWhiteSpace(linkedinLink))
                return false;
            return linkedinLink.StartsWith("linkedin.com/in/", StringComparison.OrdinalIgnoreCase);
        }



        /// <summary>
        /// This function checks the provided GitHub profile link and returns true if the link is valid; otherwise, it throws an exception.
        /// </summary>
        /// <param name="githubLink">The GitHub profile link to be checked.</param>
        /// <returns>Returns true if the GitHub profile link is valid; otherwise, it throws an exception.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided GitHub link is not valid.</exception>
        public static bool CheckGitHubLink(string? githubLink)
        {
            if (IsValidGitHubLink(githubLink))
                return true;
            throw new ArgumentException("Invalid GitHub profile link.");
        }



        /// <summary>
        /// Checks if the provided GitHub profile link is valid.
        /// </summary>
        /// <param name="githubLink">The GitHub profile link to be validated.</param>
        /// <returns>Returns true if the GitHub profile link is valid; otherwise, false.</returns>
        private static bool IsValidGitHubLink(string? githubLink)
        {
            if (string.IsNullOrWhiteSpace(githubLink))
                return false;
            return githubLink.StartsWith("github.com/", StringComparison.OrdinalIgnoreCase);
        }



        /// <summary>
        /// Checks if the provided worker's username and password match any entry in the database.
        /// </summary>
        /// <param name="userAccInfo">An array containing the worker's username and password to be checked.</param>
        /// <returns>True if the provided username and password match a database entry; otherwise, false.</returns>
        /// <exception cref="NullReferenceException">Thrown when the worker list in the database is empty.</exception>
        public static bool Check_Workers_UserName_And_Pass_In_Database(in string[] userAccInfo,Database database)
        {
            if (database.Workers != null)
            {
                foreach (var user in database.Workers)
                {
                    if (userAccInfo[0] == user.UserName && userAccInfo[1] == user.Password) { return true; }
                }
                return false;
            }
            throw new NullReferenceException("Worker list is empty...");
        }


        /// <summary>
        /// Checks if the provided employer's username and password match any entry in the database.
        /// </summary>
        /// <param name="userAccInfo">An array containing the employer's username and password to be checked.</param>
        /// <returns>True if the provided username and password match a database entry; otherwise, false.</returns>
        /// <exception cref="NullReferenceException">Thrown when the employer list in the database is empty.</exception>
        public static bool Check_Employers_UserName_And_Pass_In_Database(in string[] userAccInfo,Database database)
        {
            if (database.Employers != null)
            {
                foreach (var user in database.Employers)
                {
                    if (userAccInfo[0] == user.UserName && userAccInfo[1] == user.Password) { return true; }
                }
                return false;
            }
            throw new NullReferenceException("Employers list is empty...");
        }
    }
}
