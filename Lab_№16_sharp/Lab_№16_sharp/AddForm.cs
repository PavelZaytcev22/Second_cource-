using _10LabLibrary;
using _12LabLibrary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab__16_sharp
{
    public partial class AddForm : Form
    {
        int countForAdd = 0; 

        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    int value;
                    if (int.TryParse(textBox2.Text, out value))
                    {
                        Form1.hashTable.Add(new _10LabLibrary.Challenge(textBox1.Text, value, textBox3.Text));
                        MessageBox.Show("Элемент добавлен");
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввод какого-то поля ");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text!="")
                {
                    int value;
                    if (int.TryParse(textBox5.Text, out value))
                    {
                        Form1.hashTable.Add(new _10LabLibrary.Test(textBox4.Text, value, textBox6.Text,textBox7.Text));
                        MessageBox.Show("Элемент добавлен");
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввод какого-то поля ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }

        private void button3_click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (textBox8.Text != "")
                {
                    int value;
                    if (Int32.TryParse(textBox8.Text, out value))
                    {
                        for (int i = 0; i < value; i++) 
                        {
                            if (countForAdd % 2 == 1)
                            {
                                Challenge buff1 = new Challenge();
                                buff1.RandomInit();
                                Form1.hashTable.Add(new Challenge(buff1));
                                countForAdd++;
                            }
                            else 
                            {
                                Test buff2 = new Test();
                                buff2.RandomInit();
                                Form1.hashTable.Add(new Test(buff2));
                                countForAdd++;
                            }
                        }
                        MessageBox.Show("Элементы добавлены в таблицу");
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввоод");
                    }
                }
            }
            else { MessageBox.Show("Таблица не проинициализированна"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" )
                {
                    int value;
                    if (int.TryParse(textBox10.Text, out value))
                    {
                        if (Form1.hashTable.Remove(new Challenge(textBox9.Text,value,textBox11.Text))) 
                        {
                            MessageBox.Show("Поле было удалено");
                        }
                        else 
                        {
                            MessageBox.Show("Не получилось удалить");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввод какого-то поля ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }
               
        private void button5_click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
                {
                    int value;
                    if (int.TryParse(textBox13.Text, out value))
                    {
                        if (Form1.hashTable.Remove(new Test(textBox12.Text, value, textBox14.Text, textBox15.Text)))
                        {
                            MessageBox.Show("Поле было удалено");
                        }
                        else 
                        {
                            MessageBox.Show("Не получилось удалить");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввод какого-то поля ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }

        private void button7_click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "")
                {
                    int value;
                    if (int.TryParse(textBox17.Text, out value))
                    {
                        if (Form1.hashTable.Contains(new Challenge(textBox16.Text, value, textBox18.Text)))
                        {
                            MessageBox.Show("Поле было найдено");
                        }
                        else
                        {
                            MessageBox.Show("Не получилось найти");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввод какого-то поля ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (textBox19.Text != "" && textBox20.Text != "" && textBox21.Text != "" && textBox22.Text != "")
                {
                    int value;
                    if (int.TryParse(textBox20.Text, out value))
                    {
                        if (Form1.hashTable.Contains(new Test(textBox19.Text, value, textBox21.Text, textBox22.Text)))
                        {
                            MessageBox.Show("Поле было найдено");
                        }
                        else
                        {
                            MessageBox.Show("Не получилось найти");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввод какого-то поля ");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable.Length > 0)
            {
                if (comboBox1.Text != "")
                {
                    List<Challenge> buff;
                    HashTable<Challenge> newTable = new HashTable<Challenge>(Form1.hashTable.Length);
                    switch (comboBox1.Text) 
                    {
                        case "Названию":                           
                            foreach (var i in Form1.hashTable) 
                            {
                                if (i.Count > 1)
                                {
                                    buff = new List<Challenge>();
                                    foreach (var j in i)
                                    {
                                        if (j != null) { buff.Add(j); }
                                    }
                                    var bb = buff.OrderBy(p => p.Name);
                                    foreach (var zz in bb)
                                    {
                                        newTable.Add(zz);
                                    }
                                }
                                else 
                                {
                                    foreach (var j in i)
                                    {
                                        if (j != null) { newTable.Add(j); }
                                    }
                                }
                            }
                            Form1.hashTable = newTable;
                            break;
                        case "Заданиям":
                            foreach (var i in Form1.hashTable)
                            {
                                if (i.Count > 1)
                                {
                                    buff = new List<Challenge>();
                                    foreach (var j in i)
                                    {
                                        if (j != null) { buff.Add(j); }
                                    }
                                    var bb = buff.OrderBy(p => p.Questions);
                                    foreach (var zz in bb)
                                    {
                                        newTable.Add(zz);
                                    }
                                }
                                else
                                {
                                    foreach (var j in i)
                                    {
                                        if (j != null) { newTable.Add(j); }
                                    }
                                }
                            }
                            Form1.hashTable = newTable;
                            break;
                        
                        
                    }
                    MessageBox.Show("Сортировка прошла");
                }
                else 
                {
                    MessageBox.Show("Критерий не выбран");
                }
            }
            else 
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }

        

        private void button9_Click(object sender, EventArgs e)
        {

            if (Form1.hashTable.Length > 0)
            {
                
                HashTable<Challenge> newTable = new HashTable<Challenge>(Form1.hashTable.Length);
                if (comboBox2.Text != "")
                {
                    switch (comboBox2.Text) 
                    {
                        case "Названию":
                            if (textBox23.Text != "")
                            {                                
                                foreach (var i in Form1.hashTable)
                                {
                                    foreach (var j in i ) 
                                    {
                                        if (j != null && j.Name==textBox23.Text) { newTable.Add(j); }
                                    }
                                }
                                Form1.hashTable = newTable;
                                MessageBox.Show("Фильтрация прошла");
                            }
                            else { MessageBox.Show("Критерий не определен"); }

                            break;
                        case "Заданиям":
                            if (textBox23.Text != "")
                            {
                                int value;
                                if (Int32.TryParse(textBox23.Text, out value))
                                {
                                    foreach (var i in Form1.hashTable)
                                    {
                                        foreach (var j in i)
                                        {
                                            if (j != null && j.Questions == value) { newTable.Add(j); }
                                        }
                                    }
                                    Form1.hashTable = newTable;
                                    MessageBox.Show("Фильтрация прошла");
                                }
                                else { MessageBox.Show("Критерий неправильно определен"); } 
                            }
                            else { MessageBox.Show("Критерий не определен"); }
                            break; 
                    }
                }
                else { MessageBox.Show("Критерий не выбран"); }

            }
            else 
            {
                MessageBox.Show("Таблица не проинициализированна");
            }
        }


    }
}
