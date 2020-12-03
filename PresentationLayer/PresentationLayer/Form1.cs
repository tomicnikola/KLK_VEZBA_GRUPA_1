using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly MenuItemBusiness menuItemBusiness;

        public Form1()
        {
            this.menuItemBusiness = new MenuItemBusiness();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            List<DataAccesLayer.Models.MenuItem> items = this.menuItemBusiness.GetAllMenuItems();
            listBoxItems.Items.Clear();

            foreach (DataAccesLayer.Models.MenuItem mi in items)
                listBoxItems.Items.Add(mi.Id + ". " + mi.Title + " -" + mi.Description + "- " + mi.Price);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccesLayer.Models.MenuItem mi = new DataAccesLayer.Models.MenuItem();
            mi.Title = textBox1.Text;
            mi.Description = textBox2.Text;
            mi.Price = Convert.ToDecimal(textBox3.Text);

            if(this.menuItemBusiness.InsertMenuItem(mi))
            {
                RefreshData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Greska");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = listBoxItems.SelectedItem.ToString();
            var temp = Convert.ToInt32(s.Split('.')[0]);
            DataAccesLayer.Models.MenuItem mi = new DataAccesLayer.Models.MenuItem();
            mi.Title = textBox1.Text;
            mi.Description = textBox2.Text;
            mi.Price = Convert.ToDecimal(textBox3.Text);

            if (this.menuItemBusiness.UpdateMenuItem(mi, temp))
            {
                RefreshData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Greska");
            }

        }
    }
       
}
