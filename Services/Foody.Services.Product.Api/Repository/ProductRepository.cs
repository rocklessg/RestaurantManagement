﻿using AutoMapper;
using Foody.Services.ProductApi.Models.Dto;
using Foody.Services.ProductApi.Models;
using Foody.Services.ProductApi.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Foody.Services.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;

        public ProductRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            _ = product.ProductId > 0 ? _db.Products.Update(product) : _db.Products.Add(product);
        
            //if (product.ProductId > 0)
            //{
            //    _db.Products.Update(product);
            //}
            //else
            //{
            //    _db.Products.Add(product);
            //}
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId==productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);

        }
    }
}
