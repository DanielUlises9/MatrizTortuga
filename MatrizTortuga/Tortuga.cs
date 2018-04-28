using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizTortuga
{
    class Tortuga
    {
        private static char[,] piso;
        private char _tortuga;
        private static int length;
        private bool dibujar;
        private int girar;


        public Tortuga()
        {
            piso = new char[20, 20];
            _tortuga = '@';
            length = piso.GetLength(0);
            DibujarEsenario();
            girar = 2;
        }

        private void DibujarEsenario()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                    piso[j, i] = '=';
            }

            for (int i = 4; i < 16; i++)
            {
                piso[4, i] = '/';
                piso[i, 15] = '/';
                piso[15, i] = '/';
                piso[i, 4] = '/';
            }
            piso[9, 9] = _tortuga;
        }

        public void caminar(int cuantosPasos)
        {
            BuscarPocision(out int _Jn,out int _In);
            int temp = 0;
            if(dibujar)
            {
                switch (girar)
                {
                    case 0:
                        {
                            temp = _Jn - cuantosPasos;
                            temp = controltemp(temp);
                            piso[temp, _In] = '@';   
                                break;
                        }
                    case 1:
                        {
                            temp = _In + cuantosPasos;
                            temp = controltemp(temp);
                            piso[_Jn, temp] = '@';
                            break;
                        }
                    case 2:
                        {
                            temp = _Jn + cuantosPasos;
                            temp = controltemp(temp);
                            piso[temp, _In] = '@';
                            break;
                        }
                    case 3:
                        {
                            temp = _In - cuantosPasos;
                            temp = controltemp(temp);
                            piso[_Jn, temp] = '@';
                            break;
                        }
                }
            }
            else
            {
               
                switch (girar)
                {
                    case 0:
                        {
                            temp = _Jn - cuantosPasos;
                            temp = controltemp(temp);

                            for (int j = _Jn; j > temp; j--)
                            {
                                piso[j, _In] ='*';
                            }
                            piso[temp, _In] = '@';
                            break;
                        }
                    case 1:
                        {
                            temp = _In + cuantosPasos;
                            temp = controltemp(temp);

                            for (int i = _In; i < temp; i++)
                            {
                                piso[_Jn,i] = '*';
                            }
                            piso[_Jn, temp] = '@';
                            break;
                        }
                    case 2:
                        {
                            temp = _Jn + cuantosPasos;
                            temp = controltemp(temp);

                            for (int j = _Jn; j < temp; j++)
                            {
                                piso[j,_In] = '*';
                            }
                            piso[temp, _In] = '@';
                            break;
                        }
                    case 3:
                        {
                            temp = _In - cuantosPasos;
                            temp = controltemp(temp);

                            for (int i= _In; i > temp; i--)
                            {
                                piso[_Jn, i] = '*';
                            }
                            piso[_Jn, temp] = '@';
                            break;
                        }
                }
            }
        }

    private static void BuscarPocision(out int _j,out int _i)
        {
            /*int j=0, i=0;
            while (piso[j, i] != '@')
            {
                j++; i++;
            }
            */
            _j = 0; _i = 0;
            for (_i = 0; _i < length; _i++)
            {
                for (_j = 0; _j < length; _j++)
                {
                    if (piso[_j, _i] == '@')
                    {
                        piso[_j, _i] = '=';
                        break;
                    }
                }

            }

        }

        public override string ToString()
        {
            
            string dibujar="";
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                    dibujar += piso[j, i].ToString();
                dibujar += "\r\n";
            }
            return dibujar;
            
        }

        public void GirarDerecha() { girar--; control(); }
        public void GirarIzquierda(){ girar++; control(); }
        private void control() { if (girar > 3) girar = 0; else if (girar < 0) girar = 3; }


        private int controltemp(int temp) { if (temp > 19) temp = 1; else if (temp < 0) temp = 19; else return temp; return temp; }


        public bool _Dibujar { get => dibujar; set => dibujar = value; }


        /*static void GetTwoNumbersA(out int number1, out int number2)
        {
            number1 = 1;
            number2 = 2;
        }*/

    }
}
