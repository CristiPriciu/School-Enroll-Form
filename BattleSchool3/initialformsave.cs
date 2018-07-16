using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleSchool3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateDdlGrupa();
            PopulateDdlProfesor();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                //validare
                if (string.IsNullOrEmpty(txtNume.Text))
                {
                    MessageBox.Show("Numele este obligatoriu!");
                    return;
                }
                if (string.IsNullOrEmpty(txtPrenume.Text))
                {
                    MessageBox.Show("Prenumele este obligatoriu!");
                    return;
                }

                int varsta = 0;
                bool conversieValida = Int32.TryParse(txtVarsta.Text, out varsta);
                if (!conversieValida)
                {
                    MessageBox.Show("Inserati o valoare numerica intreaga pe campul <varsta>!");
                    txtVarsta.Clear();
                    return;
                }

                double greutate = 0;
                bool conversieValida2 = Double.TryParse(txtGreutate.Text, out greutate);
                if (!conversieValida2)
                {
                    MessageBox.Show("Inserati o valoare numerica pe campul <greutate>!");
                    txtGreutate.Clear();
                    return;
                }
                
                //salvare in Db
                Students s = new Students();
                s.Nume = txtNume.Text;
                s.Prenume = txtPrenume.Text;
                s.Varsta = Convert.ToInt32(txtVarsta.Text);
                s.Greutate = Convert.ToDouble(txtGreutate.Text);
                s.StareCivila = chkStareCivila.Checked ? true : false;  //Converts boolean to int
                s.GrupaID = Convert.ToInt32(ddlGrupa.SelectedValue);
                s.ProfesorID = Convert.ToInt32(ddlProfesor.SelectedValue);
                s.Save("insert", s);
                txtNume.Clear();
                txtPrenume.Clear();
                txtVarsta.Clear();
                txtGreutate.Clear();
                chkStareCivila.Checked = false;
                //All is ok message
                MessageBox.Show("Student enrolled successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
 
        List<Grupe> lstGrupe = new List<Grupe>();
        private void PopulateDdlGrupa()
        {
            lstGrupe = new Grupe().GetAll();            
            ddlGrupa.DisplayMember = "NumeGrupa";
            ddlGrupa.ValueMember = "Id";
            ddlGrupa.DataSource = lstGrupe;
        }

        List<Profesori> lstProfesori = new List<Profesori>();
        private void PopulateDdlProfesor()
        {
            lstProfesori = new Profesori().GetAll();  // legatura la Profesori.CS ( ruleaza lista Profesori)hk
            ddlProfesor.DisplayMember = "FullName";  //apare in dropdown
            ddlProfesor.ValueMember = "Id";
            ddlProfesor.DataSource = lstProfesori;
        }
    }
}
