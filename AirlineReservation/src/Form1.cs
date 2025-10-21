using AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation.src
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HeaderControl header = new HeaderControl();
            header.Dock = DockStyle.Top;
            this.Controls.Add(header);
        }
    }
}
