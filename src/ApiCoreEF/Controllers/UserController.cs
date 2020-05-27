using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCoreEF.Application.Interfaces;
using ApiCoreEF.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreEF.Controllers
{


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
        [HttpPut]
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
        [HttpDelete]
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
