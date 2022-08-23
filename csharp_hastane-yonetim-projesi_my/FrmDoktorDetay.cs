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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text=tc;

            //Doktor Ad Soyad getir

            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from doktor_tbl where doktortc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from randevu_tbl where randevudoktor='"+lbladsoyad.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource=dt;
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frmdbd = new FrmDoktorBilgiDuzenle();
            frmdbd.TCNO = lbltc.Text;
            frmdbd.Show();

        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchsikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
