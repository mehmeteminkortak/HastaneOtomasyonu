﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Entity
{
    public abstract class HastaneBC
    {
        #region Fields
        string _ad;
        string _soyad;
        string _tckn;
        #endregion
        #region Properties
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Ad
        {
            get
            {
                return _ad;
            }
            set
            {
                if (!IsimKontrol(value))
                    throw new Exception("Ad veya soyad da karakter hatası");
                _ad = BasHarf(value);
            }
        }
        public string Soyad
        {
            get
            {
                return _soyad;
            }
            set
            {
                if (!IsimKontrol(value))
                    throw new Exception("Ad veya soyad da karakter hatası");
                _soyad = BasHarf(value);
            }
        }
        public string TCKN
        {
            get { return _tckn; }
            set
            {
                if (!TCKNKontrol(value))
                    throw new Exception("TCKN hatalı!");
                _tckn = value;
            }
        }
        public DateTime DogumTarihi { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public Cinsiyetler Cinsiyet { get; set; }
        public KanGruplari KanGrubu { get; set; }
        #endregion
        #region Methods
        private string BasHarf(string value) => value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
        private bool IsimKontrol(string value)
        {
            foreach (var item in value)
            {
                if (!char.IsLetter(item))
                    return false;
            }
            return true;
        }
        private bool TCKNKontrol(string value)
        {
            if (value.Length == 11)
            {
                foreach (var item in value)
                {
                    if (!char.IsDigit(item))
                        return false;
                }
                return true;
            }
            return false;
        }
        public override string ToString() => $"{Ad} {Soyad}";
        #endregion
    }
    public enum Cinsiyetler
    {
        Belirsiz,
        Erkek,
        Kadın
    }
    public enum KanGruplari
    {
        SifirRhPozitif,
        SifirRhNegatif,
        ARhPozitif,
        ARhNegatif,
        BRhPozitif,
        BRhNegatif,
        ABRhPozitif,
        ABRhNegatif
    }
    public enum Birimler
    {
        Dahiliye,
        Ortopedi,
        Göz,
        Cildiye,
        KBB,
        Çocuk
    }
    public enum Gorevler
    {
        Muhasebe,
        Temizlik,
        Hastabakıcı
    }
    public enum Unvanlar
    {
        ProfDr,
        DocDr,
        UzDr,
        PratisyenDr
    }
}
