using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TurchinaTPRLab.UI
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent();
            LoadDocument();
        }

        public void LoadDocument()
        {
            string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Theory");
            string fileName;

            fileName = myPath + @"/User_guide.pdf";

            webBrowser1.Navigate(fileName);
        }

    }
}
