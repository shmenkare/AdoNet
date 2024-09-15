/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AdoNet
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet("DBPrueba");
        int cantidad = 0;
        int stocks = 0;
        int totalVenta = 0;
        public Form1()
        {
            InitializeComponent();

            DataTable dtCli = ds.Tables.Add("dtClientes");
            DataTable dtPro = ds.Tables.Add("Productos");
            DataTable dtVent = ds.Tables.Add("Ventas");

            DataColumn col = dtCli.Columns.Add("Id", typeof(int));
            dtCli.Columns.Add("Nombre", typeof(string));
            dtCli.Columns.Add("telefono", typeof(string));
            dtCli.Columns[0].AutoIncrement = true;
            dtCli.Columns[0].AutoIncrementSeed = 1;
            dtCli.Columns[0].AutoIncrementStep = 1;
            dtCli.Constraints.Add("PK_dtCli", dtCli.Columns["Id"], true);


            col = dtPro.Columns.Add("IdProd", typeof(int));
            dtPro.Columns.Add("NombreProd", typeof(string));
            dtPro.Columns.Add("Precio", typeof(int));
            dtPro.Columns.Add("Stock", typeof(int));
            dtPro.Columns[0].AutoIncrement = true;
            dtPro.Columns[0].AutoIncrementSeed = 1;
            dtPro.Columns[0].AutoIncrementStep = 1;
            dtPro.Constraints.Add("PK_dtPro", dtPro.Columns["IdProd"], true);


            col = dtVent.Columns.Add("IdVentas", typeof(int));
            dtVent.Columns.Add("IdProd", typeof(int));
            dtVent.Columns.Add("Id", typeof(int));
            dtVent.Columns.Add("Cantidad", typeof(int));
            dtVent.Columns.Add("TotalVentas", typeof(int));
            dtVent.Columns[0].AutoIncrement = true;
            dtVent.Columns[0].AutoIncrementSeed = 1;
            dtVent.Columns[0].AutoIncrementStep = 1;
            dtVent.Constraints.Add("PK_dtVent", dtVent.Columns["IdVentas"], true);


            DataRelation dr = new DataRelation("FK_seVende_a", dtPro.Columns["IdProd"], dtVent.Columns["IdProd"]);
            ds.Relations.Add(dr);

            DataRelation dr2 = new DataRelation("FK_compra_un", dtCli.Columns["Id"], dtVent.Columns["Id"]);
            ds.Relations.Add(dr2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ds.ReadXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile3.xml");

            dgvClientes.DataSource = ds.Tables["dtClientes"];
            dgvProd.DataSource = ds.Tables["Productos"];
            dgvVentas.DataSource = ds.Tables["Ventas"];
            cmbCliente.DataSource = ds.Tables["dtClientes"];
            cmbCliente.DisplayMember = "Id";
            cmbProducto.DataSource = ds.Tables["Productos"];
            cmbProducto.DisplayMember = "IdProd";
        }

        private void btnAgregarCli_Click(object sender, EventArgs e)
        {
            DataRow newRow = ds.Tables["dtClientes"].NewRow();
            newRow["Nombre"] = txtNombre.Text;
            newRow["telefono"] = txtTelefono.Text;
            ds.Tables["dtClientes"].Rows.Add(newRow);

            ds.WriteXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile3.xml");
        }
        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            DataRow newrow = ds.Tables["Productos"].NewRow();
            newrow["NombreProd"] = txtNombrePro.Text;
            newrow["Precio"] = txtPrecio.Text;
            ds.Tables["Productos"].Rows.Add(newrow);

            ds.WriteXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile3.xml");
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCliente.Text = ds.Tables["dtClientes"].Rows[cmbCliente.SelectedIndex]["Nombre"].ToString();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProducto.Text = ds.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["NombreProd"].ToString();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            cantidad = int.Parse(txtCantidad.Text);
            string stock = ds.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["Stock"].ToString();
            stocks = int.Parse(stock) - cantidad;

            totalVenta = int.Parse(ds.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["Precio"].ToString()) * cantidad;


            DataRow neweRow = ds.Tables["Ventas"].NewRow();
            neweRow["IdProd"] = int.Parse(cmbProducto.Text);
            neweRow["Id"] = int.Parse(cmbCliente.Text);
            neweRow["Cantidad"] = cantidad;
            neweRow["TotalVentas"] = totalVenta;
            ds.Tables["Ventas"].Rows.Add(neweRow);

            ds.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["Stock"] = stocks;

            ds.WriteXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile3.xml");
        }
    }
}*/
