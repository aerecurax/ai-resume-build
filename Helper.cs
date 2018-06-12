using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Creator
{
    class Helper
    {
        // Holds our connection with the database
        static SQLiteConnection m_dbConnection;
        public static string FULL_WORKSPACE = "C:\\Users\\" + getUsername() +"\\Documents\\CV Documents\\";
        public static String DATABASE_NAME = "cvbdatabase.sqlite";
        public static String WORKSPACE = "Documents\\CV Documents";
        public static string IMPORT_DOC = "C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\Documents\\";
        public static string IMPORT_PREVIEW = "C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\Picture Preview\\";
        public static string IMPORT_LIST_ICON = "C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\List Preview\\";

        public static Boolean fileExists(string path)
        {
            return new FileInfo(path).Exists;
        }

        public static Boolean directoryExists(string path)
        {
            return new DirectoryInfo(path).Exists;
        }
        
        public static Boolean checkContent(TextBox e)
        {
            if (e.Text.Equals(""))
                return false;
            else
                return true;
        }

        public static Boolean checkContent(ComboBox e)
        {
            if (e.Text.Equals(""))
                return false;
            else
                return true;
        }

        public static Boolean checkContent(RadioButton e)
        {
            if (e.Text.Equals(""))
                return false;
            else
                return true;
        }

        public static string extractString(TextBox e)
        {
            return e.Text;
        }

        public static void error(string name)
        {
            MessageBox.Show(name + " Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //copy the file to cv documents
        public static void copyTemplate(string name, string phone, byte[] resoruce_name)
        {
            //CV_Creator.Properties.Resources.sample
            if (new DirectoryInfo(FULL_WORKSPACE).Exists)
            {
                BinaryWriter bw;
                if (new FileInfo(FULL_WORKSPACE + name + ".docx").Exists)
                {
                    bw = new BinaryWriter(new FileStream(FULL_WORKSPACE + name + phone + ".docx", FileMode.Create));
                    bw.Write(resoruce_name);
                    bw.Close();
                }
                else
                {
                    bw = new BinaryWriter(new FileStream(FULL_WORKSPACE + name + ".docx", FileMode.Create));
                    bw.Write(resoruce_name);
                    bw.Close();
                }
            }
            else
            {
                //check that things are working fine
                folderCreate();
                copyTemplate(name, phone, resoruce_name);
            }
        }
        public static void folderCreate(){
            DirectoryInfo f = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Databases");
            if (!f.Exists)
                f.Create();
            DirectoryInfo f2 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\" + WORKSPACE);
            if (!f2.Exists)
                f2.Create();
            DirectoryInfo f4 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports");
            if (!f4.Exists)
            {
                f4.Create();
            }
            DirectoryInfo f5 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports\\Documents");
            if (!f5.Exists)
            {
                f5.Create();
            }
            DirectoryInfo f6 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports\\List Preview");
            if (!f6.Exists)
            {
                f6.Create();
            }
            DirectoryInfo f7 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports\\Picture Preview");
            if (!f7.Exists)
            {
                f7.Create();
            }
        }

        public static void serviceFF()
        {
            DirectoryInfo f = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Databases");
            if (!f.Exists)
                f.Create();
            DirectoryInfo f2 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\" + WORKSPACE);
            if (!f2.Exists)
                f2.Create();
            DirectoryInfo f4 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports");
            if (!f4.Exists)
            {
                f4.Create();
            }
            DirectoryInfo f5 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports\\Documents");
            if (!f5.Exists)
            {
                f5.Create();
            }
            DirectoryInfo f6 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports\\List Preview");
            if (!f6.Exists)
            {
                f6.Create();
            }
            DirectoryInfo f7 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Imports\\Picture Preview");
            if (!f7.Exists)
            {
                f7.Create();
            }
            //create new database if the fake database is missing
            FileInfo f3 = new FileInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Databases\\" + DATABASE_NAME);
            if (!f3.Exists)
            {
                f3.Create();
                //create the database if missing
                createNewDatabase();
                connectToDatabase();
                createTable();
                //default is 0 meaning false
                fillTable(1, 0);
            }

        }

        public static string getUsername()
        {
            String name = "";
            DirectoryInfo[] f = new DirectoryInfo("C:\\Users").GetDirectories();
            foreach (DirectoryInfo d in f)
            {
                if (!d.Name.Equals("Public"))
                    name = d.Name;
            }
            if (!System.Environment.UserName.Equals(""))
                return System.Environment.UserName;
            else
                return name;
        }
        // Creates an empty database file
        public static void createNewDatabase()
        {
            try
            {
                SQLiteConnection.CreateFile(DATABASE_NAME);
                SQLiteConnection.ClearAllPools();
                Console.WriteLine("Database created successfully");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        // Creates a connection with our database file.
        public static void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + DATABASE_NAME + ";");
            Console.WriteLine("Database connected successfully");
            m_dbConnection.Open();
        }

        // Creates a table named settings' with two columns: name (a string of max 20 characters) and score (an int)
        public static void createTable()
        {
            string sql = "create table settings_state (state boolean, user boolean)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            Console.WriteLine("Database table created successfully");
        }

        // Inserts some values in the settings table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        public static void fillTable(int data1, int data2)
        {
            try
            {
                string sql = "insert into settings_state (state, user) values (" + data1 + "," + data2 + ")";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                Console.WriteLine("Database insertion successfully");
            }
            catch (System.Data.SQLite.SQLiteException a)
            {
                if (a.Message.Contains("no such table"))
                {
                    //then create a table and redo insertion
                    createTable();
                    fillTable(data1, data2);
                }
            }
        }

        public static Boolean jj { set; get; }

        // get settings state
        public static Boolean getSettingState(string column)
        {

            try
            {
                string sql = "select * from settings_state";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    jj = Boolean.Parse(reader[column].ToString());
                Console.WriteLine("Settings state: " + jj);
            }
            catch (System.Data.SQLite.SQLiteException a)
            {
                if (a.Message.Contains("no such table"))
                {
                    //then create a table and redo insertion
                    createTable();
                    fillTable(0, 0);
                }
            }
            return jj;
        }

        public static void getStateUseForTemplate()
        {
            
            Program.isSplashClosedMain = true;
    
        }

        public static void creatTemplateOneDB()
        {
            DirectoryInfo f = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Databases");
            if (!f.Exists)
                f.Create();
            DirectoryInfo f2 = new DirectoryInfo("C:\\Users\\" + getUsername() + "\\" + WORKSPACE);
            if (!f2.Exists)
                f2.Create();
            //create new database if the fake database is missing
            FileInfo f3 = new FileInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Databases\\" + DATABASE_NAME);
            if (!f3.Exists)
            {
                f3.Create();
                //create the database if missing
                try
                {
                    SQLiteConnection.CreateFile("fresh.sqlite");
                    SQLiteConnection.ClearAllPools();
                    Console.WriteLine("Template1 Database created successfully");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                m_dbConnection = new SQLiteConnection("Data Source=fresh.sqlite;");
                Console.WriteLine("Template1 Database connected successfully");
                m_dbConnection.Open();
                string sql = "create table template1 (id int, name text, address text, phone text, dbo text, sex text,  marital text,  birth text,"
             + "state text, lga text,  nationality text,  religion text,  language text,  obj text,  background text,  certificate text," +
            "work text, hobby text, referee text)";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                Console.WriteLine("Template1 Database table created successfully");
        
            }
        }

        public static void fillTemplate1Table(string name, string address, string phone, string dbo, string sex, string marital, string birth,
            string state, string lga, string nationality, string religion, string language, string obj, string background, string certificate,
            string work, string hobbies, string referees)
        {
            try
            {
                string sql = "insert into settings_state (name, address, phone, dbo, sex,  marital,  birth,"
             + "state, lga,  nationality,  religion,  language,  obj,  background,  certificate," +
            "work, hobby, referee) values (" + name + "," + address + "," + phone + "," + dbo + "," + sex + "," + marital +
            "," + address + ")";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                Console.WriteLine("Database insertion successfully");
            }
            catch (System.Data.SQLite.SQLiteException a)
            {
                if (a.Message.Contains("no such table"))
                {
                    //then create a table and redo insertion
                    createTable();
                    //fillTable(data1, data2);
                }
            }
        }

        
        public String getData(string column)
        {
            String see = "";
            try
            {
                string sql = "select * from template1";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    see = reader[column].ToString();
                Console.WriteLine("Data: " + see);
            }
            catch (System.Data.SQLite.SQLiteException a)
            {
                if (a.Message.Contains("no such table"))
                {
                    //then create a table and redo insertion
                    m_dbConnection = new SQLiteConnection("Data Source=fresh.sqlite;");
                    Console.WriteLine("Template1 Database connected successfully");
                    m_dbConnection.Open();
                    string sql = "create table template1 (id int, name text, address text, phone text, dbo text, sex text,  marital text,  birth text,"
                 + "state text, lga text,  nationality text,  religion text,  language text,  obj text,  background text,  certificate text," +
                "work text, hobby text, referee text)";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Template1 Database table created successfully");
                }
            }
            return see;
        }


    }
}
