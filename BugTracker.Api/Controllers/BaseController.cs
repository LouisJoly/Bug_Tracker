using Microsoft.AspNetCore.Mvc;
using BugTracker.Api.Models;
using System;

namespace BugTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IActionResult SuccessResponse<T>(T data, int? totalCount = null, int? pageNumber = null, int? pageSize = null)
        {
            var response = new BaseResponse<T>(data)
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return Ok(response);
        }

        protected IActionResult ErrorResponse(string message)
        {
            var response = new BaseResponse<object>(message);
            return BadRequest(response);
        }

        protected IActionResult ErrorResponse(Exception ex)
        {
            var response = new BaseResponse<object>(ex);
            return StatusCode(response.StatusCode, response);
        }

        protected IActionResult NotFoundResponse(string message)
        {
            var response = new BaseResponse<object>(message)
            {
                Success = false,
                StatusCode = 404
            };
            return NotFound(response);
        }

        protected IActionResult NoContentResponse()
        {
            return NoContent();
        }

        protected IActionResult CreatedResponse<T>(T data, string location)
        {
            var response = new BaseResponse<T>(data);
            return Created(location, response);
        }

        protected IActionResult ConflictResponse(string message)
        {
            var response = new BaseResponse<object>(message)
            {
                Success = false,
                StatusCode = 409
            };
            return Conflict(response);
        }

        protected IActionResult UnauthorizedResponse(string message)
        {
            var response = new BaseResponse<object>(message)
            {
                Success = false,
                StatusCode = 401
            };
            return Unauthorized(response);
        }

        protected IActionResult ForbiddenResponse(string message)
        {
            return Forbid(message);
        }
    }
}
