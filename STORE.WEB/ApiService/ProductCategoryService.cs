using Newtonsoft.Json;
using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService
{
    public class ProductCategoryService
    {
        private readonly HttpClient _httpClient;

        public ProductCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProductCategoryDTO>> GetAllAsync()
        {
            List<ProductCategoryDTO> productCategoryDTOs;
            var response = await _httpClient.GetAsync("ProductCategory").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                productCategoryDTOs = JsonConvert.DeserializeObject<List<ProductCategoryDTO>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            else
            {
                productCategoryDTOs = null;
            }
            return productCategoryDTOs;
        }
    }
}
