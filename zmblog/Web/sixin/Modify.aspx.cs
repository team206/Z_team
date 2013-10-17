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
namespace zmblog.Web.sixin
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int msgID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(msgID);
				}
			}
		}
			
	private void ShowInfo(int msgID)
	{
		zmblog.BLL.sixin bll=new zmblog.BLL.sixin();
		zmblog.Model.sixin model=bll.GetModel(msgID);
		this.lblmsgID.Text=model.msgID.ToString();
		this.txtmsgContent.Text=model.msgContent;
		this.txtsendID.Text=model.sendID.ToString();
		this.txtreceivrID.Text=model.receivrID.ToString();
		this.txtmsgState.Text=model.msgState.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtmsgContent.Text.Trim().Length==0)
			{
				strErr+="msgContent不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsendID.Text))
			{
				strErr+="sendID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtreceivrID.Text))
			{
				strErr+="receivrID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtmsgState.Text))
			{
				strErr+="msgState格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int msgID=int.Parse(this.lblmsgID.Text);
			string msgContent=this.txtmsgContent.Text;
			int sendID=int.Parse(this.txtsendID.Text);
			int receivrID=int.Parse(this.txtreceivrID.Text);
			int msgState=int.Parse(this.txtmsgState.Text);


			zmblog.Model.sixin model=new zmblog.Model.sixin();
			model.msgID=msgID;
			model.msgContent=msgContent;
			model.sendID=sendID;
			model.receivrID=receivrID;
			model.msgState=msgState;

			zmblog.BLL.sixin bll=new zmblog.BLL.sixin();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
