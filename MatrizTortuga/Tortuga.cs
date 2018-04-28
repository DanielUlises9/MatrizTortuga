using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrizTortuga
{

    //Columnas,Renglones
    class Tortuga
    {
        private char[,] piso;
        private char _tortuga,esenario,cubo,tinta;
        private int length;
        private bool dibujar;
        private int girar;
        private int Jtorti, Itorti;


        public Tortuga()
        {
            piso = new char[20, 20];
            Jtorti = Itorti = 9;
            _tortuga = '@'; esenario = '='; cubo = '/'; tinta = '*';
            length = piso.GetLength(0);
            Girar = 0;
            dibujar = false;
            DibujarEsenario();
        }

        private void DibujarEsenario()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                    piso[j, i] = esenario;
            }

            for (int i = 4; i < 16; i++)
            {
                piso[4, i] = cubo;
                piso[i, 15] = cubo;
                piso[15, i] = cubo;
                piso[i, 4] = cubo;
            }
            piso[Itorti, Jtorti] = _tortuga;
       
        }

        public void caminar(int cuantosPasos)
        {
            //BuscarPocision(out int Jtorti,out int Itorti);
            int temp, temp2,mientras;
            mientras=temp = temp2 = 0;
            if(dibujar)
            {
                switch (Girar)
                {
                    case 0:
                        {
                            piso[Itorti, Jtorti] = esenario;
                            temp = Jtorti - cuantosPasos;
                            temp = controltemp(temp);
                            Jtorti = temp;
                            piso[Itorti, temp] = _tortuga;   
                                break;
                        }
                    case 1:
                        {
                            piso[Itorti, Jtorti] = esenario;
                            temp = Itorti + cuantosPasos;
                            temp = controltemp(temp);
                            Itorti = temp;
                            piso[temp, Jtorti] = _tortuga;
                            break;
                        }
                    case 2:
                        {
                            piso[Itorti, Jtorti] = esenario;
                            temp = Jtorti + cuantosPasos;
                            temp = controltemp(temp);
                            Jtorti = temp;
                            piso[Itorti, temp] = _tortuga;
                            break;
                        }
                    case 3:
                        {
                            piso[Itorti, Jtorti] = esenario;
                            temp = Itorti - cuantosPasos;
                            temp = controltemp(temp);
                            Itorti = temp;
                            piso[temp, Jtorti] = _tortuga;
                            break;
                        }
                }
            }
            else
            {
                switch (Girar)
                {
                    case 0:
                        {
                            mientras = Jtorti;
                            temp = Jtorti - cuantosPasos;
                            temp = AsteristicoControl(temp);
                            while (mientras > temp)
                            {
                                piso[Itorti, mientras] = tinta;
                                mientras--;
                            }
                            temp2 = Jtorti - cuantosPasos;
                            Jtorti = temp;
                            if (temp2 <0)
                            {
                                temp2 = controltemp(temp2) +1;
                                Jtorti = temp2-1;
                                piso[Itorti,Jtorti] = _tortuga;
                                while (temp2<20)
                                {
                                    piso[Itorti, temp2] = tinta;
                                    temp2++;
                                }
                            }else
                                piso[Itorti, mientras] = _tortuga;
                            break;
                        }
                    case 1:
                        {
                            mientras = Itorti;
                            temp = Itorti + cuantosPasos;
                            temp = AsteristicoControl(temp);
                            while(mientras<=temp)
                            {
                                piso[mientras, Jtorti] = tinta;
                                mientras++;
                            }
                            mientras = 0;
                            temp2 = Itorti + cuantosPasos;
                            Itorti = temp;
                            if(temp2>19)
                            {
                                temp2 = controltemp(temp2);
                                Itorti = temp2;
                                while (mientras <= temp2)
                                {
                                    piso[mientras, Jtorti] = tinta;
                                    mientras++;
                                }
                            }
                            piso[temp2, Jtorti] = _tortuga;
                            break;
                        }
                    case 2:
                        {
                            mientras = Jtorti;
                            temp = Jtorti + cuantosPasos;
                            temp = AsteristicoControl(temp);
                            while (mientras < temp)
                            {
                                piso[Itorti, mientras] = tinta;
                                mientras++;
                            }
                            mientras = 0;
                            temp2 = Itorti + cuantosPasos;
                            Jtorti = temp;
                            if (temp2 > 19)
                            {
                                temp2 = controltemp(temp2);
                                Jtorti = temp2;
                                while (mientras <= temp2)
                                {
                                    piso[Itorti, mientras] = tinta;
                                    mientras++;
                                }
                            }
                            piso[Itorti,temp2] = _tortuga;
                            break;
                        }
                    case 3:
                        {
                            mientras = Itorti;
                            temp = Itorti - cuantosPasos;
                            temp = AsteristicoControl(temp);
                            while (mientras > temp)
                            {
                                piso[mientras,Jtorti] = tinta;
                                mientras--;
                            }
                            temp2 = Itorti - cuantosPasos;
                            Itorti = temp;
                            if (temp2 < 0)
                            {
                                temp2 = controltemp(temp2) + 1;
                                Itorti = temp2 - 1;
                                piso[Itorti, Jtorti] = _tortuga;
                                while (temp2 < 20)
                                {
                                    piso[temp2,Jtorti] = tinta;
                                    temp2++;
                                }
                            }
                            else
                                piso[mientras,Jtorti] = _tortuga;
                            break;
                        }
                }
            }
        }

        /*private static void BuscarPocision(out int _j,out int _i)
            {
                int j=0, i=0;
                while (piso[j, i] != _tortuga)
                {
                    j++; i++;
                }

                _j = 0; _i = 0;
                for (_i = 0; _i < length; _i++)
                {
                    for (_j = 0; _j < length; _j++)
                    {
                        if (piso[_j, _i] == )
                        {
                            piso[_j, _i] = '=';
                            goto MYGOTO;
                        }
                    }
                }
                MYGOTO:;
    }*/

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

        public void GirarDerecha() { Girar--; control(); }
        public void GirarIzquierda(){ Girar++; control(); }
        private void control() { if (Girar > 3) Girar = 0; else if (Girar < 0) Girar = 3; }


        private int controltemp(int temp) { if (temp > 19) temp = temp -20; else if (temp < 0) { temp = 20 +temp; } else return temp; return temp; }
        private int AsteristicoControl(int temp) { if (temp > 19) return temp = 19; else if (temp < 0) return temp = 0; return temp; }


        public bool _Dibujar { get => dibujar; set => dibujar = value; }
        public int Girar { get => girar; set => girar = value; }


        /*static void GetTwoNumbersA(out int number1, out int number2)
        {
            number1 = 1;
            number2 = 2;
        }*/

    }
}
