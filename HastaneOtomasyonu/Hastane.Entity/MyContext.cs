﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Entity
{
    public class MyContext
    {
        public List<Hasta> Hastalar { get; set; } = new List<Hasta>();
        public List<Personel> Personeller { get; set; } = new List<Personel>();
        public List<Hemsire> Hemsireler { get; set; } = new List<Hemsire>();
        public List<Doktor> Doktorlar { get; set; } = new List<Doktor>();
        public List<Randevu> Randevular { get; set; } = new List<Randevu>();
    }
}
