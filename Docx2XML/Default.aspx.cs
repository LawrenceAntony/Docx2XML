using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace Docx2XML
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnProcess_Click(object sender, EventArgs e)
        {


            if (FileUploader1.PostedFile.InputStream!=null)
            {
                //using (WordprocessingDocument ObjDoc = WordprocessingDocument.Open(FileUploader1.PostedFile.InputStream, false))
                //{
                if (AWSS3.CreateFileFromStream(FileUploader1.PostedFile.InputStream, System.IO.Path.GetFileName(  FileUploader1.PostedFile.FileName)))
                {
                    LabelOutput.Text = "File Successfully saved.";
                }
                else
                    LabelOutput.Text = "Save Failed";

                
                   // LabelOutput.Text = ObjDoc.MainDocumentPart.Document.Descendants<Paragraph>().Count().ToString() + "paragraphs found in this document.";
                //}

                
            }
        }
    }
}