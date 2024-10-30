using System.Collections.Generic;

namespace Retards.DAL.BDD
{
    public interface IDepot_DAL<T_DAL>
    {
        T_DAL Insert(T_DAL entity);
        
        T_DAL? GetById(int id);

        public IEnumerable<T_DAL> GetAll();

        public T_DAL GetBetweenDates(DateTime dateDebut, DateTime dateFin );
        
        
        
    
    }
}

