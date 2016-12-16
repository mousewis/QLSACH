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
        List<ctphieuxuat> phieuxuat = new List<ctphieuxuat>();
        public Form1()
        {
            InitializeComponent();
            dataGridView2.DataSource = SachDAL.LoadAll();
            AdjSachTab(dataGridView2);
            dataGridView2.Columns["linhvuc"].Visible = false;
            comboBox1.DataSource = SachDAL.LoadDL();
            comboBox1.ValueMember = "madl";
            comboBox1.DisplayMember = "tendl";
            comboBox6.DataSource = SachDAL.LoadNXB();
            comboBox6.ValueMember = "manxb";
            comboBox6.DisplayMember = "tennxb";
            dataGridView3.Columns.Add("TenSach", "Tên Sách");
            dataGridView3.Columns["TenSach"].Visible = false;
            dataGridView4.Columns.Add("TenSach", "Tên Sách");
            dataGridView4.Columns["TenSach"].Visible = false;
            dataGridView1.Columns.Add("LV", "Lĩnh Vực");
        }
       public void AdjSachTab(DataGridView data,List<sach> sach)
        {
            data.Columns["ctphieunhaps"].Visible = false;
            data.Columns["cttkdls"].Visible = false;
            data.Columns["ctphieuxuats"].Visible = false;
            data.Columns["linhvuc"].Visible = false;
            data.Columns["linhvuc1"].Visible = false;
            data.Columns["LV"].DisplayIndex = 2;
            int row = 0;
            foreach (sach item in sach)
            {
                string value =  SachDAL.TenSach(item.linhvuc);
                data.Rows[row++].Cells["LV"].Value = value;
            }
            for (int i = 0; i < data.ColumnCount; i++)
                data.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void AdjSachTab(DataGridView data)
        {
            data.Columns["ctphieunhaps"].Visible = false;
            data.Columns["cttkdls"].Visible = false;
            data.Columns["ctphieuxuats"].Visible = false;
            data.Columns["linhvuc"].Visible = false;
            data.Columns["linhvuc1"].Visible = false;
            for (int i = 0; i < data.ColumnCount; i++)
                data.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddorEdit f2 = new AddorEdit();
            f2.ShowDialog();
            tabControl1_Click(null, null);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count < 1)
                    MessageBox.Show("Xin chọn sách để xóa");
                else
                {
                    string sach = "";
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        sach += row.Cells["tensach"].Value.ToString()+", ";
                    }
                    DialogResult result = MessageBox.Show("Bạn có chắc bạn muốn những xóa sách này ?:\n"+sach.Substring(0,sach.Length-2), "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            SachDAL.DEL_Sach(row.Cells["masach"].Value.ToString());
                        }
                        tabControl1_Click(null, null);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sách :" + ex);
            }

        }
        private void Edit_btn_Click(object sender, EventArgs e)
        {
                if (dataGridView1.SelectedRows.Count > 1)
                    MessageBox.Show("Không được chọn nhiều sách để sửa");
                else
                {
                    AddorEdit f2 = new AddorEdit(dataGridView1.CurrentRow.Cells["masach"].Value.ToString(), dataGridView1.CurrentRow.Cells["tensach"].Value.ToString(), dataGridView1.CurrentRow.Cells["linhvuc"].Value.ToString());
                    f2.ShowDialog();
                tabControl1_Click(null, null);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label21.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            label23.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            label25.Text = SachDAL.TenSach(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            label28.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            label29.Text = SachDAL.Thongketaithoidiem(dataGridView2.CurrentRow.Cells[0].Value.ToString(), dateTimePicker1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<sach> sac = SachDAL.Search_Sach(textBox1.Text);
                if (sac.Count > 0)
                {
                    dataGridView1.DataSource = sac;
                    AdjSachTab(dataGridView1, sac);
                }
                else
                    MessageBox.Show("Không tìm thấy sách bạn đang tìm ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm sách: " + ex);
            }
        }
       
        public static void AdjustView(DataGridView data,List<ctphieuxuat> phieuxuat)
        {
            data.Columns["maso"].Visible = false;
            data.Columns["phieunhap"].Visible = false;
            data.Columns["maphieunhap"].Visible = false;
            data.Columns["phieuxuat"].Visible = false;
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
            phieuxuat = SachDAL.LoadNo(comboBox1.SelectedValue.ToString(),dateTimePicker2.Value.Year,dateTimePicker2.Value.Month );
            if (phieuxuat.Count>0)
            {
                    dataGridView3.DataSource = phieuxuat;
                    AdjustView(dataGridView3, phieuxuat);
                    for (int i = 0; i < dataGridView3.ColumnCount; i++)
                        dataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (phieuxuat.ElementAt(0).tienno != 0)
                {
                    label30.Text = "";
                    UpdateDebt.Enabled = true;
                }
                else
                {
                    label30.Text = "(Phiếu xuất trong tháng đã được thanh toán)";
                    UpdateDebt.Enabled = false;
                }
            }
            else
            {
                label30.Text = "(Tháng không có phiếu xuất)";
                UpdateDebt.Enabled = false;
            }
        }

        private void UpdateDebt_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in phieuxuat)
                    SachDAL.UpdateNo(item.maso, item.masach);
                MessageBox.Show("Đã Thanh toán thành công");
                dataGridView3.DataSource = null;
                dataGridView3.Columns["TenSach"].Visible = false;
                UpdateDebt.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xuất hiện lỗi khi thanh toán\n" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                List<ctphieunhap> phieunhap = new List<ctphieunhap>();
                phieunhap = SachDAL.LoadNoNXB(comboBox6.SelectedValue.ToString(), dateTimePicker3.Value.Year, dateTimePicker3.Value.Month);

                dataGridView4.DataSource = phieunhap;
                AdjustView2(dataGridView4, phieunhap);
                for (int i = 0; i < dataGridView4.ColumnCount; i++)
                    dataGridView4.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                label19.Text = SachDAL.TongNo(comboBox6.SelectedValue.ToString(), dateTimePicker3.Value) + " VNĐ";
                label16.Text = SachDAL.ConNo(comboBox6.SelectedValue.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xuất hiện lỗi sau: \n"+ex);
            }

        }
        public static void AdjustView2(DataGridView data, List<ctphieunhap> phieunhap)
        {
            data.Columns["maso"].Visible = false;
            data.Columns["sach"].Visible = false;
            data.Columns["phieunhap"].Visible = false;
            data.Columns["ton"].Visible = false;
            data.Columns["TenSach"].Visible = true;
            data.Columns["TenSach"].DisplayIndex = 2;
            int i = 0;
            foreach (var item in phieunhap)
            {
                string value = item.sach.tensach;
                data.Rows[i++].Cells["TenSach"].Value = value;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            label30.Text = "";
            UpdateDebt.Enabled = false;
            dataGridView3.DataSource = null;
            dataGridView3.Columns["TenSach"].Visible = false;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            label30.Text = "";
            UpdateDebt.Enabled = false;
            dataGridView3.DataSource = null;
            dataGridView3.Columns["TenSach"].Visible = false;
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            label16.Text = "";
            label19.Text = "0 VNĐ";
            dataGridView4.DataSource = null;
            dataGridView4.Columns["TenSach"].Visible = false;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            List<sach> sach = SachDAL.LoadAll();
            dataGridView1.DataSource = sach;
            AdjSachTab(dataGridView1, sach);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.DataSource = SachDAL.Sort_Sach(e.ColumnIndex);
            AdjSachTab(dataGridView1, SachDAL.Sort_Sach(e.ColumnIndex) );

        }
    }
}
