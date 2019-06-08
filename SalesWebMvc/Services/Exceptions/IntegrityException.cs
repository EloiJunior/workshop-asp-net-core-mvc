using System;


namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException    //herda do ApplicationException
    {
        public IntegrityException(string message) : base(message)   //base: repassa para superclasse
        {
        }
    }
}
