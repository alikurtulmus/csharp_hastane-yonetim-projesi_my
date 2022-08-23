using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace csharp_hastane_yonetim_projesi_my
{
    internal class sqlbaglantisi
    {
        //Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=HastaneDB;Integrated Security=True
        public SqlConnection baglanti()
        {
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=HastaneDB;Integrated Security=True");
        baglan.Open();
        return baglan;

        }

    }
}
