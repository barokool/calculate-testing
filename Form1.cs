﻿using System;
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
            radCong.Checked = true;            
        }

        private void txtSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-' || txtSo1.SelectionStart != 0 || txtSo1.Text.Contains('-')))
            {
                e.Handled = true; 
            }

            if (txtSo1.Text.Length >= 10 && e.KeyChar != '\b') 
            {
                e.Handled = true; 
            }

            if (e.KeyChar == '-' && txtSo1.Text.Length == 0)
            {
                return;
            }


            
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

            if (string.IsNullOrEmpty(txtSo1.Text))
            {
                MessageBox.Show("Vui lòng nhập số thứ nhất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo1.Focus();     // Focus vào ô "Số thứ nhất"
                txtSo1.SelectAll(); // Chọn toàn bộ nội dung trong ô "Số thứ nhất"
                return; // Dừng thực hiện phép tính nếu có lỗi
            }

            // Kiểm tra xem ô "Số thứ hai" có dữ liệu hay không
            if (string.IsNullOrEmpty(txtSo2.Text))
            {
                MessageBox.Show("Vui lòng nhập số thứ hai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo2.Focus();     // Focus vào ô "Số thứ hai"
                txtSo2.SelectAll(); // Chọn toàn bộ nội dung trong ô "Số thứ hai"
                return; // Dừng thực hiện phép tính nếu có lỗi
            }

            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            Boolean check = true;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked)
            {
                if (so2 == 0)
                {
                    DialogResult dr;
                    dr = MessageBox.Show("Số thứ hai phải khác 0",
                                         "Thông báo", MessageBoxButtons.OK);
                    check = false;
                    txtSo2.Focus();
                } else kq = so1/so2;
            };
            //Hiển thị kết quả lên trên ô kết quả
            if (check == false)
            {
                txtKq.Text = "";
            } else txtKq.Text = kq.ToString();
        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            txtSo1.SelectAll(); // Chọn toàn bộ văn bản trong ô txtSo1
            txtSo1.Focus();
        }

        private void txtSo2_Click(object sender, EventArgs e)
        {
            txtSo2.SelectAll(); // Chọn toàn bộ văn bản trong ô txtSo2
            txtSo2.Focus();
        }
    }
}
