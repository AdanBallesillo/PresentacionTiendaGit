using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorProdcutos
    {
        Funciones f = new Funciones();

        public void Guardar(TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Guardar($"insert into producto values(null, '{Nombre.Text}', '{Descripcion.Text}', '{Precio.Text}')"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Borrar(int Idp, string Dato)
        {
            DialogResult re = MessageBox.Show($"Estas seguro de eliminar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                f.Borrar($"delete from producto where idproducto={Idp}");
                MessageBox.Show("Registro eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modificar(TextBox Nombre, TextBox Descripcion, TextBox Precio, int Idp)
        {
            MessageBox.Show(f.Modificar($"update producto set nombre='{Nombre.Text}', descripcion='{Descripcion.Text}', precio='{Precio.Text}' where idproducto={Idp}"),
                 "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        DataGridViewButtonColumn Boton(string t, Color co)
        {
            DataGridViewButtonColumn bo = new DataGridViewButtonColumn();
            bo.Text = t;
            bo.UseColumnTextForButtonValue = true;
            bo.FlatStyle = FlatStyle.Popup;
            bo.DefaultCellStyle.BackColor = co;
            bo.DefaultCellStyle.ForeColor = Color.White;
            return bo;
        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"select * from producto where nombre like '%{filtro}%'", "producto").Tables[0];
            tabla.Columns.Insert(4, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

    }
}
