using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStoreAPI.Domain.Commands.Handlers;
using ModernStoreAPI.Domain.Commands.Inputs;
using ModernStoreAPI.Infra.Transactions;

namespace ModernStoreAPI.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderCommandHandler _handler;

        public OrderController(IUow uow, OrderCommandHandler handler): base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/orders")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommand command)
        {
            var customer = User.Identity.Name;
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);

        }        
    }
}