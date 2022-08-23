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
    public partial class FrmHastaBilgiDuzenle : Form
    {
        public FrmHastaBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string tcno;
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmHastaBilgiDuzenle_Load(object sender, EventArgs e)
        {        
        mtxttc.Text = tcno;
            SqlCommand komut=new SqlCommand("select*from hasta_tbl where hastatc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mtxttc.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text=dr[2].ToString();
                mtxttel.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update hasta_tbl set hastaad=@p1,hastasoyad=@p2,hastatelefon=@p3,hastasifre=@p4,hastacinsiyet=@p5 where hastatc=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtad.Text);
            komut2.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mtxttel.Text);
            komut2.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", mtxttc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler güncellendi..","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
