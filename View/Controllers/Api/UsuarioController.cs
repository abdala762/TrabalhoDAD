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
        private MailServices mailServices;

        public UsuarioController()
        {
            this.usuarioServices = new UsuarioServices();
            this.mailServices = new MailServices();
        }

        [HttpGet]
        public ResponseDTO All()
        {
            return this.usuarioServices.BuscarTodos();
        }

        [HttpGet]
        public ResponseDTO Filter(string cpf)
        {
            return this.usuarioServices.Buscar(cpf);
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

        [HttpGet]
        public ResponseDTO RememberPassword(string cpf)
        {
            Usuario usuario = (Usuario)this.usuarioServices.Buscar(cpf).Contents;
            if(usuario == null)
            {
                ResponseDTO responseDTO = new ResponseDTO();
                responseDTO.Message = "Cpf não cadastrado!";
                return responseDTO;
            }

            return this.mailServices
                .EnviaMensagemEmail(usuario.email, "Lembrete de senha", 
                "Sua senha no SBG é " + usuario.senha + ", para sua segurança altere assim que acessar o portal.");
        }
    }
}

