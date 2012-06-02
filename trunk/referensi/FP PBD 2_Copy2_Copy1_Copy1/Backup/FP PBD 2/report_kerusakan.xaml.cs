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
	/// Interaction logic for report_kerusakan.xaml
	/// </summary>
	public partial class report_kerusakan : Window
	{
        string idAdmin; koneksi konek;
        Report_Kerusakan rp;
        
        string noKerusakan;
		public report_kerusakan(string id, string no)
		{
			this.InitializeComponent();
            idAdmin = id;
            noKerusakan = no;
            konek = new koneksi();
			// Insert code required on object creation below this point.
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Window kembali = new window_kerusakan_customer(idAdmin);
			kembali.Show();
			this.Close();
		}

        private void tampil_Click(object sender, RoutedEventArgs e)
        {
            rp = new Report_Kerusakan();
            rptViewer = new CrystalReportViewer();


            rp.SetDatabaseLogon("Final Project", "kel29");

            rp.SetParameterValue("id_paket", noKerusakan);

            rptViewer.ReportSource = rp;
            Report1.Child = rptViewer;
        }
	}
}