using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

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
        private TabPage tabPage3;
        private CRUD crud;

        private Maquina maquinaForm;
        private Software softwareForm;
        private Usuario usuarioForm;
        private TableLayoutPanel tableLayoutPanel1;

        public Forms()
        {
            this.Text = "Sistema Multi-Telas";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            tabControl = new TabControl { Dock = DockStyle.Fill };

            tabPage1 = new TabPage(Text = "Maquina");
            tabPage2 = new TabPage(Text = "Software");
            tabPage3 = new TabPage(Text = "Usuario");

            maquinaForm = new Maquina();
            softwareForm = new Software();
            usuarioForm = new Usuario();

            tabPage1.Controls.Add(maquinaForm);
            tabPage2.Controls.Add(softwareForm);
            tabPage3.Controls.Add(usuarioForm);

            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);
            tabControl.TabPages.Add(tabPage3);

            tableLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 23,
                RowCount = 5,
                AutoSize = true,
                Padding = new Padding(10)
            };

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            this.Controls.Add(tabControl);
        }

        public class Maquina : UserControl
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public int Velocidade { get; set; }
            public int Hardidisk { get; set; }
            public int Placa_rede { get; set; }
            public int Memoria_ram { get; set; }
            public int Fk_usuario { get; set; }

            private Label labelM1, labelM2, labelM3, labelM4, labelM5, labelM6, labelM7;
            private TextBox txtMId, txtMTipo, txtMVelocidade, txtMHarddisk, txtMPlacaRede, txtMMemoriaRam, txtMFkUsuario;
            private Button MbtnInserir, MbtnListar, MbtnAtualizar, MbtnDeletar;
            private CRUD crud = new CRUD();
            private TableLayoutPanel tableLayoutPanel1;
            public Maquina()
            {
                this.Text = "Maquinas";
                this.Size = new Size(1000, 1000);
                this.BackColor = Color.White;
                Font fonte = new Font("Poppins", 12, FontStyle.Bold);
                tableLayoutPanel1 = new TableLayoutPanel{
                    Dock = DockStyle.Top, // DockStyle é para definir a posição do controle, e o top é para definir o controle no topo.
                ColumnCount = 3, // Definir o número de colunas
                RowCount = 6, // Definir o número de linhas
                AutoSize = true, // AutoSize é para definir o tamanho do controle automaticamente
                Padding = new Padding(10), // Padding é para definir o preenchimento do controle
                };  

                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Definir o tamanho da coluna em porcentagem, 30F é 30%
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F)); // Definir o tamanho da coluna em porcentagem, 70F é 70%


                labelM1 = CriarLabel("ID");
                labelM2 = CriarLabel("Tipo:");
                labelM3 = CriarLabel("Velocidade:");
                labelM4 = CriarLabel("Hard-Disk:");
                labelM5 = CriarLabel("Placa de Rede:");
                labelM6 = CriarLabel("Memoria Ram:");
                labelM7 = CriarLabel("Fk Usuario:");

                txtMId =CriarTextBox();
                txtMHarddisk =CriarTextBox();
                txtMPlacaRede =CriarTextBox();
                txtMMemoriaRam =CriarTextBox();
                txtMFkUsuario =CriarTextBox();

                MbtnInserir =CriarBotao("Inserir","https://cdn-icons-png.flaticon.com/512/992/992651.png");
                MbtnAtualizar = CriarBotao("Atualizar","https://cdn-icons-png.flaticon.com/512/3063/3063825.png");
                MbtnDeletar = CriarBotao("Deletar", "https://cdn-icons-png.flaticon.com/512/1214/1214428.png");
                MbtnListar = CriarBotao("Listar","https://cdn-icons-png.flaticon.com/512/1087/1087080.png");

                MbtnInserir.Click += MbtnInserir_Click;
                MbtnAtualizar.Click += MbtnAtualizar_Click;
                MbtnDeletar.Click += MbtnDeletar_Click;
                MbtnListar.Click += MbtnListar_Click;

                tableLayoutPanel1.Controls.Add(labelM1, 0, 0);
                tableLayoutPanel1.Controls.Add(labelM2,0,1);
                tableLayoutPanel1.Controls.Add(labelM3,0,2);
                tableLayoutPanel1.Controls.Add(labelM4,0,3);
                tableLayoutPanel1.Controls.Add(labelM5,0,4);
                tableLayoutPanel1.Controls.Add(labelM6,0,5);
                tableLayoutPanel1.Controls.Add(labelM7,0,6);
                tableLayoutPanel1.Controls.Add(txtMId,1, 0);
                tableLayoutPanel1.Controls.Add(txtMTipo,1,1);
                tableLayoutPanel1.Controls.Add(txtMVelocidade,1,2);
                tableLayoutPanel1.Controls.Add(txtMHarddisk,1,3);
                tableLayoutPanel1.Controls.Add(txtMPlacaRede,1,4);
                tableLayoutPanel1.Controls.Add(txtMMemoriaRam,1,5);
                tableLayoutPanel1.Controls.Add(txtMFkUsuario,1,6);
                tableLayoutPanel1.Controls.Add(MbtnInserir);
                tableLayoutPanel1.Controls.Add(MbtnAtualizar);
                tableLayoutPanel1.Controls.Add(MbtnDeletar);
                tableLayoutPanel1.Controls.Add(MbtnListar);
            }
            private void MbtnInserir_Click(object sender, EventArgs e)
            {
                var maquinaa = new Exercicio_Entity_Forms.Maquina
                {
                    Tipo = txtMTipo.Text,
                    Velocidade = int.Parse(txtMVelocidade.Text),
                    Hardidisk = int.Parse(txtMHarddisk.Text),
                    Placa_rede = int.Parse(txtMPlacaRede.Text),
                    Memoria_ram = int.Parse(txtMMemoriaRam.Text),
                };
                crud.InserirMaquina(maquinaa);
            }

            private void MbtnAtualizar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtMId.Text);
                var maquina = new Exercicio_Entity_Forms.Maquina
                {
                    Id = int.Parse(txtMId.Text),
                    Tipo = txtMTipo.Text,
                    Velocidade = int.Parse(txtMVelocidade.Text),
                    Hardidisk = int.Parse(txtMHarddisk.Text),
                    Placa_rede = int.Parse(txtMPlacaRede.Text),
                    Memoria_ram = int.Parse(txtMMemoriaRam.Text),
                };
                crud.AtualizarMaquina(id, maquina);
            }

            private void MbtnDeletar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtMId.Text);
                crud.DeletarMaquina(id);
            }

            private void MbtnListar_Click(object sender, EventArgs e)
            {
                crud.ListarMaquinas();
            }
        }



        public class Software : UserControl
        {
            public int Id { get; set; }
            public string Produto { get; set; }
            public int Hardidisk { get; set; }
            public int Memoria_ram { get; set; }
            public int Fk_usuario { get; set; }
            private Label labelS1, labelS2, labelS3, labelS4, labelS5;
            private TextBox txtSId, txtSProduto, txtSHarddisk, txtSMemoria_ram, txtSFkMaquina;
            private Button SbtnInserir, SbtnListar, SbtnAtualizar, SbtnDeletar;
            private CRUD crud = new CRUD();

            public Software()
            {
                this.Text = "Sofwares";
                this.Size = new Size(1000, 1000);
                this.BackColor = Color.White;
                Font fonte = new Font("Poppins", 12, FontStyle.Bold);

                labelS1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelS2 = new Label { Text = "Produto:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelS3 = new Label { Text = "Hard-Disk:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelS4 = new Label { Text = "Memoria Ram:", Location = new Point(270, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelS5 = new Label { Text = "Fk Usuario:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };

                txtSId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonte };
                txtSProduto = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonte };
                txtSHarddisk = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonte };
                txtSMemoria_ram = new TextBox { Location = new Point(270, 30), Width = 220, Font = fonte };
                txtSFkMaquina = new TextBox { Location = new Point(270, 80), Width = 220, Font = fonte };

                SbtnInserir = CriarBotao("Inserir", "https://cdn-icons-png.flaticon.com/512/992/992651.png");
                SbtnAtualizar = CriarBotao("Atualizar", "https://cdn-icons-png.flaticon.com/512/3063/3063825.png");
                SbtnDeletar = CriarBotao("Deletar", "https://cdn-icons-png.flaticon.com/512/1214/1214428.png");
                SbtnListar = CriarBotao("Listar", "https://cdn-icons-png.flaticon.com/512/1087/1087080.png");

                SbtnInserir.Click += SbtnInserir_Click;
                SbtnAtualizar.Click += SbtnAtualizar_Click;
                SbtnDeletar.Click += SbtnDeletar_Click;
                SbtnListar.Click += SbtnListar_Click;

                this.Controls.Add(labelS1);
                this.Controls.Add(labelS2);
                this.Controls.Add(labelS3);
                this.Controls.Add(labelS4);
                this.Controls.Add(labelS5);
                this.Controls.Add(txtSId);
                this.Controls.Add(txtSHarddisk);
                this.Controls.Add(txtSMemoria_ram);
                this.Controls.Add(SbtnInserir);
                this.Controls.Add(SbtnAtualizar);
                this.Controls.Add(SbtnDeletar);
                this.Controls.Add(SbtnListar);
            }
            private void SbtnInserir_Click(object sender, EventArgs e)
            {
                var software = new Exercicio_Entity_Forms.Software
                {
                    Id = int.Parse(txtSId.Text),
                    Produto = txtSProduto.Text,
                    Hardidisk = int.Parse(txtSHarddisk.Text),
                    Memoria_ram = int.Parse(txtSMemoria_ram.Text),
                };
                crud.InserirSoftware(software);
            }

            private void SbtnAtualizar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtSId.Text);
                var software = new Exercicio_Entity_Forms.Software
                {
                    Produto = txtSProduto.Text,
                    Hardidisk = int.Parse(txtSHarddisk.Text),
                    Memoria_ram = int.Parse(txtSMemoria_ram.Text),
                };
                crud.AtualizarSoftware(id, software);
            }

            private void SbtnDeletar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtSId.Text);
                crud.DeletarSoftware(id);
            }

            private void SbtnListar_Click(object sender, EventArgs e)
            {
                crud.ListarSoftwares();
            }
        }

        public class Usuario : UserControl
        {
            public int Id { get; set; }
            public string Nome_Usuario { get; set; }
            public string Senha_Usuario { get; set; }
            public int Ramal_Usuario { get; set; }
            public string Especialidade_Usuario { get; set; }
            private Label labelU1, labelU2, labelU3, labelU4, labelU5;
            private TextBox txtUId, txtUPassword, txtUNome, txtURamal, txtUEspecialidade;
            private Button UbtnInserir, UbtnListar, UbtnAtualizar, UbtnDeletar;
            private CRUD crud = new CRUD();

            public Usuario()
            {
                this.Text = "Usuarios";
                this.Size = new Size(1000, 1000);
                this.BackColor = Color.White;
                Font fonte = new Font("Poppins", 12, FontStyle.Bold);

                labelU1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelU2 = new Label { Text = "Senha:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelU3 = new Label { Text = "Nome:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelU4 = new Label { Text = "Ramal:", Location = new Point(270, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelU5 = new Label { Text = "Especialidade:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };

                txtUId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonte };
                txtUPassword = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonte };
                txtUNome = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonte };
                txtURamal = new TextBox { Location = new Point(270, 30), Width = 220, Font = fonte };
                txtUEspecialidade = new TextBox { Location = new Point(270, 80), Width = 220, Font = fonte };

                UbtnInserir = CriarBotao("Inserir", "https://cdn-icons-png.flaticon.com/512/992/992651.png");
                UbtnAtualizar = CriarBotao("Atualizar", "https://cdn-icons-png.flaticon.com/512/3063/3063825.png");
                UbtnDeletar = CriarBotao("Deletar", "https://cdn-icons-png.flaticon.com/512/1214/1214428.png");
                UbtnListar = CriarBotao("Listar", "https://cdn-icons-png.flaticon.com/512/1087/1087080.png");

                UbtnInserir.Click += UbtnInserir_Click;
                UbtnAtualizar.Click += UbtnAtualizar_Click;
                UbtnDeletar.Click += UbtnDeletar_Click;
                UbtnListar.Click += UbtnListar_Click;

                this.Controls.Add(labelU1);
                this.Controls.Add(labelU2);
                this.Controls.Add(labelU3);
                this.Controls.Add(labelU4);
                this.Controls.Add(labelU5);
                this.Controls.Add(txtUId);
                this.Controls.Add(txtUId);
                this.Controls.Add(txtUPassword);
                this.Controls.Add(UbtnInserir);
                this.Controls.Add(UbtnAtualizar);
                this.Controls.Add(UbtnDeletar);
                this.Controls.Add(UbtnListar);
            }

            private void UbtnInserir_Click(object sender, EventArgs e)
            {
                var usuario = new Usuarios
                {
                    Id = int.Parse(txtUId.Text),
                    Nome_Usuario = txtUNome.Text,
                    Password_Usuario = txtUPassword.Text,
                    Ramal_Usuario = int.Parse(txtURamal.Text),
                    Especialidade_Usuario = txtUEspecialidade.Text
                };

                crud.InserirUsuario(usuario);
            }


            private void UbtnAtualizar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtUId.Text);  // Assumindo que você tenha um campo ID no formulário
                var usuario = new Usuarios
                {
                    Nome_Usuario = txtUNome.Text,
                    Password_Usuario = txtUPassword.Text,
                    Ramal_Usuario = int.Parse(txtURamal.Text),
                    Especialidade_Usuario = txtUEspecialidade.Text
                };

                crud.AtualizarUsuario(id, usuario);
            }


            private void UbtnDeletar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtUId.Text);  // Assumindo que o ID do usuário seja passado no campo de ID
                crud.DeletarUsuario(id);
            }


            private void UbtnListar_Click(object sender, EventArgs e)
            {
                crud.ListarUsuarios(); // Listar todos os usuários no console (ou em uma listbox, se necessário)
            }


        }
        private static Button CriarBotao(string texto, string urlImage)
        {
            Button botao = new Button
            {
                Text = texto,
                Width = 100,
                Height = 30,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Roboto", 12, FontStyle.Bold),
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5,0,5,0)
            };
                try
                {
                    using(WebClient wc = new WebClient())
                    {
                        byte[] imagemBytes = wc.DownloadData(urlImage);
                        using(var ms = new System.IO.MemoryStream(imagemBytes))
                        {
                            botao.Image = Image.FromStream(ms);
                            botao.Image = new Bitmap(botao.Image, new Size(30,30));
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            return botao;
        }

        private static Label CriarLabel(string texto)
        {
            return new Label
            {
                Text = texto,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Anchor = AnchorStyles.Left // AnchorStyles é para definir a posição do  controle na janela esquerda
            };
        }

        // Configuração global dos Texbox que vou usar
        private static TextBox CriarTextBox()
        {
            return new TextBox
            {
                Font = new Font("Arial", 12, FontStyle.Bold),
                Anchor = AnchorStyles.Left | AnchorStyles.Right// AnchorStyles é para definir a posição do controle na janela esquerda e direita
            };
        }
    }
}