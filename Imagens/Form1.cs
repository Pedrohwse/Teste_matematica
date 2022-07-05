using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imagens
{
    public partial class Form1 : Form
{
        Random randomizador = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;
 
        int multiplicand;
        int multiplier;
 
        int dividend;
        int divisor;

        int timeLeft;
      
        public void StartTheQuiz()
        {

            addend1 = randomizador.Next(51);
            addend2 = randomizador.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            soma.Value = 0;

            minuend = randomizador.Next(1, 101);
            subtrahend = randomizador.Next(1, minuend);
            menosLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            diferença.Value = 0;

            multiplicand = randomizador.Next(2, 11);
            multiplier = randomizador.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            produto.Value = 0;

            divisor = randomizador.Next(2, 11);
            int temporaryQuotient = randomizador.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quociente.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 segundo";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == soma.Value)
                && (minuend - subtrahend == diferença.Value)
                && (multiplicand * multiplier == produto.Value)
                && (dividend / divisor == quociente.Value))
                return true;
            else
                return false;
        }
   
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
               timer1.Stop();
               MessageBox.Show("Você acertou todas as respostas!",
                               "Parábens!");
               startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
               timeLeft = timeLeft - 1;
               timeLabel.Text = timeLeft + " segundos";
            }
            else
            {
               timer1.Stop();
               timeLabel.Text = "Acabou o Tempo!";
               MessageBox.Show("Você não terminou no tempo.", "Desculpe!");
               soma.Value = addend1 + addend2;
               diferença.Value = minuend - subtrahend;
               produto.Value = multiplicand * multiplier;
               quociente.Value = dividend / divisor;
               startButton.Enabled = true;
            }
        }
    }
}
