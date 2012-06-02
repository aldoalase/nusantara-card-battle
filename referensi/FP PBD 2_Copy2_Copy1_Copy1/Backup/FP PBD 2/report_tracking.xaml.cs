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
	/// Interaction logic for report_tracking.xaml
	/// </summary>
	public partial class report_tracking : Window
	{
        string idAdmin;
        string idPengiriman;
        koneksi konek;
        Report_Tracking rp;
		public report_tracking(string id, string idP)
		{
			this.InitializeComponent();
            idAdmin = id;
            idPengiriman = idP;
            konek = new koneksi();

			// Insert code required on object creation below this point.
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window keluar = new window_tracking_customer(idAdmin);
			keluar.Show();
			this.Close();
		}

        private void tampil_Click(object sender, RoutedEventArgs e)
        {
            rp = new Report_Tracking();
            rptViewer = new CrystalReportViewer();

            rp.SetDatabaseLogon("Final Project", "kel29");

            rp.SetParameterValue("id_pengirimantrack", idPengiriman);

            rptViewer.ReportSource = rp;
            Report1.Child = rptViewer;
        }
	}
}