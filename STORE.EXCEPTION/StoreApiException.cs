using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.EXCEPTION
{
    public class StoreApiException : Exception
    {
        public StoreApiException(string message) : base(message)
        {
        }
    }
}
