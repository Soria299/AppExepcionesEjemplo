using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppExepcionesEjemplo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtNumero1.KeyPress += new KeyPressEventHandler(txtNumero_KeyPress);
            txtNumero2.KeyPress += new KeyPressEventHandler(txtNumero_KeyPress);
        }
        private void btnDividir_Click(object sender, EventArgs e)
        {
            try
            {
                // Cambiamos de int a double para manejar decimales
                double numero1 = Convert.ToDouble(txtNumero1.Text);
                double numero2 = Convert.ToDouble(txtNumero2.Text);

                double resultado = numero1 / numero2;
                lblResultado.Text = $"Resultado: {resultado.ToString("N2")}"; // Formato con 2 decimales
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduce números válidos.", "Error de Formato",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("No es posible dividir entre cero.", "División por cero",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtNumero1.Clear();
                txtNumero2.Clear();
                txtNumero1.Focus();
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, punto, coma y teclas de control como backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancelar el carácter
            }

            // Evitar múltiples puntos o comas
            TextBox textBox = (TextBox)sender;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (textBox.Text.Contains('.') || textBox.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}


