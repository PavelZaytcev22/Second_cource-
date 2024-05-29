using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

using _10LabLibrary;
using _16_LabLibrary;
using _12LabLibrary;

using Microsoft.SqlServer.Server;
using System.Runtime.Serialization.Formatters.Binary;

using static System.Net.WebRequestMethods;
using System.Security.Cryptography;
using System.Diagnostics;


namespace Lab__16_sharp
{
    public partial class FileForm : Form
    {
        public FileForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0 || Form1.hashTable.Count==0)
            {
                Stopwatch sw = new Stopwatch();//Измеритель времени
                using (StreamWriter fc = new StreamWriter("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\json.json", false)) 
                {
                    sw.Start();
                    foreach (var i in Form1.hashTable)
                    {
                        foreach (var j in i)
                        {
                         //  MessageBox.Show(JsonSerializer.Serialize(j));
                          await  fc.WriteLineAsync(JsonSerializer.Serialize(j));                             
                        }
                    }
                    sw.Stop();
                }
                
                MessageBox.Show("Таблица занесена в файл за "+sw.ElapsedMilliseconds.ToString()+" мл.сек");
            }
            else 
            {
                MessageBox.Show("Таблица не создана или пустая");
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                _12LabLibrary.HashTable<Challenge> newTable = new _12LabLibrary.HashTable<Challenge>(Form1.hashTable.Length);
                using (StreamReader fc = new StreamReader("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\json.json"))
                {                    
                    while (!fc.EndOfStream)
                    {
                        Test buffObj = JsonSerializer.Deserialize<Test>(await fc.ReadLineAsync());//Считывание в производный класс
                        if (buffObj.Teacher != "?")//Взависимотсти от содержания добавляем нужный класс 
                        { newTable.Add(buffObj); }
                        else
                        { newTable.Add(new Challenge(buffObj)); }
                    }
                    Form1.hashTable = newTable;
                    MessageBox.Show("Файл был прочитан");
                }
            }
            else 
            {
                MessageBox.Show("Коллекция нулевой длины");
            }
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                Stopwatch sw = new Stopwatch();//Измеритель времени
                ChallengeTest list = new ChallengeTest();
                XmlSerializer serializer = new XmlSerializer(typeof(ChallengeTest));//Сериализатор 
                using (FileStream fc = new FileStream("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\xml.xml", FileMode.Truncate)) 
                {
                    sw.Start();
                    foreach (var i in Form1.hashTable)
                    {
                        foreach (var j in i ) 
                        {                            
                            if (j != null) 
                            {                              
                               list.challenges.Add(j);                            
                            }                                                        
                        }
                    }
                    serializer.Serialize(fc, list);
                }
                sw.Stop();
                MessageBox.Show("Таблица занесена в файл за " + sw.ElapsedMilliseconds.ToString() + " мл.сек");
            }
            else 
            {
                MessageBox.Show("Коллекция нулевой длины");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                HashTable<Challenge> newTable = new HashTable<Challenge>(Form1.hashTable.Length); 
                XmlSerializer serializer = new XmlSerializer(typeof(ChallengeTest));
                using (FileStream fc = new FileStream("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\xml.xml", FileMode.OpenOrCreate))
                {
                    ChallengeTest list = new ChallengeTest();

                    list = (ChallengeTest)serializer.Deserialize(fc);                 

                       // serializer.Deserialize(fc) as List<Challenge>;
                    foreach (var i in list.challenges) 
                    {
                        newTable.Add(i);
                       // MessageBox.Show(i.ToString());
                    }
                }
                Form1.hashTable = newTable;
                MessageBox.Show("Файл прочитан");
            }
            else
            {
                MessageBox.Show("Коллекция нулевой длины");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                Stopwatch sw = new Stopwatch();//Измеритель времени
                BinaryFormatter bf = new BinaryFormatter();//Сериализатор 
                List<Challenge> list = new List<Challenge>(); 
                using (FileStream br = new FileStream("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\binary.dat", FileMode.Create))
                {
                    sw.Start();
                    foreach (var i in Form1.hashTable)
                    {
                        foreach (var j in i)
                        {
                            list.Add(j);
                        }
                    }
                    bf.Serialize(br,list);
                    sw.Stop();
                    MessageBox.Show("Таблица занесена в файл за " + sw.ElapsedMilliseconds.ToString() + " мл.сек");
                }
            }
            else { MessageBox.Show("!!!!Коллекция пустая!!"); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<Challenge> list = new List<Challenge>();
                HashTable<Challenge> newTable = new HashTable<Challenge>(Form1.hashTable.Length);
                using (FileStream br = new FileStream("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\binary.dat", FileMode.Open)) 
                {
                    list=  (List<Challenge>)bf.Deserialize(br);
                    foreach (var i in list ) 
                    {
                        newTable.Add(i);
                    }
                    Form1.hashTable = newTable; 
                    MessageBox.Show("Файл прочитан");
                }
            }
            else  { MessageBox.Show("!!!!Коллекция пустая!!"); } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                Stopwatch sw1 = new Stopwatch();//Измеритель времени
                using (StreamWriter sw = new StreamWriter("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\TXT.txt", false))
                {
                    sw1.Start();
                    foreach (var i in Form1.hashTable)
                    {
                        foreach (var j in i)
                        {
                            sw.WriteLine(j.ToString());
                        }
                    }
                    sw1.Stop();
                }
                MessageBox.Show("Таблица занесена в файл за " + sw1.ElapsedMilliseconds.ToString() + " мл.сек");
            }
            else { MessageBox.Show("!!!!Коллекция пустая!!"); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                HashTable<Challenge> newTable = new HashTable<Challenge>(Form1.hashTable.Length);
               
                using (StreamReader sw = new StreamReader("C:\\Users\\pvl2z\\source\\repos\\Lab_№16_sharp\\Lab_№16_sharp\\Files\\TXT.txt"))
                {
                    while (!sw.EndOfStream) 
                    {
                        newTable.Add(_16_LabLibrary.Functions.GetChallenge(sw.ReadLine()));
                    }
                }
                Form1.hashTable = newTable;
                MessageBox.Show("Коллекция загружена ");
            }
            else { MessageBox.Show("!!!!Коллекция пустая!!"); }
        }

        private void FileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
