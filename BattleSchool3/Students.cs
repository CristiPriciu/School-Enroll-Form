using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BattleSchool3
{
    public class Students
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string nume;
        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        private string prenume;
        public string Prenume
        {
            get { return prenume; }
            set { prenume = value; }
        }

        private int varsta;
        public int Varsta
        {
            get { return varsta; }
            set { varsta = value; }
        }

        private double greutate;
        public double Greutate
        {
            get { return greutate; }
            set { greutate = value; }
        }

        private bool starecivila;
        public bool StareCivila
        {
            get { return starecivila; }
            set { starecivila = value; }
        }

        private int profesorid;
        public int ProfesorID
        {
            get { return profesorid; }
            set { profesorid = value; }
        }

        private int grupaid;
        public int GrupaID
        {
            get { return grupaid; }
            set { grupaid = value; }
        }

        public void Save(string operation, Students current)
        {
            List<SqlDbParameter> param = new List<SqlDbParameter>();
            param.Add(new SqlDbParameter("@act", operation));

            SqlConnection con = new SqlConnection(DataAccess.ConnectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spStudents";
            cmd.Parameters.AddWithValue("@act", operation);
            cmd.Parameters.AddWithValue("@nume", Nume);
            cmd.Parameters.AddWithValue("@prenume", Prenume);
            cmd.Parameters.AddWithValue("@varsta", Varsta);
            cmd.Parameters.AddWithValue("@greutate", Greutate);
            cmd.Parameters.AddWithValue("@starecivila", StareCivila);
            cmd.Parameters.AddWithValue("@ProfesorID", ProfesorID);
            cmd.Parameters.AddWithValue("@GrupaID", GrupaID);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            


        }

    }
}
