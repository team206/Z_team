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
namespace zmblog.Web.administrator
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtadminName.Text.Trim().Length==0)
			{
				strErr+="adminName不能为空！\\n";	
			}
			if(this.txtadminPwd.Text.Trim().Length==0)
			{
				strErr+="adminPwd不能为空！\\n";	
			}
			if(this.txtadminEmail.Text.Trim().Length==0)
			{
				strErr+="adminEmail不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtadminLevel.Text))
			{
				strErr+="adminLevel格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string adminName=this.txtadminName.Text;
			string adminPwd=this.txtadminPwd.Text;
			string adminEmail=this.txtadminEmail.Text;
			int adminLevel=int.Parse(this.txtadminLevel.Text);

			zmblog.Model.administrator model=new zmblog.Model.administrator();
			model.adminName=adminName;
			model.adminPwd=adminPwd;
			model.adminEmail=adminEmail;
			model.adminLevel=adminLevel;

			zmblog.BLL.administrator bll=new zmblog.BLL.administrator();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
