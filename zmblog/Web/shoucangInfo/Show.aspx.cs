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
namespace zmblog.Web.shoucangInfo
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
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		zmblog.BLL.shoucangInfo bll=new zmblog.BLL.shoucangInfo();
		zmblog.Model.shoucangInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblfabiaoID.Text=model.fabiaoID.ToString();
		this.lblshoucangID.Text=model.shoucangID.ToString();
		this.lblxinxianshiID.Text=model.xinxianshiID.ToString();

	}


    }
}
