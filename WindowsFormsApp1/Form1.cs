using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string cknf = "";
        string cdnf = "";

        int[] mass;

        int[,] mass1 =  {
                                {0,0,1,1},
                                {0,1,0,1}
                            };

        int[,] mass2 =  {
                                {0,0,0,0,1,1,1,1},
                                {0,0,1,1,0,0,1,1},
                                {0,1,0,1,0,1,0,1}
                            };

        int[,] mass3 =  {
                                {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1},
                                {0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1},
                                {0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1},
                                {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1}
                            };
        int selectedIndex;
        


        public Form1()
        {
            InitializeComponent();
        }



        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ComboboxItems(comboBox1.SelectedIndex);
        }

        public void ComboboxItems( int selectedIndex)
        {
            comboBox2.Items.Clear();
            for (int i = 1; i <= (int)(Math.Pow(2,selectedIndex+2)); i++)
            {
                comboBox2.Items.Add(i);
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            mass[comboBox2.SelectedIndex] = Convert.ToInt32(comboBox3.SelectedItem);
        }

        private void SelectCount_Click(object sender, EventArgs e)
        {
            mass = new int[(int)(Math.Pow(2, comboBox1.SelectedIndex + 2))];
            operationsPanel.Enabled = true;
            panel1.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            operationsPanel.Enabled = false;
            panel1.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < mass1.GetLength(1); i++)
                {
                    if (mass[i] == 1)
                    {
                        switch (mass1[0, i])
                        {
                            case 1:
                                cknf = cknf + " X&";
                                break;
                            case 0:
                                cknf = cknf + " ¬X&";
                                break;
                        }
                        switch (mass1[1, i])
                        {
                            case 1:
                                cknf = cknf + "Y V";
                                break;
                            case 0:
                                cknf = cknf + "¬Y V";
                                break;
                        }

                    }
                    else
                    {
                        switch (mass1[0, i])
                        {
                            case 1:
                                cdnf = cdnf + " (XV";
                                break;
                            case 0:
                                cdnf = cdnf + " (¬XV";
                                break;
                        }
                        switch (mass1[1, i])
                        {
                            case 1:
                                cdnf = cdnf + "Y) &";
                                break;
                            case 0:
                                cdnf = cdnf + "¬Y) &";
                                break;
                        }
                    }
                }
                MessageBox.Show(cknf);

            }
        }
    }
}
