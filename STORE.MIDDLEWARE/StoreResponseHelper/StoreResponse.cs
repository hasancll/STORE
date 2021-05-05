using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.MIDDLEWARE.StoreResponseHelper
{
    public static class StoreResponse
    {
        public static String GetStoreResponseModel(bool isSucces, String statusCode, String message, object response = null)
        {
            var responseModel = new StoreResponseModel();

            responseModel.IsSuccess = isSucces.ToString();
            responseModel.Message = message;
            responseModel.StatusCode = statusCode;
            responseModel.Response = response;

            return JsonConvert.SerializeObject(responseModel);
        }

        public static StoreResponseModel GetStoreResponseModelTry(bool isSucces, String statusCode, String message, object response = null)
        {
            var responseModel = new StoreResponseModel();

            responseModel.IsSuccess = isSucces.ToString();
            responseModel.Message = message;
            responseModel.StatusCode = statusCode;
            responseModel.Response = response;

            return responseModel;
        }
        
    }
}
