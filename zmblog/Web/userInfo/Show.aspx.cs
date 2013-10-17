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
namespace zmblog.Web.userInfo
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
					int userID=(Convert.ToInt32(strid));
					ShowInfo(userID);
				}
			}
		}
		
	private void ShowInfo(int userID)
	{
		zmblog.BLL.userInfo bll=new zmblog.BLL.userInfo();
		zmblog.Model.userInfo model=bll.GetModel(userID);
		this.lbluserID.Text=model.userID.ToString();
		this.lbluserName.Text=model.userName;
		this.lbluserPwd.Text=model.userPwd;
		this.lbluserEmail.Text=model.userEmail;
		this.lblphone.Text=model.phone;
		this.lblbirthday.Text=model.birthday.ToString();
		this.lblsex.Text=model.sex?"是":"否";
		this.lblposition.Text=model.position;

	}


    }
}
