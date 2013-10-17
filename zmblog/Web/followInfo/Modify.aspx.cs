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
namespace zmblog.Web.followInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		zmblog.BLL.followInfo bll=new zmblog.BLL.followInfo();
		zmblog.Model.followInfo model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtuserID.Text=model.userID.ToString();
		this.txtfansID.Text=model.fansID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserID.Text))
			{
				strErr+="userID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfansID.Text))
			{
				strErr+="fansID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			int userID=int.Parse(this.txtuserID.Text);
			int fansID=int.Parse(this.txtfansID.Text);


			zmblog.Model.followInfo model=new zmblog.Model.followInfo();
			model.ID=ID;
			model.userID=userID;
			model.fansID=fansID;

			zmblog.BLL.followInfo bll=new zmblog.BLL.followInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
