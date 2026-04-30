using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace CarAgencyWebApp
{
    public partial class _Default : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["CarAgencyDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanies();
                ShowCars();

                string role = Session["Role"] as string;

                if (role == "Customer")
                {
                    // إخفاء زر إضافة سيارة من القائمة
                    var addCarLink = (System.Web.UI.HtmlControls.HtmlAnchor)Master.FindControl("lnkAddCar");
                    if (addCarLink != null) addCarLink.Visible = false;
                }
                else if (role == "Admin")
                {
                    // إخفاء عمود شراء من GridView
                    gvCars.Columns[7].Visible = false; // العمود الأخير هو زر شراء
                }
            }
        }

        private void LoadCompanies()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Company FROM Cars ORDER BY Company", con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ddlCompany.DataSource = reader;
                    ddlCompany.DataTextField = "Company";
                    ddlCompany.DataValueField = "Company";
                    ddlCompany.DataBind();
                }
            }
        }

        private void ShowCars(string query = "SELECT * FROM Cars", SqlParameter param = null)
        {
            gvStats.Visible = false;
            gvCars.Visible = true;

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (param != null) cmd.Parameters.Add(param);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvCars.DataSource = dt;
                    gvCars.DataBind();
                }
            }
        }

        private void ShowStats(string query)
        {
            gvCars.Visible = false;
            gvStats.Visible = true;

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvStats.DataSource = dt;
                gvStats.DataBind();
            }
        }

        protected void btnFilterByCompany_Click(object sender, EventArgs e)
        {
            string company = ddlCompany.SelectedValue;
            ShowCars("SELECT * FROM Cars WHERE Company = @Company", new SqlParameter("@Company", company));
        }

        protected void btnAllCars_Click(object sender, EventArgs e)
        {
            ShowCars();
        }

        protected void btnPopularType_Click(object sender, EventArgs e)
        {
            ShowStats(@"SELECT TOP 1 Model AS الموديل, COUNT(*) AS العدد 
                FROM Cars 
                GROUP BY Model 
                ORDER BY العدد DESC");
        }

        protected void btnPopularColor_Click(object sender, EventArgs e)
        {
            ShowStats(@"SELECT TOP 1 Color AS اللون, COUNT(*) AS العدد FROM Cars GROUP BY Color ORDER BY العدد DESC");
        }

        protected void gvCars_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BuyCar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int carId = Convert.ToInt32(gvCars.DataKeys[index].Value);

                DeleteCar(carId);
                ShowCars();
                lblStatus.Text = "✅ تم شراء السيارة بنجاح!";
            }
        }

        private void DeleteCar(int carId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Cars WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", carId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}