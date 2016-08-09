using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Number(object sender, EventArgs e)
        {


            textBox1.Text += ((Button)sender).Text;
        }

        private void op(object sender, EventArgs e)
        {


            textBox1.Text += ((Button)sender).Text;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty; //or ="";


            //textBox1のデフォルトを0にするとか
        }


        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }




        public double Keisan(double x, double y, char option)
        {
            double ans = 0.0;

            switch (option)
            {
                case '+': ans = x + y;
                    break;
                
                case '-': ans = x - y;
                    break;

                case '*': ans = x * y;
                    break;

                case '/': ans = x / y;
                    break;

            
            }

            return ans;
        
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double left = 0.0;
            double right = 0.0;
            string copy = string.Empty; //string コピー用変数
            bool First = true;
            char Operator = ' ';

            for (int i = 0; i < textBox1.Text.Length; i++ )
                // if (数値)
                //else (演算子)
            {
                char Char_Temp = textBox1.Text[i];
                if (Char.IsDigit(Char_Temp) == true || Char_Temp == '.')
                {
                    copy += Char_Temp;//1文字ずつ追加

                    if (i == textBox1.Text.Length - 1)
                    {
                        right = double.Parse(copy);
                        left = Keisan(left, right , Operator);
                        copy = string.Empty;
                    }
                    
                }


                else if (Char_Temp == '+' || Char_Temp == '-' || Char_Temp == '*' || Char_Temp == '/')
                {
                    if (First == true)
                    {
                        left = double.Parse(copy); //文字列copyを計算の左側として、保存。
                        copy = string.Empty; //String Copyを初期化
                        First = false; //最初の数値を取得したことを表す。
                    }

                    else // bool First = false;
                        {
                        right = double.Parse(copy);                        
                        left = Keisan(left, right, Operator);
                        copy = string.Empty;
                    
                        }
                    Operator = Char_Temp; //一回目で記憶　→　２ループ目でも使う
                
                }

            }
            textBox1.Text = left.ToString();
  
        }

        


    }
}
