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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace zmblog.Web.userInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int userID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(userID);
				}
			}
		}
			
	private void ShowInfo(int userID)
	{
		zmblog.BLL.userInfo bll=new zmblog.BLL.userInfo();
		zmblog.Model.userInfo model=bll.GetModel(userID);
		this.lbluserID.Text=model.userID.ToString();
		this.txtuserName.Text=model.userName;
		this.txtuserPwd.Text=model.userPwd;
		this.txtuserEmail.Text=model.userEmail;
		this.txtphone.Text=model.phone;
		this.txtbirthday.Text=model.birthday.ToString();
		this.chksex.Checked=model.sex;
		this.txtposition.Text=model.position;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtuserName.Text.Trim().Length==0)
			{
				strErr+="userName不能为空！\\n";	
			}
			if(this.txtuserPwd.Text.Trim().Length==0)
			{
				strErr+="userPwd不能为空！\\n";	
			}
			if(this.txtuserEmail.Text.Trim().Length==0)
			{
				strErr+="userEmail不能为空！\\n";	
			}
			if(this.txtphone.Text.Trim().Length==0)
			{
				strErr+="phone不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtbirthday.Text))
			{
				strErr+="birthday格式错误！\\n";	
			}
			if(this.txtposition.Text.Trim().Length==0)
			{
				strErr+="position不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userID=int.Parse(this.lbluserID.Text);
			string userName=this.txtuserName.Text;
			string userPwd=this.txtuserPwd.Text;
			string userEmail=this.txtuserEmail.Text;
			string phone=this.txtphone.Text;
			DateTime birthday=DateTime.Parse(this.txtbirthday.Text);
			bool sex=this.chksex.Checked;
			string position=this.txtposition.Text;


			zmblog.Model.userInfo model=new zmblog.Model.userInfo();
			model.userID=userID;
			model.userName=userName;
			model.userPwd=userPwd;
			model.userEmail=userEmail;
			model.phone=phone;
			model.birthday=birthday;
			model.sex=sex;
			model.position=position;

			zmblog.BLL.userInfo bll=new zmblog.BLL.userInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
