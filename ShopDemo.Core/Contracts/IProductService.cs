﻿using ShopDemo.Core.Models;

namespace ShopDemo.Core.Contracts
{
    /// <summary>
    /// Manage product data
    /// </summary>
    public interface IProductService
    {       
        /// <summary>
        /// Get's all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GelAll();
    }
}