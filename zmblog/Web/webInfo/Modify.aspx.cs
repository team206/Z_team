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
namespace zmblog.Web.webInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		zmblog.BLL.webInfo bll=new zmblog.BLL.webInfo();
		zmblog.Model.webInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtlogoURL.Text=model.logoURL;
		this.txtwebName.Text=model.webName;
		this.txtlastPuvTime.Text=model.lastPuvTime.ToString();
		this.txtauthotr.Text=model.authotr;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtlogoURL.Text.Trim().Length==0)
			{
				strErr+="logoURL不能为空！\\n";	
			}
			if(this.txtwebName.Text.Trim().Length==0)
			{
				strErr+="webName不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlastPuvTime.Text))
			{
				strErr+="lastPuvTime格式错误！\\n";	
			}
			if(this.txtauthotr.Text.Trim().Length==0)
			{
				strErr+="authotr不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string logoURL=this.txtlogoURL.Text;
			string webName=this.txtwebName.Text;
			DateTime lastPuvTime=DateTime.Parse(this.txtlastPuvTime.Text);
			string authotr=this.txtauthotr.Text;


			zmblog.Model.webInfo model=new zmblog.Model.webInfo();
			model.id=id;
			model.logoURL=logoURL;
			model.webName=webName;
			model.lastPuvTime=lastPuvTime;
			model.authotr=authotr;

			zmblog.BLL.webInfo bll=new zmblog.BLL.webInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
