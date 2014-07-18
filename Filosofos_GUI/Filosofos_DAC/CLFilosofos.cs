using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filosofos_BE;

namespace Filosofos_DAC
{
    public class CLFilosofos
    {

        CEFilosofos oCE = new CEFilosofos();
        public int[] Estados = new int[5];
        public void Sincronizar()
        {


            if (oCE.Comer < oCE.TiempoC)
            {
                oCE.Comer++;
            }

            if (oCE.Pensar < oCE.TiempoP)
            {
                oCE.Pensar++;
            }

            //Poner hambrientos a los que piensan
            if (oCE.Pensar == oCE.TiempoP)
            {
                for (int h = 0; h < 5; h++)
                {
                    if (Estados[h] == 0)
                    {
                        Estados[h] = 2;
                    }
                }
                oCE.Pensar = 0;
            }
            //Poner [pensando o hambrientos] a los que comian
            if (oCE.Comer == oCE.TiempoC)
            {
                for (int h = 0; h < 5; h++)
                {
                    if (Estados[h] == 1)
                    {
                        //Si no hay tiempo para pensar, a pasar hambre
                        if (oCE.TiempoP > 0)
                        {
                            Estados[h] = 0;
                        }
                        else
                        {
                            Estados[h] = 2;
                        }
                    }
                }
                oCE.Comer = 0;
                //Poner a comer a los hambrientos
                oCE.Cont++;
                if (oCE.Cont > 4)
                {
                    oCE.Cont = 0;
                }
                if (oCE.Cont < 3)
                {
                    Estados[oCE.Cont] = 1;
                    Estados[oCE.Cont + 2] = 1;
                }
                else
                {
                    Estados[oCE.Cont] = 1;
                    Estados[oCE.Cont - 3] = 1;
                }
            }
        }
    }
}
