using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPIDemo
{
    public class PostGreSQLConnectionBuilder : ConnectionBuilder, IHostSelector, IPortSelector, IUserSelector, IPasswordSelector, IBuilder
    {
        private string _database;
        private string _host;
        private string _port;
        private string _username;
        private string _password;

        private PostGreSQLConnectionBuilder()
        {
        }
        private PostGreSQLConnectionBuilder(string database)
        {
            _database = database;
        }

        public static IHostSelector AddDatabase(string database)
        {
            return new PostGreSQLConnectionBuilder(database);
        }

        public IBuilder AndPassword(string password)
        {
            _password = password;
            return this;
        }

        public ConnectionBuilder Create()
        {
            ConnectionString = _username != null ? 
                $"Server={_host};Port={_port};Database={_database};User Id={_username};Password={_password};sslmode=Require;TrustServerCertificate=True;"
                : $"Server={_host};Port={_port};Database={_database};sslmode=Require;TrustServerCertificate=True;";
            return this;
        }

        public IPortSelector OnHost(string host)
        {
            _host = host;
            return this;
        }

        public IUserSelector OnPort(int port)
        {
            _port = port.ToString();
            return this;
        }

        public IPasswordSelector WithUser(string username)
        {
            _username = username;
            return this;
        }
    }

    public abstract class ConnectionBuilder
    {
        public string ConnectionString { get; set; }

        public virtual SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }
    }

    public interface IDatabaseSelector
    {
        IHostSelector AddDatabase(string database);
    }

    public interface IHostSelector
    {
        IPortSelector OnHost(string host);
    }

    public interface IPortSelector
    {
        IUserSelector OnPort(int port);
        ConnectionBuilder Create();
    }

    public interface IUserSelector
    {
        IPasswordSelector WithUser(string username);
        ConnectionBuilder Create();
    }

    public interface IPasswordSelector
    {
        IBuilder AndPassword(string password);
    }

    public interface IBuilder
    {
        ConnectionBuilder Create();
    }
}
