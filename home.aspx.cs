using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using NPOI.XSSF.UserModel;

namespace test
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null && Session["clogin"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                BindGridView();
                if (Session["clogin"] != null)
                {
                    Import.Visible = true;
                }
                else
                {
                    Import.Visible= false;
                }
            }
           
        }
        private void BindGridView()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            if (Session["login"] != null)
            {
                string query = "SELECT * FROM account WHERE uAccount = @uAccount";


                string login_Account = Session["login"].ToString();

                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uAccount", login_Account);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
            else if (Session["clogin"] != null)
            {
                SqlConnection conn = new SqlConnection(connStr);
                string query = "SELECT * FROM account";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
        protected void sign_up_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["login"] = null;
            Session["clogin"] = null;
            Response.Redirect("login.aspx");
        }

        protected void Export_Click(object sender, EventArgs e)
        { // 建立 Excel 物件
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("帳號列表");

            // 取得 GridView 的資料
            DataTable dt = new DataTable();
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text;
                }
                dt.Rows.Add(dr);
            }

            // 寫入標題
            IRow headerRow = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                headerRow.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            }

            // 寫入內容
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            // 將 Excel 寫入 MemoryStream
            using (MemoryStream exportData = new MemoryStream())
            {
                workbook.Write(exportData);
                workbook.Close();

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=AccountList.xlsx");
                Response.BinaryWrite(exportData.ToArray());
                Response.End();
            }
        }

        protected void Import_Click(object sender, EventArgs e)
        {
            Response.Redirect("import.aspx");
        }
    }
}