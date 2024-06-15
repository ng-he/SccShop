using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using DTO;
using System.Web.Script.Services;

namespace GUI.Web_Pages.user
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txt_Fullname.Value = "";
                txt_PhoneNumber.Value = "";
                txt_Days.Value = ""; txt_Months.Value = ""; txt_Years.Value = "";
                txt_Username.Value = "";
                txt_Email.Value = "";
                txt_Password.Value = "";
            }

            ckbx_GenderMale.Checked = true;
        }

        private string CheckedGender()
        {
            if (ckbx_GenderMale.Checked)
            {
                return "Nam";
            }

            if (ckbx_GenderFemale.Checked)
            {
                return "Nữ";
            }

            return "";
        }

        protected void btn_Submit_ServerClick(object sender, EventArgs e)
        {
            bool SignUpValid = true;

            if (BUS.AccountChecker.UsernameExist(txt_Username.Value)[0] != "")
            {
                small_UsernameAlert.InnerHtml = "Tên tài khoản đã có tài khoản sử dụng";
                SignUpValid = false;
                hidden_SignUpSuccessMessage.Value = "false";
            }

            if(BUS.AccountChecker.EmailExist(txt_Email.Value))
            {
                small_EmailAlert.InnerHtml = "Email đã có tài khoản sử dụng";
                SignUpValid = false;
                hidden_SignUpSuccessMessage.Value = "false";
            }

            if(BUS.InfoChecker.PhoneNumberExist(txt_PhoneNumber.Value)) {
                small_PhoneNumberAlert.InnerHtml = "Số điện thoại đã có tài khoản sử dụng";
                SignUpValid = false;
                hidden_SignUpSuccessMessage.Value = "false";
            }

            if(SignUpValid)
            {
                string[] _3LetterMonths = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                string AccountId = BUS.AccountIdGenerator.NewUserID();

                Account Acc = new Account(
                    AccountId,
                    txt_Username.Value,
                    txt_Email.Value,
                    txt_Password.Value,
                    "user"
                    );

                PersonalInfo Info = new PersonalInfo (
                    AccountId,
                    txt_Fullname.Value,
                    _3LetterMonths[int.Parse(txt_Months.Value) - 1] + " " + txt_Days.Value + ", " + txt_Years.Value,
                    txt_PhoneNumber.Value,
                    CheckedGender()
                    );

                BUS.DataAdder.AddNew(Acc);
                BUS.DataAdder.AddNew(Info);
                hidden_SignUpSuccessMessage.Value = "true";
            }         
        }
    }
}