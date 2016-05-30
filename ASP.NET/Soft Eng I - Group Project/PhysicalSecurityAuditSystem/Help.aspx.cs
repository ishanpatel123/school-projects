using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicalSecurityAuditSystem
{
    public partial class Help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When the user selects the Submit ticket button, we will show a confirmation message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SubmitBTN_Click(object sender, EventArgs e)
        {
            ConfirmationLBL.Text = "Thank you for submitting a ticket. We'll be in contact shortly.";
            ConfirmationLBL.Visible = true;
            FullNameTxt.Text = "";
            EmailTxt.Text = "";
            ProblemTxt.Text = "";
        }
    }
}