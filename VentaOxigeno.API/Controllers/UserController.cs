using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using VentaOxigeno.API.Security;

namespace UPC.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    [ApiController] //Para que lo muestre como Json
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLogin login)
        {
            var ret = _UserRepository.Login(login);

            if (ret.data != null)
            {
                var responseLogin = ret.data as EntityLoginResponse;
                var userId = responseLogin.IdUsuario.ToString();
                var userDoc = responseLogin.DocumentoIdentidad;

                var token = JsonConvert
                    .DeserializeObject<AccessToken>(
                        await new Authentication()
                        .GenerateToken(userDoc, userId)
                        ).access_token;

                responseLogin.Token = token;
                ret.data = responseLogin;
            }
            //return StatusCode(401);

            return Json(ret);
        }


        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("registeruser")]
        public ActionResult Insert(EntityUser user)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var usuarioId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault().Value;
            var usuarioDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault().Value;

            user.UsuarioCrea = int.Parse(usuarioId);
            var ret = _UserRepository.Insert(user);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /*    [Produces("application/json")]
        [SwaggerOperation("GetListUser")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListUser")]
        public ActionResult Get()
        {
            var ret = _UserRepository.GetUsers();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }*/
    }
}