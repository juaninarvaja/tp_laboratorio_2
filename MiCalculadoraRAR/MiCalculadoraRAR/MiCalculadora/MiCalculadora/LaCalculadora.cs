using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();
        }
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "0";
        }

        private static double Operar(string strNumeroUno, string strNumeroDos, string operador)
        {

            double numeroUno;
            double numeroDos;
            bool esDoubleNum1 = double.TryParse(strNumeroUno,out numeroUno);
            bool esDoubleNum2 = double.TryParse(strNumeroDos, out numeroDos);
            if (esDoubleNum1 && esDoubleNum2)
            {
                
                Numero numeroUnoNumero = new Numero(numeroUno);
                Numero numeroDosNumero = new Numero(numeroDos);
               
                return Entidades.Calculadora.Operar(numeroUnoNumero,numeroDosNumero, operador);

            }
            else return 0;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero unNumero = new Numero();
            lblResultado.Text = unNumero.DecimalBinario(lblResultado.Text);
           
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero unNumero = new Numero();
            lblResultado.Text = unNumero.BinarioDecimal(lblResultado.Text);
        }
    }
}
