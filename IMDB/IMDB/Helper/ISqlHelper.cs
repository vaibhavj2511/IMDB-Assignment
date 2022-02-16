using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SessionDemoApp.Helper
{
    public interface ISqlHelper<G>
    {
        void Execute(string sql, object param = null);
        IEnumerable<G> Query(string sql, object param = null);
        G SingleQuery(string sql, object param = null);
        int Insert(string sql, object param = null);
    }
}
