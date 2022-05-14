using System;

namespace EmployeeManagementException
{
    public class BadRequest :Exception
    {
        public BadRequest(string message):base(message)
        {
                
        }
    }
}
