using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppCreateRequest.Util;
using Dasync.Collections;

namespace WinFormsAppCreateRequest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitDataForHeader();
            InitDataForMethod();
        }

        private void InitDataForMethod()
        {
            this.comboBox2.SelectedIndex = 0;
        }

        private void InitDataForHeader()
        {
            this.dataGridView1.Rows.AddRange(DataHeader.InitDataForGridView());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string method = this.comboBox2.Text;
            if (string.IsNullOrEmpty(method))
            {
                MessageBox.Show("Vui lòng chọn phương thức gửi request", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var url = this.textBox1.Text;
            if(string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập thông tin url", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (method == Method.POST)
            {
                Int32.TryParse(this.textBox3.Text, out int loop);
                if (loop <= 0)
                {
                    MessageBox.Show("Điền giá trị lặp hợp lệ vào ô Loop", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var respone = new StringBuilder();
                List<int> numbers = new List<int>();
                for (int i = 0; i < loop; i++)
                {
                    numbers.Add(i);
                }
                await numbers.ParallelForEachAsync(async i =>
                {
                    var r = await ExcuteRequest();
                    respone.Append($"*********{i}**********").Append(Environment.NewLine);
                    respone.Append(r);
                    respone.Append($"*********{i}**********").Append(Environment.NewLine);
                });
                this.textBox4.Text = respone.ToString();
            }
        }
        private async Task<string> ExcuteRequest()
        {
            var url = this.textBox1.Text;
            var dataHeader = DataHeader.GetDataHeaderFromView(this.dataGridView1.Rows);
            var requestBody = this.textBox2.Text;
            return await HttpRequest.PostRequest(url, dataHeader, requestBody);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
