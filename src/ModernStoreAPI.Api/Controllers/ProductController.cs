using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStoreAPI.Domain.Repositories;

namespace ModernStoreAPI.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("v1/products")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_productRepository.Get());
        }

        [HttpGet]
        [Route("v1/products/{id}")]
        public string Get(Guid id)
        {
            return "adsd";
        }

    }
}