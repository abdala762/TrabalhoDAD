using System.Web.Http;
using Services;
using Model.DTO;
using Model;
using System.Web.Http.Cors;
using System.Text.RegularExpressions;
using System;
using System.Net.Mail;
using System.Net;

namespace View.Controllers.Api
{
    public class UsuarioController : ApiController
    {
        private UsuarioServices usuarioServices;

        public UsuarioController()
        {
            this.usuarioServices = new UsuarioServices();
        }

        [HttpGet]
        public ResponseDTO All()
        {
            return this.usuarioServices.BuscarTodos();
        }

        [HttpGet]
        public ResponseDTO Filter(string id)
        {
            return this.usuarioServices.Buscar(id);
        }

        public ResponseDTO Authenticate([FromBody]Usuario usuario)
        {
            return this.usuarioServices.ValidarUsuario(usuario.cpf, usuario.senha);
        }

        public ResponseDTO Register([FromBody]Usuario usuario)
        {
            return this.usuarioServices.NovoUsuario(usuario);
        }

        [HttpPut]
        public ResponseDTO Edit([FromBody]Usuario usuario)
        {
            return this.usuarioServices.EditarUsuario(usuario);
        }

        [HttpDelete]
        public ResponseDTO Delete(int id)
        {
            return this.usuarioServices.DeleteUsuario(id);
        }
    }
}

