using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    class AnalizSinif : KuralSinif
    {
        public void AnalizEt()
        {

            for (int i = 0; i < metinDizi.Length; i++)
            {
                if (metinDiziİsaretliMi[i])
                {
                    continue;
                }
                else
                {
                    KuralKontrolEt(metinDizi[i], i);
                }

            }
        }
    }
}
