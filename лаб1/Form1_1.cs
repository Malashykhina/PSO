using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace лаб1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Wlow = (double)Convert.ToDouble(textBox1.Text);
            Wup = (double)Convert.ToDouble(textBox2.Text);
            C1 = (double)Convert.ToDouble(textBox3.Text);
            C2 = (double)Convert.ToDouble(textBox4.Text);
        }
        private double Wlow;
        private double Wup;
        private double C1;
        private double C2;
        private void button1_Click(object sender, EventArgs e)
        {
            BestMax BM1 = new BestMax();
            BestMin BM2 = new BestMin();
            if (textBox1.Text!="")
                Wlow = (double) Convert.ToDouble( textBox1.Text);
            if (textBox2.Text!="")
                 Wup = (double)Convert.ToDouble(textBox2.Text);
            if (textBox3.Text != "")
                C1= (double)Convert.ToDouble(textBox3.Text);
            if (textBox4.Text != "")
                C2 = (double)Convert.ToDouble(textBox4.Text);
            textBox1.Text = Wlow.ToString();
            textBox2.Text = Wup.ToString();
            textBox3.Text = C1.ToString();
            textBox4.Text = C2.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            richTextBox1.Clear();
            int numOfP = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            int numOfIter = (int)numericUpDown2.Value;
            numericUpDown2.Enabled = false;
            if (radioButton1.Checked == true)
            {
                FDeJong DJ = new FDeJong();
                PSO(numOfP, 1000, numOfIter, DJ,BM1, Wlow,  Wup, C1, C2);
            }
            if (radioButton2.Checked == true)
            {
                Griewangk Gr = new Griewangk();
                PSO(numOfP, 1, numOfIter, Gr, BM1, Wlow, Wup, C1, C2);
            }
            if (radioButton3.Checked == true)
            {
                Goldstein_Price GP = new Goldstein_Price();
                PSO(numOfP, 1000, numOfIter, GP, BM2, Wlow, Wup, C1, C2);
            }
            if (radioButton4.Checked == true)
            {
                Branin Bran = new Branin();
                double []x=new double[2];
                x[0] = -22 / (double)7;
                x[1] = 12.275;
                richTextBox1.AppendText(Bran.Solve(x) + "\n");
                x[0] = 22 / (double)7;
                x[1] = 2.275;
                richTextBox1.AppendText(Bran.Solve(x) + "\n");
                x[0] = 66 / (double)7;
                x[1] = 2.475;
                richTextBox1.AppendText(Bran.Solve(x) + "\n");
                PSO(numOfP, 1000, numOfIter, Bran, BM2, Wlow, Wup, C1, C2);
            }
           
            if (radioButton5.Checked == true)
            {
                Martin_Gaddy MG = new Martin_Gaddy();
                PSO(numOfP, 1000, numOfIter, MG, BM2, Wlow, Wup, C1, C2);
            }
            if (radioButton6.Checked == true)
            {
                Rosenbrock2 MG = new Rosenbrock2();
                PSOForRosenbrock2(numOfP, 1000, numOfIter, MG, BM2, Wlow, Wup, C1, C2);
            }
            if (radioButton7.Checked == true)
            {
                Rosenbrock Ros = new Rosenbrock();
                PSO(numOfP, 1000, numOfIter, Ros, BM2, Wlow, Wup, C1, C2);
            }
            if (radioButton8.Checked == true)
            {
                Hyper_sphere HP = new Hyper_sphere();
                PSO(numOfP, 1000, numOfIter, HP, BM2, Wlow, Wup, C1, C2);
            }
            if (radioButton9.Checked == true)
            {
                Camel_Back CB = new Camel_Back();
                PSOForRosenbrock2(numOfP, 1000, numOfIter, CB, BM2, Wlow, Wup, C1, C2);
            }
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }
        private double RendomFill(double left, double right, int tolerance, Random Rn1)
        {
            int numOfPieces;
            double diapazon=0;
            if (tolerance==0)
                numOfPieces =1;
            else numOfPieces = tolerance;
            diapazon = right - left;
            diapazon=diapazon/((double)tolerance);
            while (Math.Round(diapazon) != 0)
            {
                numOfPieces = numOfPieces * 10;
                diapazon = diapazon / (double)10;
            }
            double Rnumb; 
            Rnumb = left + Rn1.Next(numOfPieces) * diapazon;
            Rnumb = Math.Round(Rnumb * tolerance);
            Rnumb = Rnumb / (double)tolerance;
            return Rnumb;
        }
        private void PrintVector(double[]x,int m)
        {
            for (int i = 0; i < m; i++)
            {
                richTextBox1.AppendText(" x["+i+"]="+x[i]+"; ");
            }
        }
        private void PSO(int numOfPopulation, int tolerance, int numIter, Function fn, Best BM, double Wlow, double Wup, double C1, double C2)
        {
            double leftB = fn.left;
            double rightB = fn.right;
            int N = numOfPopulation;//number of solutions
            int m = fn.num ;//num of paramrtrs
            int iter = numIter;//num of iteretions
            double[][] S = new double[N][];//рой, текущие позиции
            double[][] P = new double[N][];//множество лучших позиций
            double[][] V = new double[N][];
            double[] g = new double[m];//лучшее решение среди популяции
            double[] bestEver = new double[m];
            double Vmax;
            double R1;
            double R2;
            double W;          
            double SolveS;
            double SolveP;
            Random Rn1 = new Random();

            for (int i = 0; i < N; i++)//начальная инициализация роя
            {
                S[i] = new double[m];
                P[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    S[i][j] = RendomFill(leftB, rightB, tolerance, Rn1);
                    P[i][j] = S[i][j];
                }
            }         
            Vmax = (rightB - leftB) / (double)2;            
            g = BM.BestVectorOutOfMatrix(S,g,N,m,fn);

            for (int j = 0; j < m; j++)
            {
                bestEver[j] = g[j];
            }
            for (int i = 0; i < N; i++)
            {
                V[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    V[i][j] = 0;
                }
            }

            double C1max = C1;
            double C2max = C2;
            for (int t = 0; t < iter; t++)
            {
                C1=ChangeC1(0, C1max, iter, t);
                C2=ChangeC2(0, C2max, iter, t);
                W = Wup - (Wup - Wlow) * t / (double)iter;
                for (int i = 0; i < N; i++)//для каждой частицы(решения)
                {
                    for (int j = 0; j < m; j++)//для каждой координаты решения
                    {
                        R1 = Rn1.Next(100) / (double)100;
                        R2 = Rn1.Next(100) / (double)100;
                        V[i][j] = W* V[i][j] + C1 * R1 * (P[i][j] - S[i][j]) + C2 * R2 * (g[j] - S[i][j]);
                        if (V[i][j] > Vmax)
                        {
                            V[i][j] = Vmax;// Скорость вышла за пределы
                        }
                        if (V[i][j]< -Vmax)
                        {
                            V[i][j] = -Vmax;
                        }
                        S[i][j] = S[i][j] + V[i][j];

                        if (S[i][j] > rightB)
                        {
                            S[i][j] = rightB;
                        }
                        if (S[i][j] < leftB)
                        {
                            S[i][j] = leftB;
                        }
                    }
                                        
                    SolveP = fn.Solve(P[i]);
                    SolveS = fn.Solve(S[i]);
                    if (SolveP > SolveS)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            P[i][j] = S[i][j];
                        }
                    }                    
                }

                g = BM.BestVectorOutOfMatrix(S,g, N, m, fn);//выбираем лучшее решение
                
                if (BM.BestVectorOutOfTwoV(g, bestEver, m, fn) == 1)
                {
                    for (int var1 = 0; var1 < m; var1++)
                        bestEver[var1] = g[var1];
                    richTextBox1.AppendText(">>iter " + t + "; BestEver=" + fn.Solve(bestEver) + "; ");
                    PrintVector(bestEver, m);
                    richTextBox1.AppendText("\n");
                }
            }
        }
        private double ChangeC1(double minC1,double maxC1,int iter,int t)
        { 
           double newC1=maxC1;
           if (C1up.Checked == true)
               newC1 = minC1 + (maxC1 - minC1) * t / (double)iter;
           if (C1down.Checked == true)
               newC1 = maxC1 - (maxC1 - minC1) * t / (double)iter;
           return newC1;
        }
        private double ChangeC2(double minC2, double maxC2, int iter, int t)
        {
            double newC2 = maxC2;
            if (C2up.Checked == true)
                newC2 = minC2 + (maxC2 - minC2) * t / (double)iter;
            if (C2down.Checked == true)
                newC2 = maxC2 - (maxC2 - minC2) * t / (double)iter;
            return newC2;
        }
        private void PSOForRosenbrock2(int numOfPopulation, int tolerance, int numIter, Rosenbrock2 fn, Best BM, double Wlow, double Wup, double C1, double C2)
        {
            int N = numOfPopulation;//number of solutions
            int m = fn.num;//num of paramrtrs
            int iter = numIter;//num of iteretions
            double[][] S = new double[N][];//рой, текущие позиции
            double[][] P = new double[N][];//множество лучших позиций
            double[][] V = new double[N][];
            double[] g = new double[m];//лучшее решение среди популяции
            double[] bestEver = new double[m];
            double[] leftB = new double[m];
            double[] rightB = new double[m];
            double []Vmax=new double[m];
            double R1;
            double R2;
            double W;
            double SolveS;
            double SolveP;
            Random Rn1 = new Random();

            leftB[0] = fn.left;
            rightB[0] = fn.right;
            leftB[1] = fn.left2;
            rightB[1] = fn.right2;

            for (int i = 0; i < N; i++)//начальная инициализация роя
            {
                S[i] = new double[m];
                P[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    S[i][j] = RendomFill(leftB[j], rightB[j], tolerance, Rn1);
                    P[i][j] = S[i][j];
                }
            }
            for (int j = 0; j < m; j++)
            {
                Vmax[j] = (rightB[j] - leftB[j]) / (double)2;
            }  
            g = BM.BestVectorOutOfMatrix(S, g, N, m, fn);

            for (int j = 0; j < m; j++)
            {
                bestEver[j] = g[j];
            }
            for (int i = 0; i < N; i++)
            {
                V[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    V[i][j] = 0;
                }
            }


            for (int t = 0; t < iter; t++)
            {
                W = Wup - (Wup - Wlow) * t / (double)iter;
                for (int i = 0; i < N; i++)//для каждой частицы(решения)
                {
                    for (int j = 0; j < m; j++)//для каждой координаты решения
                    {
                        R1 = Rn1.Next(100) / (double)100;
                        R2 = Rn1.Next(100) / (double)100;
                        V[i][j] = W * V[i][j] + C1 * R1 * (P[i][j] - S[i][j]) + C2 * R2 * (g[j] - S[i][j]);
                        if (V[i][j] > Vmax[j])
                        {
                            V[i][j] = Vmax[j];// Скорость вышла за пределы
                        }
                        if (V[i][j] < -Vmax[j])
                        {
                            V[i][j] = -Vmax[j];
                        }
                        S[i][j] = S[i][j] + V[i][j];

                        if (S[i][j] > rightB[j])
                        {
                            S[i][j] = rightB[j];
                        }
                        if (S[i][j] < leftB[j])
                        {
                            S[i][j] = leftB[j];
                        }
                    }

                    SolveP = fn.Solve(P[i]);
                    SolveS = fn.Solve(S[i]);
                    if (SolveP > SolveS)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            P[i][j] = S[i][j];
                        }
                    }
                }

                g = BM.BestVectorOutOfMatrix(S, g, N, m, fn);//выбираем лучшее решение


                if (BM.BestVectorOutOfTwoV(g, bestEver, m, fn) == 1)
                {
                    for (int var1 = 0; var1 < m; var1++)
                        bestEver[var1] = g[var1];
                    richTextBox1.AppendText(">>iter " + t + "; BestEver=" + fn.Solve(bestEver) + "; ");
                    PrintVector(bestEver, m);
                    richTextBox1.AppendText("\n");
                }
            }
        }
         
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox1.Text.IndexOf(",") == -1)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox2.Text.IndexOf(",") == -1)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox3.Text.IndexOf(",") == -1)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox4.Text.IndexOf(",") == -1)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
