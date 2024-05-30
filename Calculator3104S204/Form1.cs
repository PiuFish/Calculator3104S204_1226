using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator3104S204
{
    public partial class Form1 : Form
    {
        int[] num = new int [2];
        int index = 0;
        string op = ""; //放加減乘除
        int finalresult = 0;
        public Form1()
        {
            InitializeComponent();
            btn0.Click += btnN_Click;
            btn1.Click += btnN_Click;
            btn2.Click += btnN_Click;
            btn3.Click += btnN_Click;
            btn4.Click += btnN_Click;
            btn5.Click += btnN_Click;
            btn6.Click += btnN_Click;
            btn7.Click += btnN_Click;
            btn8.Click += btnN_Click;
            btn9.Click += btnN_Click;
            btnadd.Click += btnOp_Click;
            btnminus.Click += btnOp_Click;
            btnmaltiply.Click += btnOp_Click;
            btndivide.Click += btnOp_Click;
            btnequal.Click += Btnequal_Click;
        }
        private void btnOp_Click(object sender, EventArgs e)
        {
            Button btnop = (Button)sender;
            int result = 0;
            if (int.TryParse(txtNumber.Text, out result) == true)//判斷目前的輸入框是否為數字
            {
                txtNumber.Text = "";
                num[index] = result;
                index++;
                if (index == 2)
                {
                    if (op != "＝")
                    {
                        if (op == "＋") finalresult = num[0] + num[1];
                        else if (op == "–") finalresult = num[0] - num[1];
                        else if (op == "×") finalresult = num[0] * num[1];
                        else finalresult = num[0] / num[1];
                        num[0] = finalresult;
                    }
                    index = 1;
                }
                op = btnop.Text;
            }
        }
        private void Btnequal_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (int.TryParse(txtNumber.Text, out result) == true)//判斷目前的輸入框是否為數字
            {
                num[1] = result;
                txtNumber.Text = "";
                if (op == "＋") finalresult = num[0] + num[1];
                else if (op == "–") finalresult = num[0] - num[1];
                else if (op == "×") finalresult = num[0] * num[1];
                else finalresult = num[0] / num[1];
                op = "＝";
                num[0] = finalresult;
                index = 1;
                txtNumber.Text = finalresult.ToString();
            }
        }
        private void btnN_Click(object sender, EventArgs e)
        {
            Button btnN = (Button)sender;
            string strbtnNum = btnN.Text;
            if (txtNumber.Text == "0") txtNumber.Text = strbtnNum;
            else txtNumber.Text = txtNumber.Text + strbtnNum; 
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "0";
            num[1] = 0;
            num[0] = 0;
            index = 0;
            finalresult = 0;
            op = "";
        }
    }
}
