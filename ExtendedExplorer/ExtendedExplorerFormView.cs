using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Management;
using System.Management.Instrumentation;
using ExtendedExplorer.Properties;

namespace ExtendedExplorer {
    public partial class ExtendedExplorerFormView : Form {
        private Controller controller;
        private ListViewItemComparer Kolomsorteerder = new ListViewItemComparer();
        public Legend lgnd = new Legend();
        public int VorigeKolom = 0;

        public ExtendedExplorerFormView() {
            InitializeComponent();

            controller = new Controller(trv_computer, imgl_tree, ltv_files, tsp_cmb_locationBar, cmb_fileView, cmb_chartView, cmb_listType, drw_chartDrawing, lgnd);
            controller.PopulateAll();

            
            ltv_files.ListViewItemSorter = Kolomsorteerder;
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Set window location
            if(Settings.Default.WindowLocation != null) {
                this.Location = Settings.Default.WindowLocation;
            }

            // Set window size
            if(Settings.Default.WindowSize != null) {
                this.Size = Settings.Default.WindowSize;
            }

            tbc_right.SelectedIndex = 0;  // standard tab Files;
            cmb_fileView.SelectedIndex = 2;  // standard Detail view;
            cmb_chartView.SelectedIndex = 1;  // standard Bar;
            cmb_listType.SelectedIndex = 1;  // standard Files;
        }


        #region SORTEERICON ----------------------------------------
        public struct Headeritem
        {
            public Int32 mask;
            public String pszText;
            public IntPtr hbm;
            public Int32 cchTextMax;
            public Int32 richting;
        };

        // Parameters die nodig zijn om het pijltje en de Kolommen goed te tonen.Enige aanpassing aan deze variabelen 
        // en het gaat stuk of je krijgt iets anders dan dat je wilt
        public const Int32 HDI_FORMAT = 0x0004;
        public const Int32 HDF_LEFT = 0x0000;
        public const Int32 HDF_STRING = 0x4000;
        public const Int32 HDF_SORTUP = 0x0400;
        public const Int32 HDF_SORTDOWN = 0x0200;
        public const Int32 LVM_GETHEADER = 0x1000 + 31;
        public const Int32 HDM_GETITEM = 0x1200 + 11;
        public const Int32 HDM_SETITEM = 0x1200 + 12;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageITEM(IntPtr Handle, Int32 msg, IntPtr wParam, ref Headeritem lParam);

        private void SorteerIcoontjeAanmaken(int VorigeSorteerKolom, int NieuweSorteerKolom)
        {
            IntPtr hHeader = SendMessage(ltv_files.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            IntPtr newColumn = new IntPtr(NieuweSorteerKolom);
            IntPtr prevColumn = new IntPtr(VorigeSorteerKolom);
            Headeritem hdItem = new Headeritem();
            IntPtr returnn;
            //een intPtr is een integer die zich aanpast aan het platform waar het zich op draait(bijv X64)

            if (VorigeSorteerKolom != NieuweSorteerKolom)
            {
                // Icoontjes weghalen

                hdItem.mask = HDI_FORMAT; // alleen het format ophalen
                returnn = SendMessageITEM(hHeader, HDM_GETITEM, prevColumn, ref hdItem);
                hdItem.richting &= ~HDF_SORTDOWN & ~HDF_SORTUP; // & and 2 variabelen meegeven ~ betekent geen
                returnn = SendMessageITEM(hHeader, HDM_SETITEM, prevColumn, ref hdItem);
            }

            // nieuw icoon aanmaken

            hdItem.mask = HDI_FORMAT;
            returnn = SendMessageITEM(hHeader, HDM_GETITEM, newColumn, ref hdItem);
            if (ltv_files.Sorting == SortOrder.Ascending)
            {
                hdItem.richting &= ~HDF_SORTDOWN;   // First unset the opposite direction
                hdItem.richting |= HDF_SORTUP; 
            }
            else
            {
                hdItem.richting &= ~HDF_SORTUP;
                hdItem.richting |= HDF_SORTDOWN;
            }
            returnn = SendMessageITEM(hHeader, HDM_SETITEM, newColumn, ref hdItem);
            VorigeSorteerKolom = NieuweSorteerKolom;
        }
        #endregion



        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Kolomsorteerder.Welkekolom = e.Column;

            if (Kolomsorteerder.Welkekant == SortOrder.Ascending)
            {
                Kolomsorteerder.Welkekant = SortOrder.Descending;
                SorteerIcoontjeAanmaken(VorigeKolom, e.Column);
            }

            else
            {
                Kolomsorteerder.Welkekant = SortOrder.Ascending;
                SorteerIcoontjeAanmaken(VorigeKolom, e.Column);
            }
            VorigeKolom = e.Column;
            ltv_files.Sort();
        }


       
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e) {
            Close();
        }

        private void toolStripMainHelp_Click(object sender, EventArgs e) {
            new AboutBox().ShowDialog();
        }
        private void helpToolStripButton_Click(object sender, EventArgs e) {
            new AboutBox().ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            controller.treeView1_AfterSelect(sender, e);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            controller.comboBox1_SelectedIndexChanged(sender, e);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            controller.comboBox2_SelectedIndexChanged(sender, e);
        }
        private void cmb_listType_SelectedIndexChanged(object sender, EventArgs e) {
            controller.comboBox3_SelectedIndexChanged(sender, e);
        }
        private void button1_Click(object sender, EventArgs e) {
            lgnd.ShowDialog();
        }

        #region EXTRA ----------------------------------------
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
        private void lockPC_Click(object sender, EventArgs e) {
            TaskDialog question = new TaskDialog("Lock pc?", "Confirm lock pc", TaskDialog.IconType.Question);
            question.SetButtonYesText("Lock", "Lock my pc");
            question.SetButtonNoText("Don't lock", "Don't lock my pc");
            if(question.ShowDialog() == DialogResult.Yes) {
                LockWorkStation();
            }
        }

        private void standBy_Click(object sender, EventArgs e) {
            TaskDialog question = new TaskDialog("Really standby PC?", "Confirm standby pc", TaskDialog.IconType.Question);
            question.SetButtonYesText("Standby", "Set my pc in standby");
            question.SetButtonNoText("Don't standby", "Don't set my pc in standby");
            if(question.ShowDialog() == DialogResult.Yes) {
                Application.SetSuspendState(PowerState.Suspend, true, true);
            }
        }

        private void hibernate_Click(object sender, EventArgs e) {
            TaskDialog question = new TaskDialog("Really hibernate PC?", "Confirm hibernate pc", TaskDialog.IconType.Question);
            question.SetButtonYesText("Hibernate", "Hibernate my pc");
            question.SetButtonNoText("Don't hibernate", "Don't hibernate my pc");
            if(question.ShowDialog() == DialogResult.Yes) {
                Application.SetSuspendState(PowerState.Hibernate, true, true);
            }
        }

        private void logOff_Click(object sender, EventArgs e) {
            TaskDialog question = new TaskDialog("Really log off PC?", "Confirm log off pc", TaskDialog.IconType.Question);
            question.SetButtonYesText("Log off", "Log my pc off");
            question.SetButtonNoText("Don't log off", "Don't log my pc off");
            if(question.ShowDialog() == DialogResult.Yes) {
                ExitWindowsEx(0, 0);
            }
        }
        #endregion

        private void ExtendedExplorerFormView_FormClosing(object sender, FormClosingEventArgs e) {
            // Copy window location to app settings
            Settings.Default.WindowLocation = this.Location;

            // Copy window size to app settings
            if(this.WindowState == FormWindowState.Normal) {
                Settings.Default.WindowSize = this.Size;
            }
            else {
                Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            // Save settings
            Settings.Default.Save();
        }

        private void drw_chartDrawing_Paint(object sender, PaintEventArgs e) {

        }

        private void ltv_files_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}