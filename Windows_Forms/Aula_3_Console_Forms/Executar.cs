using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_3_Console_Forms
{
    public class Executar
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        public MainForm()
        {

            this.Text = "Sistema Multi-Telas";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl { Dock = DockStyle.Fill };

            tabPage1 = new TabPage(Text = "Tela 1");
            tabPage2 = new TabPage(Text = "Tela 2");
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);

            this.Controls.Add(tabControl);

            tabPage1.Controls.Add(new Tela1());
            tabPage2.Controls.Add(new Tela2());

        }

        public class Tela1 : Form
        {
            public Tela1()
            {
                this.Text = "Tela 1";
                this.Size = new Size(300, 300);
                this.StartPosition = FormStartPosition.CenterScreen; // Centraliza o formulário na tela
                this.BackColor = Color.LightBlue; // Cor de fundo do formulário

                Label label = new Label { Text = "Tela 1" };
                label.Location = new Point(100, 100);
                this.Controls.Add(label);
            }
        }

        public class Tela2 : Form
        {
            public Tela2()
            {
                this.Text = "Tela 2";
                this.Size = new Size(300, 300);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.LightGreen;

                Label label = new Label { Text = "Tela 2" };
                label.Location = new Point(100, 100);
                this.Controls.Add(label);
            }
        }
    }
}