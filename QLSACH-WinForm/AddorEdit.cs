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

namespace QLSACH_WinForm
{
    public partial class AddorEdit : Form
    {
        QLSACHEntities db = new QLSACHEntities();
        public AddorEdit()
        {
            InitializeComponent();
        }
        public AddorEdit(string masach, string tensach, string malinhvuc)
        {
            InitializeComponent();
                textBox1.Text = masach.Trim();
            sach sach = db.saches.Find(masach.Trim());
            textBox3.Text = sach.tensach;
            comboBox1.SelectedValue = malinhvuc.Trim();
            ///comboBox1.SelectedText.Equals(malinhvuc);
            ///comboBox1.SelectedValue.Equals(malinhvuc);
            
        }

        private void AddorEdit_Load(object sender, EventArgs e)
        {
            db.linhvucs.Load();
            comboBox1.DataSource = db.linhvucs.Local.ToBindingList();
            comboBox1.DisplayMember = "tenlv";
            comboBox1.ValueMember = "malv";
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            SachDAL.ADD_Sach(textBox1.Text,textBox3.Text,comboBox1.SelectedValue.ToString());
            this.Close();
        }
    }
}
