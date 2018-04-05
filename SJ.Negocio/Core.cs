using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJ.DAL;
using SubSonic;
using SubSonic.Utilities;

namespace SJ.Negocio
{
    public class Core
    {
        public static List<T> GetAll<T>(T value, string _Class)
        {
            return new Select().From(_Class).ToList();
            //return new List<T>();
        }
    }
}
