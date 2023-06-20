using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;
using ZXing;
using System.Text.RegularExpressions;

namespace CrewConnect.ManagerClass
{
    public partial class adminSetting : Form
    {
        public static adminSetting adSet;
        public adminSetting()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
        private void adminSetting_Load(object sender, EventArgs e)
        {
            religionTB.TabStop = true;
            positionTB.TabStop = true;

            oldPass.TabStop = false;
            newPass.TabStop = false;
            newPass2.TabStop = false;

            positionTB.TabIndex = 1;
            religionTB.TabIndex = 2;

            oldPass.TabIndex = 3;
            newPass.TabIndex = 4;
            newPass2.TabIndex = 5;
            adSet = this;
            showData();
        }

        void showData()
        {
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                showComboBox(con, positionCB, "system", "position");
                showComboBox(con, religionCB, "religion", "religion");
            }
        }
        void showComboBox(SqlConnection con, Guna2ComboBox cb, string table, string column)
        {
            SqlCommand cmd = new SqlCommand($"SELECT {column} FROM {table}", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Store the data in a DataTable
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                DataRow positionRow = dataTable.NewRow();
                positionRow[column] = column;
                dataTable.Rows.InsertAt(positionRow, 0);

                // Bind the data to the ComboBox
                cb.DataSource = dataTable;
                cb.DisplayMember = column;
                cb.ValueMember = column;
                reader.Close();
            }
        }

        void removeData(string table, string column, Guna2ComboBox cb) 
        {
            messageDialogForm msg = new messageDialogForm()
            {
                title = "ARE YOU SURE?",
                message = $"YOU ARE ABOUT TO DELETE {table.ToUpper()}",
                isOkDialog = true
            };

            if (msg.ShowDialog() != DialogResult.OK)
                return;

            loading();
            string query = $"DELETE FROM {table} WHERE {column} = @SelectedText";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                // checking data
                string checkData = "";
                con.Open();
                if(cb == positionCB)
                {
                    checkData = $"SELECT COUNT(position) FROM job WHERE position = '{positionCB.Text}'";
                }
                else if(cb == religionCB)
                {
                    checkData = $"SELECT COUNT(religion) FROM personal WHERE religion = '{religionCB.Text}'";
                }

                if(!string.IsNullOrEmpty(checkData))
                {
                    using (SqlCommand checkingData = new SqlCommand(checkData, con))
                    {
                        string count = checkingData.ExecuteScalar().ToString();
                        SqlDataReader dr = checkingData.ExecuteReader();

                        if (dr.Read())
                        {
                            if(Convert.ToInt32(count.Trim()) > 0)
                            {
                                messageDialogForm msg2 = new messageDialogForm()
                                {
                                    title = "ITEM CAN'T BE DELETED",
                                    message = $"THE ITEM YOU SELECTED IS BEING USED BY {count} PEOPLES"
                                };
                                msg2.ShowDialog();
                                return;
                            }
                        }
                            dr.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SelectedText", cb.Text);

                    messageDialogForm msg2 = new messageDialogForm();
                    msg2.message = "You've Successfully Removed " + cb.Text;
                    msg2.ShowDialog();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void addReligionBtn_Click(object sender, EventArgs e)
        {
            loading();
            if (validationHelper.textBoxValidation_Alpha(religionTB, "religion", errorProvider1))
            {
                string query = "";

                query += $"DELETE FROM religion WHERE religion = 'Other indigenous beliefs'";
                query += $"INSERT INTO religion (religion) VALUES ('{religionTB.Text}');";
                query += $"INSERT INTO religion (religion) VALUES ('Other indigenous beliefs');";

                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                        messageDialogForm msg = new messageDialogForm();
                        msg.message = "You've Successfully Addedd " + religionTB.Text;
                        msg.ShowDialog();
                        religionTB.Text = "";
                        showData();
                    }
                }
            }
        }

        private void addPositionBtn_Click(object sender, EventArgs e)
        {
            loading();
            if (validationHelper.textBoxValidation_Alpha(positionTB, "position", errorProvider1))
            {
                string query = "";

                query += $"INSERT INTO system (position, control) VALUES (@position, @control);";

                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@position", positionTB.Text.ToUpper());
                        if(isAdmin.CheckState.ToString().ToUpper() == "UNCHECKED")
                            cmd.Parameters.AddWithValue("@control", "FALSE");
                        else
                            cmd.Parameters.AddWithValue("@control", "TRUE");
                        cmd.ExecuteNonQuery();

                        messageDialogForm msg = new messageDialogForm();
                        msg.message = "You've Successfully Addedd " + positionTB.Text;
                        msg.ShowDialog();
                        positionTB.Text = "";

                        showData();
                    }
                }
            }
        }

        private void removePositionBtn_Click(object sender, EventArgs e)
        {
            if (positionCB.Text.ToLower() == "position")
                return;
            removeData("system", "position", positionCB);
            showData();
        }

        private void removeReligionBtn_Click(object sender, EventArgs e)
        {
            if (religionCB.Text == "religion")
                return;

            if (religionCB.Text == "Other indigenous beliefs")
            {
                messageDialogForm error = new messageDialogForm()
                {
                    title = "ITEM CAN'T BE DELETED",
                    message = $"YOU ARE NOT ALLOWED TO DELETE THE ITEM YOU SELECTED"
                };
                error.ShowDialog();
                return;
            }

            removeData("religion", "religion", religionCB);
            showData();
        }

        void loading()
        {
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = this.Parent.PointToScreen(Point.Empty);

            int loadingFormX = listTableLocationOnForm.X + (this.Parent.Width - loadingForm.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (this.Parent.Height - loadingForm.Height) / 2;

            // Set the position of loadingForm
            loadingForm.Location = new Point(loadingFormX, loadingFormY);

            loadingForm.loadingTime = 1000;
            loadingForm.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            loading();

            if (oldPass.Text.ToUpper() == "ADMIN")
            {
                messageDialogForm msg2 = new messageDialogForm()
                {
                    title = "PERMISSION NOT GRANTED",
                    message = "YOU ARE NOT ALLOWED TO CHANGE ADMIN'S PASSWORD"
                };
                msg2.ShowDialog();
                return;
            }

            if (newPass.Text.Length < 5)
            {
                messageDialogForm msg2 = new messageDialogForm()
                {
                    title = "WEAK PASSWORD",
                    message = "MAKE SURE YOU HAVE ATLEAST 5 CHARACTERS"
                };
                msg2.ShowDialog();
                return;
            }

            

            string query = "SELECT password FROM Users WHERE password COLLATE Latin1_General_CS_AS = @password";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@password", securityHelper.HashPassword(oldPass.Text));
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string storedPassword = dr["password"].ToString();

                        if (storedPassword == oldPass.Text && newPass.Text == newPass2.Text)
                        {
                            dr.Close(); 

                            string updatePass = "UPDATE Users SET password = @newPass WHERE username = @username";
                            SqlCommand cmd2 = new SqlCommand(updatePass, con);
                            cmd2.Parameters.AddWithValue("@newPass", securityHelper.HashPassword(newPass.Text));
                            cmd2.Parameters.AddWithValue("@username", globalVariables.username);
                            cmd2.ExecuteNonQuery();

                            messageDialogForm msg = new messageDialogForm();
                            msg.message = "You've Successfully Changed Your Password";
                            msg.ShowDialog();

                            oldPass.Text = "";
                            newPass.Text = "";
                            newPass2.Text = "";
                        }
                        else
                        {
                            messageDialogForm msg = new messageDialogForm();
                            msg.title = "NEW PASSWORD MUST BE THE SAME";
                            msg.message = "PLEASE DOUBLE CHECK THE CAPITALIZATIONS";
                            msg.ShowDialog();
                        }
                    }
                    else
                    {
                        messageDialogForm msg = new messageDialogForm();
                        msg.title = "INCORECT CURRENT PASSWORD";
                        msg.message = "PLEASE DOUBLE CHECK THE CAPITALIZATIONS";
                        msg.ShowDialog();
                    }

                    dr.Close();
                }
            }
        }

        private void positionTB_Validating(object sender, CancelEventArgs e)
        {
            validationHelper.textBoxValidation_Alpha(positionTB, "position", errorProvider1);
        }

        private void religionTB_Validating(object sender, CancelEventArgs e)
        {
            validationHelper.textBoxValidation_Alpha(religionTB, "religion", errorProvider1);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            messageDialogForm msg = new messageDialogForm();
            msg.title = "ARE YOU SURE?";
            msg.message = "YOU ARE ABOUT TO RESET ALL ATTENDANCE";
            msg.isOkDialog = true;

            if (msg.ShowDialog() == DialogResult.OK)
            {
                try
                { 
                    using (SqlConnection connection = new SqlConnection(globalVariables.server))
                    {
                        connection.Open();

                        string dropTableQuery = "IF OBJECT_ID('attendance_prev', 'U') IS NOT NULL DROP TABLE attendance_prev";
                        using (SqlCommand dropTableCommand = new SqlCommand(dropTableQuery, connection))
                        {
                            dropTableCommand.ExecuteNonQuery();
                        }

                        string createTableQuery = "SELECT * INTO attendance_prev FROM attendance WHERE 1 = 0";
                        using (SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection))
                        {
                            createTableCommand.ExecuteNonQuery();
                        }

                        string enableIdentityInsertQuery = "SET IDENTITY_INSERT attendance_prev ON";
                        using (SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertQuery, connection))
                        {
                            enableIdentityInsertCommand.ExecuteNonQuery();
                        }

                        string copyDataQuery = "INSERT INTO attendance_prev (attId, Id, name, date, inTime, outTime) SELECT attId, Id, name, date, inTime, outTime FROM attendance";
                        using (SqlCommand copyDataCommand = new SqlCommand(copyDataQuery, connection))
                        {
                            copyDataCommand.ExecuteNonQuery();
                        }

                        string disableIdentityInsertQuery = "SET IDENTITY_INSERT attendance_prev OFF";
                        using (SqlCommand disableIdentityInsertCommand = new SqlCommand(disableIdentityInsertQuery, connection))
                        {
                            disableIdentityInsertCommand.ExecuteNonQuery();
                        }

                        string deleteQuery = "DELETE FROM attendance";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.ExecuteNonQuery();
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    msg = new messageDialogForm();
                    msg.isOkDialog = false;
                    msg.title = "AN ERROR HAS OCCURED";
                    msg.message = ex.Message;
                    msg.ShowDialog();
                }


            }

        }

        private void oldPass_IconRightClick(object sender, EventArgs e)
        {
            if (oldPass.PasswordChar.ToString() == "●")
            {
                oldPass.PasswordChar = '\0';
            }
            else
            {
                oldPass.PasswordChar = '●';
            }
        }

        private void newPass_IconRightClick(object sender, EventArgs e)
        {
            if (newPass.PasswordChar.ToString() == "●")
            {
                newPass.PasswordChar = '\0';
            }
            else
            {
                newPass.PasswordChar = '●';
            }
        }

        private void newPass2_IconRightClick(object sender, EventArgs e)
        {
            if (newPass2.PasswordChar.ToString() == "●")
            {
                newPass2.PasswordChar = '\0';
            }
            else
            {
                newPass2.PasswordChar = '●';
            }
        }


        private void systemBtn_Click(object sender, EventArgs e)
        {
            religionTB.TabStop = true;
            positionTB.TabStop = true;

            oldPass.TabStop = false;
            newPass.TabStop = false;
            newPass2.TabStop = false;

            titleSys.Visible = true;
            accountTitle.Visible = false;
            accountPanel.Size = new Size(50, 415);

            systemPanel.Size = new Size(686, 415);

            systemBtn.Enabled = false;
            accountBtn.Enabled = true;

            accountPanel.Location = new Point(760, 172);
            systemPanel.Location = new Point(68, 172);

        }

        private void systemPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            religionTB.TabStop = false;
            positionTB.TabStop = false;

            oldPass.TabStop = true;
            newPass.TabStop = true;
            newPass2.TabStop = true;

            titleSys.Visible = false;
            accountTitle.Visible = true;
            accountTitle.BringToFront();

            accountPanel.Size = new Size(682, 415);
            systemPanel.Size = new Size(50, 415);

            accountBtn.Enabled = false;
            systemBtn.Enabled = true;

            accountPanel.Location = new Point(128, 172);
            systemPanel.Location = new Point(68, 172);
        }

        private void religionTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void positionTB_TextChanged(object sender, EventArgs e)
        {

        }

        public void systemClick()
        {
            systemBtn.PerformClick();
        }

        public void accountClick()
        {
            accountBtn.PerformClick();
        }
        private void textboxClick(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.Space)
            {
                this.Parent.Focus();
            }
        }

        public bool isFocus()
        {
            if(newPass.Focused || newPass2.Focused || oldPass.Focused
                || positionTB.Focused || religionTB.Focused)
            {
                return true;
            }
            return false;
        }
        void tbOnclick(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                    this.Parent.Focus();
            }
        }
    }
}
