using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class checking : Accounts
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

        public void ChckToSav(string sUser, string chUser, double amount)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select chAccBalance from checking where chAccUserName = @chAccUserName", con);
            SqlCommand cmd2 = new SqlCommand("select sAccBalance from saving where sAccUserName = @sAccUserName", con);
            SqlCommand cmd3 = new SqlCommand("update checking set chAccBalance=(chAccBalance-@amountToTransfer) where chAccUserName = @chAccUserName", con);
            SqlCommand cmd4 = new SqlCommand("update saving set sAccBalance=(sAccBalance+@amountToTransfer) where sAccUserName = @sAccUserName", con);

            cmd.Parameters.AddWithValue("@chAccUserName", chUser);
            cmd2.Parameters.AddWithValue("@sAccUserName", sUser);
            cmd3.Parameters.AddWithValue("@chAccUserName", chUser);
            cmd3.Parameters.AddWithValue("@amountToTransfer", amount);
            cmd4.Parameters.AddWithValue("@sAccUserName", sUser);
            cmd4.Parameters.AddWithValue("@amountToTransfer", amount);

            con.Open();
            SqlDataReader checking = cmd3.ExecuteReader();
            checking.Close();
            SqlDataReader saving = cmd4.ExecuteReader();
            saving.Close();
            con.Close();


        }

        public checking Search(int p_accNo)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select * from checking where chAccNo=@chAccNo", con);
            cmd.Parameters.AddWithValue("@chAccNo", p_accNo);
            con.Open();
            try
            {
                SqlDataReader readARow = cmd.ExecuteReader();
                if (readARow.Read())
                {
                    checking accounts = new checking()
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

        public override bool Login(string username, string password)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select count(*) from checking where chAccUserName=@username and chAccPassWord=@password", con);
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

        public string AddNewAccount(string chAccType,int chAccNo, int chAccPin, string chAccBranch, double chAccBalance, double chDailyLimit, bool chAccisActive, string chAccUserName, string chAccPassWord)
        {

            SqlCommand cmd = new SqlCommand("insert into checking values(@chAccType,@chAccNo,@chAccPin,@chAccBranch,@chAccBalance,@chDailyLimit,@chAccIsActive,@chAccUsername,@chAccPassWord)", con);

            cmd.Parameters.AddWithValue("chAccType", chAccType);
            cmd.Parameters.AddWithValue("chAccNo", chAccNo);
            cmd.Parameters.AddWithValue("chAccPin", chAccPin);
            cmd.Parameters.AddWithValue("chAccBranch", chAccBranch);
            cmd.Parameters.AddWithValue("chAccBalance", chAccBalance);
            cmd.Parameters.AddWithValue("chDailyLimit", chDailyLimit);
            cmd.Parameters.AddWithValue("chAccisActive", chAccisActive);
            cmd.Parameters.AddWithValue("chAccUserName", chAccUserName);
            cmd.Parameters.AddWithValue("chAccPassWord", chAccPassWord);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return ("Employee added successfully");

        }

        public string DeleteAccount(string chAccUsername)
        {
            SqlCommand cmd = new SqlCommand("delete from checking where chAccUserName=@chAccUserName", con);

            cmd.Parameters.AddWithValue("chAccUsername", chAccUsername);

            con.Open();
            cmd.ExecuteNonQuery();
            return ("Employee deleted successfully");

            con.Close();

        }

        public List<checking> GetAllAccounts()
        {
            SqlCommand cmd0 = new SqlCommand("select * from checking", con);
            SqlCommand cmd = new SqlCommand("select * from checking", con);
            con.Open();

            SqlDataReader readAllRows = cmd.ExecuteReader();
            List<checking> aList = new List<checking>();
            while (readAllRows.Read())
            {
                aList.Add(new checking()
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

        public void Edit(string user, string input, int chice)
        {

            switch (chice)
            {

                case 1:
                    SqlCommand sqlCommand = new SqlCommand("update checking set chAccType = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand.Parameters.AddWithValue("@input", input);
                    sqlCommand.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    break;
                case 2:
                    SqlCommand sqlCommand2 = new SqlCommand("update checking set chAccNo = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand2.Parameters.AddWithValue("@input", input);
                    sqlCommand2.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand2.ExecuteNonQuery();
                    con.Close();
                    break;
                case 3:
                    SqlCommand sqlCommand3 = new SqlCommand("update checking set chAccPin = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand3.Parameters.AddWithValue("@input", input);
                    sqlCommand3.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand3.ExecuteNonQuery();
                    con.Close();
                    break;
                case 4:
                    SqlCommand sqlCommand4 = new SqlCommand("update checking set chAccBranch = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand4.Parameters.AddWithValue("@input", input);
                    sqlCommand4.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand4.ExecuteNonQuery();
                    con.Close();
                    break;
                case 5:
                    SqlCommand sqlCommand5 = new SqlCommand("update checking set chAccBalance = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand5.Parameters.AddWithValue("@input", input);
                    sqlCommand5.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand5.ExecuteNonQuery();
                    con.Close();
                    break;
                case 6:
                    SqlCommand sqlCommand6 = new SqlCommand("update checking set chDailyLimit = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand6.Parameters.AddWithValue("@input", input);
                    sqlCommand6.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand6.ExecuteNonQuery();
                    con.Close();

                    break;
                case 7:
                    SqlCommand sqlCommand7 = new SqlCommand("update checking set chAccIsActive = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand7.Parameters.AddWithValue("@input", input);
                    sqlCommand7.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand7.ExecuteNonQuery();
                    con.Close();

                    break;
                case 8:
                    SqlCommand sqlCommand8 = new SqlCommand("update checking set chAccUserName = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand8.Parameters.AddWithValue("@input", input);
                    sqlCommand8.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand8.ExecuteNonQuery();
                    con.Close();

                    break;
                case 9:
                    SqlCommand sqlCommand9 = new SqlCommand("update checking set chAccPassWord = @input where chAccUserName = @chAccUserName", con);
                    sqlCommand9.Parameters.AddWithValue("@input", input);
                    sqlCommand9.Parameters.AddWithValue("@chAccUserName", user);
                    con.Open();
                    sqlCommand9.ExecuteNonQuery();
                    con.Close();

                    break;

            }






        }

        public static checking Details(string user)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select * from checking where chAccUserName = @chAccUserName", con);
            cmd.Parameters.AddWithValue("@chAccUserName", user);
            con.Open();
            try
            {
                SqlDataReader readARow = cmd.ExecuteReader();
                if (readARow.Read())
                {
                    checking accounts = new checking()
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

        public void Withdraw(string username, double amountToWithdraw)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand sql = new SqlCommand("update checking set chAccBalance = (chAccBalance - @amountToWithdraw) where chAccUserName = @chAccUserName", con);

            sql.Parameters.AddWithValue("@amountToWithdraw", amountToWithdraw);
            sql.Parameters.AddWithValue("@chAccUserName", username);

            con.Open();
            sql.ExecuteNonQuery();

            con.Close();

        }

        public void Deposit(string username, double amountToDeposit)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand sql = new SqlCommand("update checking set chAccBalance = (chAccBalance + @amountToDeposit) where chAccUserName = @chAccUserName", con);

            sql.Parameters.AddWithValue("@amountToDeposit", amountToDeposit);
            sql.Parameters.AddWithValue("@chAccUserName", username);

            con.Open();
            sql.ExecuteNonQuery();

            con.Close();

        }

        public bool PwChck(string password)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from checking where chAccPassWord=@password", con);
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
            SqlCommand sql = new SqlCommand("update checking set chAccPassWord = @accPassWord where chAccUserName = @chAccUserName", con);

            sql.Parameters.AddWithValue("accPassWord", password);
            sql.Parameters.AddWithValue("chAccUserName", username);


            con.Open();
            sql.ExecuteNonQuery();

            con.Close();


            return ("Password updated successfully");
        }






    }
}
