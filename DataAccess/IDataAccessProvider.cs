using PostgresCRUD.Models;  
using System.Collections.Generic;  
  
namespace PostgresCRUD.DataAccess  
{  
    public interface IDataAccessProvider  
    {  
        void AddMonkeyRecord(Monkey monkey);  
        List<SpeciesCount> GetSpeciesCount();
    }  
}