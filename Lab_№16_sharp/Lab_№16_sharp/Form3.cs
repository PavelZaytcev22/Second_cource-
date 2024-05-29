using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab__16_sharp
{
    public partial class Form3 : Form
    {
        static Random randomer = new Random(); 
        public Form3()
        {
            InitializeComponent();
            Table1.AllowUserToAddRows = false;
            Table1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.hashTable == null || Form1.hashTable.Length < 1)
            {
                MessageBox.Show("Колекция не создана ил пустая ");
            }
            else 
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Индекс", typeof(int));
                dataTable.Columns.Add("Список", typeof(string));
                                
                int index = 0;
                
                foreach (var i in Form1.hashTable) 
                {
                    string bb = "  -> ";
                    if (i.Count > 0)
                    {
                        foreach (var j in i) 
                        {
                            if (j != null)
                            {
                                bb += " " + j.ToString() + " ->";
                            }
                            else 
                            {
                                bb += "NULL ->";
                            }
                        }
                    }                    
                     bb += " NULL ";                    
                    dataTable.Rows.Add(index, bb);
                    index++;
                }

               /* for (int i = 0; i < 10; i++)
                {
                    dataTable.Rows.Add(i, "vvv");
                }*/
                Table1.DataSource = dataTable;
                Table1.AutoResizeColumn(1);
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
