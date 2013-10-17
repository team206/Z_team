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
namespace zmblog.Web.xinxianshi
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
					int xinxianshiID=(Convert.ToInt32(strid));
					ShowInfo(xinxianshiID);
				}
			}
		}
		
	private void ShowInfo(int xinxianshiID)
	{
		zmblog.BLL.xinxianshi bll=new zmblog.BLL.xinxianshi();
		zmblog.Model.xinxianshi model=bll.GetModel(xinxianshiID);
		this.lblxinxianshiID.Text=model.xinxianshiID.ToString();
		this.lbluserID.Text=model.userID.ToString();
		this.lblpostTime.Text=model.postTime.ToString();
		this.lblcommentTitle.Text=model.commentTitle;
		this.lblcommentMsg.Text=model.commentMsg;
		this.lblimgUrl.Text=model.imgUrl;
		this.lblfaceID.Text=model.faceID.ToString();
		this.lblxinqingID.Text=model.xinqingID.ToString();

	}


    }
}
