using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BattleSchool3
{
    public class Grupe
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string numegrupa;
        public string NumeGrupa
        {
            get { return numegrupa; }
            set { numegrupa = value; }
        }

            public List<Grupe> GetAll()
        {
            List<SqlDbParameter> paramGrupe = new List<SqlDbParameter>(); //Creaza o noua lista paramGrupe
            paramGrupe.Add(new SqlDbParameter("act", "get"));  //Face legatura cu SQL dboSpProfesori(procedura salvata)
            DataTable dtGrupe = new DataTable();    //Table populat cu datele aduse din SQL
            DataAccess.RunSP("SpNumeGrupa", paramGrupe, ref dtGrupe);   //cheama functia RunSP din clasa DataAccess, aduce datele din baza de date, prin sql(vezi mai sus 1 rand)

            List<Grupe> lstGrupe = new List<Grupe>(); //noua lista lstGrupe
            foreach (DataRow row in dtGrupe.Rows)
            {
                Grupe g = new Grupe();  //?
                g.ID = Convert.ToInt32(row["ID"]);
                g.NumeGrupa = row["NumeGrupa"].ToString();
                lstGrupe.Add(g);
            }
            return lstGrupe;
        }
    }
}