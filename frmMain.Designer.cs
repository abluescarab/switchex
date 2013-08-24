namespace Switchex {
	partial class frmMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.fileOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.fileGameFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.fileAddonsFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.fileOpenRealmlist = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.fileRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSep3 = new System.Windows.Forms.ToolStripSeparator();
			this.fileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuServerLists = new System.Windows.Forms.ToolStripMenuItem();
			this.slGamesTop100 = new System.Windows.Forms.ToolStripMenuItem();
			this.slTop100Arena = new System.Windows.Forms.ToolStripMenuItem();
			this.slXtremeTop100 = new System.Windows.Forms.ToolStripMenuItem();
			this.slSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.slGameSites200 = new System.Windows.Forms.ToolStripMenuItem();
			this.slMmorpgTL = new System.Windows.Forms.ToolStripMenuItem();
			this.slSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.slWowServers = new System.Windows.Forms.ToolStripMenuItem();
			this.slSep3 = new System.Windows.Forms.ToolStripSeparator();
			this.slTop1000 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuWebsites = new System.Windows.Forms.ToolStripMenuItem();
			this.webWowWiki = new System.Windows.Forms.ToolStripMenuItem();
			this.webThottbot = new System.Windows.Forms.ToolStripMenuItem();
			this.webZamWow = new System.Windows.Forms.ToolStripMenuItem();
			this.webSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.webGotWarcraft = new System.Windows.Forms.ToolStripMenuItem();
			this.webFreeWarcraftGuides = new System.Windows.Forms.ToolStripMenuItem();
			this.webOnlineMultiplayer = new System.Windows.Forms.ToolStripMenuItem();
			this.webWowProfessions = new System.Windows.Forms.ToolStripMenuItem();
			this.webWowPopular = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.helpWebSwitchex = new System.Windows.Forms.ToolStripMenuItem();
			this.helpWebAbluescarab = new System.Windows.Forms.ToolStripMenuItem();
			this.helpWebSourceForge = new System.Windows.Forms.ToolStripMenuItem();
			this.helpWebWow = new System.Windows.Forms.ToolStripMenuItem();
			this.helpWebBattlenet = new System.Windows.Forms.ToolStripMenuItem();
			this.helpSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.helpUpdates = new System.Windows.Forms.ToolStripMenuItem();
			this.helpChangelog = new System.Windows.Forms.ToolStripMenuItem();
			this.helpSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.helpHelpTopics = new System.Windows.Forms.ToolStripMenuItem();
			this.helpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.dgvServers = new System.Windows.Forms.DataGridView();
			this.ServerOnline = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ServerWebsite = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ServerPatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ServerRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ServerNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnCheckOnline = new System.Windows.Forms.Button();
			this.btnOpenWow = new System.Windows.Forms.Button();
			this.btnOpenWebsite = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSet = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblCurrentPatch = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblCurrentServer = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnAddons = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvServers)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuServerLists,
            this.menuWebsites,
            this.menuHelp});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(904, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOptions,
            this.fileSep1,
            this.fileGameFolder,
            this.fileAddonsFolder,
            this.fileOpenRealmlist,
            this.fileSep2,
            this.fileRefresh,
            this.fileSep3,
            this.fileExit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(37, 20);
			this.menuFile.Text = "File";
			// 
			// fileOptions
			// 
			this.fileOptions.Image = global::Switchex.Properties.Resources.application_edit;
			this.fileOptions.Name = "fileOptions";
			this.fileOptions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.fileOptions.Size = new System.Drawing.Size(190, 22);
			this.fileOptions.Text = "Options";
			this.fileOptions.Click += new System.EventHandler(this.fileOptions_Click);
			// 
			// fileSep1
			// 
			this.fileSep1.Name = "fileSep1";
			this.fileSep1.Size = new System.Drawing.Size(187, 6);
			// 
			// fileGameFolder
			// 
			this.fileGameFolder.Image = global::Switchex.Properties.Resources.folder;
			this.fileGameFolder.Name = "fileGameFolder";
			this.fileGameFolder.Size = new System.Drawing.Size(190, 22);
			this.fileGameFolder.Text = "Open Game Folder";
			this.fileGameFolder.Click += new System.EventHandler(this.fileGameFolder_Click);
			// 
			// fileAddonsFolder
			// 
			this.fileAddonsFolder.Image = global::Switchex.Properties.Resources.folder_add;
			this.fileAddonsFolder.Name = "fileAddonsFolder";
			this.fileAddonsFolder.Size = new System.Drawing.Size(190, 22);
			this.fileAddonsFolder.Text = "Open Addons Folder";
			this.fileAddonsFolder.Click += new System.EventHandler(this.fileAddonsFolder_Click);
			// 
			// fileOpenRealmlist
			// 
			this.fileOpenRealmlist.Image = global::Switchex.Properties.Resources.page_white_text;
			this.fileOpenRealmlist.Name = "fileOpenRealmlist";
			this.fileOpenRealmlist.Size = new System.Drawing.Size(190, 22);
			this.fileOpenRealmlist.Text = "Open Realmlist.wtf";
			this.fileOpenRealmlist.Click += new System.EventHandler(this.fileOpenRealmlist_Click);
			// 
			// fileSep2
			// 
			this.fileSep2.Name = "fileSep2";
			this.fileSep2.Size = new System.Drawing.Size(187, 6);
			// 
			// fileRefresh
			// 
			this.fileRefresh.Image = global::Switchex.Properties.Resources.arrow_refresh;
			this.fileRefresh.Name = "fileRefresh";
			this.fileRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.fileRefresh.Size = new System.Drawing.Size(190, 22);
			this.fileRefresh.Text = "Refresh Server List";
			this.fileRefresh.Click += new System.EventHandler(this.fileRefresh_Click);
			// 
			// fileSep3
			// 
			this.fileSep3.Name = "fileSep3";
			this.fileSep3.Size = new System.Drawing.Size(187, 6);
			// 
			// fileExit
			// 
			this.fileExit.Image = global::Switchex.Properties.Resources.cross;
			this.fileExit.Name = "fileExit";
			this.fileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.fileExit.Size = new System.Drawing.Size(190, 22);
			this.fileExit.Text = "Exit";
			this.fileExit.Click += new System.EventHandler(this.fileExit_Click);
			// 
			// menuServerLists
			// 
			this.menuServerLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slGamesTop100,
            this.slTop100Arena,
            this.slXtremeTop100,
            this.slSep1,
            this.slGameSites200,
            this.slMmorpgTL,
            this.slSep2,
            this.slWowServers,
            this.slSep3,
            this.slTop1000});
			this.menuServerLists.Name = "menuServerLists";
			this.menuServerLists.Size = new System.Drawing.Size(78, 20);
			this.menuServerLists.Text = "Server Lists";
			// 
			// slGamesTop100
			// 
			this.slGamesTop100.Image = ((System.Drawing.Image)(resources.GetObject("slGamesTop100.Image")));
			this.slGamesTop100.Name = "slGamesTop100";
			this.slGamesTop100.Size = new System.Drawing.Size(188, 22);
			this.slGamesTop100.Text = "GamesTop100";
			this.slGamesTop100.Click += new System.EventHandler(this.slGamesTop100_Click);
			// 
			// slTop100Arena
			// 
			this.slTop100Arena.Image = global::Switchex.Properties.Resources.top100arena;
			this.slTop100Arena.Name = "slTop100Arena";
			this.slTop100Arena.Size = new System.Drawing.Size(188, 22);
			this.slTop100Arena.Text = "Top 100 Arena";
			this.slTop100Arena.Click += new System.EventHandler(this.slTop100Arena_Click);
			// 
			// slXtremeTop100
			// 
			this.slXtremeTop100.Image = ((System.Drawing.Image)(resources.GetObject("slXtremeTop100.Image")));
			this.slXtremeTop100.Name = "slXtremeTop100";
			this.slXtremeTop100.Size = new System.Drawing.Size(188, 22);
			this.slXtremeTop100.Text = "XtremeTop100";
			this.slXtremeTop100.Click += new System.EventHandler(this.slXtremeTop100_Click);
			// 
			// slSep1
			// 
			this.slSep1.Name = "slSep1";
			this.slSep1.Size = new System.Drawing.Size(185, 6);
			// 
			// slGameSites200
			// 
			this.slGameSites200.Image = ((System.Drawing.Image)(resources.GetObject("slGameSites200.Image")));
			this.slGameSites200.Name = "slGameSites200";
			this.slGameSites200.Size = new System.Drawing.Size(188, 22);
			this.slGameSites200.Text = "GameSites200";
			this.slGameSites200.Click += new System.EventHandler(this.slGameSites200_Click);
			// 
			// slMmorpgTL
			// 
			this.slMmorpgTL.Image = ((System.Drawing.Image)(resources.GetObject("slMmorpgTL.Image")));
			this.slMmorpgTL.Name = "slMmorpgTL";
			this.slMmorpgTL.Size = new System.Drawing.Size(188, 22);
			this.slMmorpgTL.Text = "MMORPG Top List";
			this.slMmorpgTL.Click += new System.EventHandler(this.slMmorpgTL_Click);
			// 
			// slSep2
			// 
			this.slSep2.Name = "slSep2";
			this.slSep2.Size = new System.Drawing.Size(185, 6);
			// 
			// slWowServers
			// 
			this.slWowServers.Image = global::Switchex.Properties.Resources.topsitelist;
			this.slWowServers.Name = "slWowServers";
			this.slWowServers.Size = new System.Drawing.Size(188, 22);
			this.slWowServers.Text = "#WoW Servers";
			this.slWowServers.Click += new System.EventHandler(this.slWowServers_Click);
			// 
			// slSep3
			// 
			this.slSep3.Name = "slSep3";
			this.slSep3.Size = new System.Drawing.Size(185, 6);
			// 
			// slTop1000
			// 
			this.slTop1000.Image = global::Switchex.Properties.Resources.topsitelist;
			this.slTop1000.Name = "slTop1000";
			this.slTop1000.Size = new System.Drawing.Size(188, 22);
			this.slTop1000.Text = "Top 1000 WoW Sites";
			this.slTop1000.Click += new System.EventHandler(this.slTop1000_Click);
			// 
			// menuWebsites
			// 
			this.menuWebsites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webWowWiki,
            this.webThottbot,
            this.webZamWow,
            this.webSep1,
            this.webGotWarcraft,
            this.webFreeWarcraftGuides,
            this.webOnlineMultiplayer,
            this.webWowProfessions,
            this.webWowPopular});
			this.menuWebsites.Name = "menuWebsites";
			this.menuWebsites.Size = new System.Drawing.Size(110, 20);
			this.menuWebsites.Text = "Guides and Wikis";
			// 
			// webWowWiki
			// 
			this.webWowWiki.Image = global::Switchex.Properties.Resources.wowwiki;
			this.webWowWiki.Name = "webWowWiki";
			this.webWowWiki.Size = new System.Drawing.Size(184, 22);
			this.webWowWiki.Text = "WoWWiki";
			this.webWowWiki.Click += new System.EventHandler(this.webWowWiki_Click);
			// 
			// webThottbot
			// 
			this.webThottbot.Image = global::Switchex.Properties.Resources.thottbot;
			this.webThottbot.Name = "webThottbot";
			this.webThottbot.Size = new System.Drawing.Size(184, 22);
			this.webThottbot.Text = "Thottbot";
			this.webThottbot.Click += new System.EventHandler(this.webThottbot_Click);
			// 
			// webZamWow
			// 
			this.webZamWow.Image = global::Switchex.Properties.Resources.zamwow;
			this.webZamWow.Name = "webZamWow";
			this.webZamWow.Size = new System.Drawing.Size(184, 22);
			this.webZamWow.Text = "ZAM WoW";
			this.webZamWow.Click += new System.EventHandler(this.webZamWow_Click);
			// 
			// webSep1
			// 
			this.webSep1.Name = "webSep1";
			this.webSep1.Size = new System.Drawing.Size(181, 6);
			// 
			// webGotWarcraft
			// 
			this.webGotWarcraft.Image = global::Switchex.Properties.Resources.gotwarcraft;
			this.webGotWarcraft.Name = "webGotWarcraft";
			this.webGotWarcraft.Size = new System.Drawing.Size(184, 22);
			this.webGotWarcraft.Text = "GotWarcraft";
			this.webGotWarcraft.Click += new System.EventHandler(this.webGotWarcraft_Click);
			// 
			// webFreeWarcraftGuides
			// 
			this.webFreeWarcraftGuides.Image = ((System.Drawing.Image)(resources.GetObject("webFreeWarcraftGuides.Image")));
			this.webFreeWarcraftGuides.Name = "webFreeWarcraftGuides";
			this.webFreeWarcraftGuides.Size = new System.Drawing.Size(184, 22);
			this.webFreeWarcraftGuides.Text = "Free Warcraft Guides";
			this.webFreeWarcraftGuides.Click += new System.EventHandler(this.webFreeWarcraftGuides_Click);
			// 
			// webOnlineMultiplayer
			// 
			this.webOnlineMultiplayer.Image = ((System.Drawing.Image)(resources.GetObject("webOnlineMultiplayer.Image")));
			this.webOnlineMultiplayer.Name = "webOnlineMultiplayer";
			this.webOnlineMultiplayer.Size = new System.Drawing.Size(184, 22);
			this.webOnlineMultiplayer.Text = "Online-Multiplayer";
			this.webOnlineMultiplayer.Click += new System.EventHandler(this.webOnlineMultiplayer_Click);
			// 
			// webWowProfessions
			// 
			this.webWowProfessions.Image = global::Switchex.Properties.Resources.wowprofessions;
			this.webWowProfessions.Name = "webWowProfessions";
			this.webWowProfessions.Size = new System.Drawing.Size(184, 22);
			this.webWowProfessions.Text = "WoW-Professions";
			this.webWowProfessions.Click += new System.EventHandler(this.webWowProfessions_Click);
			// 
			// webWowPopular
			// 
			this.webWowPopular.Image = global::Switchex.Properties.Resources.wowpopular;
			this.webWowPopular.Name = "webWowPopular";
			this.webWowPopular.Size = new System.Drawing.Size(184, 22);
			this.webWowPopular.Text = "WoWPopular";
			this.webWowPopular.Click += new System.EventHandler(this.webWowPopular_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpWebSwitchex,
            this.helpWebAbluescarab,
            this.helpWebSourceForge,
            this.helpWebWow,
            this.helpWebBattlenet,
            this.helpSep1,
            this.helpUpdates,
            this.helpChangelog,
            this.helpSep2,
            this.helpHelpTopics,
            this.helpAbout});
			this.menuHelp.Name = "menuHelp";
			this.menuHelp.Size = new System.Drawing.Size(44, 20);
			this.menuHelp.Text = "Help";
			// 
			// helpWebSwitchex
			// 
			this.helpWebSwitchex.Image = global::Switchex.Properties.Resources.switchex;
			this.helpWebSwitchex.Name = "helpWebSwitchex";
			this.helpWebSwitchex.Size = new System.Drawing.Size(303, 22);
			this.helpWebSwitchex.Text = "Visit the Switchex Website";
			this.helpWebSwitchex.Click += new System.EventHandler(this.helpWebSwitchex_Click);
			// 
			// helpWebAbluescarab
			// 
			this.helpWebAbluescarab.Image = global::Switchex.Properties.Resources.page_world;
			this.helpWebAbluescarab.Name = "helpWebAbluescarab";
			this.helpWebAbluescarab.Size = new System.Drawing.Size(303, 22);
			this.helpWebAbluescarab.Text = "Visit the Abluescarab Designs Website";
			this.helpWebAbluescarab.Click += new System.EventHandler(this.helpWebAbluescarab_Click);
			// 
			// helpWebSourceForge
			// 
			this.helpWebSourceForge.Image = global::Switchex.Properties.Resources.sourceforge;
			this.helpWebSourceForge.Name = "helpWebSourceForge";
			this.helpWebSourceForge.Size = new System.Drawing.Size(303, 22);
			this.helpWebSourceForge.Text = "Visit the SourceForge Project";
			this.helpWebSourceForge.Click += new System.EventHandler(this.helpWebSourceForge_Click);
			// 
			// helpWebWow
			// 
			this.helpWebWow.Image = global::Switchex.Properties.Resources.zamwow;
			this.helpWebWow.Name = "helpWebWow";
			this.helpWebWow.Size = new System.Drawing.Size(303, 22);
			this.helpWebWow.Text = "Visit the World of Warcraft Official Website";
			this.helpWebWow.Click += new System.EventHandler(this.helpWebWow_Click);
			// 
			// helpWebBattlenet
			// 
			this.helpWebBattlenet.Image = global::Switchex.Properties.Resources.battlenet;
			this.helpWebBattlenet.Name = "helpWebBattlenet";
			this.helpWebBattlenet.Size = new System.Drawing.Size(303, 22);
			this.helpWebBattlenet.Text = "Visit Battle.net";
			this.helpWebBattlenet.Click += new System.EventHandler(this.helpWebBattlenet_Click);
			// 
			// helpSep1
			// 
			this.helpSep1.Name = "helpSep1";
			this.helpSep1.Size = new System.Drawing.Size(300, 6);
			// 
			// helpUpdates
			// 
			this.helpUpdates.Image = global::Switchex.Properties.Resources.drive;
			this.helpUpdates.Name = "helpUpdates";
			this.helpUpdates.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.helpUpdates.Size = new System.Drawing.Size(303, 22);
			this.helpUpdates.Text = "Check for Updates...";
			this.helpUpdates.Click += new System.EventHandler(this.helpUpdates_Click);
			// 
			// helpChangelog
			// 
			this.helpChangelog.Image = global::Switchex.Properties.Resources.page_white_text;
			this.helpChangelog.Name = "helpChangelog";
			this.helpChangelog.Size = new System.Drawing.Size(303, 22);
			this.helpChangelog.Text = "Changelog...";
			this.helpChangelog.Click += new System.EventHandler(this.helpChangelog_Click);
			// 
			// helpSep2
			// 
			this.helpSep2.Name = "helpSep2";
			this.helpSep2.Size = new System.Drawing.Size(300, 6);
			// 
			// helpHelpTopics
			// 
			this.helpHelpTopics.Image = global::Switchex.Properties.Resources.help;
			this.helpHelpTopics.Name = "helpHelpTopics";
			this.helpHelpTopics.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.helpHelpTopics.Size = new System.Drawing.Size(303, 22);
			this.helpHelpTopics.Text = "Help Topics";
			this.helpHelpTopics.Click += new System.EventHandler(this.helpHelpTopics_Click);
			// 
			// helpAbout
			// 
			this.helpAbout.Image = global::Switchex.Properties.Resources.information;
			this.helpAbout.Name = "helpAbout";
			this.helpAbout.Size = new System.Drawing.Size(303, 22);
			this.helpAbout.Text = "About";
			this.helpAbout.Click += new System.EventHandler(this.helpAbout_Click);
			// 
			// dgvServers
			// 
			this.dgvServers.AllowUserToAddRows = false;
			this.dgvServers.AllowUserToDeleteRows = false;
			this.dgvServers.AllowUserToOrderColumns = true;
			this.dgvServers.AllowUserToResizeRows = false;
			this.dgvServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvServers.BackgroundColor = System.Drawing.Color.White;
			this.dgvServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvServers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerOnline,
            this.ServerName,
            this.ServerIP,
            this.ServerWebsite,
            this.ServerPatch,
            this.ServerRating,
            this.ServerNotes});
			this.dgvServers.Location = new System.Drawing.Point(13, 28);
			this.dgvServers.Name = "dgvServers";
			this.dgvServers.ReadOnly = true;
			this.dgvServers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvServers.Size = new System.Drawing.Size(738, 325);
			this.dgvServers.TabIndex = 99;
			// 
			// ServerOnline
			// 
			this.ServerOnline.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.ServerOnline.HeaderText = "Online";
			this.ServerOnline.Name = "ServerOnline";
			this.ServerOnline.ReadOnly = true;
			this.ServerOnline.Width = 41;
			// 
			// ServerName
			// 
			this.ServerName.HeaderText = "Name";
			this.ServerName.Name = "ServerName";
			this.ServerName.ReadOnly = true;
			this.ServerName.Width = 133;
			// 
			// ServerIP
			// 
			this.ServerIP.HeaderText = "IP";
			this.ServerIP.Name = "ServerIP";
			this.ServerIP.ReadOnly = true;
			this.ServerIP.Width = 133;
			// 
			// ServerWebsite
			// 
			this.ServerWebsite.HeaderText = "Website";
			this.ServerWebsite.Name = "ServerWebsite";
			this.ServerWebsite.ReadOnly = true;
			this.ServerWebsite.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ServerWebsite.Width = 133;
			// 
			// ServerPatch
			// 
			this.ServerPatch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ServerPatch.HeaderText = "Patch";
			this.ServerPatch.Name = "ServerPatch";
			this.ServerPatch.ReadOnly = true;
			this.ServerPatch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ServerPatch.Width = 58;
			// 
			// ServerRating
			// 
			this.ServerRating.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ServerRating.HeaderText = "Rating";
			this.ServerRating.Name = "ServerRating";
			this.ServerRating.ReadOnly = true;
			this.ServerRating.Width = 61;
			// 
			// ServerNotes
			// 
			this.ServerNotes.HeaderText = "Notes";
			this.ServerNotes.Name = "ServerNotes";
			this.ServerNotes.ReadOnly = true;
			this.ServerNotes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ServerNotes.Width = 133;
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Image = global::Switchex.Properties.Resources.cross;
			this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnExit.Location = new System.Drawing.Point(757, 328);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(135, 25);
			this.btnExit.TabIndex = 7;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnCheckOnline
			// 
			this.btnCheckOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCheckOnline.Image = global::Switchex.Properties.Resources.computer_link;
			this.btnCheckOnline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCheckOnline.Location = new System.Drawing.Point(757, 245);
			this.btnCheckOnline.Name = "btnCheckOnline";
			this.btnCheckOnline.Size = new System.Drawing.Size(135, 25);
			this.btnCheckOnline.TabIndex = 6;
			this.btnCheckOnline.Text = "Check Online";
			this.btnCheckOnline.UseVisualStyleBackColor = true;
			this.btnCheckOnline.Click += new System.EventHandler(this.btnCheckOnline_Click);
			// 
			// btnOpenWow
			// 
			this.btnOpenWow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenWow.Image = global::Switchex.Properties.Resources.application_get;
			this.btnOpenWow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOpenWow.Location = new System.Drawing.Point(757, 198);
			this.btnOpenWow.Name = "btnOpenWow";
			this.btnOpenWow.Size = new System.Drawing.Size(135, 25);
			this.btnOpenWow.TabIndex = 5;
			this.btnOpenWow.Text = "Open WoW";
			this.btnOpenWow.UseVisualStyleBackColor = true;
			this.btnOpenWow.Click += new System.EventHandler(this.btnOpenWow_Click);
			// 
			// btnOpenWebsite
			// 
			this.btnOpenWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenWebsite.Image = global::Switchex.Properties.Resources.world;
			this.btnOpenWebsite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOpenWebsite.Location = new System.Drawing.Point(757, 167);
			this.btnOpenWebsite.Name = "btnOpenWebsite";
			this.btnOpenWebsite.Size = new System.Drawing.Size(135, 25);
			this.btnOpenWebsite.TabIndex = 4;
			this.btnOpenWebsite.Text = "Open Website";
			this.btnOpenWebsite.UseVisualStyleBackColor = true;
			this.btnOpenWebsite.Click += new System.EventHandler(this.btnOpenWebsite_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::Switchex.Properties.Resources.delete;
			this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDelete.Location = new System.Drawing.Point(757, 121);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(135, 25);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete Server";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSet
			// 
			this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSet.Image = global::Switchex.Properties.Resources.accept;
			this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSet.Location = new System.Drawing.Point(757, 28);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(135, 25);
			this.btnSet.TabIndex = 0;
			this.btnSet.Text = "Set Server";
			this.btnSet.UseVisualStyleBackColor = true;
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Image = global::Switchex.Properties.Resources.pencil;
			this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.Location = new System.Drawing.Point(757, 90);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(135, 25);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit Server";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::Switchex.Properties.Resources.add;
			this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAdd.Location = new System.Drawing.Point(757, 59);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(135, 25);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add Server";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentPatch,
            this.lblCurrentServer});
			this.statusStrip1.Location = new System.Drawing.Point(0, 356);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(904, 22);
			this.statusStrip1.TabIndex = 14;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblCurrentPatch
			// 
			this.lblCurrentPatch.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
			this.lblCurrentPatch.Name = "lblCurrentPatch";
			this.lblCurrentPatch.Size = new System.Drawing.Size(37, 17);
			this.lblCurrentPatch.Text = "Patch";
			// 
			// lblCurrentServer
			// 
			this.lblCurrentServer.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
			this.lblCurrentServer.Name = "lblCurrentServer";
			this.lblCurrentServer.Size = new System.Drawing.Size(40, 17);
			this.lblCurrentServer.Text = "Server";
			// 
			// btnAddons
			// 
			this.btnAddons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddons.Image = global::Switchex.Properties.Resources.folder_add;
			this.btnAddons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAddons.Location = new System.Drawing.Point(757, 276);
			this.btnAddons.Name = "btnAddons";
			this.btnAddons.Size = new System.Drawing.Size(135, 25);
			this.btnAddons.TabIndex = 100;
			this.btnAddons.Text = "Addons";
			this.btnAddons.UseVisualStyleBackColor = true;
			this.btnAddons.Click += new System.EventHandler(this.btnAddons_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(904, 378);
			this.Controls.Add(this.btnAddons);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnOpenWow);
			this.Controls.Add(this.btnOpenWebsite);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSet);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgvServers);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.btnCheckOnline);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(350, 366);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Switchex";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvServers)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem fileOptions;
		private System.Windows.Forms.ToolStripSeparator fileSep1;
		private System.Windows.Forms.ToolStripMenuItem fileGameFolder;
		private System.Windows.Forms.ToolStripMenuItem fileAddonsFolder;
		private System.Windows.Forms.ToolStripSeparator fileSep2;
		private System.Windows.Forms.ToolStripMenuItem fileRefresh;
		private System.Windows.Forms.ToolStripSeparator fileSep3;
		private System.Windows.Forms.ToolStripMenuItem fileExit;
		private System.Windows.Forms.ToolStripMenuItem menuServerLists;
		private System.Windows.Forms.ToolStripMenuItem slGamesTop100;
		private System.Windows.Forms.ToolStripMenuItem slTop100Arena;
		private System.Windows.Forms.ToolStripMenuItem slXtremeTop100;
		private System.Windows.Forms.ToolStripSeparator slSep1;
		private System.Windows.Forms.ToolStripMenuItem slGameSites200;
		private System.Windows.Forms.ToolStripMenuItem slMmorpgTL;
		private System.Windows.Forms.ToolStripSeparator slSep2;
		private System.Windows.Forms.ToolStripMenuItem slWowServers;
		private System.Windows.Forms.ToolStripSeparator slSep3;
		private System.Windows.Forms.ToolStripMenuItem slTop1000;
		private System.Windows.Forms.ToolStripMenuItem menuWebsites;
		private System.Windows.Forms.ToolStripMenuItem webWowWiki;
		private System.Windows.Forms.ToolStripMenuItem webThottbot;
		private System.Windows.Forms.ToolStripMenuItem webZamWow;
		private System.Windows.Forms.ToolStripMenuItem webGotWarcraft;
		private System.Windows.Forms.ToolStripMenuItem webFreeWarcraftGuides;
		private System.Windows.Forms.ToolStripMenuItem webOnlineMultiplayer;
		private System.Windows.Forms.ToolStripMenuItem webWowProfessions;
		private System.Windows.Forms.ToolStripMenuItem webWowPopular;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
		private System.Windows.Forms.ToolStripMenuItem helpWebSwitchex;
		private System.Windows.Forms.ToolStripMenuItem helpWebAbluescarab;
		private System.Windows.Forms.ToolStripMenuItem helpWebSourceForge;
		private System.Windows.Forms.ToolStripMenuItem helpWebWow;
		private System.Windows.Forms.ToolStripMenuItem helpWebBattlenet;
		private System.Windows.Forms.ToolStripSeparator helpSep1;
		private System.Windows.Forms.ToolStripMenuItem helpUpdates;
		private System.Windows.Forms.ToolStripMenuItem helpChangelog;
		private System.Windows.Forms.ToolStripSeparator helpSep2;
		private System.Windows.Forms.ToolStripMenuItem helpHelpTopics;
		private System.Windows.Forms.ToolStripMenuItem helpAbout;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnOpenWebsite;
		private System.Windows.Forms.Button btnOpenWow;
		private System.Windows.Forms.Button btnCheckOnline;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.ToolStripSeparator webSep1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblCurrentPatch;
		private System.Windows.Forms.ToolStripStatusLabel lblCurrentServer;
		public System.Windows.Forms.DataGridView dgvServers;
		private System.Windows.Forms.ToolStripMenuItem fileOpenRealmlist;
		private System.Windows.Forms.Button btnAddons;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ServerOnline;
		private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ServerIP;
		private System.Windows.Forms.DataGridViewTextBoxColumn ServerWebsite;
		private System.Windows.Forms.DataGridViewTextBoxColumn ServerPatch;
		private System.Windows.Forms.DataGridViewTextBoxColumn ServerRating;
		private System.Windows.Forms.DataGridViewTextBoxColumn ServerNotes;
	}
}

