using Demo.Common.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo.WebApi.Core.Controllers
{
    public class ApiController : ControllerBase
    {
        public ApiController()
        {
        }
        protected RequestBase<TRequest> RequestOK<TRequest>(TRequest data)
        {
            return new RequestBase<TRequest>()
            {
                Data = data,
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Thành công"
            };
        }
        protected RequestBase<TRequest> BadRequest<TRequest>()
        {
            return new RequestBase<TRequest>()
            {
                Success = false,
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = "Dữ liệu đầu vào không đúng"
            };
        }
        protected RequestBase<TRequest> NotFound<TRequest>()
        {
            return new RequestBase<TRequest>()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.NotFound,
                Message = "Không có dữ liệu"
            };
        }
        protected RequestBase<TRequest> ServerError<TRequest>()
        {
            return new RequestBase<TRequest>()
            {
                Success = false,
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Lỗi server"
            };
        }
    }
}
