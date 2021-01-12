using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.MIDDLEWARE.StoreResponseHelper
{
    public class StoreResponseModel
    {
        public object Response { get; set; }
        public String StatusCode { get; set; }
        public String IsSuccess { get; set; }
        public String Message { get; set; }
    }
}
