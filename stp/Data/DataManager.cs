using stp.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace stp.Data
{
    internal class DataManager
    {   
        private static DataManager instance = null;
        private static readonly object padlock = new object();
        private ObservableCollection<Employee> employeeCollection;
        private ObservableCollection<Training> trainingCollection;

        StpDataContext test;

        #region Sql DataTypes
        private SqlConnection goliath;
        private SqlConnectionStringBuilder conBuilder;
        private DataTable dt;
        #endregion

        #region const sql connection 
        private const string userid = "SS16_STP";
        private const string password = "pKn_1620";
        private const string serverurl = "goliath.wi.fh-flensburg.de";
        private const string database = "SS16_STP";
        #endregion
        public DataManager()
        {
            conBuilder = new SqlConnectionStringBuilder();

            conBuilder.UserID = userid;
            conBuilder.Password = password;
            conBuilder.DataSource = serverurl;
            conBuilder.InitialCatalog = database;

            goliath = new SqlConnection(conBuilder.ConnectionString);

            test = new StpDataContext();

        }

        #region SelectFromEmployees

        public ObservableCollection<Employee> SelectFromEmployees()
        {

            SqlCommand sqlCommand = new SqlCommand(
                @"SELECT E.ID, E.firstName, E.name, E.city, E.birth, E.email, E.date_of_joining, E.status, D.name as department from TBL_EMPLOYEE E
                    JOIN TBL_DEPARTMENT D on D.ID = E.fk_dep
                  WHERE E.status = 1",
                goliath);

            return BuildEmployeeCollectionFromQuey(sqlCommand);

        }
        public ObservableCollection<Employee> SelectArchivedFromEmployees()
        {

            SqlCommand sqlCommand = new SqlCommand(
                @"SELECT E.ID, E.firstName, E.name, E.city, E.birth, E.email, E.date_of_joining, E.status, D.name as department from TBL_EMPLOYEE E
                    JOIN TBL_DEPARTMENT D on D.ID = E.fk_dep",
                goliath);

            return BuildEmployeeCollectionFromQuey(sqlCommand);

        }
        public ObservableCollection<Employee> SelectFromEmployees(string paramColumnName, string paramFilterValue)
        {

            SqlCommand sqlCommand = new SqlCommand(
                @"SELECT E.ID, E.firstName, E.name, E.city, E.birth, E.email, E.date_of_joining, E.status, D.name as department from TBL_EMPLOYEE E
                    JOIN TBL_DEPARTMENT D on D.ID = E.fk_dep
                  WHERE E.status = 1  
                  AND " + paramColumnName + " like '%" + paramFilterValue + "%'",
                goliath);

            return BuildEmployeeCollectionFromQuey(sqlCommand);

        }

        public void ArchiveFromEmployee(int paramId)
        {
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE TBL_EMPLOYEE 
                                                     SET status = 0
                                                     WHERE ID=" + paramId, goliath);

            try
            {
                goliath.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.Assert(false, e.Message);
            }
            finally
            {
                goliath.Close();
            }
        }

        public ObservableCollection<Training> BuildTrainingCollectionFromQuey(SqlCommand paramSqlCommand)
        {
            if (dt == null)
                dt = new DataTable();

            if (trainingCollection == null)
                trainingCollection = new ObservableCollection<Training>();

            trainingCollection.Clear();

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = paramSqlCommand;

            try
            {
                goliath.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                dt.Load(sqlDataReader);

                foreach (DataRow dr in dt.Rows)
                {
                    trainingCollection.Add((Training)dr);
                }
            }

            catch (Exception e)
            {
                Debug.Assert(false, e.Message);
            }

            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();

                dt.Clear();
                goliath.Close();
            }

            return trainingCollection;
        }
        public ObservableCollection<Employee> BuildEmployeeCollectionFromQuey(SqlCommand paramSqlCommand)
        {
            if (dt == null)
                dt = new DataTable();
                       
            if (employeeCollection == null)
                employeeCollection = new ObservableCollection<Employee>();

            employeeCollection.Clear();

            SqlDataReader sqlDataReader  = null;
            SqlCommand sqlCommand = paramSqlCommand;

            try
            {
                //goliath.Open();
                //sqlDataReader = sqlCommand.ExecuteReader();
                //dt.Load(sqlDataReader);

                //foreach (DataRow dr in dt.Rows)
                //{
                //    employeeCollection.Add((Employee)dr);
                //}

                var dataRows = from employees in test.TBL_EMPLOYEEs
                               select employees;

                foreach (var item in dataRows)
                {
                    employeeCollection.Add((Employee)item);
                }
            }

            catch (Exception e)
            {
                Debug.Assert(false, e.Message);
            }

            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();

                dt.Clear();
                goliath.Close();
            }

            return employeeCollection;
        }

        #endregion

        #region Singleton
        public static DataManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DataManager();
                    }
                    return instance;
                }
            }
        }
        #endregion
    }
}
