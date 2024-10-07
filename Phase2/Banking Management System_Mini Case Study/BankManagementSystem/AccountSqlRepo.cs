using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;


namespace BankManagementProject
{
    public class AccountSQLRepo : IAccountRepo
    {
        private static AccountSQLRepo _instance;
        private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=AccountsDb;Integrated Security=True;"; 

        public static AccountSQLRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountSQLRepo();
                }
                return _instance;
            }
        }

        public void Create(AccountModel accModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Accounts (Id,AccNo, Name, Balance, AccType, Email, PhNo, Address, IsActive, InterestPercentage, TransactionCount, LastTransactionDate) " +
                                   "VALUES (@Id,@AccNo, @Name, @Balance, @AccType, @Email, @PhNo, @Address, @IsActive, @InterestPercentage, @TransactionCount, @LastTransactionDate)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccNo", accModel.AccNo);
                    cmd.Parameters.AddWithValue("@Name", accModel.Name);
                    cmd.Parameters.AddWithValue("@Balance", accModel.Balance);
                    cmd.Parameters.AddWithValue("@AccType", accModel.AccType);
                    cmd.Parameters.AddWithValue("@Email", accModel.Email);
                    cmd.Parameters.AddWithValue("@PhNo", accModel.PhNo);
                    cmd.Parameters.AddWithValue("@Address", accModel.Address);
                    cmd.Parameters.AddWithValue("@IsActive", accModel.IsActive);
                    cmd.Parameters.AddWithValue("@InterestPercentage", accModel.InterestPercentage);
                    cmd.Parameters.AddWithValue("@TransactionCount", accModel.TransactionCount);
                    cmd.Parameters.AddWithValue("@LastTransactionDate", accModel.LastTransactionDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in creating account");
            }
        }

        public void UpdateAccount(AccountModel accModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Accounts SET Address = @Address WHERE AccNo = @AccNo";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccNo", accModel.AccNo);
                    cmd.Parameters.AddWithValue("@Address", accModel.Address);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AccountException("Account doesn't exist");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in updating account");
            }
        }

        public List<AccountModel> ReadAllAccount()
        {
            try
            {
                List<AccountModel> accounts = new List<AccountModel>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Accounts";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AccountModel account = new AccountModel
                        {
                            AccNo = (int)reader["AccNo"],
                            Name = (string)reader["Name"],
                            Balance = (decimal)reader["Balance"],
                            AccType = (string)reader["AccType"],
                            Email = (string)reader["Email"],
                            PhNo = (string)reader["PhNo"],
                            Address = (string)reader["Address"],
                            IsActive = (bool)reader["IsActive"],
                            InterestPercentage = reader["InterestPercentage"].ToString(),
                            TransactionCount = (int)reader["TransactionCount"],
                            LastTransactionDate = (DateTime)reader["LastTransactionDate"]
                        };
                        accounts.Add(account);
                    }
                }
                return accounts;
            }
            catch (Exception ex)
            {
                throw new AccountException("Error reading accounts");
            }
        }

        public void DeleteAccount(AccountModel accModel)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Accounts WHERE AccNo = @AccNo";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccNo", accModel.AccNo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in deleting account");
            }
        }

        public void Deposit(int acNo, int Amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Accounts SET Balance = Balance + @Amount, LastTransactionDate = @LastTransactionDate, TransactionCount = TransactionCount + 1 WHERE AccNo = @AccNo";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccNo", acNo);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@LastTransactionDate", DateTime.Now);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AccountException("Account not found, please input a valid account number");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in deposit");
            }
        }

        public void Withdraw(int acNo, int Amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Accounts SET Balance = Balance - @Amount, LastTransactionDate = @LastTransactionDate, TransactionCount = TransactionCount + 1 WHERE AccNo = @AccNo AND Balance >= @Amount";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AccNo", acNo);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@LastTransactionDate", DateTime.Now);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new AccountException("Insufficient balance or account not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AccountException("Error in withdrawal");
            }
        }

        public void CalculateInterestAndUpdateBalance()
        {
            // Implementation for calculating and updating interest on account balances
            throw new NotImplementedException();
        }

        ObservableCollection<AccountModel> IAccountRepo.ReadAllAccount()
        {
            throw new NotImplementedException();
        }
    }
}
