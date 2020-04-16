using PicturebotGUI.src.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PicturebotGUI.src.Database
{
    public class SqliteDataAccess
    {
        public static Metadata LoadMetadata(string path)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var meta = cnn.Query<Metadata>($"select * from Metadata where Path = '{path}'", new DynamicParameters());
                
                return meta.First();
            }
        }

        public static void SaveMetadata(Metadata meta)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Metadata(Path, Name, Shoot, Description) values(@Path, @Name, @Shoot, @Description)", meta);
            }
        }
        
        private static string LoadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
