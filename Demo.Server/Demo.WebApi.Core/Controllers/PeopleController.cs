using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using Demo.Common.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Demo.WebApi.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ApiController
    {
        private readonly IPeopleService _iPeopleService;
        public PeopleController(IPeopleService iPeopleService)
        {
            _iPeopleService = iPeopleService;
        }
        [HttpGet]
        [Route("GetAllPeople")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<RequestBase<List<People>>>> GetAllPeople()
        {
            var requestBase = new RequestBase<List<People>>();
            try
            {
                var result = await _iPeopleService.GetPeople();
                if (result != null)
                {
                    requestBase = RequestOK<List<People>>(result);
                }
                else
                {
                    requestBase = NotFound<List<People>>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ServerError:{ex.Message}");
                requestBase = ServerError<List<People>>();
            }
            return requestBase;
        }
        [HttpGet]
        [Route("GetPeople")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<RequestBase<People>>> GetPeople(string id)
        {
            var requestBase = new RequestBase<People>();
            try
            {
                var result = await _iPeopleService.GetPeopleById(id);
                if (result != null)
                {
                    requestBase = RequestOK<People>(result);
                }
                else
                {
                    requestBase = NotFound<People>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ServerError:{ex.Message}");
                requestBase = ServerError<People>();
            }
            return requestBase;
        }
        [HttpPut]
        [Route("EditData")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<RequestBase<bool>>> EditData(People EditId)
        {
            var requestBase = new RequestBase<bool>();
            try
            {
                var result = await _iPeopleService.EditData(EditId);
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
        [HttpPost]
        [Route("InsertData")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<RequestBase<bool>>> InsertData(People insertdata)
        {

            // t bảo m phải validate param mà
            if (insertdata == null || string.IsNullOrEmpty(insertdata.Name) || insertdata.PK_IDList < 0 )
            {
                return BadRequest<bool>();
            }
            var requestBase = new RequestBase<bool>();
            try
            {
                var result = await _iPeopleService.InsertData(insertdata);
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
        [HttpDelete]
        [Route("DeleteData")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<RequestBase<bool>>> DeleteData(int id)
        {
            var requestBase = new RequestBase<bool>();
            try
            {
                var result = await _iPeopleService.DeleteData(id);
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
