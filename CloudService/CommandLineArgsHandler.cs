﻿using Disk.SDK;
using Disk.SDK.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudService
{
    public class CommandLineArgsHandler
    {
        Zipper zip;
        DiskSdkClient sdk;
        Requester req;
        string diskpath, archname, password, folderpath, archpath;
        int days;
        public delegate void Dgt();
        public event Dgt Completed;
        public event Dgt Error;
        public CommandLineArgsHandler(string token, string diskpathin, string archnamein, int daysin, string passwordin, string folderpathin)
        {
            zip = new Zipper();
            sdk = new DiskSdkClient(token);
            req = new Requester(token);
            diskpath = diskpathin;
            archname = archnamein;
            days = daysin;
            password = passwordin;
            folderpath = folderpathin;
        }
        public void StartAndZip()
        {
            if (Directory.Exists(folderpath))
            {
                archname = archname + "_" +
                    DateTime.Today.ToString("d").Replace(".", "") + ".zip";
                zip.Completed += SendAfterZip;
                zip.Zip(folderpath, archname, password, Directory.GetFiles(folderpath));
                archpath = zip.archPath;
            }
            else
                Error?.Invoke();
        }
        private void SendAfterZip()
        {
            var arhstream = new FileStream(archpath, FileMode.Open);
            if (diskpath.Length > 0 && !diskpath.EndsWith("/")) diskpath = diskpath + "/";
            sdk.UploadFileAsync(diskpath + archname, arhstream, new AsyncProgress(Progress), this.SdkOnUploadCompleted);
        }
        private void SdkOnUploadCompleted(object sender, SdkEventArgs e)
        {
            if (e.Error == null)
            {
                File.Delete(archpath);
                GetList();
            }
            else
                Error?.Invoke();
        }
        private void GetList()
        {
            req.GetList(diskpath);
            req.InfoCompleted += DeleteOldFiles;
        }
        private void DeleteOldFiles()
        {
            req.DeleteCompleted += AllCompleted;
            req.DeleteOldFiles(days);
        }
        private void AllCompleted()
        {
            Completed?.Invoke();
        }
        private void Progress(ulong current, ulong total) { }
    }
}
