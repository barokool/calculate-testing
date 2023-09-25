using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void txtSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số, ký tự control (như phím Backspace), 
            // hoặc dấu trừ (nếu là ký tự đầu tiên) không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-' || txtSo1.SelectionStart != 0 || txtSo1.Text.Contains('-')))
            {
                e.Handled = true; // Ngăn việc nhập ký tự không hợp lệ
            }

            if (txtSo1.Text.Length >= 10 && e.KeyChar != '\b') // '\b' là ký tự Backspace
            {
                e.Handled = true; // Ngăn việc nhập quá 10 chữ số
            }

            // Kiểm tra giới hạn của số nguyên
            if (e.KeyChar == '-' && txtSo1.Text.Length == 0)
            {
                // Cho phép nhập dấu trừ nếu là ký tự đầu tiên
                return;
            }


            // get the current length of input 
            
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }
    }
}
