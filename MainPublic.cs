using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CV_Creator
{
    public partial class MainPublic : Form
    {
        
        static Image[] images = new Image[4];
        Image[] preview_images = new Image[4];
        int selectedItem = -1;

        Image[] customListImg;
        Image[] customPreview;
        public static SQLiteConnection m_dbConnection;
        bool custom = true;

        public MainPublic()
        {
            InitializeComponent();
            //jj = new Image[0];
            //customListImg = new Image[jj.Length];
           // customPreview = new Image[jj.Length];
            
            //initialize the templates images also
            images[0] = CV_Creator.Properties.Resources.template_normal;
            images[2] = CV_Creator.Properties.Resources.template_two;
            images[3] = CV_Creator.Properties.Resources.template_three;
            images[1] = CV_Creator.Properties.Resources.template_one;

            //initialize previews according to the images
            preview_images[0] = CV_Creator.Properties.Resources.pnormal;
            preview_images[1] = CV_Creator.Properties.Resources.ptemplate_one;
            preview_images[2] = CV_Creator.Properties.Resources.ptemplate_two;
            preview_images[3] = CV_Creator.Properties.Resources.ptemplate_three;

            kk = new ArrayList();
        }

        public void addCustom()
        {
            Helper.folderCreate();
            customListImg = getDataFrom("list_image");
            customPreview = getDataFrom("preview");

            if (customListImg != null)
            {
                listView1.Clear();
                imageList1.Images.Clear();
                for (int i = 0; i < customListImg.Length; i++)
                {
                    
                        Console.WriteLine(i +" : " + customListImg[i].ToString());
                        Console.WriteLine(i +" : " + customPreview[i].ToString());
                        imageList1.Images.Add(customListImg[i]);
                    
                }

                for (int i = 0; i < imageList1.Images.Count; i++)
                {
                    listView1.View = View.LargeIcon;
                    listView1.LargeImageList = imageList1;
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = i;
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Information", "No templates",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fixList()
        {
            listView1.Clear();
            imageList1.Images.Clear();
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i] != null)
                {
                    imageList1.Images.Add(images[i]);
                }
            }

            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                listView1.View = View.LargeIcon;
                listView1.LargeImageList = imageList1;
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                listView1.Items.Add(item);
            }
        }
        private void MainPublic_Load(object sender, EventArgs e)
        {
            connectToDatabase();
            createTable();
            fixList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (custom)
            {
                //then na default dey there
                selectedItem = listView1.SelectedItems[0].Index;
                pictureBox1.Image = preview_images[selectedItem];
                fixList();
                
            }
            else
            {
                selectedItem = listView1.SelectedItems[0].Index;
                pictureBox1.Image = customPreview[selectedItem];
                addCustom();
                
            }
        }

        private void use_Click(object sender, EventArgs e)
        {

            if (selectedItem < 0)
            {
                MessageBox.Show("No template selected", "Minor Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                setTemplate(selectedItem);
            }
        }

        private void setTemplate(int selectedItem)
        {
            
            if (custom)
            {
                switch (selectedItem)
                {
                    case 0:
                        //run the first template
                        new templates.Ordinary().Show();
                        break;
                    case 1:
                        //run the first template
                        new templates.Template1().Show();
                        break;
                    case 2:
                        new templates.Template2().Show();
                        break;
                    case 3:
                        new templates.Template3().Show();
                        break;
                }
            }
            else
            {
                if (getPath(selectedItem)[selectedItem] != null)
                {
                    Console.WriteLine(getPath(selectedItem)[selectedItem].ToString());
                    new templates.Custom(getPath(selectedItem)[selectedItem].ToString()).Show();
                }
                else
                {
                    MessageBox.Show("No template selected", "Minor Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //this.Close();
                  
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //m_dbConnection.Close();
            new Import().Show();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            custom = !custom;
            if(custom){
                changeToolStripMenuItem.Text = "Custom Templates";
                fixList();
            } else {
                changeToolStripMenuItem.Text = "Default Templates";
                addCustom();
            }
            selectedItem = -1;
            pictureBox1.Image = Properties.Resources.none_selected;
           
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=imports.sqlite;");
            Console.WriteLine("Database connected successfully");
            m_dbConnection.Open();
        }

        // Creates a table named settings' with two columns: name (a string of max 20 characters) and score (an int)
        public static void createTable()
        {
            try
            {
                string sql = "create table customtemplates (id int primary key, document_path text, list_image text, preview text)";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                Console.WriteLine("Database table created successfully");
            }
            catch (SQLiteException e)
            {
                if (e.Message.Equals("table templates already exists"))
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

     

        public static Image[] jj { set; get; }

        // get file misc
        public static Image[] getDataFrom(string column)
        {
            SQLiteCommand cmd = new SQLiteCommand("select count(preview) from customtemplates", m_dbConnection);
            cmd.CommandType = CommandType.Text;
            int rowCount = 0;
            rowCount = Convert.ToInt32(cmd.ExecuteScalar());
            jj = new Image[rowCount];
            try
            {
                string sql = "select * from customtemplates";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                            if (column.Equals("preview"))
                            {
                                jj[i] = Image.FromFile(Helper.IMPORT_PREVIEW + reader[column].ToString());
                            }
                            else
                            {
                                jj[i] = Image.FromFile(Helper.IMPORT_LIST_ICON + reader[column].ToString());
                            }
                            Console.WriteLine("Output: " + jj[i]);
                            i = i + 1;
                        
                    }
                }
            }
            catch (System.Data.SQLite.SQLiteException a)
            {
                if (a.Message.Contains("no such table"))
                {
                    //then create a table and redo insertion
                    createTable();
                }
            }
            return jj;
        }

        public static ArrayList kk { set; get; }

        public static ArrayList getPath(int data)
        {
            try
            {
                string sql = "select * from customtemplates";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                     kk.Add(reader["document_path"].ToString());
                     Console.WriteLine("Template Row: " + kk[i].ToString());
                     i++;
                    }
                    
                }
            }
            catch (System.Data.SQLite.SQLiteException a)
            {
                if (a.Message.Contains("no such table"))
                {
                    //then create a table and redo insertion
                    createTable();
                }
            }
            return kk;
        }

        private void clearCustomTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearDB();
        }

        private static void clearDB()
        {
            string sql = "delete from customtemplates";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "vacuum";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            Console.WriteLine("Database truncated successfully");
            Application.Restart();
        }

        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().Show();
        }

        private void howToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            howto();
        }

        private void howto()
        {
            if (Helper.fileExists(Helper.FULL_WORKSPACE + "Welcome to Curriculum Vitae Builder.pdf"))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + "C:\\Users\\" + Helper.getUsername() + "\\Documents\\CV Documents\\Welcome to Curriculum Vitae Builder.pdf\"");
            }
            else
            {
                Helper.folderCreate();
                BinaryWriter bw;
                bw = new BinaryWriter(new FileStream(Helper.FULL_WORKSPACE + "Welcome to Curriculum Vitae Builder.pdf", FileMode.Create));
                bw.Write(Properties.Resources.Welcome_to_Curriculum_Vitae_Builder);
                bw.Close();
                howto();
            }
        }

        private void cVTutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tutor();
        }

        private void tutor()
        {
            if (Helper.fileExists(Helper.FULL_WORKSPACE + "Custom Template Tutor.pdf"))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + "C:\\Users\\" + Helper.getUsername() + "\\Documents\\CV Documents\\Custom Template Tutor.pdf\"");
            }
            else
            {
                Helper.folderCreate();
                BinaryWriter bw;
                bw = new BinaryWriter(new FileStream(Helper.FULL_WORKSPACE + "Custom Template Tutor.pdf", FileMode.Create));
                bw.Write(Properties.Resources.Custom_Template_Tutor);
                bw.Close();
                tutor();
            }
        }
    }
}
