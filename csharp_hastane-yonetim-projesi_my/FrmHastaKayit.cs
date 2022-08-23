using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace csharp_hastane_yonetim_projesi_my
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into hasta_tbl (hastaad,hastasoyad,hastatc,hastatelefon,hastasifre,hastacinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mtxttc.Text);
            komut.Parameters.AddWithValue("@p4", mtxttel.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbcinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız gerçekleşmiştir. Şifreniz: "+txtsifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }
    }
}
