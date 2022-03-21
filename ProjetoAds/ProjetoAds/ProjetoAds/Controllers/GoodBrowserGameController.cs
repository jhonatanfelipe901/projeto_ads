using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Request.GoodBrowserGame;
using ProjetoAds.Application.DTO.Response;
using ProjetoAds.Application.DTO.Response.GoodBrowserGame;

namespace ProjetoAds.Controllers
{
    [Produces("application/json")]
    [Route("api/goodbrowsergame")]
    public class GoodBrowserGameController : BaseController
    {
        private readonly IGoodBrowserGameApplication _goodBrowserGameApplication;

        public GoodBrowserGameController(IGoodBrowserGameApplication goodBrowserGameApplication)
        {
            _goodBrowserGameApplication = goodBrowserGameApplication;
        }

        [Authorize]
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<GoodBrowserGameGetResponse>>> GetAll()
        {
            var usuarios = await _goodBrowserGameApplication.GetAll();

            return usuarios;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:long}")]
        public async Task<BaseResponse<GoodBrowserGameGetResponse>> Get(long id)
        {
            var usuario = await _goodBrowserGameApplication.Get(id);

            return usuario;
        }

        [Authorize]
        [HttpPost]
        public async Task<BaseResponse<GoodBrowserGameOperationResponse>> Post(GoodBrowserGamePostRequest request)
        {
            return await _goodBrowserGameApplication.Insert(request);
        }

        [Authorize]
        [HttpPut]
        public async Task<BaseResponse<GoodBrowserGameOperationResponse>> Put(GoodBrowserGamePutRequest request)
        {
            return await _goodBrowserGameApplication.Update(request);
        }

        [Authorize]
        [HttpDelete]
        public async Task<BaseResponse<GoodBrowserGameOperationResponse>> Delete(long id)
        {
            return await _goodBrowserGameApplication.Delete(id);
        }
    }
}
