using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_hastane_yonetim_projesi_my
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void btnhastagiris_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frmhg =new FrmHastaGiris();
            frmhg.Show();
            this.Hide();
        }

        private void btndoktorgiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris frmdg =new FrmDoktorGiris();
            frmdg.Show();
            this.Hide();
        }

        private void btnsekretergiris_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris frmsg = new FrmSekreterGiris();
            frmsg.Show();
            this.Hide();
        }
    }
}
