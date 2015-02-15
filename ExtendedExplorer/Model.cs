using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Globalization;
using System.Drawing;
using System.Collections.Generic;

namespace ExtendedExplorer {
    public class Model {
        Chart chartDrawing;
        public Model(Chart chartDrawingtje) {
            chartDrawing = chartDrawingtje;
        }

        public TreeNode getDriveTree(ImageList imageList) {
            int imageIndex = 1;
            int selectIndex = 1;

            imageList.Images.Add(IconReader.Instance.getClosedFolderIcon());  // add closed folder icon;
            TreeNode nodeTreeNode = new TreeNode("My Computer", 0, 0);  // create root node;

            ManagementObjectSearcher queryCollection = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
            foreach(ManagementObject disk in queryCollection.Get()) {
                string diskName = disk["Name"].ToString();
                imageList.Images.Add(diskName, IconReader.Instance.getSmallFileTypeIcon(diskName));
                nodeTreeNode.Nodes.Add(new TreeNode(diskName + @"\", imageIndex, selectIndex));
                imageIndex++;
                selectIndex++;
            }
            return nodeTreeNode;
        }

        public ArrayList getFolderTree(TreeNode nodeCurrent) {
            int imageIndex = 0;
            int selectIndex = 0;

            ArrayList treenodeArray = new ArrayList();

            try {
                if(Directory.Exists(getFullPath(nodeCurrent.FullPath)) == false) {  // check path;
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    foreach(string stringDir in Directory.GetDirectories(getFullPath(nodeCurrent.FullPath))) {  // loop throught all directories;
                        treenodeArray.Add(new TreeNode(GetPathName(stringDir), imageIndex, selectIndex));  // create node for directories;
                    }
                }
            }
            catch(IOException) {
                MessageBox.Show("Error: Drive not ready or directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(UnauthorizedAccessException) {
                MessageBox.Show("Error: Drive or directory access denided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e) {
                MessageBox.Show("Error: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return treenodeArray;
        }


        public ListView.ListViewItemCollection populateItems(ListType listType, ListView listView, TreeNode selectedNode) {
            TreeNode nodeHighest = selectedNode;
            while(nodeHighest.Parent != null) {  // we only want the highest node in the tree;
                nodeHighest = nodeHighest.Parent;
            }
            if(selectedNode != nodeHighest) {
                switch(listType) {
                    case ListType.Files:
                        return getFileList(selectedNode, listView);
                    case ListType.Folders:
                        return getFolderList(selectedNode, listView);
                    case ListType.Extensions:
                        return getFileExtensionList(selectedNode, listView);
                }
            }
            else {
                listView.Items.Clear();  // clear all items;
            }
            return null;
        }

        private ListView.ListViewItemCollection getFolderList(TreeNode nodeCurrent, ListView listView) {  // Populate listview with files
            ListView.ListViewItemCollection newList = new ListView.ListViewItemCollection(listView);
            newList.Clear();
            try {
                if(Directory.Exists(getFullPath(nodeCurrent.FullPath)) == false) {  // check path;
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    string[] dirData = new string[5] { "0", "0", "0", "0", "0" }; // array op 0 zetten
                    Int64 TotaleFileSizes = 0, tempFolderSize = 0;
                    double Percentage = 0;
                    string tempPercentage = "0";
                    DirectoryInfo dirInfo;

                    foreach(string stringDir in Directory.GetDirectories(getFullPath(nodeCurrent.FullPath))) {
                        // Dit gehele stuk is nodig om vooraf de Foreach loop te doorlopen om zo het totale size aan data op te halen.
                        // Daarna kan je het per stuk met een Percentage berekening uitrekenen.
                        try {
                            TotaleFileSizes += Folder.Size(stringDir, true);
                            Folder.reset();  // set total back to 0;
                        }
                        catch(Exception) {
                            TotaleFileSizes += 0;
                        }
                    }

                    foreach(string stringDir in Directory.GetDirectories(getFullPath(nodeCurrent.FullPath))) {  // loop throught all directories;
                        dirInfo = new DirectoryInfo(stringDir);

                        if(!newList.ContainsKey(dirInfo.Name)) {  // does not exist in list;
                            try {
                                tempFolderSize = Folder.Size(stringDir, true);
                                Folder.reset();  // set total back to 0;
                            }
                            catch(Exception) {
                                tempFolderSize = 0;
                            }

                            Percentage = (tempFolderSize / float.Parse(TotaleFileSizes.ToString())) * 100;
                            if(Percentage < 1) {
                                tempPercentage = "≤ 0 %";
                            }
                            else {
                                tempPercentage = Percentage.ToString("0.000") + " %";
                                if(tempPercentage.EndsWith("000 %")) { // Als een percentage bijv eindigt met 000 %, dan word het geheel afgerond
                                    tempPercentage = Math.Round(Percentage) + " %";
                                }
                            }

                            dirData[0] = GetPathName(stringDir);
                            dirData[1] = formatSize(tempFolderSize);
                            dirData[2] = formatDate(dirInfo.CreationTime);
                            dirData[3] = formatDate(dirInfo.LastWriteTime);
                            dirData[4] = tempPercentage;
                            
                            ListViewItem dirDatas = new ListViewItem(dirData);
                            dirDatas.Name = dirInfo.Name;  // key;
                            newList.Add(dirDatas);
                        }
                    }
                }
            }
            catch(IOException) {
                MessageBox.Show("Error: Drive not ready or directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(UnauthorizedAccessException) {
                MessageBox.Show("Error: Drive or directory access denided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e) {
                MessageBox.Show("Error: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newList;
        }

        private ListView.ListViewItemCollection getFileList(TreeNode nodeCurrent, ListView listView) {  // Populate listview with files
            ListView.ListViewItemCollection newList = new ListView.ListViewItemCollection(listView);
            newList.Clear();
            try {
                if(Directory.Exists((string)getFullPath(nodeCurrent.FullPath)) == false) {  // check path;
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    IDictionary Data = new Dictionary<string, long>();
                    string[] fileData = new string[5] { "0", "0", "0", "0", "0" };
                    Int64 TotaleFileSizes = 0;
                    double Percentage = 0;
                    string tempPercentage = "0";
                    FileInfo fileInfo;

                    foreach(string file in Directory.GetFiles(getFullPath(nodeCurrent.FullPath))) {
                        // Dit gehele stuk is nodig om vooraf de Foreach loop te doorlopen om zo het totale size aan data op te halen.
                        // Daarna kan je het per stuk met een Percentage berekening uitrekenen.
                        fileInfo = new FileInfo(file);
                        TotaleFileSizes += Int64.Parse(fileInfo.Length.ToString().Replace(",", ""));
                    }

                    foreach(string file in Directory.GetFiles(getFullPath(nodeCurrent.FullPath))) {  // loop throught all files;
                        fileInfo = new FileInfo(file);
                        if(!newList.ContainsKey(fileInfo.Name)) {  // does not exist in list;
                            Percentage = (long.Parse(fileInfo.Length.ToString()) / float.Parse(TotaleFileSizes.ToString())) * 100;
                            if(Percentage < 1) {
                                tempPercentage = "≤ 0 %";
                            }
                            else {
                                tempPercentage = Percentage.ToString("0.000") + " %";
                                if(tempPercentage.EndsWith("000 %")) { // Als een percentage bijv eindigt met 000 %, dan word het geheel afgerond
                                    tempPercentage = Math.Round(Percentage) + " %";
                                }
                            }

                            fileData[0] = fileInfo.Name;  // file size;
                            fileData[1] = formatSize(fileInfo.Length);
                            fileData[2] = formatDate(fileInfo.CreationTime);
                            fileData[3] = formatDate(fileInfo.LastWriteTime);
                            fileData[4] = tempPercentage;

                            ListViewItem fileDatas = new ListViewItem(fileData);
                            fileDatas.Name = fileInfo.Name;  // key;
                            newList.Add(fileDatas);
                            Data.Add(file, fileInfo.Length);
                        }
                    }
                    chartDrawing.Data = Data;
                }
            }
            catch(IOException) {
                MessageBox.Show("Error: Drive not ready or directory does not exist.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch(UnauthorizedAccessException) {
                MessageBox.Show("Error: Drive or directory access denided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e) {
                MessageBox.Show("Error: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newList;
        }

        private ListView.ListViewItemCollection getFileExtensionList(TreeNode nodeCurrent, ListView listView) {  // get file list with extensions;
            ListView.ListViewItemCollection newList = new ListView.ListViewItemCollection(listView);
            newList.Clear();
            try {
                if(Directory.Exists((string)getFullPath(nodeCurrent.FullPath)) == false) {  // check path;
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    IDictionary Data = new Dictionary<string, long>();
                    string[] fileData = new string[5] { "0", "0", "0", "0", "0" };
                    Int64 TotaleFileSizes = 0;
                    double Percentage = 0;
                    string tempPercentage = "0";
                    FileInfo fileInfo;
                    IDictionary tempFileSize = new Dictionary<string, Int64>();
                    
                    foreach(string file in Directory.GetFiles(getFullPath(nodeCurrent.FullPath))) {
                        // Dit gehele stuk is nodig om vooraf de Foreach loop te doorlopen om zo het totale size aan data op te halen.
                        // Daarna kan je het per stuk met een Percentage berekening uitrekenen.
                        fileInfo = new FileInfo(file);
                        if(tempFileSize.Contains(fileInfo.Extension.ToLower())) {
                            tempFileSize[fileInfo.Extension.ToLower()] = (long)tempFileSize[fileInfo.Extension.ToLower()] + fileInfo.Length;
                        }
                        else {
                            tempFileSize.Add(fileInfo.Extension.ToLower(), fileInfo.Length);
                        }
                        TotaleFileSizes += Int64.Parse(fileInfo.Length.ToString().Replace(",", ""));
                    }

                    foreach(string file in Directory.GetFiles(getFullPath(nodeCurrent.FullPath))) {  // loop throught all files;
                        fileInfo = new FileInfo(file);
                        if(!newList.ContainsKey(fileInfo.Extension.ToLower())) {  // does not exist in list;
                            Percentage = ((long)tempFileSize[fileInfo.Extension.ToLower()] / float.Parse(TotaleFileSizes.ToString())) * 100;
                            if(Percentage < 1) {
                                tempPercentage = "≤ 0 %";
                            }
                            else {
                                tempPercentage = Percentage.ToString("0.000") + " %";
                                if(tempPercentage.EndsWith("000 %")) { // Als een percentage bijv eindigt met 000 %, dan word het geheel afgerond
                                    tempPercentage = Math.Round(Percentage) + " %";
                                }
                            }
                            fileData[0] = fileInfo.Extension.ToLower();  // file extension;
                            fileData[1] = formatSize(fileInfo.Length);
                            fileData[2] = "-";
                            fileData[3] = "-";
                            fileData[4] = tempPercentage;
                            ListViewItem fileDatas = new ListViewItem(fileData);
                            fileDatas.Name = fileInfo.Extension.ToLower();  // key;
                            newList.Add(fileDatas);
                        }
                        else {  // does exist, so sum;

                            long temp = (long.Parse(newList[fileInfo.Extension.ToLower()].SubItems[1].Text.Replace(",", "").Replace("KB", ""))*1024);

                            newList[fileInfo.Extension.ToLower()].SubItems[1].Text = formatSize(temp + fileInfo.Length);

                            Percentage = (temp / TotaleFileSizes) * 100;
                            if(Percentage < 1) {
                                tempPercentage = "≤ 1 %";

                            }
                            else {
                                tempPercentage = Percentage.ToString("0.000") + " %";
                                if(tempPercentage.EndsWith("000 %")) { // Als een percentage bijv eindigt met 000 %, dan word het geheel afgerond
                                    tempPercentage = Math.Round(Percentage) + " %";
                                }
                            }

                            newList[fileInfo.Extension.ToLower()].SubItems[4].Text = tempPercentage;
                        }
                    }
                }
            }
            catch(IOException) {
                MessageBox.Show("Error: Drive not ready or directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(UnauthorizedAccessException) {
                MessageBox.Show("Error: Drive or directory access denided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e) {
                MessageBox.Show("Error: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newList;
        }


        public string formatDate(DateTime dtDate) {  // Get date and time in short format;
            if(TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtDate) == false) {  // check if file is in local current day light saving time;
                dtDate = dtDate.AddHours(1);
            }
            return dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();
        }

        public string formatSize(Int64 lSize) {  // Format number to KB
            string stringSize = "";
            NumberFormatInfo myNfi = new NumberFormatInfo();
            Int64 lKBSize = 0;

            if(lSize < 1024) {
                if(lSize == 0) {  // zero byte
                    stringSize = "0";
                }
                else {  // less than 1K but not zero byte
                    stringSize = "1";
                }
            }
            else {
                lKBSize = lSize / 1024;  // convert to KB
                stringSize = lKBSize.ToString("n", myNfi);  // format number with default format
                stringSize = stringSize.Replace(".00", "");  // remove decimal
            }
            return stringSize + " KB";
        }

        public string getFullPath(string stringPath) {  // remove My Computer from path.
            return @stringPath.Replace("My Computer\\", "");
        }

        public string GetPathName(string stringPath) {  // Get Name of folder
            string[] stringSplit = stringPath.Split('\\');
            int _maxIndex = stringSplit.Length;
            return stringSplit[_maxIndex - 1];
        }
    }
}