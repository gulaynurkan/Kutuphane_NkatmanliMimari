using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace Kutuphane
{
    public partial class Kütüphane : Form
    {
        BusinessLogic.BLL bll;
      //  Guid ID;
        string kitapturu;
        string Yazarturu;
        string dil;
        public Kütüphane()
        {
            InitializeComponent();
            bll = new BusinessLogic.BLL();
        }
        private void ListeGoster()
        {
            dataGridView1.DataSource = bll.KayitListeleView();
            //    dataGridView1.Columns["ID"].Visible = false;


            List<uyeler> uyelistesi = bll.KayitListele();
            if (uyelistesi != null && uyelistesi.Count > 0)
            {
                dataGridView1.DataSource = uyelistesi;
            }
        }



        private void ListeGosterr()
        {
            dataGridView2.DataSource = bll.KayitKitapListeleVieew();
            //    dataGridView1.Columns["ID"].Visible = false;


            List<kitaplar> kitaplistesi = bll.KayitListelee();
            if (kitaplistesi != null && kitaplistesi.Count > 0)
            {
                dataGridView1.DataSource = kitaplistesi;
            }
        }
       // List<kitapturleri> tür= new List<kitapturleri>
    
        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {

        }
       
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {



        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int donenveri = bll.KayıtEkleK(Ktp_ISBN.Text, Ktp_Adi.Text, kitapturu, Yazarturu,dil, DT_basimtarihi.Value);

            if (donenveri > 0)
            {
                MessageBox.Show("Yeni Kayıt eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGosterr();
            }
            else
                MessageBox.Show("Kayıt eklenemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int donenveri = bll.KayıtEkleU(txt_kod.Text, txt_ad.Text, txt_soyad.Text, dTP_dogum_tarihi.Value, txt_tel.Text, txt_email.Text, txt_adres.Text);

            if (donenveri > 0)
            {
                MessageBox.Show("Yeni Kayıt eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
            else
                MessageBox.Show("Kayıt eklenemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
      

    private void Kütüphane_Load(object sender, EventArgs e)
        {
            ListeGoster();
            ListeGosterr();

            List<kitapturleri> BookList = bll.AddBookTypeList();
            if (BookList != null && BookList.Count > 0)
            {
                comboBoxKitapTurKodu.DataSource = BookList;
      
            }

            List<yazarlar> outhorlist = bll.AddauthorTypeList();
            if (outhorlist != null && outhorlist.Count > 0)
            {
                comboboxYazarKodu.DataSource = outhorlist;

            }
            List<diller> languageList = bll.AddlanguageTypeList();
            if (languageList != null && languageList.Count > 0)
            {
                comboboxDil.DataSource = languageList;

            }
        }

        private void button3_Click(object sender, EventArgs e) //sil buton içi
        {

            //   BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int donendeger = bll.KayitSil(txt_kod.Text);
            if (donendeger > 0)
            {
                MessageBox.Show("Kayıt silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //  ID = (Guid)dataGridView1.CurrentRow.Cells[0].Value;
            txt_kod.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_ad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_soyad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_tel.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_email.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_adres.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  ID = (Guid)dataGridView1.CurrentRow.Cells[0].Value;
          //  Ktp_kodu.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Ktp_ISBN.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            Ktp_Adi.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            comboBoxKitapTurKodu.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            comboboxYazarKodu.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            comboboxDil.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            //  DT_basimtarihi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxKitapTurKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            kitapturu = (comboBoxKitapTurKodu.SelectedItem as kitapturleri).kt_kodu;
        }


        private void comboboxDil_SelectedIndexChanged(object sender, EventArgs e)
        {
            dil = (comboboxDil.SelectedItem as diller).d_id;
        }

        private void comboboxYazarKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Yazarturu = (comboboxYazarKodu.SelectedItem as yazarlar).y_kodu;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int donendeger = bll.KayitKitapSil(Ktp_ISBN.Text);
            if (donendeger > 0)
            {
                MessageBox.Show("Kayıt silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int donendeger = bll.KitapKayitDuzenle(Ktp_ISBN.Text,Ktp_Adi.Text, kitapturu, Yazarturu, dil, DT_basimtarihi.Value);

            if (donendeger > 0)
            {
                MessageBox.Show("Kayıt güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
            else
                MessageBox.Show("Kayıt değiştirilemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int donendeger = bll.UyeKayitDuzenle(txt_kod.Text, txt_ad.Text, txt_soyad.Text, dTP_dogum_tarihi.Value, txt_tel.Text, txt_email.Text, txt_adres.Text);

            if (donendeger > 0)
            {
                MessageBox.Show("Kayıt güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGoster();
            }
            else
                MessageBox.Show("Kayıt değiştirilemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }

