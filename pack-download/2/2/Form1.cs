using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        string constr;
        SqlConnection con;
        SqlDataAdapter dataAdapter;
        DataTable table;

        public Form1()
        {
            InitializeComponent();
            constr = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Armazem2";
            con = new SqlConnection(constr);
        }

        private void Bind(string sql)
        {
            dataAdapter = new SqlDataAdapter(sql, constr);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            table = new DataTable();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bind("select * from Clientes");
        }

        private void encomendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bind("select * from Encomendas");
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bind("select * from Produtos");
        }

        private void relacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bind("select * from Relacao");
        }

        private void submit_Click(object sender, EventArgs e)
        {
            dataAdapter.Update(table);
        }

        private void Pesquisa_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            Bind("select data, designacao, quantidade from Encomendas join Relacao on codencomenda = codencomendaFK join Produtos on codproduto = codprodutoFK where codencomenda = " + a);
        }
    }
}
