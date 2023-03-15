using HmsBackendTaskOne.Application.Commands.AddEmployee;
using HmsBackendTaskOne.Application.Queries.GetEmployeeById;
using System.Reflection;

namespace HmsBackendTaskOne.Application.Codes
{
    public class EmployeeAssemblyTypes
    {
        public static Assembly Command = typeof(AddEmployeeCommand).GetTypeInfo().Assembly;
        public static Assembly Query = typeof(GetEmployeeByIdQuery).GetTypeInfo().Assembly;
    }
}