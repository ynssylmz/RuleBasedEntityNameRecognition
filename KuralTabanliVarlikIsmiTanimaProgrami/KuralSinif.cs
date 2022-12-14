using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuralTabanliVarlikIsmiTanimaProgrami
{
    class KuralSinif : TemelSinif
    {
        SozlukSinif sozlukKural = new SozlukSinif();

        public int KuralKontrolEt(string s, int index)
        {
            int isaretlenecekSozcukSayisi = 0;
            int i = 0;
            //---------------------------------------------------------------------
            //Hepsi büyük harf olan sözcükler kısaltma kabul edilir ve isim olarak etiketlenir(Kurum İsimleri 3.Kural)
            //foreach(char chr in s)
            //{
            //    if (chr >= 60 && chr <= 90)
            //    {
            //        i++;
            //        continue; 
            //    }
            //    else if(i==s.Length-1)

            //}
            //---------------------------------------------------------------------
            foreach (string sozluk in sozlukKural.sozluk_Organizasyon_IsimdenSonra)
            {
                if (s == sozluk)
                {
                    for (int j = 0; j > 4; j++)
                    {
                        //Aşağıda anahtar kelimeden önceki ismin büyük harfle başladığı ve virgülle ayrılmadığı kontrol edilir.
                        if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDizi[index - j].EndsWith(','))
                        {
                            isaretlenecekSozcukSayisi++;
                            continue;
                        }
                        //Aşağıda anahtar kelimeden önceki ismin virgülle ayrıldığı kontrol edilir.(Kurum İsimleri 7.Kural)
                        else if (metinDizi[index - j].EndsWith(','))
                            break;
                        //Kurum isimleri "ve" bağlacıyla bağlanıyorsa işaretlemeye dahil olur."Bilgi ve Teknoloji Kurumu" gibi vb.
                        //(Kurum İsimleri 6.Kural)
                        else if (!BasHarfKontrolEt(metinDizi[index - j]) && metinDizi[index - j] == "ve")
                        {
                            isaretlenecekSozcukSayisi++;
                            continue;
                        }
                        else break;
                    }
                    BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                }
                return 0;
            }
            //---------------------------------------------------------------------
            //(Kurum İsimleri 2.Kural)
            foreach (string sozluk in sozlukKural.sozluk_Organizasyon_IsminIcinde)
            {
                if (s.Contains(sozluk) && BasHarfKontrolEt(s))
                {
                    Isaretle(index);
                }
                return 0;
            }
            //---------------------------------------------------------------------
            foreach (string sozluk in sozlukKural.sozluk_Unvan_IsimdenOnce)
            {
                if (s == sozluk)
                {
                    for (int j = 0; j > 4; j++)
                    {
                        //dizideki bir sonraki string degeri kontrol ederken noktalama işaretlerini kontrol et.(Kişi İsmi 5.Kural)
                        if (BasHarfKontrolEt(metinDizi[index + j]) && !metinDizi[index + j - 1].EndsWith(',') && !metinDizi[index + j - 1].EndsWith('.'))//"&& index + j != metinDizi.Length"(Bu kontrol dizi taşmaması için!-unutma ekle)
                        {
                            isaretlenecekSozcukSayisi++;
                            continue;
                        }
                        //İsimden sonra ismi virgülle bağlanan ismi işaretlemek için.(Kişi İsmi 8.Kural)
                        else if (BasHarfKontrolEt(metinDizi[index + j]) && metinDizi[index + j - 1].EndsWith(','))
                        {
                            Isaretle(index + j);
                        }
                        //Aşağıdaki else if kontrolu ünvandan sonra gelen isim "ve" bağlacı ile başka bir isme bağlanıyorsa bütün
                        //döngüden bağımsız bir şekilde isim olarak işaretlenir.(Kişi ismi 7.Kural)
                        else if (metinDizi[index + j] == "ve" && BasHarfKontrolEt(metinDizi[index + j + 1]))
                        {
                            Isaretle(index + j + 1);
                        }
                        else break;
                    }
                    BirlestirIsaretle(index + 1, isaretlenecekSozcukSayisi);
                }
                return 0;
            }
            //-------------------------------------------------------------------
            foreach (string sozluk in sozlukKural.sozluk_Unvan_IsimdenSonra)
            {
                if (s == sozluk)
                    for (int j = 0; j < 4; j++)
                    {
                        if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDiziİsaretliMi[index])
                        {
                            isaretlenecekSozcukSayisi++;
                            continue;
                        }
                        else if (metinDiziİsaretliMi[index])
                        {
                            IsaretKaldir(index);
                            isaretlenecekSozcukSayisi++;
                        }
                        BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                    }
                //Ve kendinden işaretlenmiş veya işaretlenecek isimden önceki string virgülle bitiyor ve 
                //büyük harf ile başlıyorsa işaretli mi kontrol et ve işaretle.
                return 0;
            }
            //----------------------------------------------------------------------------------------------
            /*Aşağıdaki kod satırları yer isimleri önde ve sonda olan anahtar kelimelerin kontrollerini içeren kodlar
             * 3,4,5,7 ve 7.Kurallar eklenecek.
            //-------------------------------------------------------------------
            //(Yer İsimleri 1.Kural)
            foreach (string sozluk in sozlukKural.sozluk_Yer_IsimdenOnce)
            {
                if (s == sozluk)
                    for (int j = 0; j < 4; j++)
                    {
                        if (BasHarfKontrolEt(metinDizi[index + j]) && !metinDiziİsaretliMi[index])
                        {
                            isaretlenecekSozcukSayisi++;
                            continue;
                        }
                        else if (metinDiziİsaretliMi[index])
                        {
                            IsaretKaldir(index);
                            isaretlenecekSozcukSayisi++;
                        }
                        
                    }
                if (BasHarfKontrolEt(s))
                    BirlestirIsaretle(index, isaretlenecekSozcukSayisi);
                else if (!BasHarfKontrolEt(s))
                    BirlestirIsaretle(index + 1, isaretlenecekSozcukSayisi);

                return 0;
            }
            //-------------------------------------------------------------------
            //(Yer İsimleri 2.Kural)
            foreach (string sozluk in sozlukKural.sozluk_Yer_IsimdenSonra)
            {
                if (s == sozluk)
                    for (int j = 0; j < 4; j++)
                    {
                        if (BasHarfKontrolEt(metinDizi[index - j]) && !metinDiziİsaretliMi[index])
                        {
                            isaretlenecekSozcukSayisi++;
                            continue;
                        }
                        else if (BasHarfKontrolEt(metinDizi[index - j])&&metinDiziİsaretliMi[index])
                        {
                            IsaretKaldir(index);
                            isaretlenecekSozcukSayisi++;
                        }
                        BirlestirIsaretle(index - isaretlenecekSozcukSayisi, isaretlenecekSozcukSayisi);
                    }
                return 0;
            }
             * Yer işaretleri 3,4,5,6,7 nolu kurallar eklenecek olan alan sonu.
             */
            //----------------------------------------------------------------------------------------------
            return 0;
        }
        //---------------------------------------------------------------------------------------------------
        //Baş harfi kontrol et
        //Isaretleme ve Birleştirip işaretle fonksiyonları
        //ve İşareti kaldır,sil

        public bool BasHarfKontrolEt(string s)
        {
            if (Convert.ToChar(s.Substring(0, 1)) >= 65 && Convert.ToChar(s.Substring(0, 1)) <= 90)
                return true;
            else return false;
        }

        public void BirlestirIsaretle(int index, int isaretlenecekSozcukSayisi)
        {
            //Aşağıdaki foreach kontrolu kişi isimlerinin 6. kuralı için. "Genel Başkan Yardımcısı"ndaki "Yardımcısı"yı işaretlemeyi önlemek vb.
            foreach (string sozluk in sozlukKural.sozluk_Unvan_IsimdenOnce)
            {
                if (metinDizi[index] == sozluk)
                {
                    index++;
                }
            }

            metinDizi[index] = ilkIsaret + metinDizi[index].ToString();
            metinDizi[index + (isaretlenecekSozcukSayisi - 1)] = metinDizi[index].ToString() + sonIsaret;

            for (int i = 0; i <= isaretlenecekSozcukSayisi; i++)
                metinDiziİsaretliMi[index + i] = true;
        }

        public void Isaretle(int index)
        {
            metinDizi[index] = ilkIsaret + metinDizi[index].ToString() + sonIsaret;
            metinDiziİsaretliMi[index] = true;
        }

        public void IsaretKaldir(int index)
        {
            if (metinDizi[index].Contains(ilkIsaret) || metinDizi[index].Contains(sonIsaret))
            {
                metinDizi[index] = metinDiziOrijinal[index];
                metinDiziİsaretliMi[index] = false;
            }
        }
    }
}