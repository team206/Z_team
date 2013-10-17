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
namespace zmblog.Web.shoucangInfo
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
		zmblog.BLL.shoucangInfo bll=new zmblog.BLL.shoucangInfo();
		zmblog.Model.shoucangInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtfabiaoID.Text=model.fabiaoID.ToString();
		this.txtshoucangID.Text=model.shoucangID.ToString();
		this.txtxinxianshiID.Text=model.xinxianshiID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtfabiaoID.Text))
			{
				strErr+="fabiaoID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtshoucangID.Text))
			{
				strErr+="shoucangID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtxinxianshiID.Text))
			{
				strErr+="xinxianshiID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int fabiaoID=int.Parse(this.txtfabiaoID.Text);
			int shoucangID=int.Parse(this.txtshoucangID.Text);
			int xinxianshiID=int.Parse(this.txtxinxianshiID.Text);


			zmblog.Model.shoucangInfo model=new zmblog.Model.shoucangInfo();
			model.id=id;
			model.fabiaoID=fabiaoID;
			model.shoucangID=shoucangID;
			model.xinxianshiID=xinxianshiID;

			zmblog.BLL.shoucangInfo bll=new zmblog.BLL.shoucangInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
