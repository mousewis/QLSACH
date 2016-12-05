using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSACH_WinForm
{
    public partial class DebtUpdate : Form
    {
        string idphieu = null;
        public DebtUpdate(string id,string idbook,string name,int gia,int slg )
        {
            InitializeComponent();
            label2.Text = idbook;
            label4.Text = name;
            label6.Text = gia.ToString();
            for(int i = 0;i<slg+1;i++)
            comboBox1.Items.Add(i);
            idphieu = id;
        }

        private void DebtUpdate_Load(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            SachDAL.UpdateNo(idphieu,label2.Text, int.Parse(comboBox1.SelectedItem.ToString()));
            this.Close();
        }
    }
}
