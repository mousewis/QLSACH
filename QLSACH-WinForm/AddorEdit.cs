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
        public AddorEdit(string masach, string tensach, string linhvuc)
        {
            
            InitializeComponent();
                textBox1.Text = masach;
                textBox3.Text = tensach;
            var lv = db.linhvucs.Where(c=>c.tenlv.Equals(linhvuc));
            foreach (var a in lv)
                comboBox1.SelectedValue = a.malv;
        }

        private void AddorEdit_Load(object sender, EventArgs e)
        {
            db.linhvucs.Load();
            comboBox1.DataSource = db.linhvucs.Local.ToBindingList();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            //SachDAL.ADD_Sach(textBox1.Text,textBox3.Text,comboBox1.SelectedValue.ToString());
            //this.Close();
        }
    }
}
