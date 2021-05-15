using PostgresCRUD.Models;
using System.Collections.Generic;  
using System.Linq;
using System;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
  
namespace PostgresCRUD.DataAccess  
{  
    public class DataAccessProvider: IDataAccessProvider  
    {  
        private readonly PostgreSqlContext _context; 
        private readonly IConfiguration _config;
  
        public DataAccessProvider(PostgreSqlContext context, IConfiguration config)  
        {  
            _context = context;
            _config = config;
        }  
  
        public void AddMonkeyRecord(Monkey monkey)  
        {  
            _context.monkeys.Add(monkey);  
            _context.SaveChanges();  
        }  
 
         // TODO: Separate "repository"
        public List<SpeciesCount> GetSpeciesCount()  
        {  
            var sqlConnectionString = _config.GetConnectionString("DefaultConnection");

            using var Connection = new NpgsqlConnection(sqlConnectionString);
            
            List<SpeciesCount> Report = new List<SpeciesCount>();
            
            try 
            {
                Connection.Open();

                string sql = "SELECT species, COUNT(*) AS count FROM monkeys GROUP BY species ORDER BY count DESC";
                using var cmd = new NpgsqlCommand(sql, Connection);

                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    SpeciesCount _count = new SpeciesCount();
                    _count.Species = rdr.GetString(0);
                    _count.Count = rdr.GetInt32(1);
                    Report.Add(_count);
                }
            }
            finally
            {
                Connection.Close();
            }
            return Report;
        }  
    }  
}
