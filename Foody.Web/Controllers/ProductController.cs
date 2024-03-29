﻿using Foody.Web.Models;
using Foody.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foody.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger=logger;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetAllProductsAsync<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> ProductCreate() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProductAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProductAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }

       // Get
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);

                if (response != null && response.IsSuccess)
                {
                    ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                    return View(model);
                }
                else
                {
                    _logger.LogError("Unable to retrieve product for deletion. Response: {@Response}", response);
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the delete request.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accessToken = await HttpContext.GetTokenAsync("access_token");
                    var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId, accessToken);

                    if (response.IsSuccess)
                    {
                        return RedirectToAction(nameof(ProductIndex));
                    }
                    else
                    {
                        _logger.LogError("Unable to delete product. Response: {Response}", response);
                    }
                }
                else
                {
                    _logger.LogWarning("Invalid model state during product deletion.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the delete request.");
            }

            return View(model);
        }


        // GET
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> ProductDelete(int productId)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");
        //    var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
        //    if (response != null && response.IsSuccess)
        //    {
        //        ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
        //        return View(model);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ProductDelete(ProductDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var accessToken = await HttpContext.GetTokenAsync("access_token");
        //        var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId, accessToken);
        //        if (response.IsSuccess)
        //        {
        //            return RedirectToAction(nameof(ProductIndex));
        //        }
        //    }
        //    return View(model);
        //}
    }
}
