using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    abstract internal class Accounts
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

        virtual public bool  Login(string username, string password)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("select count(*) from accountInfo where accUserName=@username and accPassWord=@password", con);
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
        public string AddNewAccount(string newAccType, int aNo, int aPin, string aBranch, double aBalance, double aDailyLimit, bool aIsActive, string accUsername, string accPassWord)
        {

            SqlCommand cmd = new SqlCommand("insert into accountInfo values(@newAccType,@accNo,@accPin,@accBranch,@accBalance,@dailyLimit,@accIsActive,@accUsername,@accPassWord)", con);

            cmd.Parameters.AddWithValue("newAccType", newAccType);
            cmd.Parameters.AddWithValue("accNo", aNo);
            cmd.Parameters.AddWithValue("accPin", aPin);
            cmd.Parameters.AddWithValue("accBranch", aBranch);
            cmd.Parameters.AddWithValue("accBalance", aBalance);
            cmd.Parameters.AddWithValue("dailyLimit", aDailyLimit);
            cmd.Parameters.AddWithValue("accIsActive", aIsActive);
            cmd.Parameters.AddWithValue("accUsername", accUsername);
            cmd.Parameters.AddWithValue("accPassWord", accPassWord);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return ("Employee added successfully");

        }

        public string DeleteAccount(string accUsername)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand cmd = new SqlCommand("delete from accountInfo where accUserName=@accUserName", con);

            cmd.Parameters.AddWithValue("accUsername", accUsername);

            con.Open();
            cmd.ExecuteNonQuery();
            return ("Employee deleted successfully");

            con.Close();

        }

        virtual public void Withdraw(string username, double amountToWithdraw)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand sql = new SqlCommand("update accountInfo set accBalance = (accBalance - @amountToWithdraw) where accUserName = @accUserName", con);

            sql.Parameters.AddWithValue("@amountToWithdraw", amountToWithdraw);
            sql.Parameters.AddWithValue("@accUserName", username);

            con.Open();
            sql.ExecuteNonQuery();

            con.Close();

        }
        public void Deposit(string username, double amountToDeposit)
        {
            SqlConnection con = new SqlConnection("server= D-COMP\\NEW_DANNY_SERVER;database=bankingProjectDB;user id=sa;password=p@s3rd!");
            SqlCommand sql = new SqlCommand("update accountInfo set accBalance = (accBalance + @amountToDeposit) where accUserName = @accUserName", con);

            sql.Parameters.AddWithValue("@amountToWithdraw", amountToDeposit);
            sql.Parameters.AddWithValue("@accUserName", username);

            con.Open();
            sql.ExecuteNonQuery();

            con.Close();

        }



        }




}
