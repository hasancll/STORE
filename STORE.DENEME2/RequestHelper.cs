using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STORE.DENEME2
{
    public static class RequestHelper
    {
        /// <summary>
        /// <para><b>EN: </b>This Method creating a request message for send.</para>
        /// <para><b>TR: </b>Bu method gönderme için bir istek mesajı oluşturur.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="httpMethod"></param>
        /// <param name="url"></param>
        /// <returns>HttpRequestMessage</returns>
        public static HttpRequestMessage HttpRequestMessage(HttpMethod httpMethod, String url, Object obj = null)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("https://localhost:5001/api/"+url),
                Method = httpMethod
            };

            if (json != "null")
            {
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            requestMessage.Headers.Add("Accept", "application/json");

            //if (Token.token != null)
            //    requestMessage.Headers.Add("Authorization", $"Bearer {Token.token}");

            return requestMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequestMessage"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetHttpResponseMultipleAsyn<T>(HttpRequestMessage httpRequestMessage)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseObject = JsonConvert.DeserializeObject<List<T>>(responseString);

            return responseObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequestMessage"></param>
        /// <returns></returns>
        public static async Task<T> GetHttpResponseSingleAsync<T>(HttpRequestMessage httpRequestMessage)
        {
            HttpClient httpClient = new HttpClient();

            String responseString = "";

            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
                responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //DialogResult dialogResult = MessageBox.Show("Sistemsel bir sıkıntıyla karşılaşılmıştır. Lütfen program yöneticisine ulaşınız ve ona bu hata mesajını bildiriniz. Hata mesajı : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //if (dialogResult == DialogResult.OK)
                //{
                //    Application.Exit();
                //}

            }

            var responseObject = JsonConvert.DeserializeObject<T>(responseString);
            return responseObject;
        }
    }
}
