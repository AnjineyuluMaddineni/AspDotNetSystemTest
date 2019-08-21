using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspDotNetSystemTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(connString);
            sqlconn.Open();
            string employeeName = txtEmployeeName.Text.ToString();
            string dob = txtDOB.Text.ToString();
            string department = txtDepartment.Text.ToString();
            string reportingmanager = txtReportingManager.Text.ToString();
            string insertQuery = "insert into EmployeeTest (employeename,dob,department,reportingManager) values('" + employeeName + "','" + dob + "','" + department + "','" + reportingmanager + "')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconn);
            insertCommand.ExecuteNonQuery();
            insertCommand.Dispose();
            sqlconn.Close();
            lblInsertMessage.Text = "Inserted Successfully";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int firstNum = 0;
            int secondNum = 0;
            if (Int32.TryParse(txtFirstNum.Text, out firstNum) && Int32.TryParse(txtsecondNum.Text, out secondNum))
            {
                txtTotal.Text = (firstNum + secondNum).ToString();
                Label6.Text = "Verification Succesfully";
            }
            else
            {
                Label6.Text = "Verification Failed,Try Again";
            }
        }
    }
}