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

namespace VentaOxigeno.API.Controllers

{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Project")]

    public class ReserveController : Controller

    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IReserveRepository _ReserveRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReserveRepository"></param>
        public ReserveController(IReserveRepository ReserveRepository)
        {
            _ReserveRepository = ReserveRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("getprojects")]
        public ActionResult GetProjects()
        {
            var ret = _ReserveRepository.GetReserves();
            return Json(ret);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        //[AllowAnonymous]
        [HttpGet]
        [Route("getproject")]

        public ActionResult GetProject(int id)
        {
            var ret = _ReserveRepository.GetReserve(id);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price_min"></param>
        /// <param name="price_max"></param>
        /// <param name="direccion"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getprojectprice")]

        public ActionResult GetProjectPrice(decimal price_min, decimal price_max, string direccion)
        {
            var ret = _ReserveRepository.GetReservePrice(price_min, price_max, direccion);

            return Json(ret);
        }

        /// <summary>
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("newprojet")]
        public ActionResult Insert(EntityReserve reserve)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var usuarioId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault().Value;
            var usuarioDoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault().Value;

            reserve.UsuarioCrea = int.Parse(usuarioId);
            var ret = _ReserveRepository.Insert(reserve);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}