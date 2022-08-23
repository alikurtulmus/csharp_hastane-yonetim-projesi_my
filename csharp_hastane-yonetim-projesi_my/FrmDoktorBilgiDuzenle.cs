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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCNO;

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mtxttc.Text = TCNO;
            SqlCommand komut = new SqlCommand("select*from doktor_tbl where doktortc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mtxttc.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text=dr[2].ToString();
                cmbbrans.Text = dr[3].ToString();
                txtsifre.Text=dr[5].ToString();
                bgl.baglanti().Close();
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update doktor_tbl set doktorad=@p1,doktorsoyad=@p2,doktorbrans=@p3,doktorsifre=@p4 where doktortc=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut.Parameters.AddWithValue("@p5", mtxttc.Text);
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Kayıt Güncellendi.");

        }
    }
}
