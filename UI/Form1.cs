using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace TresCamadas2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void LoadAll()
        {
            dgUsuarios.AutoGenerateColumns = false;
            dgUsuarios.DataSource = cboUsuario.DataSource = cboComboBusca.DataSource = new Usuario().Todos();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var endereco = new Endereco();
            endereco.CPF = ((Usuario)cboUsuario.SelectedValue).CPF;
            endereco.Rua = txtRua.Text;
            endereco.Numero = txtNumero.Text;
            endereco.Cidade = txtCidade.Text;
            endereco.Estado = txtEstado.Text;
            endereco.Salvar();

            MessageBox.Show("Endereço salvo para o usuário " + cboUsuario.SelectedValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var usuario = (Usuario)cboComboBusca.SelectedValue;
            lblNome.Text = "Nome: " + usuario.Nome;
            lblTelefone.Text = "Telefone: " + usuario.Telefone;
            lblCpf.Text = "CPF: " + usuario.CPF;
            gridEnderecos.DataSource = usuario.Enderecos;
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
            if(txtId.Text != "")
            {
                usuario.Id = int.Parse(txtId.Text);
            }

            usuario.Nome = txtNome.Text;
            usuario.CPF = txtCpf.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.Salvar();
            limparCampos();
            LoadAll();

            MessageBox.Show("Usuário salvo com sucesso");
        }
       

        private void dgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario usuario = ((Usuario)dgUsuarios.Rows[e.RowIndex].DataBoundItem);
            txtNome.Text = usuario.Nome;
            txtTelefone.Text = usuario.Telefone;
            txtCpf.Text = usuario.CPF;
            txtId.Text = usuario.Id.ToString();
            BtnGravar.Text = "Alterar";
        }

        private void limparCampos()
        {
            txtNome.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtId.Text = string.Empty;
            BtnGravar.Text = "Salvar";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var retorno = MessageBox.Show("Tem certeza que deseja excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno.Equals(DialogResult.Yes))
            {
                foreach (DataGridViewCell cell in dgUsuarios.SelectedCells)
                {
                    Usuario usuario = ((Usuario)dgUsuarios.Rows[cell.RowIndex].DataBoundItem);
                    usuario.Excluir();
                }

                foreach (DataGridViewRow row in dgUsuarios.SelectedRows)
                {
                    Usuario usuario = (Usuario)row.DataBoundItem;
                    usuario.Excluir();
                }
            }
            
            LoadAll();
        }
    }
}
