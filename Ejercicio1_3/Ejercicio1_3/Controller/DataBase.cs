using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejercicio1_3.Models;

namespace Ejercicio1_3.Controller
{
 
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        //creacion de BD
        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);
            dbase.CreateTableAsync<Models.Personas>(); 
        }

        //crud
        #region OperacionesPersona
        public Task<int> GuardarPersona(Personas persona)
        {
            if (persona.id != 0)
            {
                return dbase.UpdateAsync(persona);
            }
            else
            {
                return dbase.InsertAsync(persona);
            }

        }  

        //mostrar personas
         public Task<List<Personas>> getListPersonas()
        {
            return dbase.Table<Personas>().ToListAsync();
        }
        //mostrar una persona
        public Task<Personas> getPersona(int pid)
        {
            return dbase.Table<Personas>() 
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePersona(Personas persona)
        {
            return dbase.DeleteAsync(persona);
        }
        #endregion OperacionesPersona

    }
}
