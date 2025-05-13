using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDatabase.model;

namespace ProjetoDatabase.controller
{
    internal class ClienteController
    {
        int i = 0;
        private string connectionString = string.Empty;
        public ClienteController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddCliente(Cliente c)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tb_cliente (nome) VALUES (@nome)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", c.Name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.ToString());
                }
            }
        }

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "SELECT id, nome FROM tb_cliente";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["nome"].ToString()
                        };

                        clientes.Add(cliente);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching clients: " + ex.Message);
                }
            }

            return clientes;
        }

        public bool TestarConexao()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Erro de conexão: " + ex.Message);
                    return false;
                }
            }
        }

        public List<Cliente> GetClientes()
        {
            var list = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, nome FROM tb_cliente";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            list.Add(new Cliente
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.ToString());
                }
            }

            return list

        }


    }
}
