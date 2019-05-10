using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class frmGiris : Form
    {
        BusinessLogic.BLL bll;

        public frmGiris()

           
        {
            
            InitializeComponent();

            bll = new BusinessLogic.BLL();

        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            int gelendeger = bll.SistemKontrol(txt_KullanıcıAdı.Text,txt_Sifre.Text);
            if (gelendeger > 0)
            {
           Kütüphane af =  new Kütüphane();
                af.Show();
            }
            else
                MessageBox.Show("Hatalı kullanıcı adı veya şifre girişi", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
 }
