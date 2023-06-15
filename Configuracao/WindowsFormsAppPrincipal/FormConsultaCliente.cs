using System;
using BLL;
using Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WindowsFormsAppPrincipal
{
    public partial class FormConsultaCliente : Form
    {
        public FormConsultaCliente()
        {
            InitializeComponent();
        }

        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            using (FormCadastroCliente frm = new FormCadastroCliente())
            {
                frm.ShowDialog();
            }
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {  switch (comboBoxBuscarPor.SelectedIndex)
                { 
                    case 0:
                        if (String.IsNullOrEmpty(textBoxBuscar.Text ))
                            throw new Exception("Informe um Id para fazer a buscar.") { Data = { { "Id", 31 } } };

                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorId(Convert.ToInt32(textBoxBuscar.Text));
                        break;
                    case 1:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorNome(textBoxBuscar.Text);
                        break;
                    case 2:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorCPF(textBoxBuscar.Text);
                        break ;
                    case 3:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarTodos ();
                        break;

                        default:

                           break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonExcluirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteBindingSource.Count <= 0)
                {
                    MessageBox.Show("Não existe registro para ser excluído");
                    return;
                }

                if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                    int id = ((Cliente)clienteBindingSource.Current).Id;

                    new ClienteBLL().Excluir(id);

                clienteBindingSource.RemoveCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAlterarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteBindingSource.Count == 0) 
                {
                    MessageBox.Show("Não existe cliente para ser alterado. ");
                    return ;
                }
                int id = ((Cliente)clienteBindingSource.Current).Id;

                using (FormCadastroCliente frm = new FormCadastroCliente(id))
                {
                    frm.ShowDialog();
                }
                buttonBuscarCliente_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FormConsultaCliente_Load(object sender, EventArgs e)
        {
            comboBoxBuscarPor.SelectedIndex = 3;
        }

        private void buttonSelecionar_Click(object sender, EventArgs e)
        {

        }
    }
}

