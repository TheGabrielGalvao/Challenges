using CadastroCliente.DTO;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.BD
{
    public class RepositorioCliente
    {
        private string stringConexao;

        public RepositorioCliente()
        {
            stringConexao = "Server=localhost;Database=avaliacao;Uid=root;Pwd='';";
        }

        public bool Salvar(ClienteDTO modelo)
        {
            try
            {
                using (var sqlConnection = new MySqlConnection(this.stringConexao))
                    if(modelo.Id > 0)
                    {
                        sqlConnection.Execute("UPDATE Cliente SET " +
                    "Nome =  @Nome, " +
                    "DataNascimento = @DataNascimento, " +
                    "Sexo =  @Sexo, " +
                    "Cep =  @Cep, " +
                    "Endereco =  @Endereco, " +
                    "Numero =  @Numero, " +
                    "Complemento =  @Complemento, " +
                    "Bairro =  @Bairro, " +
                    "Cidade =  @Cidade, " +
                    "Estado = @Estado " +
                    "WHERE Id = @Id", modelo);
                    }
                    else {
                        sqlConnection.Execute("Insert Into Cliente (Nome, DataNascimento, Sexo, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Estado) " +
                      "Values(@Nome, @DataNascimento, @Sexo, @Cep, @Endereco, @Numero, @Complemento, @Bairro, @Cidade, @Estado)", modelo);
                    }
                    
                
                return true;

            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public bool Excluir(ClienteDTO modelo)
        {
            try
            {
                var id = modelo.Id;
                using (var sqlConnection = new MySqlConnection(this.stringConexao))
                    sqlConnection.Execute("DELETE FROM Cliente WHERE Id = @Id", new { Id = id});

                return true;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public IList<ClienteDTO> Listar()
        {
            try
            {
                string consulta = @"SELECT * FROM Cliente";

                using (MySqlConnection sqlConnection = new MySqlConnection(this.stringConexao))
                    return sqlConnection.Query<ClienteDTO>(consulta).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
