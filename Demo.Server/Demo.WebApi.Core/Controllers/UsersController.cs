using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using Demo.Common.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace Demo.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IUsersService _iUsersService;
        public UsersController(IUsersService iUsersService)
        {
            _iUsersService = iUsersService;
        }
        [HttpGet]
        [Route("GetUser")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<RequestBase<User>>> GetUser(string username)
        {
            var requestBase = new RequestBase<User>();
            try
            {
                var result = await _iUsersService.GetUserByName(username);
                if (result != null)
                {
                    requestBase = RequestOK<User>(result);
                }
                else
                {
                    requestBase = NotFound<User>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ServerError:{ex.Message}");
                requestBase = ServerError<User>();
            }
            return requestBase;
        }
        [HttpPut]
        [Route("ChangePassword")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<RequestBase<bool>>> ChangePassWord(ChangePassWord changePass)
        {
            var requestBase = new RequestBase<bool>();
            try
            {
                var result = await _iUsersService.ChangePassWord(changePass);
                if (result)
                {
                    requestBase = RequestOK<bool>(result);
                }
                else
                {
                    requestBase = NotFound<bool>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ServerError:{ex.Message}");
                requestBase = ServerError<bool>();
            }
            return requestBase;
        }

        


    }
}
