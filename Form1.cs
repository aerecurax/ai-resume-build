using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Creator
{
    public partial class Form1 : Form
    {
        // Holds our connection with the database
        static SQLiteConnection m_dbConnection;
        public static String DATABASE_NAME = "cvbdatabase.sqlite";
        public static String WORKSPACE = "Documents\\CV Documents";
        public Form1()
        {
            InitializeComponent();
        }

        private int time { set; get; }

        private void Form1_Load(object sender, EventArgs e)
        {
            serviceFF();
           time = 30;
           timer1.Start();
            //createNewDatabase();
            //
            //createTable();
            //
            //printHighscores();
        }

        private void serviceFF()
        {
            DirectoryInfo f = new DirectoryInfo("C:\\Users\\"+getUsername()+"\\.cv.creator\\Databases");
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
            FileInfo f3 = new FileInfo("C:\\Users\\" + getUsername() + "\\.cv.creator\\Databases\\"+DATABASE_NAME);
            if (!f3.Exists)
            {
                f3.Create();
                //create the database if missing
                createNewDatabase();
                connectToDatabase();
                createTable();
                //default is 0 meaning false
                fillTable(1,0);
            }

        }

        public static string getUsername()
        {
            String name = "";
            DirectoryInfo[] f = new DirectoryInfo("C:\\Users").GetDirectories();
            foreach(DirectoryInfo d in f){
                if (!d.Name.Equals("Public"))
                    name = d.Name;
            }
            if (!System.Environment.UserName.Equals(""))
                return System.Environment.UserName;
            else
                return name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time = time - 1;
            }
            else
            {
                timer1.Stop();
                Program.isSplashClosedMain = true;
                this.Close();
            }
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
                Console.WriteLine("Error: "+e.Message);
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
                string sql = "insert into settings_state (state, user) values ("+data1+","+data2+")";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                Console.WriteLine("Database insertion successfully");
            } catch (System.Data.SQLite.SQLiteException a){
                if(a.Message.Contains("no such table")){
                    //then create a table and redo insertion
                    createTable();
                    fillTable(data1,data2);
                }
            }
        }

        public static Boolean jj { set; get; }

        // get settings state
        public Boolean getSettingState(string column)
        {
            
            try{
            string sql = "select * from settings_state";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
               jj = Boolean.Parse(reader[column].ToString());
            Console.WriteLine("Settings state: "+ jj);
            } catch (System.Data.SQLite.SQLiteException a){
                if(a.Message.Contains("no such table")){
                    //then create a table and redo insertion
                    createTable();
                    fillTable(0,0);
                }
            }
            return jj;
        }
      
    }
}
