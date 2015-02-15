using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Globalization;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ExtendedExplorer {
    public class Controller {
        public TreeView treeView1 = new TreeView();
        public ImageList imageList1 = new ImageList();
        public ListView listView1 = new ListView();
        public ToolStripComboBox locationBar = new ToolStripComboBox();
        public Chart chartDrawing = new Chart();
        public ComboBox comboBox1 = new ComboBox(), comboBox2 = new ComboBox(), comboBox3 = new ComboBox();
        public ListType listType = ListType.Files;
        Model model;
        Legend lgnd;

        public Controller(TreeView treeviewtje, ImageList imagelistje, ListView listjeviewtje, ToolStripComboBox locationbartje,
                ComboBox comboBox1tje, ComboBox comboBox2tje, ComboBox comboBox3tje, Chart Chartdrawingtje, Legend lgndtje)
        {

            treeView1 = treeviewtje;
            imageList1 = imagelistje;
            listView1 = listjeviewtje;
            locationBar = locationbartje;
            comboBox1 = comboBox1tje;
            comboBox2 = comboBox2tje;
            comboBox3 = comboBox3tje;
            chartDrawing = Chartdrawingtje;
            lgnd = lgndtje;

            model = new Model(chartDrawing);

            chartDrawing.draw2Legend = lgnd;
        }
        public void PopulateAll() {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(model.getDriveTree(imageList1));
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

        public void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            Cursor.Current = Cursors.WaitCursor;

            treeView1.BeginUpdate();  // suppress repainting the TreeView until all the objects have been created;

            TreeNode nodeCurrent = e.Node;  // get current selected drive or folder;
            locationBar.Text = model.getFullPath(nodeCurrent.FullPath).ToString().Replace("\\\\", "\\");

            TreeNode nodeHighest = nodeCurrent;
            while(nodeHighest.Parent != null) {  // we only want the highest node in the tree;
                nodeHighest = nodeHighest.Parent;
            }

            if(nodeCurrent == nodeHighest) {  // selected node is highest in tree: populate drive;
                treeView1.Nodes.Clear();  // clear all tree nodes;
                treeView1.Nodes.Add(model.getDriveTree(imageList1));  // add drives;
                treeView1.ExpandAll();
            }
            else {  // populate sub-folders;
                nodeCurrent.Nodes.Clear();  // clear all sub-folders;
                listView1.Items.Clear();  // clear all items;

                ArrayList treeNodes = model.getFolderTree(nodeCurrent);  // add sub-folders;
                foreach(TreeNode treeNode in treeNodes) {
                    if(treeNode != null) {
                        nodeCurrent.Nodes.Add(treeNode);
                    }
                }

                if(treeView1.SelectedNode != null) {
                    foreach(ListViewItem itm in model.populateItems(listType, listView1, treeView1.SelectedNode)) {
                        if(!listView1.Items.Contains(itm)) {
                            listView1.Items.Add(itm);
                        }
                    }
                }
                else {
                    listView1.Items.Clear();  // clear all items;
                }
            }

            treeView1.EndUpdate();  // begin repainting the TreeView;

            chartDrawing.draw();  // draw charts;

            Cursor.Current = Cursors.Default;
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if(comboBox1.SelectedItem.ToString() == "Small icon") {
                listView1.View = View.SmallIcon;
            }
            else if(comboBox1.SelectedItem.ToString() == "Large icon") {
                listView1.View = View.LargeIcon;
            }
            else if(comboBox1.SelectedItem.ToString() == "Detail view") {
                listView1.View = View.Details;
            }
            else if(comboBox1.SelectedItem.ToString() == "Tile View") {
                listView1.View = View.Tile;
            }
            else if(comboBox1.SelectedItem.ToString() == "List view") {
                listView1.View = View.List;
            }
        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            if(comboBox2.SelectedItem.ToString() == "Pie") {
                chartDrawing.View = ChartView.Pie;
            }
            else if(comboBox2.SelectedItem.ToString() == "Bar") {
                chartDrawing.View = ChartView.Bar;
            }
            chartDrawing.draw();
        }

        public void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            if(comboBox3.SelectedItem.ToString() == "Files") {
                listType = ListType.Files;
            }
            else if(comboBox3.SelectedItem.ToString() == "Folders") {
                listType = ListType.Folders;
            }
            else if(comboBox3.SelectedItem.ToString() == "Filetype") {
                listType = ListType.Extensions;
            }

            if(treeView1.SelectedNode != null) {
                foreach(ListViewItem itm in model.populateItems(listType, listView1, treeView1.SelectedNode)) {
                    if(!listView1.Items.Contains(itm)) {
                        listView1.Items.Add(itm);
                    }
                }
            }
            else {
                listView1.Items.Clear();  // clear all items;
            }
            chartDrawing.draw();
        }
    }


    // extra class to calculate folder size (includes all files within);
    public class Folder {
        private static Int64 sizeInBytes = 0;
        public static void reset() {
            sizeInBytes = 0;
        }
        public static Int64 Size(string directory, bool deep) {
            Cursor.Current = Cursors.WaitCursor;
            try {
                DirectoryInfo dir = new DirectoryInfo(directory);
                foreach(FileInfo f in dir.GetFiles()) {
                    sizeInBytes += f.Length;
                }
                if(deep) {
                    foreach(DirectoryInfo d in dir.GetDirectories()) {
                        Size(d.FullName, deep);
                    }
                }
            }
            catch(Exception) { }
            Cursor.Current = Cursors.Default;
            return sizeInBytes;
        }
    }
}