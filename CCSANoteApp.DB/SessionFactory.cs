using CCSANoteApp.DB.Configurations;
using CCSANoteApp.DB.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CCSANoteApp.DB
{
    public class SessionFactory
    {
        private readonly string _conString;
        public SessionFactory(string conString)
        {
            _conString = conString;
            if (_sessionFactory is null)
            {
                _sessionFactory = BuildSessionFactory(_conString);
            }
        }

        public ISession GetSession() => _sessionFactory.OpenSession();

        private readonly ISessionFactory _sessionFactory;

        private ISessionFactory BuildSessionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(NoteMap).Assembly))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(true, true);
                });
            return configuration.BuildSessionFactory();
        }

        
        
    }
}
