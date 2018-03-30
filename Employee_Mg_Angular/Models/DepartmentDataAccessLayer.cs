using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Mg_Angular.Models
{
    public class DepartmentDataAccessLayer
    {
        string connectionString = "Data Source = (localdb)\\mssqllocaldb; Initial Catalog = EmployeeManagement; Integrated Security = True";

        //To View all Department details
        public IEnumerable<DepartmentMaster1> GetAllDepartment()
        {
            try
            {
                List<DepartmentMaster1> lstdepartment = new List<DepartmentMaster1>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ManageDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Department_Id", 0);
                    cmd.Parameters.AddWithValue("@Department_Name", "");
                    cmd.Parameters.AddWithValue("@Query", 5);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        DepartmentMaster1 department = new DepartmentMaster1();

                        department.ID = Convert.ToInt32(rdr["Department_Id"]);
                        department.Name = rdr["Department_Name"].ToString();
                        lstdepartment.Add(department);
                    }
                    con.Close();
                }
                return lstdepartment;
            }
            catch
            {
                throw;
            }
        }

        //To Add new Department record 
        public int AddDepartment(DepartmentMaster1 department)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ManageDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Department_Id", 0);
                    cmd.Parameters.AddWithValue("@Department_Name", department.Name);
                    cmd.Parameters.AddWithValue("@Query", 1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Department
        public int UpdatedDepartment(DepartmentMaster1 department)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ManageDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Department_Id", department.ID);
                    cmd.Parameters.AddWithValue("@Department_Name", department.Name);
                    cmd.Parameters.AddWithValue("@Query", 2);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Department
        public DepartmentMaster1 GetdDepartmentData(int id)
        {
            try
            {
                DepartmentMaster1 department = new DepartmentMaster1();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ManageDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Department_Id", id);
                    cmd.Parameters.AddWithValue("@Department_Name", "");
                    cmd.Parameters.AddWithValue("@Query", 4);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        department.ID = Convert.ToInt32(rdr["Department_Id"]);
                        department.Name = rdr["Department_Name"].ToString();
                    }
                    con.Close();
                  
                }
                return department;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular Department
        public int DeletedDepartment(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ManageDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Department_Id", id);
                    cmd.Parameters.AddWithValue("@Department_Name", "");
                    cmd.Parameters.AddWithValue("@Query", 3);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                   
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

    }
}
