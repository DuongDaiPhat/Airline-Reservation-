using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.UserControls;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.User
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }


        private async void MainForm_Load(object sender, EventArgs e)
        {
            EmployeeDashboard dashboard = new EmployeeDashboard
            {
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Clear();
            panelContent.Controls.Add(dashboard);
            await dashboard.LoadDashboardDataAsync();
        }

    }
}
