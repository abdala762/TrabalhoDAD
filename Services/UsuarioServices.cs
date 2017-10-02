using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsuarioServices : Services<Usuario>
    {
        public Usuario Buscar(string cpf)
        {
            return this.context.Usuarios.FirstOrDefault(x => x.cpf == cpf);
        }
        public void ValidarUsuario(string cpf, string senha)
        {
            var usuario = Buscar(cpf);
            if (usuario != null)
            {
                if (usuario.bloqueado)
                {
                    //Nao deixar logar
                    //********* IMPLEMENTAR MENSAGEM DE ERRO
                }
                else
                {
                    if (usuario.senha != senha)
                    {
                        //se senha for invalida, aumentar numero de tentativas e bloquear se ja tiver 3
                        usuario.tentativas += 1;
                        if (usuario.tentativas >= 3)
                            usuario.bloqueado = true;
                        this.context.SaveChanges();
                    }
                    else
                    {
                        //se senha for valida, zerar tentativas
                        if (usuario.tentativas != 0)
                        {
                            usuario.tentativas = 0;
                            this.context.SaveChanges();
                        }

                        //Realizar login
                        // ***** IMPLEMENTAR LOGIN *******
                    }
                }
            }
            else
            {
                //usuario invalido
                //******** IMPLEMENTAR MENSAGEM DE ERRO
            }

        }

        public void NovoUsuario(string cpf, string senha)
        {
            try
            {
                if (Buscar(cpf) != null)
                {
                    //****** MENSAGEM DE ERRO - USUARIO EXISTENTE
                }
                else
                {
                    Usuario u = new Usuario { cpf = cpf, senha = senha, tipo = "Associado", bloqueado = false, tentativas = 0 };
                    this.context.Usuarios.Add(u);
                   
                    this.context.SaveChanges();
                    //****** Usuario criado com sucesso
                }
            }
            catch (Exception ex)
            {
                //****** IMPLEMENTAR ERRO AO CRIAR USUARIO
            }
        }

        public void NovoUsuario(Usuario u)
        {
            try
            {
                if (Buscar(u.cpf) != null)
                {
                    //****** MENSAGEM DE ERRO - USUARIO EXISTENTE
                }
                else
                {
                    this.context.Usuarios.Add(u);

                    this.context.SaveChanges();
                    //****** IMPLEMENTAR Usuario criado com sucesso
                }
            }
            catch (Exception ex)
            {
                //****** IMPLEMENTAR ERRO AO CRIAR USUARIO
            }
        }

    }
}
