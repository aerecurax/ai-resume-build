using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CV_Creator
{
    class Junks
    {
        private void test()
        {

            try
            {

                //  Just to kill WINWORD.EXE if it is running
                //killprocess("winword");
                //  copy letter format to temp.doc
                //File.Copy("C:\\OfferLetter.doc", "c:\\temp.doc", true);
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = false;

                //  create Word document object
                Word.Document aDoc = null;

                //  create & define filename object with temp.doc
                object filename = "C:\\Users\\temp\\Documents\\samplee.docx";
                //  if temp.doc available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Documents.Application.Visible = false;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                            ref readOnly, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref isVisible, ref missing, ref missing,
                            ref missing, ref missing);
                    aDoc.Activate();
                    //  Call FindAndReplace()function for each change
                    this.FindAndReplace(wordApp, "<Name>", "Emmanuel Sunesis".Trim());
                    this.FindAndReplace(wordApp, "<Phone number>", "08142412522".Trim());
                    this.FindAndReplace(wordApp, "<Address>",
                "Plot 22, Owoseni Street".Trim());
                    //  save temp.doc after modified
                    aDoc.Save();
                    wordApp.Documents.Close();
                    wordApp.Quit(true, ref missing, ref missing);
                }
                else
                    MessageBox.Show("File does not exist.",
            "No File", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                //killprocess("winword");

            }
            catch (Exception)
            {
                MessageBox.Show("Error in process.", "Internal Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FindAndReplace(Word.Application wordApp,
            object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = false;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }
    }
}
