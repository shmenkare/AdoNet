using System;
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
        int cantidad = 0;
        int stocks = 0;
        int totalVenta = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataSetPrueba.ReadXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile4.xml");

            dgvClientes.DataSource = dataSetPrueba.Tables["dtClientes"];
            dgvProd.DataSource = dataSetPrueba.Tables["Productos"];
            dgvVentas.DataSource = dataSetPrueba.Tables["Ventas"];
            cmbCliente.DataSource = dataSetPrueba.Tables["dtClientes"];
            cmbCliente.DisplayMember = "Id";
            cmbProducto.DataSource = dataSetPrueba.Tables["Productos"];
            cmbProducto.DisplayMember = "IdProd";
        }

        private void btnAgregarCli_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataSetPrueba.Tables["dtClientes"].NewRow();
            newRow["Nombre"] = txtNombre.Text;
            newRow["telefono"] = txtTelefono.Text;
            dataSetPrueba.Tables["dtClientes"].Rows.Add(newRow);

            dataSetPrueba.WriteXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile4.xml");
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataSetPrueba.Tables["Productos"].NewRow();
            newRow["NombreProd"] = txtNombrePro.Text;
            newRow["Precio"] = txtPrecio.Text;
            dataSetPrueba.Tables["Productos"].Rows.Add(newRow);

            dataSetPrueba.WriteXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile4.xml");
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCliente.Text = dataSetPrueba.Tables["dtClientes"].Rows[cmbCliente.SelectedIndex]["Nombre"].ToString();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProducto.Text = dataSetPrueba.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["NombreProd"].ToString();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            cantidad = int.Parse(txtCantidad.Text);
            string stock = dataSetPrueba.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["Stock"].ToString();
            stocks = int.Parse(stock) - cantidad;

            totalVenta = int.Parse(dataSetPrueba.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["Precio"].ToString()) * cantidad;


            DataRow neweRow = dataSetPrueba.Tables["Ventas"].NewRow();
            neweRow["IdProd"] = int.Parse(cmbProducto.Text);
            neweRow["Id"] = int.Parse(cmbCliente.Text);
            neweRow["Cantidad"] = cantidad;
            neweRow["TotalVentas"] = totalVenta;
            dataSetPrueba.Tables["Ventas"].Rows.Add(neweRow);

            dataSetPrueba.Tables["Productos"].Rows[cmbProducto.SelectedIndex]["Stock"] = stocks;

            dataSetPrueba.WriteXml("F:\\Mis Documentos\\CURSOS\\PROGRAMING\\REPOS VISUAL STUDIO\\Desarrollador .NET\\AdoNet\\XMLFile4.xml");
        }


    }
}
