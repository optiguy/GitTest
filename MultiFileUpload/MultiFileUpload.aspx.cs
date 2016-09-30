using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiFileUpload
{
    public partial class MultiFileUpload : System.Web.UI.Page
    {

        private List<string> messages = new List<string>();
        private int maxAllowedFileSize = 1024 * 1000 * 12;
        private List<string> allowedFileTypes = new List<string>(){
            {"image/jpeg"},
            {"image/gif"},
            {"audio/mpeg3"},
            {"video/mp4"}
        };
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_upload_Click(object sender, EventArgs e)
        {
            
            foreach(HttpPostedFile file in Fileupload_multi.PostedFiles)
            {
                //Tjek på den enkelte fils størrelse
                if (file.ContentLength >= maxAllowedFileSize)
                {
                    messages.Add(String.Format("Filen <strong>{0}</strong> er for stor!", file.FileName));
                    return;
                }

                if (!allowedFileTypes.Contains(file.ContentType))
                {
                    messages.Add(String.Format("Filtypen {0} er ikke tilladt for fil {1}", file.ContentType, file.FileName));
                    return;
                }

                Guid uniktId = Guid.NewGuid();
                string nytNavn = uniktId.ToString() + "_" + file.FileName;
            }
            ShowMessages();
        }

        private void ShowMessages()
        {
            string html = "";
            foreach (string message in messages)
            {
                html += string.Format("<li>{0}</li>", message);
            }
            Literal_message.Text = "<ul>" + html + "</ul>";
        }
    }
}