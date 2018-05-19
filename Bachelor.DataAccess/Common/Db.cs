using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.DataAccess.Common
{
    internal sealed class Db
    {

        #region Private Variables

        /// <summary>
        /// db
        /// </summary>
        private readonly Database _db;

        private string connectionString = ConfigurationManager.ConnectionStrings["BachelorConnection"].ConnectionString;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataBaseName">dataBaseName</param>
        internal Db()
        {
            _db = new SqlDatabase(connectionString);
        }

        #endregion
        
        #region ExecuteNonQuery

        /// <summary>
        /// ExecuteNonQuery.
        /// </summary>
        /// <param name="sprocName">sprocName</param>
        /// <param name="param">param</param>
        /// <returns>int</returns>
        internal int ExecuteNonQuery(string sprocName, object[] param)
        {
            return _db.ExecuteNonQuery(sprocName, param);
        }

        /// <summary>
        /// ExcuteNonQuery
        /// </summary>
        /// <param name="command">command</param>
        /// <returns>int</returns>
        internal int ExecuteNonQuery(DbCommand command)
        {
            return _db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Gets DbCommand for the passed Procedurename and parameters
        /// </summary>
        /// <param name="sprocName">sprocName</param>
        /// <param name="param">param</param>
        /// <returns>DbCommand</returns>
        internal DbCommand GetCommand(string sprocName, object[] param)
        {
            DbCommand dbCommand = null;

            dbCommand = _db.GetStoredProcCommand(sprocName, param);

            return dbCommand;
        }

        /// <summary>
        /// Gets StoredProc Command.
        /// </summary>
        /// <param name="storedProcedureName">storedProcedureName</param>
        /// <returns>DbCommand</returns>
        internal DbCommand GetStoredProcCommand(string storedProcedureName)
        {
            return _db.GetStoredProcCommand(storedProcedureName);
        }

        /// <summary>
        /// Adds In Parameter.
        /// </summary>
        /// <param name="command">command</param>
        /// <param name="name">name</param>
        /// <param name="dbType">dbType</param>
        /// <param name="value">value</param>
        internal void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            _db.AddInParameter(command, name, dbType, value);
        }

        /// <summary>
        /// Adds Out Parameter.
        /// </summary>
        /// <param name="command">command</param>
        /// <param name="name">name</param>
        /// <param name="dbType">dbType</param>
        /// <param name="size">size</param>
        internal void AddOutParameter(DbCommand command, string name, DbType dbType, int size)
        {
            _db.AddOutParameter(command, name, dbType, size);
        }

        /// <summary>
        /// Gets DbCommand for the passed Procedurename and parameters.
        /// </summary>
        /// <param name="sprocName">sprocName</param>        
        /// <returns>DbCommand</returns>
        internal DbCommand GetCommand(string sprocName)
        {
            return _db.GetStoredProcCommand(sprocName);
        }

        /// <summary>
        /// Gets Parameter Value
        /// </summary>
        /// <param name="command">command</param>
        /// <param name="name">name</param>
        /// <returns>object</returns>
        internal object GetParameterValue(DbCommand command, string name)
        {
            return _db.GetParameterValue(command, name);
        }

        /// <summary>
        /// Executes DataSet.
        /// </summary>
        /// <param name="command">command</param>
        /// <returns>DataSet</returns>
        internal DataSet ExecuteDataSet(DbCommand command)
        {
            return _db.ExecuteDataSet(command);
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="sprocName">sprocName</param>
        /// <returns>IDataReader</returns>
        internal IDataReader ExecuteReader(string sprocName)
        {
            return _db.ExecuteReader(sprocName);
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="sprocName">sprocName</param>
        /// <returns>IDataReader</returns>
        internal IDataReader ExecuteReader(DbCommand dbCommand)
        {
            return _db.ExecuteReader(dbCommand);
        }

        #endregion
    }
}
