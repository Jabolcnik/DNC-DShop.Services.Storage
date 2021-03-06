﻿using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Messages.Events.Products;
using DShop.Services.Storage.Repositories;
using DShop.Services.Storage.ServiceForwarders;
using RestEase;
using System.Threading.Tasks;

namespace DShop.Services.Storage.Handlers.Products
{
    public sealed class ProductUpdatedHandler : IEventHandler<ProductUpdated>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IProductsService _productsService;

        public ProductUpdatedHandler(IProductsRepository productsRepository,
            IProductsService productsService)
        {
            _productsRepository = productsRepository;
            _productsService = productsService;
        }

        public async Task HandleAsync(ProductUpdated @event, ICorrelationContext context)
        {
            var product = await _productsService.GetProductByIdAsync(@event.Id);
            await _productsRepository.UpdateAsync(product);
        }
    }
}
