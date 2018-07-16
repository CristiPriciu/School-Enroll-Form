using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSchool3
{
    public class SqlDbParameter
    {
        public string ParName;
        public object ParValue;
        public DbType ParType;
        public ParameterDirection Direction;
        public int ParSize;

        public SqlDbParameter(string parName, object parValue, DbType parType)
        {
            ParName = parName;
            ParValue = parValue;
            ParType = parType;
        }


        public SqlDbParameter(string parName, object parValue)
        {
            ParName = parName;
            ParValue = parValue;
        }

        public SqlDbParameter(string parName, object parValue, ParameterDirection direction)
        {
            ParName = parName;
            ParValue = parValue;
            Direction = direction;
        }


        public enum DbFieldType
        {
            Float = 0,
            Integer = 1,
            String = 2,
            Date = 3,
            DateTime = 4,
            Array = 5
        }
    }
}