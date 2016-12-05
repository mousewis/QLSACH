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
            AdjSachTab(dataGridView2);
            dataGridView2.Columns["linhvuc"].Visible = false;
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            db.dailies.Load();
            comboBox1.DataSource = db.dailies.Local.ToList();
            comboBox1.ValueMember = "madl";
            comboBox1.DisplayMember = "tendl";
            dataGridView3.Columns.Add("TenSach", "Tên Sách");
            dataGridView3.Columns["TenSach"].Visible = false;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            sachDataGridView.DataSource = SachDAL.LoadAll(db);
            int row = 0;
            foreach (sach entity in SachDAL.LoadAll())
            {
                string description = SachDAL.TenSach(entity.linhvuc);
                sachDataGridView.Rows[row].Cells[2].Value = description;
                row++;
            }
            AdjSachTab(sachDataGridView);
       }
       public void AdjSachTab(DataGridView data)
        {
            data.Columns["ctphieunhaps"].Visible = false;
            data.Columns["cttkdls"].Visible = false;
            data.Columns["ctphieuxuats"].Visible = false;
            data.Columns["linhvuc1"].Visible = false;
            for (int i = 0; i < data.ColumnCount; i++)
                data.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                AdjSachTab(sachDataGridView);
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
            sachDataGridView.DataSource = SachDAL.Search_Sach(textBox1.Text,db);
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
        public static void AdjustView(DataGridView data,List<ctphieuxuat> phieuxuat)
        {
            data.Columns["maso"].Visible = false;
            data.Columns["phieunhap"].Visible = false;
            data.Columns["sach"].Visible = false;
            data.Columns["TenSach"].Visible = true;
            data.Columns["TenSach"].DisplayIndex = 2;
            int i = 0;
            foreach (var item in phieuxuat)
            {
                string value = item.sach.tensach;
                data.Rows[i++].Cells["TenSach"].Value = value;
            }
        }
        private void XemNo_Click(object sender, EventArgs e)
        {
            List<ctphieuxuat> phieuxuat = new List<ctphieuxuat>();
            phieuxuat = SachDAL.LoadNo(comboBox1.SelectedValue.ToString(), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox3.SelectedItem.ToString()));
            dataGridView3.DataSource = phieuxuat;
            AdjustView(dataGridView3, phieuxuat);
            for (int i = 0; i < dataGridView3.ColumnCount; i++)
                dataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void UpdateDebt_Click(object sender, EventArgs e)
        {
            DebtUpdate debt = new DebtUpdate(dataGridView3.CurrentRow.Cells["maso"].Value.ToString(),dataGridView3.CurrentRow.Cells["masach"].Value.ToString(), dataGridView3.CurrentRow.Cells["TenSach"].Value.ToString(), int.Parse(dataGridView3.CurrentRow.Cells["gia"].Value.ToString()),int.Parse(dataGridView3.CurrentRow.Cells["soluong"].Value.ToString()));
            debt.ShowDialog();
            XemNo_Click(null, null);
        }
    }
}
