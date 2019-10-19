using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Domain.Const;

namespace Restaurante.Application.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(Policy.AllowAll)]
    [ApiController]
    public class APIController : ControllerBase
    {
    }
}