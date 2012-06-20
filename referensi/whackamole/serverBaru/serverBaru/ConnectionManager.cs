using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace serverBaru
{
    class ConnectionManager
    {
        private string connectionString;
        private OracleConnection connection;

        #region "Constructor"

        public ConnectionManager(string connectionString)
        {
            connection = new OracleConnection(connectionString);
            this.connectionString = connectionString;
        }

        public ConnectionManager()
            : this("Data Source=(DESCRIPTION="
                + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))"
                + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));"
                + "User Id=fpprogjar;Password=fpprogjar;") { }

        #endregion

        #region "Properties"

        public string ConnectionString
        {
            set { connectionString = value; }
            get { return connectionString; }
        }

        public OracleConnection Connection
        {
            get { return connection; }
        }

        #endregion

        #region "TestConnection"

        public ConnectionState TestConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection.State;
        }
        #endregion

        #region "Private Method"

        private void AssignParameters(OracleCommand cmd, OracleParameter[] cmdParameters)
        {
            if (cmdParameters == null) return;
            foreach (OracleParameter p in cmdParameters)
                cmd.Parameters.Add(p);
        }

        private void AssignParameters(OracleCommand cmd, object[] parameterValues)
        {
            //if (cmd.Parameters.Count - 1 = parameterValues.Length) throw new ApplicationException("Stored procedure's parameters and parameter values does not match.");
            //int i;
            //foreach (OracleParameter p in cmd.Parameters)
            //{
            //    if(p.Direction = Paramete
            //}
        }

        #endregion

        #region "Manage Connection"

        public void Open()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Close()
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "ExecuteNonQuery"

        public int ExecuteNonQuery(string cmd, OracleParameter[] parameters)
        {
            //OracleConnection connection = null;
            OracleTransaction transaction = null;
            OracleCommand command = null;
            int result = -1;
            try
            {
                // connection = new OracleConnection(connectionString);
                command = new OracleCommand(cmd, connection);
                if (parameters != null)
                    this.AssignParameters(command, parameters);
                connection.Open();
                transaction = connection.BeginTransaction();
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
                if (command != null)
                    command.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
            return result;
        }

        public int ExecuteNonQuery(string cmd)
        {
            return this.ExecuteNonQuery(cmd, null);
        }

        #endregion

        #region "ExecuteScalar"
        public Object ExecuteScalar(string cmd, OracleParameter[] parameters)
        {
            // OracleConnection connection = null;
            OracleTransaction transaction = null;
            OracleCommand command = null;
            Object result = null;

            try
            {
                //connection = new OracleConnection(connectionString);
                command = new OracleCommand(cmd, connection);
                if (parameters != null)
                    this.AssignParameters(command, parameters);
                connection.Open();
                transaction = connection.BeginTransaction();
                result = command.ExecuteScalar();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
                if (command != null)
                    command.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
            return result;
        }

        public Object ExecuteScalar(string cmd)
        {
            return ExecuteScalar(cmd, null);
        }
        #endregion

        #region "ExecuteReader"

        public OracleDataReader ExecuteReader(string cmd, OracleParameter[] parameters)
        {
            //OracleConnection connection = null;
            OracleCommand command = null;
            OracleDataReader result = null;
            try
            {
                //connection = new OracleConnection(connectionString);
                command = new OracleCommand(cmd, connection);
                connection.Open();
                if (parameters != null)
                    this.AssignParameters(command, parameters);
                result = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public OracleDataReader ExecuteReader(string cmd)
        {
            return this.ExecuteReader(cmd, null);
        }

        #endregion

        #region "FillDataSet"

        public DataSet FillDataSet(string cmd, OracleParameter[] parameters)
        {
            //OracleConnection connection = null;
            OracleCommand command = null;
            OracleDataAdapter adapter = null;
            DataSet result = new DataSet();
            try
            {
                //connection = new OracleConnection(connectionString);
                command = new OracleCommand(cmd, connection);
                if (parameters != null)
                    this.AssignParameters(command, parameters);
                adapter = new OracleDataAdapter(command);
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
                if (command != null)
                    command.Dispose();
            }
            return result;
        }

        public DataSet FillDataSet(string cmd)
        {
            return FillDataSet(cmd, null);
        }

        #endregion

        #region "ExecuteDataSet"

        public int ExecuteDataSet(OracleCommand insertCmd, OracleCommand updateCmd, OracleCommand deleteCmd, DataSet ds, string srcTable)
        {
            //OracleConnection connection = null;
            OracleDataAdapter adapter = null;
            int result = 0;
            try
            {
                //connection = new OracleConnection(connectionString);
                adapter = new OracleDataAdapter();
                if (insertCmd != null)
                {
                    insertCmd.Connection = connection;
                    adapter.InsertCommand = insertCmd;
                }
                if (updateCmd != null)
                {
                    updateCmd.Connection = connection;
                    adapter.UpdateCommand = updateCmd;
                }
                if (deleteCmd != null)
                {
                    deleteCmd.Connection = connection;
                    adapter.DeleteCommand = deleteCmd;
                }
                result = adapter.Update(ds, srcTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
                if (insertCmd != null)
                    insertCmd.Dispose();
                if (updateCmd != null)
                    updateCmd.Dispose();
                if (deleteCmd != null)
                    deleteCmd.Dispose();
                if (adapter != null)
                    adapter.Dispose();
            }
            return result;
        }

        #endregion
    }
}
