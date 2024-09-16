using System;
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
    public partial class FrmAgregar : Form
    {
        ManejadorProdcutos mp;
        public FrmAgregar()
        {
            InitializeComponent();
            mp =  new ManejadorProdcutos();
            if(Form1.Idp > 0 )
            {
                txtNombre.Text = Form1.nombre;
                txtDescripcion.Text = Form1.descripcion;
                txtPrecio.Text = Form1.precio.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Form1.Idp > 0)
            {
                mp.Modificar(txtNombre, txtDescripcion, txtPrecio, Form1.Idp);
            }
            else
            {
                mp.Guardar(txtNombre, txtDescripcion, txtPrecio);
            }
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
