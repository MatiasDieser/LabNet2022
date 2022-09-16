using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioPOO
{
    public partial class Form1 : Form
    {
        List<TransportePublico> vehiculo = new List<TransportePublico>();
        int cantidad = 1;
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            if(cantidad == 1)
            {
                label1.Text = $"Ingrese el número de pasajeros del ómnibus {cantidad}:";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pasajeros = 0;
            
            if (cantidad>=1 && cantidad <= 5 && textBox1.Text != "")
            {
                
                pasajeros = int.Parse(textBox1.Text);
                if (pasajeros >= 0 && pasajeros <= 100)
                {
                    vehiculo.Add(new Omnibus(pasajeros));
                    cantidad++;
                    label1.Text = $"Ingrese el número de pasajeros del ómnibus {cantidad}:";
                }
                else
                {
                    MessageBox.Show("Los ómnibus solo permiten de 0 a 100 pasajeros", "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                textBox1.Clear();
                if(cantidad == 6)
                {
                    label1.Text = $"Ingrese el número de pasajeros del taxi {cantidad -5}:";
                }
            }
            else if (cantidad >= 5 && cantidad <= 10 && textBox1.Text != "")
            {
                
                pasajeros = int.Parse(textBox1.Text);
                if(pasajeros >=0 && pasajeros <= 4)
                {
                    vehiculo.Add(new Taxi(pasajeros));
                    cantidad++;
                    label1.Text = $"Ingrese el número de pasajeros del taxi {cantidad - 5}:";
                }
                else
                {
                    MessageBox.Show("Los taxis solo permiten de 0 a 4 pasajeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                textBox1.Clear();
            }
            if (cantidad > 10)
            {
                for(int i = 0; i<vehiculo.Count; i++)
                {
                    label2.Text = label2.Text + $"{vehiculo[i].Nombre()} {i+1} : {vehiculo[i].cantidadPasajeros} pasajero/s \n";
                }
                label1.Text = $"Ha llegado al límite de cargas (10)";
                button1.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //No permite que se ingresen letras o símbolos
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            vehiculo.Clear();
            cantidad = 1;
            button1.Enabled = true;
            label2.Text = "";
            label1.Text = $"Ingrese el número de pasajeros del ómnibus {cantidad}:";
        }
    }
}
