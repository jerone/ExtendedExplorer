using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Management;
using System.Globalization;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using ExtendedExplorer;

namespace test {
    class TreeView {
        public TreeView() {
            PopulateDriveList();
        }

        Form4 form4 = new Form4();
        IconReader iR = new IconReader();

        public void PopulateDriveList() {
            int imageIndex = 0;
            int selectIndex = 0;

            const int Removable = 2;
            const int LocalDisk = 3;
            const int Network = 4;
            const int CD = 5;
            const int RAMDrive = 6;
            
            form4.Cursor = Cursors.WaitCursor;
            
            form4.treeView1.Nodes.Clear();  // clear TreeView
            TreeNode nodeTreeNode = new TreeNode("My Computer", 0, 0);
            form4.treeView1.Nodes.Add(nodeTreeNode);

            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;  // set node collection

            ManagementObjectCollection queryCollection = getDrives();  // Get Drive list
            foreach(ManagementObject mo in queryCollection) {
                switch(int.Parse(mo["DriveType"].ToString())) {
                    case Removable: // removable drives
                    imageIndex = 5;
                    selectIndex = 5;
                    break;
                    case LocalDisk: // Local drives
                    imageIndex = 6;
                    selectIndex = 6;
                    break;
                    case CD:        // CD rom drives
                    imageIndex = 7;
                    selectIndex = 7;
                    break;
                    case Network:   // Network drives
                    imageIndex = 8;
                    selectIndex = 8;
                    break;
                    default:        // defalut to folder
                    imageIndex = 2;
                    selectIndex = 3;
                    break;
                }
                nodeTreeNode = new TreeNode(mo["Name"].ToString() + "\\", imageIndex, selectIndex);  // create new drive node
                nodeCollection.Add(nodeTreeNode);  // add new node
            }

            InitListView();  // Init files ListView

            form4.Cursor = Cursors.Default;
        }

        protected void InitListView() {  // init ListView control
            form4.listView1.Clear();  // clear control
            // create column header for ListView
            form4.listView1.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            form4.listView1.Columns.Add("Size", 75, System.Windows.Forms.HorizontalAlignment.Right);
            form4.listView1.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
            form4.listView1.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);
        }

        protected ManagementObjectCollection getDrives() {  // get drive collection
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
            ManagementObjectCollection queryCollection = query.Get();
            return queryCollection;
        }

        protected void PopulateDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection) {
            TreeNode nodeDir;
            int imageIndex = 2;   // unselected image index
            int selectIndex = 3;  // selected image index

            if(nodeCurrent.SelectedImageIndex != 0) {  // populate treeview with folders
                try {
                    form4.textBox1.Text = getFullPath(nodeCurrent.FullPath).ToString();

                    if(Directory.Exists(getFullPath(nodeCurrent.FullPath)) == false) {  // check path
                        MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                    }
                    else {
                        PopulateFiles(nodeCurrent);  // populate files

                        string[] stringDirectories = Directory.GetDirectories(getFullPath(nodeCurrent.FullPath));
                        string stringFullPath = "";
                        string stringPathName = "";

                        foreach(string stringDir in stringDirectories) {  // loop throught all directories
                            stringFullPath = stringDir;
                            stringPathName = GetPathName(stringFullPath);

                            // create node for directories
                            nodeDir = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
                            nodeCurrentCollection.Add(nodeDir);
                        }
                    }
                }
                catch(IOException e) {
                    MessageBox.Show("Error: Drive not ready or directory does not exist.");
                }
                catch(UnauthorizedAccessException e) {
                    MessageBox.Show("Error: Drive or directory access denided.");
                }
                catch(Exception e) {
                    MessageBox.Show("Error: " + e);
                }
            }
        }

        protected string GetPathName(string stringPath) {  // Get Name of folder
            string[] stringSplit = stringPath.Split('\\');
            int _maxIndex = stringSplit.Length;
            return stringSplit[_maxIndex - 1];
        }

        protected void PopulateFiles(TreeNode nodeCurrent) {  // Populate listview with files
            string[] lvData = new string[4];

            InitListView();  // clear list

            if(nodeCurrent.SelectedImageIndex != 0) {  // check path
                if(Directory.Exists((string)getFullPath(nodeCurrent.FullPath)) == false) {
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                }
                else {
                    try {
                        string[] stringFiles = Directory.GetFiles(getFullPath(nodeCurrent.FullPath));
                        string stringFileName = "";
                        DateTime dtCreateDate, dtModifyDate;
                        Int64 lFileSize = 0;


                        foreach(string stringFile in stringFiles) {  // loop throught all files
                            stringFileName = stringFile;
                            FileInfo objFileSize = new FileInfo(stringFileName);
                            lFileSize = objFileSize.Length;
                            dtCreateDate = objFileSize.CreationTime;  // GetCreationTime(stringFileName);
                            dtModifyDate = objFileSize.LastWriteTime;  // GetLastWriteTime(stringFileName);

                            //create listview data
                            lvData[0] = GetPathName(stringFileName);
                            lvData[1] = formatSize(lFileSize);

                            //check if file is in local current day light saving time
                            if(TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false) {
                                //not in day light saving time adjust time
                                lvData[2] = formatDate(dtCreateDate.AddHours(1));
                            }
                            else {
                                //is in day light saving time adjust time
                                lvData[2] = formatDate(dtCreateDate);
                            }

                            //check if file is in local current day light saving time
                            if(TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false) {
                                //not in day light saving time adjust time
                                lvData[3] = formatDate(dtModifyDate.AddHours(1));
                            }
                            else {
                                //not in day light saving time adjust time
                                lvData[3] = formatDate(dtModifyDate);
                            }

                            //Create actual list item
                            ListViewItem lvItem = new ListViewItem(lvData, 0);
                            form4.listView1.Items.Add(lvItem);
                        }
                    }
                    catch(IOException e) {
                        MessageBox.Show("Error: Drive not ready or directory does not exist.");
                    }
                    catch(UnauthorizedAccessException e) {
                        MessageBox.Show("Error: Drive or directory access denided.");
                    }
                    catch(Exception e) {
                        MessageBox.Show("Error: " + e);
                    }
                }
            }
        }

        protected string formatDate(DateTime dtDate) {  // Get date and time in short format
            return dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();
        }

        protected string getFullPath(string stringPath) {  // remove My Computer from path.
            return stringPath.Replace("My Computer\\", "");
        }

        protected string formatSize(Int64 lSize) {  // Format number to KB
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            IntPtr hImgSmall;    // the handle to the system image list
            IntPtr hImgLarge;    // the handle to the system image list
            string fName = "";
            SHFILEINFO shinfo = new SHFILEINFO();

            form4.listView1.SmallImageList = form4.imageList1;
            form4.imageList1.ColorDepth = ColorDepth.Depth16Bit;
            form4.imageList1.ImageSize = new Size(16, 16);

            // Use this to get the small Icon
            hImgSmall = Win32.SHGetFileInfo(fName, 0, ref shinfo,
                                           (uint)Marshal.SizeOf(shinfo),
                                            Win32.SHGFI_ICON |
                                            Win32.SHGFI_SMALLICON);

            // Use this to get the large Icon
            hImgLarge = Win32.SHGetFileInfo(fName, 0, ref shinfo,
                                           (uint)Marshal.SizeOf(shinfo),
                                            Win32.SHGFI_ICON |
                                            Win32.SHGFI_LARGEICON);

            // The icon is returned in the hIcon member of the shinfo struct
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

            form4.imageList1.Images.Add(iR.getSmallFileTypeIcon(fName));
            form4.listView1.LargeImageList = form4.imageList1;
            form4.treeView1.ImageList = form4.imageList1;

            form4.Cursor = Cursors.WaitCursor;

            TreeNode nodeCurrent = e.Node;  // get current selected drive or folder

            nodeCurrent.Nodes.Clear();  // clear all sub-folders

            if(nodeCurrent.SelectedImageIndex == 0) {  // Selected My Computer - repopulate drive list
                PopulateDriveList();
            }
            else {  // populate sub-folders and folder files
                PopulateDirectory(nodeCurrent, nodeCurrent.Nodes);
            }

            form4.Cursor = Cursors.Default;

            form4.listView1.LargeImageList = form4.imageList1;
            form4.treeView1.ImageList = form4.imageList1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if(form4.comboBox1.SelectedItem.ToString() == "Small icon") {
                form4.listView1.View = View.SmallIcon;
            }
            else if(form4.comboBox1.SelectedItem.ToString() == "Large icon") {
                form4.listView1.View = View.LargeIcon;
            }
            else if(form4.comboBox1.SelectedItem.ToString() == "Detail view") {
                form4.listView1.View = View.Details;
            }
            else if(form4.comboBox1.SelectedItem.ToString() == "Tile View") {
                form4.listView1.View = View.Tile;
            }
            else if(form4.comboBox1.SelectedItem.ToString() == "List view") {
                form4.listView1.View = View.List;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        class Win32 {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0;    // Large icon
            public const uint SHGFI_SMALLICON = 0x1;    // Small icon

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath,
                                                      uint dwFileAttributes,
                                                      ref SHFILEINFO psfi,
                                                      uint cbSizeFileInfo,
                                                      uint uFlags);
        }
    }
}
