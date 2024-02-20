using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Repositories;
using Shop.Requests;
using Shop.Response;
using Shop.Services;
using System;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    //[ApiController]
    [Route("Autorizacao")]
    public class AuthController : Controller
    {



        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login(
            [FromServices] IMediator mediator,
            [FromBody]LoginRequest loginRequest)
        {
            LoginResponse response = await mediator.Send(loginRequest);
            if(String.IsNullOrEmpty(response.Token))
                return BadRequest(
                    new { 
                    message = "Usuario ou senha estão incorretos"
                });

            return Ok(response);

        }

        [HttpGet]
        [Route("/get-logado")]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetUsuarioLogado([FromServices] GetLogedUserService getLogedUserService)
        {
            return getLogedUserService;
        }


        [HttpPost]
        [Route("/register-usuario")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Register(
            [FromBody]ResgisterUserRequest user,
            [FromServices]IMediator medietor)
        {
                var response = await medietor.Send(user);
            if(response.DeuCerto)
                return Ok(response);
            return BadRequest( new {mesasge= "Usuario já cadastrado" });
            
        }

        [HttpGet]
        [Route("/Autorizado")]
        [Authorize]
        public string Authenticated()
        {
            return string.Format("Autenticado - {0} ", User.Identity.Name);
        }

        [HttpGet]
        [Route("/gerenciamento")]
        [Authorize(Roles = "Gerente")]
        public string PainelGerente()
        {
            return string.Format("O {0} entrou no painel do gerente",User.Identity.Name);
        }

        [HttpGet]
        [Route("/funcionarios")]
        [Authorize(Roles ="Gerente,Funcionario")]
        public string PainelFuncionario()
        {
            return string.Format("O {0} entrou no painel do funcionario", User.Identity.Name);
        }
    }
}
