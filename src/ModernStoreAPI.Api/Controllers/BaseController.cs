using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using ModernStoreAPI.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStoreAPI.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    //Elmah(log error);
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "A Internal Failure occurred on the server." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}
