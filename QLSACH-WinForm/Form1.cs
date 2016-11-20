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
    public partial class Form1 : Form
    {
        QLSACHEntities db = new QLSACHEntities();
        public Form1()
        {
            
            InitializeComponent();
            dataGridView2.DataSource = SachDAL.LoadAll();
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            db.nxbs.Load();
            comboBox1.DataSource = db.nxbs.Local.ToList();
            comboBox1.ValueMember = "manxb";
            comboBox1.DisplayMember = "tennxb";
            dateTimePicker4.MinDate = dateTimePicker3.Value.AddDays(1);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.sachBindingSource.DataSource = SachDAL.LoadAll(db);
            int row = 0;
            foreach (var entity in SachDAL.LoadAll())
            {
                string description = entity.linhvuc1.tenlv;
                sachDataGridView.Rows[row].Cells[2].Value = description;
                row++;
            }
          
         }
       
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddorEdit f2 = new AddorEdit();
            f2.ShowDialog();
            OnLoad(null);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc bạn muốn xóa sách này ?","Xác nhận xóa",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in sachDataGridView.SelectedRows)
                {
                    SachDAL.DEL_Sach(row.Cells[0].Value.ToString());
                    sachDataGridView.Rows.Remove(row);
                }
            }

        }
        private void Edit_btn_Click(object sender, EventArgs e)
        {
            if (sachDataGridView.SelectedRows.Count > 1)
                MessageBox.Show("Không được chọn nhiều sách để sửa");
            else
            {
                AddorEdit f2 = new AddorEdit(sachDataGridView.CurrentRow.Cells[0].Value.ToString(), sachDataGridView.CurrentRow.Cells[1].Value.ToString(), sachDataGridView.CurrentRow.Cells[2].Value.ToString());
                f2.ShowDialog();
                OnLoad(null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (dateTimePicker2.Enabled == true)
                    dataGridView1.DataSource = SachDAL.Thongkekhoangthoigian(dataGridView2.CurrentRow.Cells[0].Value.ToString(), dateTimePicker1.Value, dateTimePicker2.Value);
                else
                    dataGridView1.DataSource = SachDAL.Thongketaithoidiem(dataGridView2.CurrentRow.Cells[0].Value.ToString(), dateTimePicker1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sachBindingSource.DataSource = SachDAL.Search_Sach(textBox1.Text,db);
            int row = 0;
            foreach (var entity in SachDAL.Search_Sach(textBox1.Text))
            {
                string description = entity.linhvuc1.tenlv;
                sachDataGridView.Rows[row].Cells[2].Value = description;
                row++;
            }
        }
        private void Active_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Enabled == false)
            {
                dateTimePicker2.Enabled = true;
                label9.Text = "Từ :";
            }
            else
            {
                dateTimePicker2.Enabled = false;
                label9.Text = "Tại :";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void XemNo_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = SachDAL.LoadNo();
        }
    }
}
