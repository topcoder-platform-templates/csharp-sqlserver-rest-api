/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    /// <summary>
    /// The base controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
