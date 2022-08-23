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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string stc;
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = stc;

            //ad soyad getirme

            SqlCommand komut1 = new SqlCommand("Select sekreteradsoyad from sekreter_tbl where sekretertc=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr1=komut1.ExecuteReader();
            while(dr1.Read())
            {
                lbladsoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //branşları getirme
            DataTable dt1=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select* from brans_tbl", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource=dt1;

            //doktorları getirme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select doktorid,(doktorad+' '+doktorsoyad) as 'doktor ad',doktorbrans from doktor_tbl", bgl.baglanti());
            da1.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //branşları combobox'a aktarma

            SqlCommand komut2 = new SqlCommand("select bransad from brans_tbl", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while( dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        //Randevu Kaydetme

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into randevu_tbl (randevutarih,randevusaat,randevubrans,randevudoktor) values (@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", mtxtrandevutarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2",mtxtrandevusaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            komutkaydet.Parameters.AddWithValue("@r5",mtxthastatc.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Kaydedildi!");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("select (doktorad+' '+doktorsoyad) from doktor_tbl where doktorbrans=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                cmbdoktor.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnduyuru_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into duyuru_tbl (duyuruad) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",rctduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru oluşturuldu.");
        }

        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp=new FrmDoktorPaneli();
            drp.Show();
        }

        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            FrmBrans frb=new FrmBrans();
            frb.Show();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frmrs = new FrmRandevuListesi();
            frmrs.Show();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update randevu_tbl set randevutarih=@p1,randevusaat=@p2,randevubrans=@p3,randevudoktor=@p4,hastatc=@p5 where randevuid=@p6", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mtxtrandevutarih.Text);
            komut.Parameters.AddWithValue("@p2", mtxtrandevusaat.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", cmbdoktor.Text);
            komut.Parameters.AddWithValue("@p5", mtxthastatc.Text);
            komut.Parameters.AddWithValue("@p6", txtrandevuid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu güncellendi!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmd = new FrmDuyurular();
            frmd.Show();
        }
    }
}
