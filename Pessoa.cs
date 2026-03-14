using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppCRUD_MVC
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string idade { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\Desktop\\AppCRUD_MVC\\AppCRUD_MVC\\DbPessoa.mdf;Integrated Security=True");

        public List<Pessoa> ListarPessoas()
        {
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM Pessoa";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa p = new Pessoa();
                p.Id = Convert.ToInt32(dr["Id"]);
                p.nome = dr["nome"].ToString();
                p.idade = dr["idade"].ToString();
                li.Add(p);
            }
            return li;
            dr.Close();
            con.Close();
        }

        public void Inserir(string nome, string idade)
        {
            try
            {
                string sql = "INSERT INTO Pessoa(nome, idade) VALUES('" + nome + "','" + idade + "')";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro: " + er.Message);
            }
        }
        public void Atualizar(int Id, string nome, string idade)
        {
            try
            {
                string sql = "UPDATE Pessoa SET nome='"+nome+"',idade='"+idade+"' WHERE Id='"+Id+"'";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro: " + er.Message);
            }
        }

        public void Excluir(int Id)
        {
            try
            {
                string sql = "DELETE FROM Pessoa WHERE Id='"+Id+"'";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro: " + er.Message);
            }
        }
    }
}
