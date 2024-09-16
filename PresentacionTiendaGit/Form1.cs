using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;

namespace PresentacionTiendaGit
{
    public partial class Form1 : Form
    {
        ManejadorProdcutos mp;
        int fila = 0, columna = 0;
        public static int Idp = 0;
        public static string nombre = "", descripcion = "";
        public static double precio = 0;

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvProductos.Visible = true;
            mp.Mostrar(dtgvProductos, txtBuscar.Text);
        }

        private void dtgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 4:
                    {
                        Idp = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        mp.Borrar(Idp, dtgvProductos.Rows[fila].Cells[1].Value.ToString());
                    }
                    break;
                case 5:
                    {
                        Idp = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        nombre = dtgvProductos.Rows[fila].Cells[1].Value.ToString();
                        descripcion = dtgvProductos.Rows[fila].Cells[2].Value.ToString();
                        precio = double.Parse(dtgvProductos.Rows[fila].Cells[3].Value.ToString());
                        
                        FrmAgregar Ap = new FrmAgregar();
                        Ap.ShowDialog();
                        dtgvProductos.Visible = false;
                    }
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
            mp = new ManejadorProdcutos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Idp = 0; nombre = ""; descripcion = ""; precio = 0;
            dtgvProductos.Visible = false;
            FrmAgregar Ap = new FrmAgregar();
            Ap.ShowDialog();
            txtBuscar.Focus();
        }
    }
}
