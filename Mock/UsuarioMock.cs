using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Model;
using Services;

namespace Mock
{
    public class UsuarioMock 
    {
        #region SCRIPT TABELA USUARIO
        /*SCRIPT PARA TABELA USUARIO
         USE [master]
        GO
        SET ANSI_NULLS ON
        GO

        SET QUOTED_IDENTIFIER ON
        GO

        CREATE TABLE[dbo].[usuario]
                (

           [cpf][nvarchar](50) NOT NULL,

          [senha] [nvarchar] (50) NULL,
	        [tipo] [nvarchar] (50) NULL,
	        [tentativas] [int] NULL,
	        [bloqueado] [bit] NULL,
         CONSTRAINT[PK_usuario] PRIMARY KEY CLUSTERED
        (
           [cpf] ASC
        )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
        ) ON[PRIMARY]
        GO
         */
        #endregion
        //MUDAR CONNECTION STRING NO WEBCONFIG DE ACORDO COM SEU SERVIDOR
        public void CriarUsuariosTeste()
        {
            var us = new UsuarioServices();
            Usuario u = new Usuario { cpf = "Teste1", senha = "teste", tipo = "Associado", bloqueado = false, tentativas = 0 };
            us.NovoUsuario(u);
            u = new Usuario { cpf = "Teste2", senha = "teste", tipo = "Associado", bloqueado = false, tentativas = 0 };
            us.NovoUsuario(u);
            u = new Usuario { cpf = "Teste3", senha = "teste", tipo = "Associado", bloqueado = false, tentativas = 0 };
            us.NovoUsuario(u);
            u = new Usuario { cpf = "Teste4", senha = "teste", tipo = "Gerente", bloqueado = false, tentativas = 0 };
            us.NovoUsuario(u);
        }
        public IEnumerable<Usuario> SelectUsuarios()
        {
            var u = new UsuarioServices();
            return u.All();
        }
    }
}
