using System;
using System.IO;
using System.Web;

namespace Vizew.WebUI
{
    static public partial class Extension
    {
        public static bool CheckImageType(this HttpPostedFileBase postedFile)
        {
            return postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" 
                || postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/gif";
        }

        public static bool CheckImageSize(this HttpPostedFileBase postedFile, int mb)
        {
            return postedFile.ContentLength / 1024 / 1024 < mb;
        }

        public static string SaveImage(this HttpPostedFileBase postedFile, string folder)
        {
            string fileName = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss")+ Path.GetFileName(postedFile.FileName);
            string path = Path.Combine(folder, fileName);
            postedFile.SaveAs(path);
            return fileName;
        }

        public static void MoveFile(this HttpServerUtilityBase server,string folder
            , string imageSourceName, string imageDestinationPath)
        {
            imageSourceName = server.MapPath(Path.Combine(folder, imageSourceName));
            imageDestinationPath = server.MapPath(Path.Combine(folder, imageDestinationPath));

            File.Move(imageSourceName, imageDestinationPath);
        }
    }


}