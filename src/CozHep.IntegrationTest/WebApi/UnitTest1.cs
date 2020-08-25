using CozHep.Application.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace CozHep.IntegrationTest
{
   
    public class CepHepApiTest
    {
        private static HttpClient _httpClient = new HttpClient();

        public void TestMethod1()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:54207");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }
        private static async Task<ProductViewModel> CreateProduct(ProductViewModel product)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/products");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = product.AsJsonContent();

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var createdProduct = await response.Content.ReadAs<Product>();
            return createdProduct;
        }

        //private static async Task<Product> UpdateProduct(Guid id, Product product)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Put, $"api/products/{id}");
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    request.Content = product.AsJsonContent();

        //    var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        //    response.EnsureSuccessStatusCode();
        //    var updatedProduct = await response.Content.ReadAs<Product>();
        //    return updatedProduct;
        //}

    }
}
