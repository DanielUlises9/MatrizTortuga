using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrizTortuga
{
    public partial class Form1 : Form
    {

        Tortuga torti = new Tortuga();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMatriz.Text = torti.ToString(); 
        }

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            lblMatriz.Text = Convert.ToString( e.KeyChar);

        }

        private void txtEntrada_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void txtEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var matches = Regex.Matches(txtEntrada.Text, "[0-9]+");
                //int lenght=Convert.ToInt32( Convert.ToString(matches));
                int i = 0,j=0;

                foreach (var march in matches)
                {
                    j++;
                }
                int[] valor = new int[j];
                foreach (var march in matches)
                {
                    string hola = Convert.ToString(march);
                    valor[i] = Convert.ToInt32(hola);
                    i++;
                }
                switch (valor[0])
                {
                    case 1:
                        {
                            torti._Dibujar=true;
                            break;
                        }
                    case 2:
                        {
                            torti._Dibujar = false;
                            break;
                        }
                    case 3:
                        {
                            torti.GirarDerecha();
                            break;
                        }
                    case 4:
                        {
                            torti.GirarIzquierda();
                            break;
                        }
                    case 5:
                        {
                            torti.caminar(valor[1]);
                            break;
                        }
                    case 6:
                        {
                            lblMatriz.Text=torti.ToString();
                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                }
            }   
        }
    }
}
