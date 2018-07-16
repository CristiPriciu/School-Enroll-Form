using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BattleSchool3
{

    public class Profesori
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

        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        public List<Profesori> GetAll()
        {
            List<SqlDbParameter> param = new List<SqlDbParameter>();
            param.Add(new SqlDbParameter("act", "get"));
            DataTable dt = new DataTable();
            DataAccess.RunSP("SpProfesori", param, ref dt);

            List<Profesori> lst = new List<Profesori>();
            foreach (DataRow row in dt.Rows)
            {
                Profesori p = new Profesori();
                p.ID = Convert.ToInt32(row["ID"]);
                p.Nume = row["Nume"].ToString();
                p.Prenume = row["Prenume"].ToString();
                p.FullName = row["FullName"].ToString();
                lst.Add(p);
            }
            return lst;
        }
    }

}
