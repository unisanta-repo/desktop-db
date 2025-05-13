using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoDatabase.controller;
using ProjetoDatabase.model;


namespace ProjetoDatabase
{
    public partial class Form1 : Form
    {
        ClienteController clienteController;
        //string connectionString = "Server=localhost;Database=db_CLiente;UserId=unisanta;Password=unisanta;";
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=db_clientes;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            clienteController = new ClienteController(connectionString);
            AtualizarClientesGrid();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!clienteController.TestarConexao())
            {
                MessageBox.Show("Não foi possível conectar ao banco de dados.");
                Application.Exit();
            }

            string nome = textBox1.Text;
            Cliente cliente = new Cliente
            {
                Name = nome
            };

            clienteController.AddCliente(cliente);
            AtualizarClientesGrid();

            textBox1.Text = "";
        }

        private void AtualizarClientesGrid()
        {
            var clientes = clienteController.GetAllClientes();
            dataGridView1.DataSource = clientes;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var clientes = clienteController.GetAllClientes();
            dataGridView1.DataSource = clientes;
        }
    }




}
