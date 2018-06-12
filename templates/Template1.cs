using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CV_Creator.templates
{
    public partial class Template1: Form
    {
        
        public Template1()
        {
            InitializeComponent();
            nationality.Text = "Nigerian";
            languages.Text = "English";
           
            sex.SelectedItem = 1;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Boolean checkContent(TextBox e)
        {
            if (e.Text.Equals(""))
                return false;
            else
                return true;
        }

        private string extractString(TextBox e)
        {
            return e.Text;
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (checkContent(fullname))
            {
                if (checkContent(address))
                {
                    if (checkContent(phone))
                    {
                        if (checkContent(place_of_birth))
                        {
                            if (checkContent(soo))
                            {
                                if (checkContent(nationality))
                                {
                                    if (checkContent(religion))
                                    {
                                        if (checkContent(languages))
                                        {
                                            if (checkContent(objectives))
                                            {
                                                if (checkContent(address))
                                                {
                                                    if (checkContent(certificates))
                                                    {
                                                        if (checkContent(work))
                                                        {
                                                            if (checkContent(hobbies))
                                                            {
                                                                if (checkContent(referees))
                                                                {
                                                                    createCV();
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Referees Field cannot be empty", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Hobbies Field cannot be empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Work Field cannot be empty", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Certificates Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Educational Background Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Your Objectives Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Language Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Religion Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Nationality Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("State of Origin Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Place of Birth Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phone number Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Address Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else
            {
                MessageBox.Show("Name Field cannot be empty", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Helper.getStateUseForTemplate();
            this.Close();
        }


        private void createCV()
        {
            Helper.copyTemplate(fullname.Text.ToLower(), phone.Text.ToLower(), Properties.Resources.template1);
            try
            {
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = false;

                //  create Word document object
                Word.Document aDoc = null;

                //  create & define filename object with temp.doc
                object filename = Helper.FULL_WORKSPACE + fullname.Text.ToLower()+".docx";
                //  if temp.doc available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = true;
                    //  make visible Word application
                    wordApp.Documents.Application.Visible = true;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                            ref readOnly, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref isVisible, ref missing, ref missing,
                            ref missing, ref missing);
                    aDoc.Activate();
                    //  Call FindAndReplace()function for each change
                    this.FindAndReplace(wordApp, aDoc, "Fullname", fullname.Text);
                    this.FindAndReplace(wordApp, aDoc, "Address", address.Text);
                    this.FindAndReplace(wordApp, aDoc, "Phone", phone.Text);
                    this.FindAndReplace(wordApp, aDoc, "DOB", dob.Text);
                    this.FindAndReplace(wordApp, aDoc, "Sex", sex.Text);
                    this.FindAndReplace(wordApp, aDoc, "Marital", marital.Text);
                    this.FindAndReplace(wordApp, aDoc, "Birth", place_of_birth.Text);
                    this.FindAndReplace(wordApp, aDoc, "State", soo.Text);
                    this.FindAndReplace(wordApp, aDoc, "LGA", lga.Text + " ");
                    this.FindAndReplace(wordApp, aDoc, "Nationality", nationality.Text);
                    this.FindAndReplace(wordApp, aDoc, "Religion", religion.Text);
                    this.FindAndReplace(wordApp, aDoc, "Language", languages.Text);
                    this.FindAndReplace(wordApp, aDoc, "Objectives", objectives.Text);
                    this.FindAndReplace(wordApp, aDoc, "Education", edu.Text);
                    this.FindAndReplace(wordApp, aDoc, "Certificates", certificates.Text);
                    this.FindAndReplace(wordApp, aDoc, "Work", work.Text);
                    this.FindAndReplace(wordApp, aDoc, "Hobbies", hobbies.Text);
                    this.FindAndReplace(wordApp, aDoc, "Referee", referees.Text);

                    //  save temp.doc after modified
                    aDoc.Save();

                    //wordApp.Application.Quit();
                    MessageBox.Show("Creation successful", "Information",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Helper.getStateUseForTemplate();
                    this.Close();
                }
                else
                {
                    Helper.copyTemplate(fullname.Text.ToLower(), phone.Text.ToLower(), Properties.Resources.template1);
                    createCV();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error in process. "+e.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FindAndReplace(Word.Application wordApp, Word.Document aDoc,
            object bookmarkId, object replaceText)
        {
            aDoc.Bookmarks[(string)bookmarkId].Select();
            wordApp.Selection.TypeText((string)replaceText);
        }
        
    }
}
