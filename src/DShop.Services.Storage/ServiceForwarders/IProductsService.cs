﻿using DShop.Services.Storage.Models.Products;
using RestEase;
using System;
using System.Threading.Tasks;

namespace DShop.Services.Storage.ServiceForwarders
{
    public interface IProductsService
    {
        [Get("api/Products/{id}")]
        Task<Product> GetProductByIdAsync([Path] Guid id);
    }
}
