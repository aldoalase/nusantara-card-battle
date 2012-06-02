using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Forms.Integration;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;

namespace FP_PBD_2
{
	/// <summary>
	/// Interaction logic for report_pengiriman.xaml
	/// </summary>
	public partial class report_pengiriman : Window
	{
        //CrystalReportViewer rptViewer ;
		Report_Pengiriman rp ;
        string t;
        string idAdmin;
        koneksi konek;
        public report_pengiriman(string id, string transaksi)
		{
			
			this.InitializeComponent();
            idAdmin = id;
            t = transaksi;
            konek = new koneksi();
			// Insert code required on object creation below this point.
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{/*
			// TODO: Add event handler implementation here.
			reportPengiriman.SetDatabaseLogon("final_project", "1234");
			rptViewer.ReportSource = reportPengiriman;
			//host.Child = rptViewer;*/


			Window keluar = new window_pengiriman(idAdmin);
			keluar.Show();
			this.Close();
		}

        private void Lihat_Click(object sender, RoutedEventArgs e)
        {
            rp = new Report_Pengiriman();
            rptViewer = new CrystalReportViewer();
            
            
            rp.SetDatabaseLogon("Final Project","kel29");
            
            rp.SetParameterValue("id_pengiriman", t);
            
            rptViewer.ReportSource = rp;
            Report1.Child = rptViewer;
        }
	}
}