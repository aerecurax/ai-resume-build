using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Creator
{
    static class Program
    {
        // Holds our connection with the database
        static SQLiteConnection m_dbConnection;
        static string DATABASE_NAME = "cvbdatabase.sqlite";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             
            isSplashClosedMain = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            if (isSplashClosedMain)
            {
                Application.Run(new MainPublic());
            }

                    

        }

        public static Boolean jj { set; get; }

        public static Boolean isSplashClosedMain { set; get; }
    }
}
