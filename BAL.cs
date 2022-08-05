using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace register
{
    class BAL
    {
        DAL d = new DAL();
        public string name;
        public string family;
        public string stdno;
        public string address;
        public string telephone;
        public string majorid;
        public string sex;

        public void insert()
        {

            string sql = "Insert into registertbl (name,family,stdno,address,telephone,majorid,sex) VALUES (@A , @B , @C, @D , @E ,@F ,@G)";
            //
            String[] paramsArray = new String[7];
            String[] valuesArray = new String[7];
            paramsArray[0] = "@A";
            paramsArray[1] = "@B";
            paramsArray[2] = "@C";
            paramsArray[3] = "@D";
            paramsArray[4] = "@E";
            paramsArray[5] = "@F";
            paramsArray[6] = "@G";

            valuesArray[0] = this.name;
            valuesArray[1] = this.family;
            valuesArray[2] = this.stdno;
            valuesArray[3] = this.address;
            valuesArray[4] = this.telephone;
            valuesArray[5] = this.majorid;
            valuesArray[6] = this.sex;



            d.EXE(sql, paramsArray, valuesArray);
        }

        public bool check_login(string a, string b)
        {

            string sql = "SELECT majorid,stdno FROM registertbl WHERE stdno='" + a + "'  AND majorid='" + b + "'";

            d.EXE1(sql);
            d.dr = d.com.ExecuteReader();
            if (d.dr.Read())

                return true;


            else
                return false;

        }


        public DataTable showdata(String majorID)
        {
            d.connect();
            DataTable dt = d.Select("SELECT coursetbl.id, coursetbl.coursename, coursetbl.classtime, coursetbl.courseid, coursetbl.teachername FROM coursetbl WHERE (coursetbl.majorid = '" + majorID + "')");
            d.disconnect();
            return dt;


        }

        public static String[][] getMajors()
        {
            String[][] majors = new String[2][];
            majors[0] = new String[2];
            //
            majors[0][0] = "102";
            majors[0][1] = "ریاضی";
            //
            majors[1] = new String[2];
            majors[1][0] = "101";
            majors[1][1] = "نرم افزار";
            return majors;
        }



    }
}
