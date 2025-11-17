using AirlineReservation.Presentation__WinForms_.Views.UserControls.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation.Presentation__WinForms_.Views.Forms.User
{
    public partial class MainUserForm : Form
    {
        private uc_UserFormHeader _header;
        private uc_SearchingForm _searchingform;
        public MainUserForm()
        {
            InitializeComponent();
            InitializeShell();
        }
        private void InitializeShell()
        {
            this.SuspendLayout();
            userFormPanelHeader.SuspendLayout();
            userFormPanelContent.SuspendLayout();

            _header = new uc_UserFormHeader { Dock = DockStyle.Fill};
            userFormPanelHeader.Controls.Clear();
            userFormPanelHeader.Controls.Add(_header);

            _searchingform = new uc_SearchingForm { Dock = DockStyle.Fill };
            userFormPanelContent.Controls.Clear();
            userFormPanelContent.Controls.Add(_searchingform);
        }
    }
}
