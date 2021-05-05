using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class DataAccess
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                String tableBooksCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Books (ISBN INTEGER PRIMARY KEY, " +
                    "Title NVARCHAR(2048) NULL, " +
                    "Description NVARCHAR(2048) NULL, " +
                    "Price INTEGER NULL )";
                SqliteCommand createBooksTable = new SqliteCommand(tableBooksCommand, db);
                createBooksTable.ExecuteReader();

                String tableCustomersCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (Customers_ID INTEGER PRIMARY KEY, " +
                    "Customers_Name NVARCHAR(2048) NULL, " +
                    "Address NVARCHAR(2048) NULL, " +
                    "Email NVARCHAR(2048) NULL )";
                SqliteCommand createCustomersTable = new SqliteCommand(tableCustomersCommand, db);
                createCustomersTable.ExecuteReader();

                String tableTransactionsCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Transactions (List INTEGER PRIMARY KEY, " +
                    "ISBN INTEGER NULL, " +
                    "Customers_ID INTEGER NULL, " +
                    "Quatity INTEGER NULL, " +
                    "Total_Price INTEGER NULL, " +
                    "Personnel_Name NVARCHAR(2048) NULL )";
                SqliteCommand createTransactionsTable = new SqliteCommand(tableTransactionsCommand, db);
                createTransactionsTable.ExecuteReader();

                String tablePersonnelCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Personnel (Personnel_ID INTEGER PRIMARY KEY, " +
                    "Personnel_Name NVARCHAR(2048) NULL, " +
                    "Personnel_User NVARCHAR(2048) NULL, " +
                    "Personnel_Password NVARCHAR(2048) NULL )";
                SqliteCommand createPersonnelTable = new SqliteCommand(tablePersonnelCommand, db);
                createPersonnelTable.ExecuteReader();
            }
        }
        public static void AddDataPersonnel(string NameText,string UserText, string PasswordText)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Personnel VALUES (NULL, @Name, @User, @Password);";
                insertCommand.Parameters.AddWithValue("@Name", NameText);
                insertCommand.Parameters.AddWithValue("@User", UserText);
                insertCommand.Parameters.AddWithValue("@Password", PasswordText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static List<List<string>> GetDataPersonnel(string User)
        {
            List<List<string>> entries = new List<List<string>>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT * from Personnel WHERE Personnel_User = {User}", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    int i = 0;
                    List<string> result = new List<string>();
                    while (i < query.FieldCount)
                    {
                        result.Add(query.GetString(i));
                        i++;
                    }
                    entries.Add(result);
                }

                db.Close();

            }
            return entries;
        }

        public static void AddDataCustomers(int IDint, string NameText, string AddressText, string EamilText)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customers VALUES (@ID, @Name, @Address, @Eamil);";
                insertCommand.Parameters.AddWithValue("@ID", IDint);
                insertCommand.Parameters.AddWithValue("@Name", NameText);
                insertCommand.Parameters.AddWithValue("@Address", AddressText);
                insertCommand.Parameters.AddWithValue("@Eamil", EamilText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static void UpdateDataCustomers(int IDint, string NameText, string AddressText, string EamilText)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;
                
                updateCommand.CommandText = "UPDATE Customers " + 
                                            "SET Customers_Name = @Name, " +
                                            "Address = @Address, " +
                                            "Email = @Email " +
                                            $"WHERE Customers_ID = {IDint}";
                updateCommand.Parameters.AddWithValue("@Name", NameText);
                updateCommand.Parameters.AddWithValue("@Address", AddressText);
                updateCommand.Parameters.AddWithValue("@Email", EamilText);

                updateCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<List<string>> GetDataCustomers(int ID)
        {
            List<List<string>> entries = new List<List<string>>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT * from Customers WHERE Customers_ID = {ID}", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    int i = 0;
                    List<string> result = new List<string>();
                    while (i < query.FieldCount)
                    {
                        result.Add(query.GetString(i));
                        i++;
                    }
                    entries.Add(result);
                }

                db.Close();

            }
            return entries;
        }
        public static void DeleteDataCustomers(int ID)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = $"DELETE from Customers WHERE Customers_ID = {ID};";
                deleteCommand.ExecuteReader();

                db.Close();
            }
        }
        public static void AddDataBooks(int IDint, string NameText, string DescriptionText, int Priceint)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Books VALUES (@ID, @Name, @Description, @Price);";
                insertCommand.Parameters.AddWithValue("@ID", IDint);
                insertCommand.Parameters.AddWithValue("@Name", NameText);
                insertCommand.Parameters.AddWithValue("@Description", DescriptionText);
                insertCommand.Parameters.AddWithValue("@Price", Priceint);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static void UpdateDataBooks(int IDint, string NameText, string DescriptionText, int Priceint)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Books " +
                                            "SET Title = @Name, " +
                                            "Description = @Description, " +
                                            "Price = @Price " +
                                            $"WHERE ISBN = {IDint}";
                updateCommand.Parameters.AddWithValue("@Name", NameText);
                updateCommand.Parameters.AddWithValue("@Description", DescriptionText);
                updateCommand.Parameters.AddWithValue("@Price", Priceint);

                updateCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<List<string>> GetDataBooks(int ID)
        {
            List<List<string>> entries = new List<List<string>>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT * from Books WHERE ISBN = {ID}", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    int i = 0;
                    List<string> result = new List<string>();
                    while (i < query.FieldCount)
                    {
                        result.Add(query.GetString(i));
                        i++;
                    }
                    entries.Add(result);
                }

                db.Close();

            }
            return entries;
        }
        public static void DeleteDataBooks(int ID)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = $"DELETE from Books WHERE ISBN = {ID};";
                deleteCommand.ExecuteReader();

                db.Close();
            }
        }
        public static void AddDataTransactions(int ISBNint, int CustomerIDint, int Quatityint, int Priceint, string PersonnelNameText)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Transactions VALUES (NULL, @ISBN, @CustomerID, @Quatity, @Price, @PersonnelName);";
                insertCommand.Parameters.AddWithValue("@ISBN", ISBNint);
                insertCommand.Parameters.AddWithValue("@CustomerID", CustomerIDint);
                insertCommand.Parameters.AddWithValue("@Quatity", Quatityint);
                insertCommand.Parameters.AddWithValue("@Price", Priceint);
                insertCommand.Parameters.AddWithValue("@PersonnelName", PersonnelNameText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<List<string>> GetHistoryOrderData()
        {
            List<List<string>> entries = new List<List<string>>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Transactions", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    int i = 0;
                    List<string> result = new List<string>();
                    while (i < query.FieldCount)
                    {
                        result.Add(query.GetString(i));
                        i++;
                    }
                    entries.Add(result);
                }

                db.Close();

            }
            return entries;
        }
    }
}
