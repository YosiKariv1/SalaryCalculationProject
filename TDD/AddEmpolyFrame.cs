using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TDD.MainProgramFrame;

namespace TDD
{
    public partial class AddEmpolyFrame : Form
    {
        private String firstName, lastName, phoneNumber, address, email, Id;
        private int salary;


        public AddEmpolyFrame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "" || this.textBox2.Text == "" || this.textBox3.Text == "" || this.textBox4.Text == "" || this.textBox5.Text == "" || this.textBox6.Text == "" || this.textBox7.Text == "")
            {
                MessageBox.Show("חסר פרטים, נא נסה שנית");
                return;

            }
            
            firstName = this.textBox1.Text;
            lastName = this.textBox2.Text;
            Id = this.textBox3.Text;
            address = this.textBox4.Text;
            phoneNumber = this.textBox5.Text;
            email = this.textBox6.Text;
            salary = int.Parse(this.textBox7.Text);

            Employs employ = new Employs(this.firstName, this.lastName, this.address, this.email, this.Id, this.phoneNumber, this.salary);
            employs.Add(employ);
            this.Close();
            MessageBox.Show("העובד נוסף בהצלחה");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.All(char.IsLetter))
            {
                MessageBox.Show("יש להכניס רק אותיות");
                textBox1.Text = "";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!textBox2.Text.All(char.IsLetter))
            {
                MessageBox.Show("יש להכניס רק אותיות");
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(!textBox3.Text.All(char.IsDigit))
            {
                MessageBox.Show("יש להכניס רק מספרים");
                textBox3.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!textBox5.Text.All(char.IsDigit))
            {
                MessageBox.Show("יש להכניס רק מספרים");
                textBox5.Text = "";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!textBox7.Text.All(char.IsDigit))
            {
                MessageBox.Show("יש להכניס רק מספרים");
                textBox7.Text = "";
            }
        }



    }
}
