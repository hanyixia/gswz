﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb.Admin
{
    public partial class com_index : System.Web.UI.Page
    {
        public string userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                userName = Session["name"].ToString();
            }
        }
    }
}