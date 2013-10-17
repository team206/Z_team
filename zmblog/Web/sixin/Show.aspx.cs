using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace zmblog.Web.sixin
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int msgID=(Convert.ToInt32(strid));
					ShowInfo(msgID);
				}
			}
		}
		
	private void ShowInfo(int msgID)
	{
		zmblog.BLL.sixin bll=new zmblog.BLL.sixin();
		zmblog.Model.sixin model=bll.GetModel(msgID);
		this.lblmsgID.Text=model.msgID.ToString();
		this.lblmsgContent.Text=model.msgContent;
		this.lblsendID.Text=model.sendID.ToString();
		this.lblreceivrID.Text=model.receivrID.ToString();
		this.lblmsgState.Text=model.msgState.ToString();

	}


    }
}
