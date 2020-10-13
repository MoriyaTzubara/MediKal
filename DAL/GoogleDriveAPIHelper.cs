using BE;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
   public class GoogleDriveAPIHelper
    {
        //add scope
        public string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };

        /// <summary>
        /// create Drive API service
        /// </summary>
        /// <returns></returns>
        public DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            //Root Folder of project
            var CSPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            using (var stream =
                           new FileStream(@"C:\Users\User\Desktop\MediKal\DAL\credentials.json", FileMode.Open, FileAccess.Read))
            {
                String FolderPath = System.Web.Hosting.HostingEnvironment.MapPath("~/"); ;
                String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(FilePath, true)).Result;
            }
            //create Drive API service.
            DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveMVCUpload",
            });
            return service;
        }

        /// <summary>
        /// file Upload to the Google Drive root folder
        /// </summary>
        /// <param name="file"></param>
        public void UploadFileOnDrive(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                //create service
                DriveService service = GetService();
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                Path.GetFileName(file.FileName));
                file.SaveAs(path);
                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(file.FileName);
                FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }



            }
        }

        private string folderNameToFolderId(string folderName)
        {
            return (from folder in this.GetDriveFolders()
                    where folder.Name == folderName
                    select folder.Id).FirstOrDefault();

        }
        /// <summary>
        /// File upload to the Google Drive in existing folder
        /// </summary>
        /// <param name="file"></param>
        /// <param name="folderId"></param>
        public void UploadFileOnDriveInFolder(HttpPostedFileBase file, string folderName)
        {
            if (file != null && file.ContentLength > 0)
            {
                //convert from folder name to it Id
                string folderId = this.folderNameToFolderId(folderName);
                //if folder not founded- create one and enter the file to the new folder
                if (folderId == null)
                {
                    this.CreateFolder(folderName);
                    folderId = this.folderNameToFolderId(folderName);
                }
                //create service
                DriveService service = GetService();
                //get file path
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                Path.GetFileName(file.FileName));
                file.SaveAs(path);
                //create file metadata
                var FileMetaData = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(file.FileName),
                    MimeType = MimeMapping.GetMimeMapping(path),
                    //id of parent folder 
                    Parents = new List<string>
                    {
                        folderId
                    }
                };
                FilesResource.CreateMediaUpload request;
                //create stream and upload
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
                var file1 = request.ResponseBody;
            }
        }

        /// <summary>
        /// File upload to the Google Drive in existing folder with new file name
        /// </summary>
        /// <param name="file"></param>
        /// <param name="folderId"></param>
        /// <param name="newFileName"></param>
        public void UplaodFileOnDriveInFolder(HttpPostedFileBase file, string newFileName, string folderName)
        {
            if (file != null && file.ContentLength > 0)
            {
                //convert from folder name to it Id
                string folderId = this.folderNameToFolderId(folderName);
                //if folder not founded- create one and enter the file to the new folder
                if (folderId == null)
                {
                    this.CreateFolder(folderName);
                    folderId = this.folderNameToFolderId(folderName);
                }
                //create service
                DriveService service = GetService();
                //get file path
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                Path.GetFileName(file.FileName));
                file.SaveAs(path);
                //create file metadata
                var FileMetaData = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = newFileName + Path.GetExtension(file.FileName),
                    MimeType = MimeMapping.GetMimeMapping(path),
                    //id of parent folder 
                    Parents = new List<string>
                    {
                        folderId
                    }
                };
                FilesResource.CreateMediaUpload request;
                //create stream and upload
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
                var file1 = request.ResponseBody;
            }
        }

        /// <summary>
        /// returns all files from drive
        /// </summary>
        /// <returns></returns>
        public List<GoogleDriveFile> GetDriveFiles()
        {
            Google.Apis.Drive.v3.DriveService service = GetService();
            // Define parameters of request.
            Google.Apis.Drive.v3.FilesResource.ListRequest FileListRequest = service.Files.List();

            // for getting folders only.
            //FileListRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            FileListRequest.Fields = "nextPageToken, files(*)";
            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDriveFile> FileList = new List<GoogleDriveFile>();
            // For getting only folders
            // files = files.Where(x => x.MimeType == "application/vnd.google-apps.folder").ToList();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    GoogleDriveFile File = new GoogleDriveFile
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime,
                        Parents = file.Parents,
                        MimeType = file.MimeType
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }

        /// <summary>
        /// get only the folders from google drive
        /// </summary>
        /// <returns></returns>
        public List<GoogleDriveFile> GetDriveFolders()
        {
            DriveService service = GetService();
            List<GoogleDriveFile> FolderList = new List<GoogleDriveFile>();
            FilesResource.ListRequest request = service.Files.List();
            request.Q = "mimeType='application/vnd.google-apps.folder'";
            request.Fields = "files(id, name)";
            Google.Apis.Drive.v3.Data.FileList result = request.Execute();
            foreach (var file in result.Files)
            {
                GoogleDriveFile File = new GoogleDriveFile
                {
                    Id = file.Id,
                    Name = file.Name,
                    Size = file.Size,
                    Version = file.Version,
                    CreatedTime = file.CreatedTime
                };
                FolderList.Add(File);
            }
            return FolderList;
        }

        /// <summary>
        /// Create Folder in root
        /// </summary>
        /// <param name="FolderName"></param>
        public void CreateFolder(string FolderName)
        {
            DriveService service = GetService();
            var FileMetaData = new Google.Apis.Drive.v3.Data.File();
            FileMetaData.Name = FolderName;
            //this mimetype specify that we need folder in google drive
            FileMetaData.MimeType = "application/vnd.google-apps.folder";
            FilesResource.CreateRequest request;
            request = service.Files.Create(FileMetaData);
            request.Fields = "id";
            var file = request.Execute();

        }

        /// <summary>
        /// Download file from Google Drive by file name (the name should be without extension)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string DownloadGoogleFileByName(string fileName)
        {
            string fileId = (from file in this.GetDriveFiles()
                             where file.Name == (fileName)
                             select file.Id).FirstOrDefault();
            if (fileId != null)
                return this.DownloadGoogleFile(fileId);
            else
                return "icorrect file name";
        }

        /// <summary>
        /// Download file from Google Drive by fileId
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string DownloadGoogleFile(string fileId)
        {
            DriveService service = GetService();
            string FolderPath = HttpContext.Current.Server.MapPath("/GoogleDriveFiles/");
            FilesResource.GetRequest request = service.Files.Get(fileId);
            string FileName = request.Execute().Name;
            string FilePath = Path.Combine(FolderPath, FileName);
            MemoryStream stream1 = new MemoryStream();
            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            //Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            // Console.WriteLine("Download complete.");
                            SaveStream(stream1, FilePath);
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            //Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream1);
            return FilePath;
        }

        /// <summary>
        /// file save to server path
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="FilePath"></param>
        private void SaveStream(MemoryStream stream, string FilePath)
        {
            using (FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }


    }

}

