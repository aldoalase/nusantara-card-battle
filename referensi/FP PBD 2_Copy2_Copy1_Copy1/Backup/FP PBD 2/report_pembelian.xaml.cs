using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;

namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for report_pembelian.xaml
	/// </summary>
	public partial class report_pembelian : Window
	{
        string struk;
        string idAdmin;
        koneksi konek;
        Report_Pembelian rp;
		public report_pembelian(string id,string idP)
		{
			this.InitializeComponent();
            idAdmin = id;
            struk = idP;
			// Insert code required on object creation below this point.
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window keluar = new window_penjualan(idAdmin);
			keluar.Show();
			this.Close();
		}

        private void tampil_Click(object sender, RoutedEventArgs e)
        {
            rp = new Report_Pembelian();
            rptViewer = new CrystalReportViewer();
            

            rp.SetDatabaseLogon("Final Project", "kel29");
            System.Windows.MessageBox.Show(struk);
            rp.SetParameterValue("id_struk", struk);
            
            rptViewer.ReportSource = rp;
            Report1.Child = rptViewer;
        }
	}
}