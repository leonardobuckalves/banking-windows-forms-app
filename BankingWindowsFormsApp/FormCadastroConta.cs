using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingWindowsFormsApp.Busca;
using BankingWindowsFormsApp.Contas;

namespace BankingWindowsFormsApp
{
    public partial class FormCadastroConta : Form
    {
        private ICollection<string> devedores;

        private Form1 formPrincipal;

        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();

            GeradorDeDevedores gerador = new GeradorDeDevedores();
            devedores = gerador.GeraList();
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            textoNumero.Text = Convert.ToString(Conta.ProximoNumero());
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            string titular = textoTitular.Text;
            bool isDevedor = false;

            for (int i = 0; i < 30000; i++)
            {
                isDevedor = devedores.Contains(titular);
            }
            if(!isDevedor)
            {
                Conta novaConta = new ContaCorrente();
                novaConta.Titular = new Cliente(textoTitular.Text);
                this.formPrincipal.AdicionaConta(novaConta);
            }
            else
            {
                MessageBox.Show("Devedor!");
            }
        }
    }
}
