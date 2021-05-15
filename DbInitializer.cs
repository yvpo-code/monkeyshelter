using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PostgresCRUD.Models;
using PostgresCRUD.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
//using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
 using System.Text.Json;
 using System.Text.Json.Serialization;

namespace monkey_shelter
{
public class DbInitializer
{
    //TODO Transactional?
    public static void Initialize(IServiceProvider services)
    {
        using(var context = new PostgreSqlContext(
                services.GetRequiredService<
                    DbContextOptions<PostgreSqlContext>>()))
        {
        // Get a logger
        var logger = services.GetRequiredService<ILogger<DbInitializer>>();
        IDataAccessProvider dbProvider = services.GetRequiredService<IDataAccessProvider>();

        if (context.monkeys.Any())
        {
            logger.LogInformation("DB not empty");
            return;
        }

        logger.LogInformation("Start seeding DB...");

string MonkeyJson = File.ReadAllText("monkeycollection.json");

var options = new JsonSerializerOptions {
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
    };
    options.Converters.Add(new JsonDateTimeConverter());

            List<Monkey> MonkeyList = JsonSerializer.Deserialize<List<Monkey>>(MonkeyJson, options);

            MonkeyList.ForEach((monkey) => dbProvider.AddMonkeyRecord(monkey));

        logger.LogInformation("Finished seeding DB.");
        }
    }
}
}