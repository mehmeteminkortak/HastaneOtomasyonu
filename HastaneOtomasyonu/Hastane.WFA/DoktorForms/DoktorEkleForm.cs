﻿using Hastane.Entity;
using Hastane.WFA.BaseForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane.WFA.DoktorForms
{
    public partial class DoktorEkleForm : EkleBaseForm
    {
        public DoktorEkleForm()
        {
            InitializeComponent();
        }
        public List<Doktor> Doktorlar { get; set; }
        public List<Hemsire> Hemsireler { get; set; }
        public List<Hemsire> DoktorunHemsireleri { get; set; }
        public Birimler SeciliBirim { get; set; }
        private void cmbBirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBirim.SelectedIndex == -1) return;
            clstHemsireler.Items.Clear();
            SeciliBirim = (Birimler)Enum.Parse(typeof(Birimler), cmbBirim.SelectedItem.ToString());
            var atanmamisHemsireler = Hemsireler.Where(x => x.Birimi == SeciliBirim && x.AtandiMi == false).ToList();
            atanmamisHemsireler.ForEach(x => clstHemsireler.Items.Add(x));
        }

        private void DoktorEkleForm_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.Items.AddRange(Enum.GetNames(typeof(Cinsiyetler)));
            cmbKanGrubu.Items.AddRange(Enum.GetNames(typeof(KanGruplari)));
            cmbBirim.Items.AddRange(Enum.GetNames(typeof(Birimler))); ;
            cmbUnvan.Items.AddRange(Enum.GetNames(typeof(Unvanlar)));
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Doktor eklenecekDoktor = new Doktor()
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    TCKN = txtTCKN.Text,
                    DogumTarihi = dtpDogumTarihi.Value,
                    Cinsiyet = (Cinsiyetler)Enum.Parse(typeof(Cinsiyetler), cmbCinsiyet.SelectedItem.ToString()),
                    KanGrubu = (KanGruplari)Enum.Parse(typeof(KanGruplari), cmbKanGrubu.SelectedItem.ToString()),
                    Birimi = (Birimler)Enum.Parse(typeof(Birimler), cmbBirim.SelectedItem.ToString()),
                    Maas = nMaas.Value,
                    Unvan = (Unvanlar)Enum.Parse(typeof(Unvanlar), cmbUnvan.SelectedItem.ToString())
                };
                DoktorunHemsireleri = new List<Hemsire>();
                if (clstHemsireler.CheckedItems.Count > 0)
                {
                    foreach (Hemsire item in clstHemsireler.CheckedItems)
                    {
                        DoktorunHemsireleri.Add(item);
                    }
                    DoktorunHemsireleri.ForEach(x => x.AtandiMi = true);
                    eklenecekDoktor.Hemsireler = DoktorunHemsireleri;
                }
                Doktorlar.Add(eklenecekDoktor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
