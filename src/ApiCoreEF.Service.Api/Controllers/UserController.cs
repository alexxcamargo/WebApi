using System;
using System.Collections.Generic;
using ApiCoreEF.Application.Interfaces;
using ApiCoreEF.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreEF.Service.Api
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [Route("users")]
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _userAppService.GetAll();
        }

        [Route("users")]
        [HttpPost]
        public ActionResult Post([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userAppService.Add(user);
            return Ok();
        }

        [Route("users")]
        [HttpPost]
        public ActionResult Put([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userAppService.Update(user);
            return Ok();
        }

        [Route("users/{id:guid}")]
        [HttpPost]
        public ActionResult Delete(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userAppService.Remove(Id);
            return Ok();
        }

    }
}
