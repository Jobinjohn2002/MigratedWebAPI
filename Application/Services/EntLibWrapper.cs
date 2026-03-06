using SynergyApplicationFrameworkApi.Application.Interfaces;
using Serilog;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public class EntLibWrapper : ISynergyExceptionHandler
    {
        public bool HandleException(Exception exception)
        {
            Log.Error(exception, "Unhandled exception");
            return false;
        }

        public bool HandleException(Exception exception, string policyName)
        {
            Log.Error(exception, "Unhandled exception. Policy: {Policy}", policyName);
            return false;
        }

        public bool HandleException(Exception exception, string policyName, out Exception exceptionToThrow)
        {
            Log.Error(exception, "Unhandled exception. Policy: {Policy}", policyName);
            exceptionToThrow = exception;
            return false;
        }

        public void ManageException(Exception exception)
        {
            Log.Error(exception, "Managed exception");
        }

        public void ManageException(Exception exception, string policyName)
        {
            Log.Error(exception, "Managed exception. Policy: {Policy}", policyName);
        }

        public void ManageException(Exception exception, string policyName, out Exception exceptionToThrow)
        {
            Log.Error(exception, "Managed exception. Policy: {Policy}", policyName);
            exceptionToThrow = exception;
        }
    }
}