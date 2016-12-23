using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace QLSACH_WinForm
{
    public partial class AddorEdit : Form
    {
        QLSACHEntities db = new QLSACHEntities();
        private static bool IsNew = true;
        public AddorEdit()
        {
            InitializeComponent();
            IsNew = true;
        }
        public AddorEdit(string masach, string tensach, string malinhvuc)
        {
            InitializeComponent();
            IsNew = false;
            textBox1.Text = masach.Trim();
            sach sach = db.saches.Find(masach.Trim());
            textBox3.Text = sach.tensach;
            comboBox1.SelectedValue = sach.linhvuc1.malv;
            textBox1.ReadOnly = true;
        }

        private void AddorEdit_Load(object sender, EventArgs e)
        {
            db.linhvucs.Load();
            comboBox1.DataSource = db.linhvucs.Local.ToBindingList();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox3.Text))
                {
                    if (IsNew == true)
                    {
                        if (SachDAL.SearchID(textBox1.Text).ToString().Length > 0)
                            MessageBox.Show("Mã sách tồn tại !!!");
                        else
                        {
                            SachDAL.ADD_Sach(textBox1.Text, textBox3.Text, comboBox1.SelectedValue.ToString());
                            this.Close();
                            MessageBox.Show("Lưu thành công");
                        }
                    }
                    else
                    {
                        SachDAL.Edit_Sach(textBox1.Text, textBox3.Text, comboBox1.SelectedValue.ToString());
                        this.Close();
                        MessageBox.Show("Lưu thành công");
                    }
                }
                else
                {
                    string s = "";
                    if (String.IsNullOrEmpty(textBox1.Text))
                        s += " Mã sách,";
                    if (String.IsNullOrEmpty(textBox3.Text))
                        s += " Tên sách,";
                    MessageBox.Show("Xin nhập " + s.Substring(0,s.Length-1));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi lưu sách: " + ex);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
