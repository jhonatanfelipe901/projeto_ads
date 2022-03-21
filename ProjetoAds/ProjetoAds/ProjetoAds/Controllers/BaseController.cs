using Microsoft.AspNetCore.Mvc;
using ProjetoAds.Application.DTO.Response;

namespace ProjetoAds.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult BaseResponse<T>(BaseResponse<T> response)
        {
            if (response.Errors != null && response.Errors.Count > 0)
                return BadRequest(response);
            else
                return Ok(response);
        }

        protected IActionResult ResponseBadRequest<T>(string message)
        {
            var errors = new List<ErrorResponse>();

            errors.Add(new ErrorResponse { ErrorMessage = message });

            return BadRequest(new BaseResponse<T>
            {
                ValidationsErrors = errors
            });
        }

        protected IActionResult ResponseBadRequest<T>(IEnumerable<string> messages)
        {
            var errorList = new List<ErrorResponse>();

            messages.ToList().ForEach(m => errorList.Add(new ErrorResponse { ErrorMessage = m }));

            return BadRequest(new BaseResponse<T>
            {
                ValidationsErrors = errorList
            });
        }

        protected IEnumerable<string> GetModelStateErrors()
        {
            var erroMsgList = new List<string>();

            var errorList = ModelState.Values.SelectMany(v => v.Errors);

            foreach (var erro in errorList)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                erroMsgList.Add(erroMsg);
            }

            return erroMsgList;
        }
    }
}
