using Model;
using Model.DTO;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Services
{
    public class MailServices : Services<Mail>
    {     
        /// <summary>
        /// Envia email para o usuario
        /// conta : testedad39@gmail.com
        /// senha : dad@2017
        /// </summary>
        public ResponseDTO EnviaMensagemEmail(string cpf, string remetente, string destinatario, string assunto, string corpo)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    MailMessage mensagemEmail = new MailMessage(remetente, destinatario, assunto, corpo);

                    // Se o email não é validao retorna uma mensagem
                    if (ValidaEnderecoEmail(destinatario) == false)
                    {
                        responseDTO.Message = "Email do destinatário inválido!";
                        return responseDTO;
                    }

                    Usuario usuario = this.context.Usuarios.FirstOrDefault(c => c.email.Equals(destinatario) && c.cpf.Equals(cpf));

                    //valida se o usuario esta cadastrado na base
                    if (usuario == null)
                    {
                        responseDTO.Message = "Cpf não cadastrado na base!";
                        return responseDTO;
                    }

                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("testedad39@gmail.com", "dad@2017");
                    smtp.Send(mensagemEmail);
                }

                responseDTO.Success = true;
                responseDTO.Message = "Sua senha foi enviada para  " + destinatario + " às " + DateTime.Now.ToString() + ".";
            }
            catch (Exception ex)
            {
                string erro = ex.InnerException.ToString();
                responseDTO.Message = ex.Message.ToString() + erro;
            }
            return responseDTO;
        }

        /// <summary>
        /// Confirma a validade de um email
        /// </summary>
        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
