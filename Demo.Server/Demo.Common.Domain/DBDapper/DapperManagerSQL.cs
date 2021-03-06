using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Domain.DBDapper
{
    public class DapperManagerSQL
    {
        private DapperManagerSQL()
        {
            ReConnect();
        }
        private static DapperManagerSQL _Obj { get; set; }

        public SqlConnection _conn { get; set; }
        public SqlConnection Conn
        {
            get
            {
                if (_conn == null)
                    ReConnect();
                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    try
                    {
                        _conn.Open();
                    }
                    catch
                    {
                        ReConnect();
                    }
                }

                return _conn;
            }
        }

        private void ReConnect()
        {
            _conn = new SqlConnection(@"Data source=ADMIN\SQLEXPRESS;initial catalog=FullDemo;persist security info=True;password=haley@400402;user id=sa;MultipleActiveResultSets=True;App=EntityFramework");
            _conn.Open();
        }
        public static DapperManagerSQL Instance
        {
            get
            {
                if (_Obj == null)
                    _Obj = new DapperManagerSQL();
                return _Obj;
            }
        }

        public void Dispose()
        {
            _conn.Close();
            _conn.Dispose();
        }
    }
}
