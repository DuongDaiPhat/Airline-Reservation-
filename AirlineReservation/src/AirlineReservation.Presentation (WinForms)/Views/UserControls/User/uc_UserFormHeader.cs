using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation.Presentation__WinForms_.Views.UserControls.User
{
    public partial class uc_UserFormHeader : UserControl
    {
        public uc_UserFormHeader()
        {
            InitializeComponent();
        }

        private void UserFormHeader_Load(object sender, EventArgs e)
        {
            HeaderCompanyLogo.Image = Properties.Resources.logo_blacktext;
            bookingPageBtn.Image = Properties.Resources.plane_icon;
            mySeatBtn.Image = Properties.Resources.plane_ticket_icon;
            discountPagebtn.Image = Properties.Resources.discount_icon;
            loginBtn.Image = Properties.Resources.user_icon;
        }
    }
}
