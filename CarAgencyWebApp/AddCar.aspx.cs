using System;
using System.Data.SqlClient;
using System.Configuration;

namespace CarAgencyWebApp
{
    public partial class AddCar : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["CarAgencyDb"].ConnectionString;

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtCompany.Text) ||
                string.IsNullOrWhiteSpace(txtModel.Text) ||
                string.IsNullOrWhiteSpace(txtSeats.Text) ||
                string.IsNullOrWhiteSpace(txtPlate.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                lblMessage.Text = "يرجى تعبئة جميع الحقول المطلوبة.";
                return;
            }

            if (!int.TryParse(txtSeats.Text, out int seats))
            {
                lblMessage.Text = "عدد المقاعد يجب أن يكون رقمًا صحيحًا.";
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                lblMessage.Text = "السعر يجب أن يكون رقمًا عشريًا.";
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Cars (Company, Model, Seats, PlateNumber, Price, Color)
                                     VALUES (@Company, @Model, @Seats, @PlateNumber, @Price, @Color)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Company", txtCompany.Text);
                    cmd.Parameters.AddWithValue("@Model", txtModel.Text);
                    cmd.Parameters.AddWithValue("@Seats", seats);
                    cmd.Parameters.AddWithValue("@PlateNumber", txtPlate.Text);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Color", ddlColor.SelectedValue);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Default.aspx");
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "✅ تم إضافة السيارة بنجاح!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ: " + ex.Message;
            }
        }
    }
}