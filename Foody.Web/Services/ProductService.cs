using Foody.Web.Models;
using Foody.Web.Services.IServices;

namespace Foody.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiConstant.ApiType.POST,
                Data = productDto,
                Url = ApiConstant.ProductAPIBase + "/api/product",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiConstant.ApiType.DELETE,
                Url = ApiConstant.ProductAPIBase + "/api/product/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiConstant.ApiType.GET,
                Url = ApiConstant.ProductAPIBase + "/api/product",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiConstant.ApiType.GET,
                Url = ApiConstant.ProductAPIBase + "/api/product/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiConstant.ApiType.PUT,
                Data = productDto,
                Url = ApiConstant.ProductAPIBase + "/api/product",
                AccessToken = ""
            });
        }
    }
}
