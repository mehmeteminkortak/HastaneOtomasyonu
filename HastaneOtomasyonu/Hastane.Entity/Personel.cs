﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Entity
{
    public class Personel : HastaneBC, IMaas
    {
        public int AylikGunSayisi
        {
            get; set;
        }

        public decimal BirimFiyat
        {
            get
            {
                return Maas / 30;
            }
        }

        public Gorevler Gorevi { get; set; }

        public decimal Maas
        {
            get; set;
        }

        public decimal MaasHesapla()
        {
            return BirimFiyat * AylikGunSayisi + 150;
        }
    }
}
