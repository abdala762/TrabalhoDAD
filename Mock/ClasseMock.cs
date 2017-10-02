using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Mock
{
    public class ClasseMock
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
        public void CriarUsuario()
        {
            string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
            string cmd = "INSERT INTO usuario (cpf, senha, tipo, tentativas, bloqueado) VALUES('11553546644', 'abdala', 'Gerente', 0, 0); ";
            cmd += "INSERT INTO [dbo].[usuario] (cpf, senha, tipo, tentativas, bloqueado) VALUES('12345678910', 'senha', 'Gerente', 0, 0); ";
            cmd += "INSERT INTO [dbo].[usuario] (cpf, senha, tipo, tentativas, bloqueado) VALUES('10987654321', 'senha', 'Gerente', 0, 0);";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand(cmd,conn))
                {
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
        }
        public SqlDataReader SelectUsuarios()
        {
            string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            sqlConnection1.Close();
            return reader;
        }
    }
}
