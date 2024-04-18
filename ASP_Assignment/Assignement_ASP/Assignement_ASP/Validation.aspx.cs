using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Assignement_ASP
{
    public partial class Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ValidateName(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string name = txtName.Text;
            string familyName = txtFamilyName.Text;


            args.IsValid = !name.Equals(familyName, StringComparison.OrdinalIgnoreCase);
        }

        protected void ValidateAddress(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string address = txtAddress.Text;


            args.IsValid = address.Length >= 2;
        }

        protected void ValidateCity(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string city = txtCity.Text;


            args.IsValid = city.Length >= 2;
        }

        protected void ValidateZipCode(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string zipCode = txtZipCode.Text;


            args.IsValid = Regex.IsMatch(zipCode, @"^\d{5}$");
        }

        protected void ValidatePhone(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string phone = txtPhone.Text;


            args.IsValid = Regex.IsMatch(phone, @"^91-\d{10}$");
        }

        protected void ValidateEmail(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string email = txtEmail.Text;


            args.IsValid = Regex.IsMatch(email, @"/^[a-zA-Z0-9.! #$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/");
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                Response.Redirect("Successful.aspx");
            }
            else
            {
                // Validation failed, stay on the current page
            }
        }
    }
}