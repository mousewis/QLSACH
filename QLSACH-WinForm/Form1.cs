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
        QLSACHEntities db;
        public static string[] entity;

        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            db = new QLSACHEntities();
            db.saches.Load();
            this.sachBindingSource.DataSource = db.saches.Local.ToBindingList();
            int row = 0;
            foreach(var entity in db.saches.Local.ToBindingList())
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
                //foreach (var entity in db.saches.Local.ToBindingList())
                //{
                //    string description = entity.linhvuc1.tenlv;
                //    sachDataGridView.Rows[row].Cells[2].Value = description;
                //    row++;
                //}
                AddorEdit f2 = new AddorEdit(sachDataGridView.CurrentRow.Cells[0].Value.ToString(), sachDataGridView.CurrentRow.Cells[1].Value.ToString(), sachDataGridView.CurrentRow.Cells[2].Value.ToString());
                f2.ShowDialog();
                OnLoad(null);
            }
        }
    }
}
