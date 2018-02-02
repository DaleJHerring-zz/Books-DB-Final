using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BooksFinal
{
    public partial class BooksForm : Form
    {
        //variables for db connection and class disp
        private SqlConnection dbConn;
        private SqlCommand dbCmd;
        private SqlDataReader dbReader;
        private BookCourse aCourse;
        private string sConnection;
        private string sql;

        public BooksForm()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            //construct object of sqlconnection class
            try
            {
                sConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Books.mdf;Integrated Security=True";

                dbConn = new SqlConnection(sConnection);
                dbConn.Open();

                sql = "SELECT CoursseNo, CourseTbl.ISBN, Title, Publisher FROM BookTbl JOIN CourseTbl ON BookTbl.ISBN = CourseTbl.ISBN;";

                dbCmd = new SqlCommand();
                dbCmd.CommandText = sql;
                dbCmd.Connection = dbConn;

                dbReader = dbCmd.ExecuteReader();

                //use sql data to instantiate object

                while (dbReader.Read())
                {
                    aCourse = new BookCourse(dbReader["CoursseNo"].ToString(), dbReader["ISBN"].ToString(), dbReader["Title"].ToString(), dbReader["Publisher"].ToString());

                    this.BooksBox.Items.Add(aCourse);
                }

                dbReader.Close();
                dbConn.Close();
            }
            catch(SqlException sEx)
            {
                MessageBox.Show(sEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }//end btn click

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }//end btn click

    }//end class
}//end namespace
