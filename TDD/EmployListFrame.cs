using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TDD.MainProgramFrame;

namespace TDD
{
    public partial class EmployListFrame : Form
    {

        public int tax = 0;


        public EmployListFrame()
        {
            InitializeComponent();
        }

        public object MainApplication { get; private set; }

        private void EmployListFrame_Load(object sender, EventArgs e)
        {
            AddTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (employs.Count == 0)
            {
                MessageBox.Show("אין עובדים ברשימה כרגע");
                return;
            }

            float sal = employs[dataGridView1.CurrentCell.RowIndex].salary;
            sal = CalculateTax(sal);
            MessageBox.Show("מס הכנסה חודשי: "+ sal);


        }

        public float CalculateTax(float sal)
        {
            int taxGrade = getTaxGrade(sal);
            sal = (sal * taxGrade) / 100;
            return sal;

        }

        public int getTaxGrade(float sal)
        {
            if (sal <= 6450)
                return 10;
            if (sal <= 9240)
                return 14;
            if (sal <= 14840)
                return 20;
            if (sal <= 20620)
                return 31;
            if (sal <= 42910)
                return 35;
            
            return 47;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(employs.Count == 0)
            {
                MessageBox.Show("אין עובדים ברשימה כרגע");
                return;
            }
            
            var start = DateTime.Now;
            //BubbleSort();
            QuickSort(0, employs.Count-1);
            AddTable();
            var time = DateTime.Now - start;
            MessageBox.Show(String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0')) + " ms");
        }

        public void BubbleSort()
        {
            Employs temp;
            for (int j = 0; j <= employs.Count - 2; j++)
            {
                for (int i = 0; i <= employs.Count - 2; i++)
                {
                    if (employs[i].salary < employs[i + 1].salary)
                    {
                        temp = employs[i + 1];
                        employs[i + 1] = employs[i];
                        employs[i] = temp;
                    }
                }
            }
        }

        public void QuickSort(int start, int end)
        {
            int i;
            if (start < end)
            {
                i = partition(start, end);
                QuickSort(start, i-1);
                QuickSort(i+1, end);
            }
        }

        public int partition(int start, int end)
        {
            Employs t;
            Employs p = employs[end];
            int i = start-1;
            for(int j = start; j <= end-1; j++)
            {
                if(employs[j].salary > p.salary)
                {
                    i++;
                    t = employs[i];
                    employs[i] = employs[j];
                    employs[j] = t;
                }
            }
            t = employs[i+1];
            employs[i + 1] = employs[end];
            employs[end] = t;
            return i + 1;
        }

        public void AddTable()
        {
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;
            dataTable.Columns.Add("שם");
            dataTable.Columns.Add("שם משפחה");
            dataTable.Columns.Add("תעודת זהות");
            dataTable.Columns.Add("כתובת");
            dataTable.Columns.Add("טלפון");
            dataTable.Columns.Add("אימייל");
            dataTable.Columns.Add("משכורת");

            for (int i = 0; i < employs.Count; i++)
            {
                dataTable.Rows.Add(employs[i].firstName, employs[i].lastName, employs[i].Id, employs[i].address, employs[i].phoneNumber, employs[i].email, employs[i].salary);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public Boolean sortCheck()
        {
            for(int i = 0; i < employs.Count; i++)
            {
                if (employs[i].salary > employs[i + 1].salary)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
