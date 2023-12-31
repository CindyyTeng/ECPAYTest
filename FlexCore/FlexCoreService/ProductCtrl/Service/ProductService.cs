﻿using EFModels.Models;
using FlexCoreService.ProductCtrl.Interface;
using FlexCoreService.ProductCtrl.Models.Dtos;

namespace FlexCoreService.ProductCtrl.Service
{
    public class ProductService
    {
        private IProductRepository _repo;
        private AppDbContext _db;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
            _db = new AppDbContext();
        }

        //public IEnumerable<ProductCardDto> SearchProducts()
        //{
        //    var products = _repo.SearchProducts();
        //    return products;
        //}

        public IEnumerable<ProductCardDto> SearchProducts(int salesId, string? categoryName, string? subCategoryName)
        {
            var products = _repo.SearchProducts(salesId, categoryName, subCategoryName);
            return products;
        }

        public IEnumerable<ProductDetailDto> GetProductDetail(string productId)
        {
            var product = _repo.GetProductDetail(productId);
            return product;
        }
    }
}
