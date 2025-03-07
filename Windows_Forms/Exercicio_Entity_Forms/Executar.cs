using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_Entity_Forms
{
    public class Executar
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms());
        }
    }

    public class Forms : Form
    {
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;

        // , labelS1, labelS2, labelS3, labelU1, labelU2, labelU3;
        // , txtSId, txtSProduto, txtSHarddisk, txtSMemoria_ram, txtSFkMaquina, txtUId, txtUPassword, txtUNome, txtURamal, txtUEspecialidade;
        // , SbtnInserir, SbtnListar, SbtnAtualizar, SbtnDeletar, UbtnInserir, UbtnListar, UbtnAtualizar, UbtnDeletar;
        private ListBox lstUsuario, lstMaquina, lstSoftware;

        private CRUD crud;

        private Maquina maquinaForm;
        
        public Forms(){
            this.Text = "Sistema Multi-Telas";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl { Dock = DockStyle.Fill };

            tabPage1 = new TabPage(Text = "Maquina");
            tabPage2 = new TabPage(Text = "Tela 2");

            maquinaForm = new Maquina();

            tabPage1.Controls.Add(maquinaForm);

            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);

            this.Controls.Add(tabControl);
        }

        public class Maquina : UserControl
        {
            private Label labelM1, labelM2, labelM3, labelM4, labelM5, labelM6, labelM7;
            private TextBox txtMId, txtMTipo, txtMVelocidade, txtMHarddisk, txtMPlacaRede, txtMMemoriaRam, txtMFkUsuario;
            private Button MbtnInserir, MbtnListar, MbtnAtualizar, MbtnDeletar;
            public Maquina()
            {
                this.Text = "Maquinas";
                this.Size = new Size(1000, 1000);
                this.BackColor = Color.White; 
                Font fonte = new Font("Poppins", 12, FontStyle.Bold);

                labelM1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelM2 = new Label { Text = "Tipo:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelM3 = new Label { Text = "Velocidade:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelM4 = new Label { Text = "Hard-Disk:", Location = new Point(270, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelM5 = new Label { Text = "Placa de Rede:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelM6 = new Label { Text = "Memoria Ram:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelM7 = new Label { Text = "Fk Usuario:", Location = new Point(160, 160), Font = fonte, ForeColor = Color.DarkBlue };

                txtMId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonte };
                txtMTipo = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonte };
                txtMVelocidade = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonte };
                txtMHarddisk = new TextBox { Location = new Point(270, 30), Width = 220, Font = fonte };
                txtMPlacaRede = new TextBox { Location = new Point(270, 80), Width = 220, Font = fonte };
                txtMMemoriaRam = new TextBox { Location = new Point(270, 130), Width = 220, Font = fonte };
                txtMFkUsuario = new TextBox { Location = new Point(160, 190), Width = 220, Font = fonte };

                MbtnInserir = CriarBotao("Inserir", new Point(20,240));
                MbtnAtualizar = CriarBotao("Atualizar", new Point(130,240));
                MbtnDeletar = CriarBotao("Deletar", new Point(240,240));
                MbtnListar = CriarBotao("Listar", new Point(340,240));

                this.Controls.Add(labelM1);
                this.Controls.Add(labelM2);
                this.Controls.Add(labelM3);
                this.Controls.Add(labelM4);
                this.Controls.Add(labelM5);
                this.Controls.Add(labelM6);
                this.Controls.Add(labelM7);
                this.Controls.Add(txtMId);
                this.Controls.Add(txtMTipo);
                this.Controls.Add(txtMVelocidade);
                this.Controls.Add(txtMHarddisk);
                this.Controls.Add(txtMPlacaRede);
                this.Controls.Add(txtMMemoriaRam);
                this.Controls.Add(txtMFkUsuario);
                this.Controls.Add(MbtnInserir);
                this.Controls.Add(MbtnAtualizar);
                this.Controls.Add(MbtnDeletar);
                this.Controls.Add(MbtnListar);
            }
        }

        private static Button CriarBotao(string texto, Point localizacao)
        {
            return new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font ("Roboto", 12, FontStyle.Bold)
            };
        }
    }


}