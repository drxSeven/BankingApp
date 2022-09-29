using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace test
{
    internal class saving : Accounts
    {

        public string newAccType { get; set; }
        public int accNo { get; set; }
        public int accPin { get; set; }
        public string accBranch { get; set; }
        public double accBalance { get; set; }
        public double accDailyLimit { get; set; }
        public bool accIsActive { get; set; }
        public string aUsername { get; set; }
        public string aPassWord { get; set; }


        SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");

        public string AddNewAccount(string sAccType,int sAccNo, int sAccPin, string sAccBranch, double sAccBalance, double sAccDailyLimit, bool sAccisActive, string sAccUserName, string sAccPassWord)
        {

            SqlCommand cmd = new SqlCommand("insert into saving values(@sAccType,@sAccNo,@sAccPin,@sAccBranch,@sAccBalance,@sAccDailyLimit,@sAccisActive,@sAccUserName,@sAccPassWord)", con);

            cmd.Parameters.AddWithValue("sAccType", sAccType);
            cmd.Parameters.AddWithValue("sAccNo", sAccNo);
            cmd.Parameters.AddWithValue("sAccPin", sAccPin);
            cmd.Parameters.AddWithValue("sAccBranch", sAccBranch);
            cmd.Parameters.AddWithValue("sAccBalance", sAccBalance);
            cmd.Parameters.AddWithValue("sAccDailyLimit", sAccDailyLimit);
            cmd.Parameters.AddWithValue("sAccisActive", sAccisActive);
            cmd.Parameters.AddWithValue("sAccUserName", sAccUserName);
            cmd.Parameters.AddWithValue("sAccPassWord", sAccPassWord);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return ("Employee added successfully");

        }

        public override bool Login(string username, string password)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select count(*) from saving where sAccUserName=@username and sAccPassWord=@password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            con.Open();
            int result = (int)cmd.ExecuteScalar();
            con.Close();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string DeleteAccount(string sAccUsername)
        {
            SqlCommand cmd = new SqlCommand("delete from saving where sAccUserName=@sAccUserName", con);

            cmd.Parameters.AddWithValue("sAccUsername", sAccUsername);

            con.Open();
            cmd.ExecuteNonQuery();
            return ("Employee deleted successfully");

            con.Close();

        }

        public static saving Search(int p_accNo)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select * from saving where sAccNo=@sAccNo", con);
            cmd.Parameters.AddWithValue("@sAccNo", p_accNo);
            con.Open();
            try
            {
                SqlDataReader readARow = cmd.ExecuteReader();
                if (readARow.Read())
                {
                    saving accounts = new saving()
                    {
                        newAccType = Convert.ToString(readARow[0]),
                        accNo = Convert.ToInt32(readARow[1]),
                        accPin = Convert.ToInt32(readARow[2]),
                        accBranch = readARow[3].ToString(),
                        accBalance = Convert.ToDouble(readARow[4]),
                        accDailyLimit = Convert.ToDouble(readARow[5]),
                        accIsActive = Convert.ToBoolean(readARow[6]),
                        aUsername = readARow[7].ToString(),
                        aPassWord = readARow[8].ToString(),

                    }; return accounts;
                }
                else
                {
                    throw new Exception("Employee Not Found");
                }
            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }

            con.Close();
            return null;

        }

        public List<saving> GetAllAccounts()
        {
            SqlCommand cmd0 = new SqlCommand("select * from saving", con);
            SqlCommand cmd = new SqlCommand("select * from saving", con);
            con.Open();

            SqlDataReader readAllRows = cmd.ExecuteReader();
            List<saving> aList = new List<saving>();
            while (readAllRows.Read())
            {
                aList.Add(new saving()
                {
                    newAccType = readAllRows[0].ToString(),
                    accNo = Convert.ToInt32(readAllRows[1]),
                    accPin = Convert.ToInt32(readAllRows[2]),
                    accBranch = readAllRows[3].ToString(),
                    accBalance = Convert.ToDouble(readAllRows[4]),
                    accDailyLimit = Convert.ToDouble(readAllRows[5]),
                    accIsActive = Convert.ToBoolean(readAllRows[6]),
                    aUsername = readAllRows[7].ToString(),
                    aPassWord = readAllRows[8].ToString(),
                });
            }
            con.Close();
            return aList;

        }

         public void Withdraw(string username, double amountToWithdraw)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand sql = new SqlCommand("update saving set sAccBalance = (sAccBalance - @amountToWithdraw) where sAccUserName = @sAccUserName", con);

            sql.Parameters.AddWithValue("@amountToWithdraw", amountToWithdraw);
            sql.Parameters.AddWithValue("@sAccUserName", username);

            con.Open();
            sql.ExecuteNonQuery();

            con.Close();

        }

        public void Deposit(string username, double amountToDeposit)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand sql = new SqlCommand("update saving set sAccBalance = (sAccBalance + @amountToDeposit) where sAccUserName = @sAccUserName", con);

            sql.Parameters.AddWithValue("@amountToDeposit", amountToDeposit);
            sql.Parameters.AddWithValue("@sAccUserName", username);

            con.Open();
            sql.ExecuteNonQuery();

            con.Close();

        }


        public static saving Details(string user)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select * from saving where sAccUserName = @sAccUserName", con);
            cmd.Parameters.AddWithValue("@sAccUserName", user);
            con.Open();
            try
            {
                SqlDataReader readARow = cmd.ExecuteReader();
                if (readARow.Read())
                {
                    saving accounts = new saving()
                    {
                        newAccType = Convert.ToString(readARow[0]),
                        accNo = Convert.ToInt32(readARow[1]),
                        accPin = Convert.ToInt32(readARow[2]),
                        accBranch = readARow[3].ToString(),
                        accBalance = Convert.ToDouble(readARow[4]),
                        accDailyLimit = Convert.ToDouble(readARow[5]),
                        accIsActive = Convert.ToBoolean(readARow[6]),
                        aUsername = readARow[7].ToString(),
                        aPassWord = readARow[8].ToString(),

                    }; return accounts;
                }
                else
                {
                    throw new Exception("Employee Not Found");
                }
            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }

            con.Close();
            return null;

        }


        public void SavToChck(string sUser, string chUser, double amount)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select sAccBalance from saving where sAccUserName = @sAccUserName", con);
            SqlCommand cmd2 = new SqlCommand("select chAccBalance from checking where chAccUserName = @chAccUserName", con);
            SqlCommand cmd3 = new SqlCommand("update saving set sAccBalance=(sAccBalance-@amountToTransfer) where sAccUserName = @sAccUserName", con);
            SqlCommand cmd4 = new SqlCommand("update checking set chAccBalance=(chAccBalance+@amountToTransfer) where chAccUserName = @chAccUserName",con);

            cmd.Parameters.AddWithValue("@sAccUserName", sUser);
            cmd2.Parameters.AddWithValue("@chAccUserName", chUser);
            cmd3.Parameters.AddWithValue("@sAccUserName", sUser);
            cmd3.Parameters.AddWithValue("@amountToTransfer", amount);
            cmd4.Parameters.AddWithValue("@chAccUserName", chUser);
            cmd4.Parameters.AddWithValue("@amountToTransfer", amount);

            con.Open();
            SqlDataReader checking = cmd3.ExecuteReader();
            checking.Close();
            SqlDataReader saving = cmd4.ExecuteReader();
            saving.Close();
            con.Close();


        }



        public void Edit(string user, string input, int chice)
        {

            switch (chice)
            {

                case 1:
                    SqlCommand sqlCommand = new SqlCommand("update saving set sAccType = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand.Parameters.AddWithValue("@input", input);
                    sqlCommand.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    break;
                case 2:
                    SqlCommand sqlCommand2 = new SqlCommand("update saving set sAccNo = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand2.Parameters.AddWithValue("@input", input);
                    sqlCommand2.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand2.ExecuteNonQuery();
                    con.Close();
                    break;
                case 3:
                    SqlCommand sqlCommand3 = new SqlCommand("update saving set sAccPin = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand3.Parameters.AddWithValue("@input", input);
                    sqlCommand3.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand3.ExecuteNonQuery();
                    con.Close();
                    break;
                case 4:
                    SqlCommand sqlCommand4 = new SqlCommand("update saving set sAccBranch = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand4.Parameters.AddWithValue("@input", input);
                    sqlCommand4.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand4.ExecuteNonQuery();
                    con.Close();
                    break;
                case 5:
                    SqlCommand sqlCommand5 = new SqlCommand("update saving set sAccBalance = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand5.Parameters.AddWithValue("@input", input);
                    sqlCommand5.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand5.ExecuteNonQuery();
                    con.Close();
                    break;
                case 6:
                    SqlCommand sqlCommand6 = new SqlCommand("update saving set sDailyLimit = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand6.Parameters.AddWithValue("@input", input);
                    sqlCommand6.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand6.ExecuteNonQuery();
                    con.Close();

                    break;
                case 7:
                    SqlCommand sqlCommand7 = new SqlCommand("update saving set sAccIsActive = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand7.Parameters.AddWithValue("@input", input);
                    sqlCommand7.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand7.ExecuteNonQuery();
                    con.Close();

                    break;
                case 8:
                    SqlCommand sqlCommand8 = new SqlCommand("update saving set sAccUserName = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand8.Parameters.AddWithValue("@input", input);
                    sqlCommand8.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand8.ExecuteNonQuery();
                    con.Close();

                    break;
                case 9:
                    SqlCommand sqlCommand9 = new SqlCommand("update saving set sAccPassWord = @input where sAccUserName = @sAccUserName", con);
                    sqlCommand9.Parameters.AddWithValue("@input", input);
                    sqlCommand9.Parameters.AddWithValue("@sAccUserName", user);
                    con.Open();
                    sqlCommand9.ExecuteNonQuery();
                    con.Close();

                    break;

            }






        }

        public bool PwChck(string password)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from saving where sAccPassWord=@password", con);
            cmd.Parameters.AddWithValue("@password", password);

            con.Open();
            int result = (int)cmd.ExecuteScalar();
            con.Close();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        public string UpdatePW(string password, string username)
        {
            SqlCommand sql = new SqlCommand("update saving set sAccPassWord = @accPassWord where sAccUserName = @sAccUserName", con);

            sql.Parameters.AddWithValue("accPassWord", password);
            sql.Parameters.AddWithValue("sAccUserName", username);


            con.Open();
            sql.ExecuteNonQuery();

            con.Close();


            return ("Password updated successfully");
        }



    }






}

