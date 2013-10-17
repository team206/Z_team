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
namespace zmblog.Web.skinInfo
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
		zmblog.BLL.skinInfo bll=new zmblog.BLL.skinInfo();
		zmblog.Model.skinInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtskinNme.Text=model.skinNme;
		this.txtskinID.Text=model.skinID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtskinNme.Text.Trim().Length==0)
			{
				strErr+="skinNme不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtskinID.Text))
			{
				strErr+="skinID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string skinNme=this.txtskinNme.Text;
			int skinID=int.Parse(this.txtskinID.Text);


			zmblog.Model.skinInfo model=new zmblog.Model.skinInfo();
			model.id=id;
			model.skinNme=skinNme;
			model.skinID=skinID;

			zmblog.BLL.skinInfo bll=new zmblog.BLL.skinInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
