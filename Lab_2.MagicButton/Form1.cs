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
using System.Xml;

namespace Lab_2.MagicButton
{
    public partial class Lab_2_HTML_to_XML : Form
    {
        List<Worker> Colegues = new List<Worker>();
        public Lab_2_HTML_to_XML()
        {
            InitializeComponent();
            Search linq = new Search(new LINQ());
            Worker w = new Worker();
            Colegues = linq.ExecuteSearch(w, "F:\\XML files\\Workers.xml");
            HashSet<string> Sset = new HashSet<string>();
            int Scount = 0;
            foreach (var s in Colegues)
            {
                Scount = Sset.Count;
                Sset.Add(s.Name);
                if (Scount != Sset.Count)
                {
                    boxName.Items.Add(s.Name);
                }
                Scount = Sset.Count;
                Sset.Add(s.Faculty);
                if (Scount != Sset.Count)
                {
                    boxFaculty.Items.Add(s.Faculty);
                }
                Scount = Sset.Count;
                Sset.Add(s.Сathedra);
                if (Scount != Sset.Count)
                {
                    boxСathedra.Items.Add(s.Сathedra);
                }
                Scount = Sset.Count;
                Sset.Add(s.Position);
                if (Scount != Sset.Count)
                {
                    boxPosition.Items.Add(s.Position);
                }
                Scount = Sset.Count;
                Sset.Add(s.Salary);
                if (Scount != Sset.Count)
                {
                    boxSalary.Items.Add(s.Salary);
                }
                Scount = Sset.Count;
                Sset.Add(s.Time);
                if (Scount != Sset.Count)
                {
                    boxTime.Items.Add(s.Time);
                }
            }
        }
        //public void ReadTable(string path)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(path);
        //    int X;
        //    int Y;
        //    string f = xmlDoc.InnerXml;
        //    string chislo = string.Empty;
        //    int beg = f.IndexOf("columns");
        //    for (int i = 0; f[beg + 9 + i] != 34; i++)
        //        chislo += f[beg + 9 + i];
        //    int columns = Convert.ToInt32(chislo);
        //    beg = f.IndexOf("rows");
        //    chislo = string.Empty;
        //    for (int i = 0; f[beg + 6 + i] != 34; i++)
        //        chislo += f[beg + 6 + i];
        //    int rows = Convert.ToInt32(chislo);
        //    Cell[,] Cells = new Cell[rows, columns];
        //    for (int i = 0; i < rows; i++)
        //        for (int j = 0; j < columns; j++)
        //            Cells[i, j] = new Cell();
        //    foreach (XmlElement table in xmlDoc.DocumentElement.ChildNodes)
        //    {
        //        foreach (XmlElement cellinfo in xmlDoc.DocumentElement.ChildNodes)
        //        {
        //            Int32.TryParse(cellinfo.GetAttribute("X"), out X);
        //            Int32.TryParse(cellinfo.GetAttribute("Y"), out Y);
        //            Cells[X - 1, Y - 1] = new Cell(cellinfo.InnerText);
        //        }
        //    }
        //    Worker Col = new Worker();
        //    for (int i = 1; i < rows; i++)
        //    {
        //        Col = new Worker();
        //        for (int j = 0; j < 6; j++)
        //        {
        //            Col.Set(j, Cells[i, j].expression);
        //        }
        //        Colegues.Add(Col);
        //    }

        //}
        public class Cell
        {
            public string name;
            public string expression;
            public double value;
            public bool Is_Formula_Count = false;
            public Cell(string expr)
            {
                expression = expr;
                value = 0;
            }
            public Cell()
            {
                expression = "";
                value = 0;
            }
            public bool IsNULL()
            {
                if ((expression == string.Empty))
                    return true;
                return false;
            }
        }
        static int GetRadioIndex(GroupBox group)
        {
            foreach (Control control in group.Controls)
                if (control is RadioButton)
                    if (((RadioButton)control).Checked)
                        return int.Parse(control.Tag.ToString());
            return -1;
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            boxName.Text = "";
            boxFaculty.Text = "";
            boxСathedra.Text = "";
            boxPosition.Text = "";
            boxSalary.Text = "";
            boxTime.Text = "";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            int i = GetRadioIndex(groupBox1);
            Worker w = new Worker();
            //           w.Name = boxName1.Text + boxName2.Text + boxName3.Text;
            w.Name = boxName.Text;
            w.Faculty = boxFaculty.Text;
            w.Сathedra = boxСathedra.Text;
            w.Position = boxPosition.Text;
            w.Salary = boxSalary.Text;
            w.Time = boxTime.Text;
            switch(i)
            { 
                case 0:
                    Search sax = new Search(new SAX());
                    Colegues = sax.ExecuteSearch(w, "F:\\XML files\\Workers.xml");
                    break;
                case 1:
                    Search dom = new Search(new DOM());
                    Colegues = dom.ExecuteSearch(w, "F:\\XML files\\Workers.xml");
                    break;
                case 2: Search linq = new Search(new LINQ());
                    Colegues = linq.ExecuteSearch(w, "F:\\XML files\\Workers.xml");
                    break;
            }
            if (Colegues.Count() == 0)
            {
                textBoxSearch.Text = "Таких записів немає у базі даних ";
                return;
            }
            textBoxSearch.Text = "Результати пошуку \r\n \r\n";

            foreach (var s in Colegues)
            {
                textBoxSearch.Text += "П.І.П \t\t\t" + s.Name + ";\r\n";
                textBoxSearch.Text += "факультет \t\t" + s.Faculty + ";\r\n";
                textBoxSearch.Text += "кафедра \t\t\t" + s.Сathedra + ";\r\n";
                textBoxSearch.Text += "посада \t\t\t" + s.Position + ";\r\n";
                textBoxSearch.Text += "посадовий оклад \t\t" + s.Salary + ";\r\n";
                textBoxSearch.Text += "час перебування на посаді \t" + s.Time + " років.\r\n";
                textBoxSearch.Text += ("---------------------------" + "\r\n");
            }
        }

        private void buttonHTML_Click(object sender, EventArgs e)
        {
            HTML htmltext = new HTML();
            string s = htmltext.ConvertDataTableToHtml(Colegues);
            string html = @"F:\\XML files\\Workers.html";
            File.WriteAllText( html, s);
            System.Diagnostics.Process.Start(@"chrome.exe", @"file:///F:/XML%20files/Workers.html");
        }
    }
}