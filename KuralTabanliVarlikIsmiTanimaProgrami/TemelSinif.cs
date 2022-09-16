using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    class TemelSinif
    {
        public string ilkIsaret = "<isim>";
        public string sonIsaret = "</isim>";

        public string[] metinDizi;
        public string[] metinDiziOrijinal;
        public bool[] metinDiziİsaretliMi;

        public void MetinParcala(string metin)
        {
            metinDizi = metin.Split(' ');
            metinDiziOrijinal = metin.Split(' ');

            metinDiziİsaretliMi=new bool[metinDizi.Length];
            for (int i = 0; i < metinDizi.Length; i++)
                metinDiziİsaretliMi[i] = false;
        }
    }
}
