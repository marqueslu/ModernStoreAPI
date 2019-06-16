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
    public class CustomerController : BaseController
    {

        private readonly CustomerCommandHandler _handler;

        public CustomerController(IUow uow, CustomerCommandHandler handler) : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customers")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {

            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);

        }
    }
}