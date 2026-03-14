using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCRUD_MVC
{
    public partial class frmCrud : Form
    {
        public frmCrud()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty || txtIdade.Text == string.Empty) 
            {
                MessageBox.Show("Por favor, preencha todo o formulário", "Campos obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ActiveControl = txtNome;
                return;
            }
            Pessoa pessoa = new Pessoa();
            pessoa.Inserir(txtNome.Text, txtIdade.Text);
            MessageBox.Show("Pessoa cadastrada components sucesso!", "Inserção",MessageBoxButtons.OK , MessageBoxIcon.Information);
            txtNome.Text = string.Empty;
            txtIdade.Text = string.Empty;
            List<Pessoa> pes = pessoa.ListarPessoas();
            dgvPessoa.DataSource = pes;
            this.ActiveControl = txtNome;
        }

        private void frmCrud_Load(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pes = pessoa.ListarPessoas();
            dgvPessoa.DataSource = pes;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.ActiveControl = txtNome;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente fechar o progama?","Fechar",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
                {
                Environment.Exit(0);
            }

        }
        private void txtIdade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvPessoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPessoa.Rows[e.RowIndex];
                this.dgvPessoa.Rows[e.RowIndex].Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtIdade.Text = row.Cells[2].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Atualizar(id, txtNome.Text, txtIdade.Text); 
            MessageBox.Show("Pessoa atulizada components sucesso!", "Atualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNome.Text = string.Empty;
            txtIdade.Text = string.Empty;
            txtId.Text = string.Empty;
            List<Pessoa> pes = pessoa.ListarPessoas();
            dgvPessoa.DataSource = pes;
            this.ActiveControl = txtNome;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Excluir(id);
            MessageBox.Show("Pessoa excluida com sucesso!", "Excluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNome.Text = string.Empty;
            txtIdade.Text = string.Empty;
            txtId.Text = string.Empty;
            List<Pessoa> pes = pessoa.ListarPessoas();
            dgvPessoa.DataSource = pes;
            this.ActiveControl = txtNome;
        }
    }
}
