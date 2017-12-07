using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle.Text = Page.Title;
            pageTitle.Style.Add("font-size", "120px");
            pageTitle.Style.Add("font-family", "'Vivaldi', cursive");
            pageTitle.Style.Add("text-align", "center");
            pageTitle.Style.Add("color", "orangered");
        }
    }
}