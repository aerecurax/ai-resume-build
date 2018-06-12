using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Creator
{
    public partial class Import : Form
    {
        string chosen_image;
        string chosen_doc;
        string chosen_list_ico;
        private static SQLiteConnection m_dbConnection = MainPublic.m_dbConnection;

        public Import()
        {
            InitializeComponent();
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void pick_picture_Click(object sender, EventArgs e)
        {
            imagesDialog.Title = "Select Custom Preview Picture";
            imagesDialog.InitialDirectory = "C:\\Users\\" + Helper.getUsername() + "\\Desktop";
            imagesDialog.FileName = "";
            imagesDialog.Multiselect = false;
            imagesDialog.Filter = "PNG Images|*.png";
            //imagesDialog.ShowDialog();

            if (imagesDialog.ShowDialog() != DialogResult.Cancel)
            {
                chosen_image = imagesDialog.FileName;
                image_path.Text = chosen_image;
                
                //pictureBox1.Image = Image.FromFile(chosen_image);
            }
        }

        private void pick_file_Click(object sender, EventArgs e)
        {
            documentDialog.Title = "Select Custom Document";
            documentDialog.InitialDirectory = "C:\\Users\\" + Helper.getUsername() + "\\Desktop";
            documentDialog.FileName = "";
            documentDialog.Multiselect = false;
            documentDialog.Filter = "Word Document(.docx)|*.docx|Word Document(.doc)|*.doc";
            //documentDialog.ShowDialog();

            if (documentDialog.ShowDialog() != DialogResult.Cancel)
            {
                chosen_doc = documentDialog.FileName;
                document_path.Text = chosen_doc;

                //pictureBox1.Image = Image.FromFile(chosen_image);
            }
        }

        private void pick_ico_Click(object sender, EventArgs e)
        {
            imagesDialog.Title = "Select Custom List Preview";
            imagesDialog.InitialDirectory = "C:\\Users\\" + Helper.getUsername() + "\\Desktop";
            imagesDialog.FileName = "";
            imagesDialog.Multiselect = false;
            imagesDialog.Filter = "PNG Images|*.png";
            //imagesDialog.ShowDialog();

            if (imagesDialog.ShowDialog() != DialogResult.Cancel)
            {
                chosen_list_ico = imagesDialog.FileName;
                list_ico.Text = chosen_list_ico;

                //pictureBox1.Image = Image.FromFile(chosen_image);
            }
        }

        private void imports_Click(object sender, EventArgs e)
        {
            if (Helper.fileExists(image_path.Text) && Helper.fileExists(list_ico.Text) && Helper.fileExists(document_path.Text))
            {
                Helper.folderCreate();
                fillTable(createDocument(chosen_doc), createListPrev(chosen_list_ico), createPicturePrev(chosen_image));
                MessageBox.Show("Import Successful, Toggle Templates for changes.", "Information",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                this.Close();
            }
            else
            {
                MessageBox.Show("File selected in one of the field is missing", "Warning",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

               
        private string createDocument(string path)
        {
            FileInfo f = new FileInfo(path);
            if (!Helper.fileExists("C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\Documents\\" + f.Name))
            {
                f.CopyTo("C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\Documents\\" + f.Name);
            }
            else
            {
                MessageBox.Show("File selected in one of the field already exists\n"+f.Name, "Warning",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return f.Name;
        }

        private string createPicturePrev(string path)
        {
            FileInfo f = new FileInfo(path);
            if (!Helper.fileExists("C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\Picture Preview\\" + f.Name))
            {
                f.CopyTo("C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\Picture Preview\\" + f.Name);
            }
            else
            {
                MessageBox.Show("File selected in one of the field already exists\n" + f.Name, "Warning",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return f.Name;
        }

        private string createListPrev(string path)
        {
            FileInfo f = new FileInfo(path);
            if (!Helper.fileExists("C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\List Preview\\" + f.Name))
            {
                f.CopyTo("C:\\Users\\" + Helper.getUsername() + "\\.cv.creator\\Imports\\List Preview\\" + f.Name);
            }
            else
            {
                MessageBox.Show("File selected in one of the field already exists\n" + f.Name, "Warning",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return f.Name;
        }

     
        // Creates a table named settings' with two columns: name (a string of max 20 characters) and score (an int)
        public static void createTable()
        {
            string sql = "create table customtemplates (id int primary key, document_path text, list_image text, preview text)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            Console.WriteLine("Database table created successfully");
        }

        // Inserts some values in the settings table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        public static void fillTable(string data1, string data2, string data3)
        {
            try
            {
                string sql = "insert into customtemplates (document_path, list_image, preview) values (\'"+ data1 + "\',\'" + data2 + "\',\'" + data3 + "\')";
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
                    fillTable(data1, data2, data3);
                }
                Console.WriteLine("Na wa o "+a.Message);
            }
        }

       
    }
}
