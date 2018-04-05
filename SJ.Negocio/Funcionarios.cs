using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJ.DAL;
using SubSonic;
namespace SJ.Negocio
{
    public partial class Funcionarios : SJ.DAL.Funcionario
    {
        public static FuncionarioCollection GetAll()
        {
            return new Select().From<Funcionario>().ExecuteAsCollection<FuncionarioCollection>();
        }

        public static FuncionarioCollection GetAllAtivos()
        {
            return new Select().From<Funcionario>()
                .Where(AtivoColumn).IsEqualTo(true)
                .ExecuteAsCollection<FuncionarioCollection>();
        }

        public static Funcionario GetById(long Id)
        {
            return new Funcionario(Id);
        }

        public static bool Delete(long Id)
        {
            try
            {
                new Delete().From<Funcionario>().Where(Funcionario.IdColumn).IsEqualTo(Id).Execute();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
