namespace ExtendedExplorer {
    partial class ExtendedExplorerFormView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("My Computer");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtendedExplorerFormView));
            this.trv_computer = new System.Windows.Forms.TreeView();
            this.imgl_tree = new System.Windows.Forms.ImageList(this.components);
            this.tsp_main = new System.Windows.Forms.ToolStrip();
            this.tsp_ddb_file = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsp_mnu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp_ddb_help = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsp_mnu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.tsp_location = new System.Windows.Forms.ToolStrip();
            this.tsp_lbl_address = new System.Windows.Forms.ToolStripLabel();
            this.tsp_cmb_locationBar = new System.Windows.Forms.ToolStripComboBox();
            this.tsp_sep_separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsp_btn_logOff = new System.Windows.Forms.ToolStripButton();
            this.tsp_btn_hibernate = new System.Windows.Forms.ToolStripButton();
            this.tsp_btn_standBy = new System.Windows.Forms.ToolStripButton();
            this.tsp_btn_lockPC = new System.Windows.Forms.ToolStripButton();
            this.tsp_btn_help = new System.Windows.Forms.ToolStripButton();
            this.spc_splitContainer = new System.Windows.Forms.SplitContainer();
            this.tbc_right = new System.Windows.Forms.TabControl();
            this.tab_list = new System.Windows.Forms.TabPage();
            this.cmb_listType = new System.Windows.Forms.ComboBox();
            this.pnl_files = new System.Windows.Forms.Panel();
            this.ltv_files = new System.Windows.Forms.ListView();
            this.clh_name = new System.Windows.Forms.ColumnHeader();
            this.clh_size = new System.Windows.Forms.ColumnHeader();
            this.clh_created = new System.Windows.Forms.ColumnHeader();
            this.clh_modified = new System.Windows.Forms.ColumnHeader();
            this.clh_percentage = new System.Windows.Forms.ColumnHeader();
            this.imgl_list = new System.Windows.Forms.ImageList(this.components);
            this.cmb_fileView = new System.Windows.Forms.ComboBox();
            this.tab_chart = new System.Windows.Forms.TabPage();
            this.btn_legend = new System.Windows.Forms.Button();
            this.pnl_chart = new System.Windows.Forms.Panel();
            this.cmb_chartView = new System.Windows.Forms.ComboBox();
            this.drw_chartDrawing = new ExtendedExplorer.Chart();
            this.tsp_main.SuspendLayout();
            this.tsp_location.SuspendLayout();
            this.spc_splitContainer.Panel1.SuspendLayout();
            this.spc_splitContainer.Panel2.SuspendLayout();
            this.spc_splitContainer.SuspendLayout();
            this.tbc_right.SuspendLayout();
            this.tab_list.SuspendLayout();
            this.pnl_files.SuspendLayout();
            this.tab_chart.SuspendLayout();
            this.pnl_chart.SuspendLayout();
            this.SuspendLayout();
            // 
            // trv_computer
            // 
            this.trv_computer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_computer.ImageIndex = 0;
            this.trv_computer.ImageList = this.imgl_tree;
            this.trv_computer.Location = new System.Drawing.Point(0, 0);
            this.trv_computer.Name = "trv_computer";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "MyComputer";
            treeNode1.Text = "My Computer";
            this.trv_computer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trv_computer.SelectedImageIndex = 0;
            this.trv_computer.Size = new System.Drawing.Size(200, 512);
            this.trv_computer.TabIndex = 0;
            this.trv_computer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imgl_tree
            // 
            this.imgl_tree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgl_tree.ImageSize = new System.Drawing.Size(16, 16);
            this.imgl_tree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tsp_main
            // 
            this.tsp_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsp_ddb_file,
            this.tsp_ddb_help});
            this.tsp_main.Location = new System.Drawing.Point(0, 0);
            this.tsp_main.Name = "tsp_main";
            this.tsp_main.Size = new System.Drawing.Size(734, 25);
            this.tsp_main.TabIndex = 7;
            this.tsp_main.Text = "toolStrip1";
            // 
            // tsp_ddb_file
            // 
            this.tsp_ddb_file.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsp_ddb_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsp_mnu_exit});
            this.tsp_ddb_file.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_ddb_file.Name = "tsp_ddb_file";
            this.tsp_ddb_file.Size = new System.Drawing.Size(38, 22);
            this.tsp_ddb_file.Text = "&File";
            // 
            // tsp_mnu_exit
            // 
            this.tsp_mnu_exit.Image = global::ExtendedExplorer.Properties.Resources.shutdown;
            this.tsp_mnu_exit.Name = "tsp_mnu_exit";
            this.tsp_mnu_exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsp_mnu_exit.Size = new System.Drawing.Size(134, 22);
            this.tsp_mnu_exit.Text = "E&xit";
            this.tsp_mnu_exit.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // tsp_ddb_help
            // 
            this.tsp_ddb_help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsp_ddb_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsp_mnu_about});
            this.tsp_ddb_help.Image = ((System.Drawing.Image)(resources.GetObject("tsp_ddb_help.Image")));
            this.tsp_ddb_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_ddb_help.Name = "tsp_ddb_help";
            this.tsp_ddb_help.Size = new System.Drawing.Size(45, 22);
            this.tsp_ddb_help.Text = "&Help";
            // 
            // tsp_mnu_about
            // 
            this.tsp_mnu_about.Image = ((System.Drawing.Image)(resources.GetObject("tsp_mnu_about.Image")));
            this.tsp_mnu_about.Name = "tsp_mnu_about";
            this.tsp_mnu_about.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsp_mnu_about.Size = new System.Drawing.Size(126, 22);
            this.tsp_mnu_about.Text = "&About";
            this.tsp_mnu_about.Click += new System.EventHandler(this.toolStripMainHelp_Click);
            // 
            // tsp_location
            // 
            this.tsp_location.AllowDrop = true;
            this.tsp_location.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsp_lbl_address,
            this.tsp_cmb_locationBar,
            this.tsp_sep_separator1,
            this.tsp_btn_logOff,
            this.tsp_btn_hibernate,
            this.tsp_btn_standBy,
            this.tsp_btn_lockPC,
            this.tsp_btn_help});
            this.tsp_location.Location = new System.Drawing.Point(0, 25);
            this.tsp_location.Name = "tsp_location";
            this.tsp_location.Size = new System.Drawing.Size(734, 25);
            this.tsp_location.Stretch = true;
            this.tsp_location.TabIndex = 9;
            this.tsp_location.Text = "toolStrip2";
            // 
            // tsp_lbl_address
            // 
            this.tsp_lbl_address.Name = "tsp_lbl_address";
            this.tsp_lbl_address.Size = new System.Drawing.Size(52, 22);
            this.tsp_lbl_address.Text = "Address:";
            // 
            // tsp_cmb_locationBar
            // 
            this.tsp_cmb_locationBar.Enabled = false;
            this.tsp_cmb_locationBar.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tsp_cmb_locationBar.Name = "tsp_cmb_locationBar";
            this.tsp_cmb_locationBar.Size = new System.Drawing.Size(300, 25);
            // 
            // tsp_sep_separator1
            // 
            this.tsp_sep_separator1.Name = "tsp_sep_separator1";
            this.tsp_sep_separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsp_btn_logOff
            // 
            this.tsp_btn_logOff.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsp_btn_logOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_btn_logOff.Image = global::ExtendedExplorer.Properties.Resources.logoff;
            this.tsp_btn_logOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_btn_logOff.Name = "tsp_btn_logOff";
            this.tsp_btn_logOff.Size = new System.Drawing.Size(23, 22);
            this.tsp_btn_logOff.Text = "Log Off";
            this.tsp_btn_logOff.Click += new System.EventHandler(this.logOff_Click);
            // 
            // tsp_btn_hibernate
            // 
            this.tsp_btn_hibernate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsp_btn_hibernate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_btn_hibernate.Image = global::ExtendedExplorer.Properties.Resources.hibernate;
            this.tsp_btn_hibernate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_btn_hibernate.Name = "tsp_btn_hibernate";
            this.tsp_btn_hibernate.Size = new System.Drawing.Size(23, 22);
            this.tsp_btn_hibernate.Text = "Hibernate";
            this.tsp_btn_hibernate.Click += new System.EventHandler(this.hibernate_Click);
            // 
            // tsp_btn_standBy
            // 
            this.tsp_btn_standBy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsp_btn_standBy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_btn_standBy.Image = global::ExtendedExplorer.Properties.Resources.standby;
            this.tsp_btn_standBy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_btn_standBy.Name = "tsp_btn_standBy";
            this.tsp_btn_standBy.Size = new System.Drawing.Size(23, 22);
            this.tsp_btn_standBy.Text = "Standby";
            this.tsp_btn_standBy.Click += new System.EventHandler(this.standBy_Click);
            // 
            // tsp_btn_lockPC
            // 
            this.tsp_btn_lockPC.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsp_btn_lockPC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_btn_lockPC.Image = global::ExtendedExplorer.Properties.Resources.lockpc;
            this.tsp_btn_lockPC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_btn_lockPC.Name = "tsp_btn_lockPC";
            this.tsp_btn_lockPC.Size = new System.Drawing.Size(23, 22);
            this.tsp_btn_lockPC.Text = "Lock PC";
            this.tsp_btn_lockPC.Click += new System.EventHandler(this.lockPC_Click);
            // 
            // tsp_btn_help
            // 
            this.tsp_btn_help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsp_btn_help.Image = ((System.Drawing.Image)(resources.GetObject("tsp_btn_help.Image")));
            this.tsp_btn_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsp_btn_help.Name = "tsp_btn_help";
            this.tsp_btn_help.Size = new System.Drawing.Size(23, 22);
            this.tsp_btn_help.Text = "About";
            this.tsp_btn_help.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // spc_splitContainer
            // 
            this.spc_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spc_splitContainer.Location = new System.Drawing.Point(0, 52);
            this.spc_splitContainer.Name = "spc_splitContainer";
            // 
            // spc_splitContainer.Panel1
            // 
            this.spc_splitContainer.Panel1.Controls.Add(this.trv_computer);
            // 
            // spc_splitContainer.Panel2
            // 
            this.spc_splitContainer.Panel2.Controls.Add(this.tbc_right);
            this.spc_splitContainer.Size = new System.Drawing.Size(734, 512);
            this.spc_splitContainer.SplitterDistance = 200;
            this.spc_splitContainer.TabIndex = 12;
            // 
            // tbc_right
            // 
            this.tbc_right.Controls.Add(this.tab_list);
            this.tbc_right.Controls.Add(this.tab_chart);
            this.tbc_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_right.Location = new System.Drawing.Point(0, 0);
            this.tbc_right.Margin = new System.Windows.Forms.Padding(0);
            this.tbc_right.Name = "tbc_right";
            this.tbc_right.SelectedIndex = 0;
            this.tbc_right.Size = new System.Drawing.Size(530, 512);
            this.tbc_right.TabIndex = 8;
            // 
            // tab_list
            // 
            this.tab_list.Controls.Add(this.cmb_listType);
            this.tab_list.Controls.Add(this.pnl_files);
            this.tab_list.Controls.Add(this.cmb_fileView);
            this.tab_list.Location = new System.Drawing.Point(4, 22);
            this.tab_list.Name = "tab_list";
            this.tab_list.Padding = new System.Windows.Forms.Padding(3);
            this.tab_list.Size = new System.Drawing.Size(522, 486);
            this.tab_list.TabIndex = 0;
            this.tab_list.Text = "List";
            this.tab_list.UseVisualStyleBackColor = true;
            // 
            // cmb_listType
            // 
            this.cmb_listType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_listType.FormattingEnabled = true;
            this.cmb_listType.Items.AddRange(new object[] {
            "Folders",
            "Files",
            "Filetype"});
            this.cmb_listType.Location = new System.Drawing.Point(6, 6);
            this.cmb_listType.Name = "cmb_listType";
            this.cmb_listType.Size = new System.Drawing.Size(121, 21);
            this.cmb_listType.TabIndex = 7;
            this.cmb_listType.SelectedIndexChanged += new System.EventHandler(this.cmb_listType_SelectedIndexChanged);
            // 
            // pnl_files
            // 
            this.pnl_files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_files.Controls.Add(this.ltv_files);
            this.pnl_files.Location = new System.Drawing.Point(3, 39);
            this.pnl_files.Name = "pnl_files";
            this.pnl_files.Size = new System.Drawing.Size(516, 444);
            this.pnl_files.TabIndex = 6;
            // 
            // ltv_files
            // 
            this.ltv_files.BackColor = System.Drawing.SystemColors.Window;
            this.ltv_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clh_name,
            this.clh_size,
            this.clh_created,
            this.clh_modified,
            this.clh_percentage});
            this.ltv_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltv_files.LargeImageList = this.imgl_list;
            this.ltv_files.Location = new System.Drawing.Point(0, 0);
            this.ltv_files.Name = "ltv_files";
            this.ltv_files.Size = new System.Drawing.Size(516, 444);
            this.ltv_files.SmallImageList = this.imgl_list;
            this.ltv_files.TabIndex = 2;
            this.ltv_files.UseCompatibleStateImageBehavior = false;
            this.ltv_files.View = System.Windows.Forms.View.Details;
            this.ltv_files.SelectedIndexChanged += new System.EventHandler(this.ltv_files_SelectedIndexChanged);
            this.ltv_files.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // clh_name
            // 
            this.clh_name.Text = "Name";
            this.clh_name.Width = 150;
            // 
            // clh_size
            // 
            this.clh_size.Text = "Size";
            this.clh_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clh_size.Width = 85;
            // 
            // clh_created
            // 
            this.clh_created.Text = "Created";
            this.clh_created.Width = 100;
            // 
            // clh_modified
            // 
            this.clh_modified.Text = "Modified";
            this.clh_modified.Width = 100;
            // 
            // clh_percentage
            // 
            this.clh_percentage.Text = "Percentage";
            this.clh_percentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clh_percentage.Width = 75;
            // 
            // imgl_list
            // 
            this.imgl_list.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgl_list.ImageSize = new System.Drawing.Size(16, 16);
            this.imgl_list.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmb_fileView
            // 
            this.cmb_fileView.AllowDrop = true;
            this.cmb_fileView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_fileView.FormattingEnabled = true;
            this.cmb_fileView.Items.AddRange(new object[] {
            "Large icon",
            "Small icon",
            "Detail view",
            "Tile View",
            "List view"});
            this.cmb_fileView.Location = new System.Drawing.Point(133, 6);
            this.cmb_fileView.Name = "cmb_fileView";
            this.cmb_fileView.Size = new System.Drawing.Size(100, 21);
            this.cmb_fileView.TabIndex = 5;
            this.cmb_fileView.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tab_chart
            // 
            this.tab_chart.Controls.Add(this.btn_legend);
            this.tab_chart.Controls.Add(this.pnl_chart);
            this.tab_chart.Controls.Add(this.cmb_chartView);
            this.tab_chart.Location = new System.Drawing.Point(4, 22);
            this.tab_chart.Name = "tab_chart";
            this.tab_chart.Padding = new System.Windows.Forms.Padding(3);
            this.tab_chart.Size = new System.Drawing.Size(522, 486);
            this.tab_chart.TabIndex = 1;
            this.tab_chart.Text = "Chart";
            this.tab_chart.UseVisualStyleBackColor = true;
            // 
            // btn_legend
            // 
            this.btn_legend.Location = new System.Drawing.Point(112, 5);
            this.btn_legend.Name = "btn_legend";
            this.btn_legend.Size = new System.Drawing.Size(75, 23);
            this.btn_legend.TabIndex = 10;
            this.btn_legend.Text = "Legend";
            this.btn_legend.UseVisualStyleBackColor = true;
            this.btn_legend.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_chart
            // 
            this.pnl_chart.Controls.Add(this.drw_chartDrawing);
            this.pnl_chart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_chart.Location = new System.Drawing.Point(3, 39);
            this.pnl_chart.Name = "pnl_chart";
            this.pnl_chart.Size = new System.Drawing.Size(516, 444);
            this.pnl_chart.TabIndex = 9;
            // 
            // cmb_chartView
            // 
            this.cmb_chartView.AllowDrop = true;
            this.cmb_chartView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_chartView.FormattingEnabled = true;
            this.cmb_chartView.Items.AddRange(new object[] {
            "Pie",
            "Bar"});
            this.cmb_chartView.Location = new System.Drawing.Point(6, 6);
            this.cmb_chartView.Name = "cmb_chartView";
            this.cmb_chartView.Size = new System.Drawing.Size(100, 21);
            this.cmb_chartView.TabIndex = 7;
            this.cmb_chartView.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // drw_chartDrawing
            // 
            this.drw_chartDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drw_chartDrawing.Location = new System.Drawing.Point(0, 0);
            this.drw_chartDrawing.Name = "drw_chartDrawing";
            this.drw_chartDrawing.Size = new System.Drawing.Size(516, 444);
            this.drw_chartDrawing.TabIndex = 0;
            this.drw_chartDrawing.Text = "chart1";
            this.drw_chartDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.drw_chartDrawing_Paint);
            // 
            // ExtendedExplorerFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 564);
            this.Controls.Add(this.spc_splitContainer);
            this.Controls.Add(this.tsp_location);
            this.Controls.Add(this.tsp_main);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ExtendedExplorer.Properties.Settings.Default, "WindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::ExtendedExplorer.Properties.Settings.Default.WindowLocation;
            this.MinimumSize = new System.Drawing.Size(400, 220);
            this.Name = "ExtendedExplorerFormView";
            this.Text = "ExtendedExplorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtendedExplorerFormView_FormClosing);
            this.tsp_main.ResumeLayout(false);
            this.tsp_main.PerformLayout();
            this.tsp_location.ResumeLayout(false);
            this.tsp_location.PerformLayout();
            this.spc_splitContainer.Panel1.ResumeLayout(false);
            this.spc_splitContainer.Panel2.ResumeLayout(false);
            this.spc_splitContainer.ResumeLayout(false);
            this.tbc_right.ResumeLayout(false);
            this.tab_list.ResumeLayout(false);
            this.pnl_files.ResumeLayout(false);
            this.tab_chart.ResumeLayout(false);
            this.pnl_chart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsp_main;
        private System.Windows.Forms.ToolStripDropDownButton tsp_ddb_file;
        private System.Windows.Forms.ToolStripMenuItem tsp_mnu_exit;
        private System.Windows.Forms.ImageList imgl_tree;
        private System.Windows.Forms.ToolStrip tsp_location;
        private System.Windows.Forms.ToolStripComboBox tsp_cmb_locationBar;
        private System.Windows.Forms.ToolStripDropDownButton tsp_ddb_help;
        private System.Windows.Forms.ToolStripMenuItem tsp_mnu_about;
        private System.Windows.Forms.ToolStripLabel tsp_lbl_address;
        private System.Windows.Forms.SplitContainer spc_splitContainer;
        private System.Windows.Forms.ToolStripButton tsp_btn_lockPC;
        private System.Windows.Forms.ToolStripSeparator tsp_sep_separator1;
        private System.Windows.Forms.ToolStripButton tsp_btn_standBy;
        private System.Windows.Forms.ToolStripButton tsp_btn_hibernate;
        private System.Windows.Forms.ToolStripButton tsp_btn_logOff;
        private System.Windows.Forms.ToolStripButton tsp_btn_help;
        private System.Windows.Forms.TabControl tbc_right;
        private System.Windows.Forms.TabPage tab_list;
        private System.Windows.Forms.Panel pnl_files;
        private System.Windows.Forms.ListView ltv_files;
        private System.Windows.Forms.ComboBox cmb_fileView;
        private System.Windows.Forms.TabPage tab_chart;
        private System.Windows.Forms.Button btn_legend;
        private System.Windows.Forms.Panel pnl_chart;
        private System.Windows.Forms.ComboBox cmb_chartView;
        private System.Windows.Forms.ComboBox cmb_listType;
        public System.Windows.Forms.TreeView trv_computer;
        private System.Windows.Forms.ImageList imgl_list;
        private System.Windows.Forms.ColumnHeader clh_name;
        private System.Windows.Forms.ColumnHeader clh_size;
        private System.Windows.Forms.ColumnHeader clh_created;
        private System.Windows.Forms.ColumnHeader clh_modified;
        private System.Windows.Forms.ColumnHeader clh_percentage;
        private Chart drw_chartDrawing;
    }
}