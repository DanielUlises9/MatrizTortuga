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

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMatriz.Text = torti.ToString();
        }

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {

            lblMatriz.Text = Convert.ToString(e.KeyChar);

        }
        private void txtEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<int> list = new List<int>();
                var matches = Regex.Matches(txtEntrada.Text, "\\d+");

                foreach (var march in matches)
                {
                    list.Add(Convert.ToInt32((Convert.ToString(march))));
                }
                for (int index =0; index<list.Count();index++)
                {
                    switch (list.ElementAt(index))
                    {
                        case 1:
                            {
                                torti._Dibujar = true;
                                MostrarEstados();
                                break;
                            }
                        case 2:
                            {
                                torti._Dibujar = false;
                                MostrarEstados();
                                break;
                            }
                        case 3:
                            {
                                torti.GirarDerecha();
                                MostrarEstados();
                                break;
                            }
                        case 4:
                            {
                                torti.GirarIzquierda();
                                MostrarEstados();
                                break;
                            }
                        case 5:
                            {
                                torti.caminar(list.ElementAt(index+1));
                                index++;
                                break;
                            }
                        case 6:
                            {
                                lblMatriz.Text = torti.ToString();
                                break;
                            }
                        case 7:
                            {
                                goto FINAL;
                            }
                    }
                    FINAL:;
                }
                    list.Clear();
            }
        }
        public void MostrarEstados()
        {
            lblPlumaEstate.Text = torti._Dibujar.ToString();
            lblVistaTortuga.Text = "La tortuga mira hacia: " + torti.Girar;
        }
    }
}
