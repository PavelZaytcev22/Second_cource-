using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_15_C_
{
    //public delegate void ThreadStart();
    public partial class Form1 : Form
    {

        static int Honey = 0;
        int timeSleep = 0;
        int countHoney = 0;
        static Random randomer = new Random();
        static bool bearAlive = true;

        public void Bee1(object obj)
        {
            
            Image BeeTexture = Resource1.BeeSuperLitle;            
            bool left = true, right = false;
            PictureBox pictureBoxBee = (PictureBox)obj;
            int positionX = pictureBoxBee.Location.X;
            int positionY = pictureBoxBee.Location.Y;
            pictureBoxBee.Image = BeeTexture;
            pictureBoxBee.Location = new Point(positionX, positionY);
                do
                {
                do 
                {
                    positionX -= 10;
                    pictureBoxBee.Location = new Point(positionX, positionY);
                    Thread.Sleep(randomer.Next(100, 600));
                    if (positionX<300) 
                    {
                        left = false;
                        right = true;
                    }
                } while(left);
                do 
                {
                    positionX += 10;
                    pictureBoxBee.Location = new Point(positionX, positionY);
                    Thread.Sleep(randomer.Next(100, 600));
                    if (positionX > 500)
                    {
                        right = false;
                        left = true;
                        Honey += 50;
                        textBox3.Text = Honey.ToString();
                    }
                } while (right);
                    

                } while (bearAlive);         

        }

        public void Bear(object obj) 
        {
            bool flag1 = true, flag2 = true;
            Image BearTexture1 = Resource1.Bear1;
            Image BearTexture2 = Resource1.Bear2;
            Image BearTexture3 = Resource1.Bear3;
            PictureBox pictureBoxBear = (PictureBox)obj;
            pictureBoxBear.BackgroundImage = BearTexture1;
            Thread.Sleep(timeSleep);
            do
            {
                if (Honey >= countHoney && flag1 )
                {
                    Honey -= countHoney;//Съел мед
                    textBox3.Text = Honey.ToString();//Отображение меда 
                    Thread.Sleep(timeSleep);
                }
                else 
                {
                    if (flag2 && Honey<countHoney) 
                    {
                        flag1 = false;
                        pictureBoxBear.BackgroundImage = BearTexture2;
                        Thread.Sleep(timeSleep);
                    }                   
                }

                if (flag2 && !flag1 && Honey>=countHoney) 
                {
                       Honey -= countHoney;//Съел мед
                       textBox3.Text = Honey.ToString();//Отображение меда 
                       flag1 = true;
                       pictureBoxBear.BackgroundImage = BearTexture1;
                       Thread.Sleep(timeSleep);
                }
                else
                {
                    if (!flag1 && Honey<countHoney) 
                    {
                        flag2 = false;
                        pictureBoxBear.BackgroundImage = BearTexture3;
                    }                    
                }          

                
            } while (flag1 || flag2);
            bearAlive = false;
        }     
        
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countBees=0;
            bool flag1 = Int32.TryParse(comboBox1.Text, out countBees);
            bool flag2 = Int32.TryParse(textBox1.Text, out timeSleep);
            bool flag3 = Int32.TryParse(textBox2.Text, out countHoney);
            if (timeSleep < 1) 
            {
                flag2 = false;
            }
            if (countHoney<1) 
            {
                flag3 = false;
            }
            
            if (flag1 && flag2 && flag3) 
            {
                button1.Enabled = false;
                comboBox1.Enabled = false;
                //MessageBox.Show("Правильный ввод!!!");
                Thread[] listBee = new Thread[10];
                for (int i = 0; i < 10; i++)
                {
                    listBee[i] = new Thread(new ParameterizedThreadStart(Bee1));

                }
                Thread bear = new Thread(new ParameterizedThreadStart(Bear));

                PictureBox[] listsBox = new PictureBox[10];
                listsBox[0] = pictureBox2;
                listsBox[1] = pictureBox3;
                listsBox[2] = pictureBox4;
                listsBox[3] = pictureBox5;
                listsBox[4] = pictureBox6;
                listsBox[5] = pictureBox7;
                listsBox[6] = pictureBox8;
                listsBox[7] = pictureBox9;
                listsBox[8] = pictureBox10;
                listsBox[9] = pictureBox11;

                for (int i = 0; i < countBees; i++)
                {
                    listBee[i].Start(listsBox[i]);
                
                }
                bear.Start(pictureBox13);

                /*Thread c1 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c2 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c3 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c4 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c5 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c6 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c7 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c8 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c9 = new Thread(new ParameterizedThreadStart(Bee1));
                Thread c10 = new Thread(new ParameterizedThreadStart(Bee1));

                switch (countBees) 
                {
                    case 1:
                        c1.Start(pictureBox2);
                        bear.Start(pictureBox13);
                        break;
                    case 2:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        bear.Start(pictureBox13);
                        break;
                    case 3:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        bear.Start(pictureBox13);
                        break;
                    case 4:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        c4.Start(pictureBox5);
                        bear.Start(pictureBox13);
                        break;
                    case 5:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        c4.Start(pictureBox5);
                        c5.Start(pictureBox6);
                        bear.Start(pictureBox13);
                        break;
                    case 6:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        c4.Start(pictureBox5);
                        c5.Start(pictureBox6);
                        c6.Start(pictureBox7);
                        bear.Start(pictureBox13);
                        break;
                    case 7:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        c4.Start(pictureBox5);
                        c5.Start(pictureBox6);
                        c6.Start(pictureBox7);
                        c7.Start(pictureBox8);
                        bear.Start(pictureBox13);
                        break;
                    case 8:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        c4.Start(pictureBox5);
                        c5.Start(pictureBox6);
                        c6.Start(pictureBox7);
                        c7.Start(pictureBox8);
                        c8.Start(pictureBox9);
                        bear.Start(pictureBox13);
                        break;
                    case 9:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        c4.Start(pictureBox5);
                        c5.Start(pictureBox6);
                        c6.Start(pictureBox7);
                        c7.Start(pictureBox8);
                        c8.Start(pictureBox9);
                        c9.Start(pictureBox10);
                        bear.Start(pictureBox13);
                        break;
                    case 10:
                        c1.Start(pictureBox2);
                        c2.Start(pictureBox3);
                        c3.Start(pictureBox4);
                        c4.Start(pictureBox5);
                        c5.Start(pictureBox6);
                        c6.Start(pictureBox7);
                        c7.Start(pictureBox8);
                        c8.Start(pictureBox9);
                        c9.Start(pictureBox10);
                        c10.Start(pictureBox11);
                        bear.Start(pictureBox13);
                        break; 


                }     */



            }
            else 
            {
                MessageBox.Show("!!!!!Не правильный ввод!!!!");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            bearAlive = false;
        }
    }
}
