using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
namespace test
{
    public partial class import : System.Web.UI.Page
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
            }
        }
        private void BindGridView()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            string filePath = TextBox1.Text;

            DataTable dataTable;
            int result = ReadExcelToDataTable(filePath, out dataTable); // 讀取資料並檢查是否有空值

            if (result == 1) // 如果有空值
            {
                Response.Write("<script>alert('資料中有空值，請檢查 Excel 檔案。')</script>");
                TextBox1.Text = "";
                return; // 停止後續處理
            }

            SaveToDatabase(dataTable, connStr); // 保存資料到資料庫

            Response.Write("<script>alert('存入成功')</script>");
            TextBox1.Text = "";
            BindGridView();
        }


        static int ReadExcelToDataTable(string filePath, out DataTable dt)
        {
            dt = new DataTable();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook;
                if (Path.GetExtension(filePath) == ".xls")
                    workbook = new HSSFWorkbook(fs);  // 讀取舊版 Excel (.xls)
                else
                    workbook = new XSSFWorkbook(fs);  // 讀取新版 Excel (.xlsx)

                ISheet sheet = workbook.GetSheetAt(0); // 讀取第一個工作表
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;

                // 建立 DataTable 欄位
                for (int i = 0; i < cellCount; i++)
                    dt.Columns.Add(headerRow.GetCell(i).ToString());

                // 讀取數據行
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;

                    DataRow dataRow = dt.NewRow();
                    for (int j = 0; j < cellCount; j++)
                    {
                        ICell cell = row.GetCell(j);
                        string cellValue = cell?.ToString() ?? "";

                        // 如果某一列的值是空的，返回 1 來停止
                        if (string.IsNullOrEmpty(cellValue))
                        {
                            return 1; // 有空值，停止處理
                        }

                        dataRow[j] = cellValue;
                    }
                    dt.Rows.Add(dataRow);
                }
            }
            return 0; // 表示資料處理完成，沒有發現空值
        }

        static void SaveToDatabase(DataTable dt, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (DataRow row in dt.Rows)
                {
                    string query = "INSERT INTO account (uName,uAccount,uPassword) VALUES (@uName, @uAccount, @uPassword)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uName", row[0]);
                        cmd.Parameters.AddWithValue("@uAccount", row[1]);
                        cmd.Parameters.AddWithValue("@uPassword", row[2]);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {

            Response.Redirect("home.aspx");
        }
    }
}