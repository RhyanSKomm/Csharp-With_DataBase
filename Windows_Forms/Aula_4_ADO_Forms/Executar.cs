using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Aula_4_ADO_Forms
{
    public class Executar
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cadastro());
        }
    }

    public class Cadastro : Form
    {
        private Label label1, label2, label3;
        private TextBox txtId, txtNome, txtEmail;
        private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
        private ListBox lstUsuario;

        private CRUD crud;

        public Cadastro()
        {
            crud = new CRUD();
            
            this.Size = new Size (500, 500);
            this.Text = "Cadastro de Usuários";
            this.BackColor = Color.White;

            Font fonte = new Font("Poppins", 12, FontStyle.Bold);

            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.DarkBlue };
            label2 = new Label { Text = "Nome:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
            label3 = new Label { Text = "Email:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };

            txtId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonte };
            txtNome = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonte };
            txtEmail = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonte };

            btnInserir = CriarBotao("Inserir", new Point(270, 30), Color.DarkMagenta);
            btnListar = CriarBotao("Listar", new Point(270, 80), Color.DarkMagenta);
            btnAtualizar = CriarBotao("Atualizar", new Point(270, 130), Color.DarkMagenta);
            btnDeletar = CriarBotao("Deletar", new Point(380, 30), Color.DarkMagenta);
        
            btnInserir.Click += new EventHandler(this.btnInserir_Click);
            btnListar.Click += new EventHandler(this.btnListar_Click);
            btnAtualizar.Click += new EventHandler(this.btnAtualizar_Click);
            btnDeletar.Click += new EventHandler(this.btnDeletar_Click);

            lstUsuario = new ListBox { Location = new Point(20, 180), Width = 500, Height = 150, BackColor = Color.
            White, ForeColor = Color.DarkSeaGreen, Font = fonte };


            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(txtId);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnInserir);
            this.Controls.Add(btnListar);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(btnDeletar);
            this.Controls.Add(lstUsuario);

        }

        private Button CriarBotao(string texto, Point localizacao, Color cor)
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.InserirUsuario(id, nome, email);
                MessageBox.Show("Usuário inserido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;

                crud.AtualizarUsuario(id, nome);
                MessageBox.Show("Usuário atualizado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                lstUsuario.Items.Clear();

                List<string> usuarios = crud.ListarUsuarios();
                if(usuarios.Count > 0)
                {
                    foreach (string usuario in usuarios)
                    {
                        lstUsuario.Items.Add(usuario);
                    }
                }
                else
                {
                    lstUsuario.Items.Add("Nenhum encontrado");
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private void btnDeletar_Click (object sender, EventArgs e)
        {
            try
            {
               int id = int.Parse(txtId.Text);
               crud.DeletarUsuario(id);
                MessageBox.Show("Usuário deletado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
        }
    }
}