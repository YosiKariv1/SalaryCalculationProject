using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDD
{
    public partial class MainProgramFrame : Form
    {

        public static List<Employs> employs = new List<Employs>();
        public string[] names = System.IO.File.ReadAllLines(@"..\..\files\Names.txt");
        public string[] lastNames = System.IO.File.ReadAllLines(@"..\..\files\LastNames.txt");
        public string[] address = System.IO.File.ReadAllLines(@"..\..\files\Adress.csv");

        public MainProgramFrame()
        {
            InitializeComponent();

        }

        public void AddAllEmploys()
        {
            for(int i = 0; i < 10000; i++)
            {
                Random random = new Random();
                String name = names[random.Next(0, names.Length)];
                Employs employ = new Employs(name, lastNames[random.Next(0, lastNames.Length)], address[random.Next(0, address.Length)], name + "@gmail.com", IdMaker(), PhoneMaker(), MakeSalary());
                employs.Add(employ);
            }    

        }

        public static bool sortCheck()
        {
            throw new NotImplementedException();
        }

        public String IdMaker()
        {
            Random random = new Random();
            int num = random.Next(200000000, 400000000);

            return Convert.ToString(num);
        }
        
        public String PhoneMaker()
        {
            Random rand = new Random();
            int num = rand.Next(1000000, 10000000);
            int num1 = rand.Next(0, 5);


            return "05" + num1 + Convert.ToString(num);
        }

        public int MakeSalary()
        {
            Random rand = new Random();
            int num = rand.Next(3000, 50000);

            return num;

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            AddEmpolyFrame addEmploy = new AddEmpolyFrame();
            addEmploy.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע את הפעולה?", "", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    AddAllEmploys();
                    break;
                case DialogResult.No:
                    break;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployListFrame listFrame = new EmployListFrame();
            listFrame.ShowDialog();
        }
    }
}
