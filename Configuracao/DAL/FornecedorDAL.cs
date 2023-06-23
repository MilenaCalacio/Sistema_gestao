using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FornecedorDAL
    {
        public void Inserir(Fornecedor _fornecedor)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn .CreateCommand();
                cmd.CommandText = @"INSERT INTO Fornecedor(Nome, Fone, Email, Site) VALUES (@Nome,@Fone,@Email,@Site)";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Fone", _fornecedor.Fone);
                cmd.Parameters.AddWithValue("@Email", _fornecedor.Email);
                cmd.Parameters.AddWithValue("@Site", _fornecedor.Site);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar Inserir fornecedor no banco de dados", ex) { Data = { { "Id", 98 } } };

            }
            finally
            {
                cn.Close();
            }
           
        }
        public List<Fornecedor> BuscarPorTodos ()
        {
            List<Fornecedor> fornecedorList = new List<Fornecedor>();
            Fornecedor fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection (Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id, Nome, Fone, Email, Site FROM Fornecedor ";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        fornecedor = new Fornecedor();
                        fornecedor.Id = (int)rd["Id"];
                        fornecedor.Nome = rd["Nome"].ToString();
                        fornecedor.Fone  = rd["Fone"].ToString();
                        fornecedor.Email = rd["Email"].ToString();
                        fornecedor.Site = rd["Site"].ToString();

                        fornecedorList.Add(fornecedor);
                    }
                }
                return fornecedorList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os fornecedor no banco de dados", ex) { Data = { { "Id", 33 } } };
            }
            finally
            {
                cn.Close();
            }

           
        }
        public Fornecedor BuscarPorId (int _id)
        {

            Fornecedor fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id,Nome, Fone, Email, Site FROM Fornecedor WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        fornecedor = new Fornecedor();
                        fornecedor.Id = (int)rd["Id"];
                        fornecedor.Nome = rd["Nome"].ToString();
                        fornecedor.Site = rd["Site"].ToString();
                        fornecedor.Email = rd["Email"].ToString();
                        fornecedor.Fone = rd["Fone"].ToString();
                    }
                }
                return fornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar por id fornecedor no banco de dados", ex) { Data = { { "Id", 35 } } };
            }
            finally
            {
                cn.Close();
            }

        }
        public List<Fornecedor> BuscarPorNome (string _nome)
        {
            List<Fornecedor> fornecedorList = new List<Fornecedor>();
            Fornecedor fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id,Nome, Fone, Email, Site FROM Fornecedor WHERE Nome LIKE @Nome";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", "%" + _nome + "%");

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())

                    {
                        fornecedor = new Fornecedor();
                        fornecedor.Id = (int)rd["Id"];
                        fornecedor.Nome = rd["Nome"].ToString();
                        fornecedor.Site = rd["Fone"].ToString();
                        fornecedor.Email = rd["Email"].ToString();
                        fornecedor.Fone = rd["Site"].ToString();

                        fornecedorList.Add(fornecedor);
                    }
                }
                return fornecedorList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar fornecedor no banco de dados", ex) { Data = { { "Id", 36 } } };
            }
            finally
            {
                cn.Close();
            }

        }
        public List<Fornecedor> BuscarPorSite (string _site)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            Fornecedor fornecedor = new Fornecedor();

            try
            {

                SqlCommand cmd = new SqlCommand();


                List<Fornecedor> fornecedorList = new List<Fornecedor>();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id,Nome, Fone, Email, Site FROM Fornecedor WHERE Site Like @Site";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Site", _site);


                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        fornecedor = new Fornecedor();
                        fornecedor.Id = (int)rd["Id"];
                        fornecedor.Nome = rd["Nome"].ToString();
                        fornecedor.Fone = rd["Fone"].ToString();
                        fornecedor.Email = rd["Email"].ToString();
                        fornecedor.Site = rd["Site"].ToString();

                        fornecedorList.Add(fornecedor);
                    }
                }
                return fornecedorList;


            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao tentar buscar fornecedor por site no banco de dados", ex) { Data = { { "Id", 39 } } };
            }
            finally
            {
                cn.Close();
            }

        }
        public void Alterar (Fornecedor _fornecedor)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Fornecedor SET
                                      Nome = @Nome,
                                      Site = @Site,
                                      Email = @Email,
                                      Fone = @Fone
                                      WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _fornecedor.Id);
                cmd.Parameters.AddWithValue("@Nome", _fornecedor.Nome);
                cmd.Parameters.AddWithValue("@fone", _fornecedor.Fone);
                cmd.Parameters.AddWithValue("@Email", _fornecedor.Email);
                cmd.Parameters.AddWithValue("@Site", _fornecedor.Site);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar altera um cliente do banco de dados.", ex);
            }
            finally
            { cn.Close(); }
        }
        public void Excluir (int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"DELETE FROM Fornecedor WHERE id = @id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar excluir Fornecedor no banco de dados.", ex) { Data = { { "Id", 37 } } };
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
