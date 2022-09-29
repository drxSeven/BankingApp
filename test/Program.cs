using System.Data;
using System.Runtime.ExceptionServices;
using test;

Console.WriteLine("----------Welcome to Your Banking Application----------");
Console.WriteLine("Please choose from the following options: ");
Console.WriteLine("1. Admin");
Console.WriteLine("2. Customer");
int firstChoice = Convert.ToInt32(Console.ReadLine());

bool op = true;
saving sObj = new saving();
checking cObj = new checking();





#region Admin
if (firstChoice == 1)
{
    Console.Write("Please enter your Username: ");
    string adminUN = Console.ReadLine();

    Console.Write("Please enter your Password: ");
    string adminPW = Console.ReadLine();

    bool login = sObj.Login(adminUN, adminPW);


    while (op == true)
    {
        if (adminUN == "Admin" && login)
        {
            Console.Clear();
            Console.WriteLine("1. Create a new account");
            Console.WriteLine("2. Delete an account");
            Console.WriteLine("3. Edit an Account");
            Console.WriteLine("4. Search for an Account");
            Console.WriteLine("5. Checking Account List");
            Console.WriteLine("6. Saving Account List");
            Console.WriteLine("7. Exit");


            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                #region Add New Account
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter the account type: ");
                    Console.WriteLine("1. Saving");
                    Console.WriteLine("2. Checking");
                    int newAccType = Convert.ToInt32(Console.ReadLine());
                    if (newAccType == 1)
                    {
                        string sAccType = "Saving";

                        Console.WriteLine("Enter Account Number: ");
                        int sAccNo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Account PIN: ");
                        int sAccPin = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Account Branch");
                        string sAccBranch = Console.ReadLine();

                        Console.WriteLine("Enter Account Daily Limit");
                        double sAccDailyLimit = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter Account Balance");
                        double sAccBalance = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter Account Is Active");
                        bool sAccisActive = Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Enter Account Username: ");
                        string sAccUserName = Console.ReadLine();

                        Console.WriteLine("Enter Account Password: ");
                        string sAccPassWord = Console.ReadLine();

                        try
                        {
                            Console.Clear();
                            string addResult = sObj.AddNewAccount(sAccType, sAccNo, sAccPin, sAccBranch, sAccBalance, sAccDailyLimit, sAccisActive, sAccUserName, sAccPassWord);
                            Console.WriteLine(addResult);
                        }
                        catch (Exception es)
                        {
                            Console.WriteLine(es.Message);
                        }
                    }
                    else if (newAccType == 2)
                    {
                        string chAccType = "Checking";

                        Console.WriteLine("Enter Account Number: ");
                        int chAccNo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Account PIN: ");
                        int chAccPin = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Account Branch");
                        string chAccBranch = Console.ReadLine();

                        Console.WriteLine("Enter Account Daily Limit");
                        double chAccDailyLimit = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter Account Balance");
                        double chAccBalance = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter Account Is Active");
                        bool chAccisActive = Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Enter Account Username: ");
                        string chAccUserName = Console.ReadLine();

                        Console.WriteLine("Enter Account Password: ");
                        string chAccPassWord = Console.ReadLine();

                        try
                        {
                            Console.Clear();
                            string addResult = cObj.AddNewAccount(chAccType, chAccNo, chAccPin, chAccBranch, chAccBalance, chAccDailyLimit, chAccisActive, chAccUserName, chAccPassWord);
                            Console.WriteLine(addResult);
                        }
                        catch (Exception es)
                        {
                            Console.WriteLine(es.Message);
                        }
                    }
                    Console.WriteLine("Press enter to continue!");
                    Console.ReadLine();
                    break;

                #endregion
                #region Delete Account
                case 2:
                    Console.WriteLine("What kind of account would you like to delete?");
                    Console.WriteLine("1. Saving");
                    Console.WriteLine("2. Checking");
                    int opt = Convert.ToInt32(Console.ReadLine());

                    if (opt == 1)
                    {
                        Console.Write("Enter account username: ");
                        string del_Acc = Console.ReadLine();
                        string deleteResult = sObj.DeleteAccount(del_Acc);
                        Console.WriteLine(deleteResult);
                    }
                    else if (opt == 2)
                    {
                        Console.Write("Enter account username: ");
                        string del_Acc = Console.ReadLine();
                        string deleteResult = cObj.DeleteAccount(del_Acc);
                        Console.WriteLine(deleteResult);
                    }
                    Console.WriteLine("Press enter to continue!");
                    Console.ReadLine();

                    break;

                #endregion
                #region Edit an Account
                case 3:
                    Console.WriteLine("Would you like to edit a saving or checking account?");
                    Console.WriteLine("1. Saving");
                    Console.WriteLine("2. Checking");
                    Console.WriteLine("3. Exit");
                    int opo = Convert.ToInt32(Console.ReadLine());

                    if (opo == 1)
                    {
                        Console.WriteLine("What is the username for this account?");
                        string user = Console.ReadLine();
                        Console.WriteLine("What would you like to edit?");
                        Console.WriteLine("1. Account Type");
                        Console.WriteLine("2. Account Number");
                        Console.WriteLine("3. Account PIN");
                        Console.WriteLine("4. Account Branch");
                        Console.WriteLine("5. Account Balance");
                        Console.WriteLine("6. Account Daily Limit");
                        Console.WriteLine("7. Account Active Status");
                        Console.WriteLine("8. Account Username");
                        Console.WriteLine("9. Account Password");
                        int chice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter updated account information: ");
                        string input = Console.ReadLine();
                        sObj.Edit(user, input, chice);
                        Console.WriteLine("Account updated successfully!");

                    }
                    else if (opo == 2)
                    {
                        Console.WriteLine("What is the username for this account?");
                        string user = Console.ReadLine();
                        Console.WriteLine("What would you like to edit?");
                        Console.WriteLine("1. Account Type");
                        Console.WriteLine("2. Account Number");
                        Console.WriteLine("3. Account PIN");
                        Console.WriteLine("4. Account Branch");
                        Console.WriteLine("5. Account Balance");
                        Console.WriteLine("6. Account Daily Limit");
                        Console.WriteLine("7. Account Active Status");
                        Console.WriteLine("8. Account Username");
                        Console.WriteLine("9. Account Password");
                        int chice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Please enter updated account information: ");
                        string input = Console.ReadLine();
                        cObj.Edit(user, input, chice);
                        Console.WriteLine("Account updated successfully!");

                    }
                    else if (opo == 3)
                    {
                        Console.WriteLine("Thank you for banking with us!");
                        op = false;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option");
                    }
                    Console.WriteLine("Press enter to continue!");
                    Console.ReadLine();

                    break;



                #endregion
                #region Search for Account
                case 4:

                    Console.WriteLine("What kind of account would you like to search for?");
                    Console.WriteLine("1. Saving");
                    Console.WriteLine("2. Checking");
                    int opdt = Convert.ToInt32(Console.ReadLine());

                    if (opdt == 1)
                    {
                        Console.Write("Please Enter Account Number: ");
                        int v_accNo = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            saving detail = saving.Search(v_accNo);
                            Console.WriteLine("Account type: " + detail.newAccType);
                            Console.WriteLine("Account number: " + detail.accNo);
                            Console.WriteLine("Account PIN: " + detail.accPin);
                            Console.WriteLine("Account Branch: " + detail.accBranch);
                            Console.WriteLine("Account Balance: " + detail.accBalance);
                            Console.WriteLine("Account Daily Limit: " + detail.accDailyLimit);
                            Console.WriteLine("Account Active: " + detail.accIsActive);
                            Console.WriteLine("Account Username: " + detail.aUsername);
                            Console.WriteLine("Account Password: " + detail.aPassWord);
                        }
                        catch (Exception es)
                        {
                            Console.WriteLine(es.Message);
                        }
                    }
                    else if (opdt == 2)
                    {
                        Console.Write("Please Enter Account Number: ");
                        int v_accNo = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            checking detail = cObj.Search(v_accNo);
                            Console.WriteLine("Account type: " + detail.newAccType);
                            Console.WriteLine("Account number: " + detail.accNo);
                            Console.WriteLine("Account PIN: " + detail.accPin);
                            Console.WriteLine("Account Branch: " + detail.accBranch);
                            Console.WriteLine("Account Balance: " + detail.accBalance);
                            Console.WriteLine("Account Daily Limit: " + detail.accDailyLimit);
                            Console.WriteLine("Account Active: " + detail.accIsActive);
                            Console.WriteLine("Account Username: " + detail.aUsername);
                            Console.WriteLine("Account Password: " + detail.aPassWord);
                        }
                        catch (Exception es)
                        {
                            Console.WriteLine(es.Message);
                        }

                    }
                    Console.WriteLine("Press enter to continue!");
                    Console.ReadLine();
                    break;
                #endregion
                #region Checking Account List
                case 5:

                    List<checking> aList = cObj.GetAllAccounts();
                    foreach (var detail in aList)
                    {
                        Console.WriteLine("Account type: " + detail.newAccType);
                        Console.WriteLine("Account number: " + detail.accNo);
                        Console.WriteLine("Account PIN: " + detail.accPin);
                        Console.WriteLine("Account Branch: " + detail.accBranch);
                        Console.WriteLine("Account Balance: " + detail.accBalance);
                        Console.WriteLine("Account Daily Limit: " + detail.accDailyLimit);
                        Console.WriteLine("Account Active: " + detail.accIsActive);
                        Console.WriteLine("Account Username: " + detail.aUsername);
                        Console.WriteLine("Account Password: " + detail.aPassWord);
                        Console.WriteLine("--------------------------------------------------------------------");
                    }
                    Console.WriteLine("Press enter to continue!");
                    Console.ReadLine();

                    break;
                #endregion
                #region Saving Account List
                case 6:
                    List<saving> bList = sObj.GetAllAccounts();
                    foreach (var detail in bList)
                    {
                        Console.WriteLine("Account type: " + detail.newAccType);
                        Console.WriteLine("Account number: " + detail.accNo);
                        Console.WriteLine("Account PIN: " + detail.accPin);
                        Console.WriteLine("Account Branch: " + detail.accBranch);
                        Console.WriteLine("Account Balance: " + detail.accBalance);
                        Console.WriteLine("Account Daily Limit: " + detail.accDailyLimit);
                        Console.WriteLine("Account Active: " + detail.accIsActive);
                        Console.WriteLine("Account Username: " + detail.aUsername);
                        Console.WriteLine("Account Password: " + detail.aPassWord);
                        Console.WriteLine("--------------------------------------------------------------------");
                    }
                    Console.WriteLine("Press enter to continue!");
                    Console.ReadLine();

                    break;
                #endregion
                #region Exit
                case 7:
                    Console.WriteLine("Thanks for banking with us!");
                    op = false;
                    break;
                #endregion
                #region Default
                default:
                    Console.WriteLine("Not an option");
                    break;
                    #endregion
            }
        }

        else
        {
            Console.WriteLine("Incorrect username/password");
            Console.ReadLine();
        }
    }
}


#endregion
#region Custmer
else if (firstChoice == 2)
{
    Console.Clear();
    Console.WriteLine("Which account would you like to access?");
    Console.WriteLine("1. Saving");
    Console.WriteLine("2. Checking");
    int ch = Convert.ToInt32(Console.ReadLine());

    if (ch == 1)
    {
        Console.WriteLine("Please enter your username: ");
        string custUser = Console.ReadLine();
        Console.WriteLine("Please enter your password: ");
        string custPW = Console.ReadLine();
        bool login = sObj.Login(custUser, custPW);
        while (op == true)
        {
            if (login)
            {

                Console.Clear();
                Console.WriteLine("1. View Details");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. change password");
                Console.WriteLine("7. exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    #region View Details
                    case 1:
                        saving detail = saving.Details(custUser);
                        Console.WriteLine("Account type: " + detail.newAccType);
                        Console.WriteLine("Account number: " + detail.accNo);
                        Console.WriteLine("Account PIN: " + detail.accPin);
                        Console.WriteLine("Account Branch: " + detail.accBranch);
                        Console.WriteLine("Account Balance: " + detail.accBalance);
                        Console.WriteLine("Account Daily Limit: " + detail.accDailyLimit);
                        Console.WriteLine("Account Active: " + detail.accIsActive);
                        Console.WriteLine("Account Username: " + detail.aUsername);
                        Console.WriteLine("Account Password: " + detail.aPassWord);
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Withdraw
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please enter the amount to withdraw from your savings account: ");
                        int amountToWithdraw = Convert.ToInt32(Console.ReadLine());
                        sObj.Withdraw(custUser, amountToWithdraw);
                        Console.WriteLine("Withdraw successful!");
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Deposit
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please enter the amount to deposit into your savings account: ");
                        int amountToDeposit = Convert.ToInt32(Console.ReadLine());
                        sObj.Deposit(custUser, amountToDeposit);
                        Console.WriteLine("Deposit successful!");
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Transfer
                    case 4:
                        Console.WriteLine("What is the username of the checking account you'd like to transfer to?");
                        string chUser = Console.ReadLine();
                        Console.WriteLine("How much would you like to transfer out of your savings account?");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        sObj.SavToChck(custUser, chUser, amount);
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Change Password
                    case 5:
                        Console.WriteLine("Please enter your current password: ");
                        string passw = Console.ReadLine();
                        bool pw = sObj.PwChck(passw);
                        if (pw)
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter your new password: ");
                            string new_pw = Console.ReadLine();
                            string adResult = sObj.UpdatePW(new_pw, custUser);
                            Console.WriteLine(adResult);

                        }
                        else
                        {
                            Console.WriteLine("Incorrect password");
                        }
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Exit
                    case 7:
                        Console.WriteLine("7. exit");
                        op = false;
                        break;
                    #endregion
                    #region Default
                    default:
                        Console.WriteLine("Not an option");
                        break;
                        #endregion
                }

            }
            else
            {
                Console.WriteLine("Incorrect username/password");
                op = false;
            }

        }
    }
    else if (ch == 2)
    {

        Console.WriteLine("Please enter your username: ");
        string custUser = Console.ReadLine();
        Console.WriteLine("Please enter your password: ");
        string custPW = Console.ReadLine();
        bool login = cObj.Login(custUser, custPW);

        while (op == true)
        {
            if (login)
            {

                Console.Clear();
                Console.WriteLine("1. View Details");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. change password");
                Console.WriteLine("7. exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    #region View Details
                    case 1:
                        checking detail = checking.Details(custUser);
                        Console.WriteLine("Account type: " + detail.newAccType);
                        Console.WriteLine("Account number: " + detail.accNo);
                        Console.WriteLine("Account PIN: " + detail.accPin);
                        Console.WriteLine("Account Branch: " + detail.accBranch);
                        Console.WriteLine("Account Balance: " + detail.accBalance);
                        Console.WriteLine("Account Daily Limit: " + detail.accDailyLimit);
                        Console.WriteLine("Account Active: " + detail.accIsActive);
                        Console.WriteLine("Account Username: " + detail.aUsername);
                        Console.WriteLine("Account Password: " + detail.aPassWord);
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Withdraw
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please enter the amount to withdraw from your checking account: ");
                        int amountToWithdraw = Convert.ToInt32(Console.ReadLine());
                        cObj.Withdraw(custUser, amountToWithdraw);
                        Console.WriteLine("Withdraw successful!");
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Deposit
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please enter the amount to deposit into your checking account: ");
                        int amountToDeposit = Convert.ToInt32(Console.ReadLine());
                        cObj.Deposit(custUser, amountToDeposit);
                        Console.WriteLine("Deposit successful!");
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Transfer
                    case 4:
                        Console.WriteLine("What is the username of the saving account you'd like to transfer to?");
                        string sUser = Console.ReadLine();
                        Console.WriteLine("How much would you like to transfer out of your checking account?");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        cObj.ChckToSav(sUser, custUser, amount);
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Change Password
                    case 5:
                        Console.WriteLine("Please enter your current password: ");
                        string passw = Console.ReadLine();
                        bool pw = cObj.PwChck(passw);
                        if (pw)
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter your new password: ");
                            string new_pw = Console.ReadLine();
                            string adResult = cObj.UpdatePW(new_pw, custUser);
                            Console.WriteLine(adResult);

                        }
                        else
                        {
                            Console.WriteLine("Incorrect password");
                        }
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Exit
                    case 7:
                        Console.WriteLine("7. exit");
                        op = false;
                        break;
                    #endregion
                    #region Default
                    default:
                        Console.WriteLine("Not an option");
                        break;
                        #endregion
                }

            }
            else
            {
                Console.WriteLine("Incorrect username/password");
                op = false;
            }




        }
    }

    

}

#endregion
