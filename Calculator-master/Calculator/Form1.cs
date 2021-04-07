using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDisplay.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            previousOperation = operation.None;
            txtDisplay.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length>0)
            {
                double d;
                if (double.TryParse(txtDisplay.Text[txtDisplay.Text.Length - 1].ToString(), out d))
                {
                    previousOperation = operation.None;
                }
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (previousOperation != operation.None)
                PerformCalculation(previousOperation);
            
                previousOperation = operation.Div;
                txtDisplay.Text += (sender as Button).Text;
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            if (previousOperation != operation.None)
                 PerformCalculation(previousOperation);
            
                previousOperation = operation.Mul;
                txtDisplay.Text += (sender as Button).Text;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (previousOperation != operation.None)
                PerformCalculation(previousOperation);

            previousOperation = operation.Sub;
                txtDisplay.Text += (sender as Button).Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (previousOperation != operation.None)
                PerformCalculation(previousOperation); 
            
            previousOperation = operation.Add;
            txtDisplay.Text += (sender as Button).Text;
        }

        private void PerformCalculation(operation previousOperation)
        {
            List<double> lstNums = new List<double>();
            switch (previousOperation)
            {
                case operation.Add:
                    lstNums = txtDisplay.Text.Split('+').Select(double.Parse).ToList();
                    txtDisplay.Text = (lstNums[0] + lstNums[1]).ToString();
                    break;
                case operation.Sub:
                    lstNums = txtDisplay.Text.Split('-').Select(double.Parse).ToList();
                    txtDisplay.Text = (lstNums[0] - lstNums[1]).ToString();
                    break;
                case operation.Mul:
                    lstNums = txtDisplay.Text.Split('*').Select(double.Parse).ToList();
                    txtDisplay.Text = (lstNums[0] * lstNums[1]).ToString();
                    break;
                case operation.Div:
                    try
                    {
                        lstNums = txtDisplay.Text.Split('/').Select(double.Parse).ToList();
                        txtDisplay.Text = (lstNums[0] / lstNums[1]).ToString();
                    } catch (DivideByZeroException)
                    {
                        txtDisplay.Text = "EEEEEE";
                    }
                    break;
                case operation.None:
                    break;
                default:
                    break;
            }
        }

        private void btnNum_Click(object Btn, EventArgs e)
        {
            txtDisplay.Text += (Btn as Button).Text;
        } 

        enum operation
        {
            Add,
            Sub,
            Mul,
            Div,
            None
        }
        static operation previousOperation = operation.None;

        private void btnRes_Click(object sender, EventArgs e)
        {
            if (previousOperation == operation.None)
                return;
            else
                PerformCalculation(previousOperation);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test / test / nog iets
        }
    }
}
  