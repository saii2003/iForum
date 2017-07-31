using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iFourms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace iFourms
{
    public partial class validcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MemberBL bl = new MemberBL();
            bl.getValidCodeImage();
        }

        
    }
}