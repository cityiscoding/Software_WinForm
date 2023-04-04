using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void bntBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frmDN = new frmDangNhap(); // Tạo một đối tượng mới của frmDangNhap
            frmDN.Show(); // Hiển thị frmDangNhap
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void ClearData()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        private void frmDangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.ExitApplication();
        }


        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string connection = @"Server=DESKTOP-E532F7N; Database=PMQLKS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    string query = "INSERT INTO MatKhau (phone, username, password) VALUES (@Phone, @Username, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Phone", txtSoDienThoai.Text);
                        cmd.Parameters.AddWithValue("@Username", txtTenDangNhap.Text);
                        cmd.Parameters.AddWithValue("@Password", txtMatKhau.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công");
                  
                    }
                }
                catch
                {
                    MessageBox.Show("Đăng ký thất bại! Thông tin đã tồn tại hoặc nhập không đúng");
             
                }
            }
        }



        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Tên đăng nhập")
            {
                txtTenDangNhap.Text = "";
                txtTenDangNhap.ForeColor = Color.Black;
            }
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                txtTenDangNhap.Text = "Tên đăng nhập";
                txtTenDangNhap.ForeColor = Color.Silver;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu")
            {
                txtMatKhau.UseSystemPasswordChar = true;
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.UseSystemPasswordChar = false;
                txtMatKhau.Text = "Mật khẩu";
                txtMatKhau.ForeColor = Color.Silver;
            }
        }

        private void txtSoDienThoai_Enter(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text == "Số điện thoại")
            {
                txtSoDienThoai.ForeColor = Color.Silver;
                txtSoDienThoai.Text = "Số điện thoại";
            }
        }

        private void txtSoDienThoai_Click(object sender, EventArgs e)
        {
                txtSoDienThoai.Text = "";
             
        }
    }
}
