using System.Collections.Generic;
using SessionDemoApp.Helper;
using SessionDemoApp.Models;

namespace SessionDemoApp.Repository
{
    public class ProducerRepository : IProducerRepository
    {

        private readonly ISqlHelper<Producer> _sqlHelper;
        public ProducerRepository(ISqlHelper<Producer> sqlHelper)
        {
            this._sqlHelper = sqlHelper;
        }

        public Producer GetById(int id)
        {
            string sql = @"SELECT Id [Id]
	                               ,Name [Name]
	                               ,DOB [DOB]
	                               ,Bio [Bio]
	                               ,Gender [Gender]
                            FROM Producers
                            WHERE Id = @id";


            return _sqlHelper.SingleQuery(sql, new { id });
        }

    }
}
