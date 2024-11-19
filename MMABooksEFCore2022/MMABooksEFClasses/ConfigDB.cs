using System;

using Microsoft.Extensions.Configuration;

/*
 * dotnet tool install --global dotnet-ef
 * Use nuget package manager to install efcore, efcore.analyzers, design, tools and mysql.data.efcore
 * -- Install-Package Microsoft.EntityFrameworkCore.Tools could do from the console too
 * Get-Help about_EntityFrameworkCore from the console
 *        
 *      Scaffold-DbContext "server=127.0.0.1;uid=root;pwd=420fouR20!69;database=MMABooks; Port=3308;" MySql.Data.EntityFrameworkCore -OutputDir Models -context MMABooksContext -project MMABooksEFClasses -startupproject MMABooksEFClasses -force
 * this line of code worked     Scaffold-DbContext "server=127.0.0.1;uid=root;pwd=420fouR20!69;database=MMABooks; Port=3308;" Pomelo.EntityFrameworkCore.MySql -OutputDir Models -context MMABooksContext -project MMABooksEFClasses -startupproject MMABooksEFClasses -force
 *     
 *     <code below gets added to MMABooksContext.cs c# file>
 *STRING CONNECTIONSTRING = CONFIGDB.GETMYSQLCONNECTIONSTRING();
 *IF (!OPTIONSBUILDER.ISCONFIGURED)
 *  {
	    VAR SERVERVERSION = NEW MYSQLSERVERVERSION(NEW VERSION(8, 0));
	    OPTIONSBUILDER.USEMYSQL(CONNECTIONSTRING, SERVERVERSION);
    }
 *
 *
 *
 *
 */
namespace MMABooksEFClasses
{
    public class ConfigDB
    {
        public static string GetMySqlConnectionString()
        {
            string folder = System.AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                    .SetBasePath(folder)
                    .AddJsonFile("mySqlSettings.json", optional: true, reloadOnChange: true);

            string connectionString = builder.Build().GetConnectionString("mySql");

            return connectionString;
        }
    }
}
