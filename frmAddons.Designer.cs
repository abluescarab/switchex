namespace Switchex {
	partial class frmAddons {
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
			this.lbAddons = new System.Windows.Forms.ListBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblInstalled = new System.Windows.Forms.Label();
			this.txtInstalled = new System.Windows.Forms.TextBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.lblVersion = new System.Windows.Forms.Label();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbAddons
			// 
			this.lbAddons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbAddons.FormattingEnabled = true;
			this.lbAddons.HorizontalScrollbar = true;
			this.lbAddons.IntegralHeight = false;
			this.lbAddons.Location = new System.Drawing.Point(12, 38);
			this.lbAddons.Name = "lbAddons";
			this.lbAddons.Size = new System.Drawing.Size(213, 316);
			this.lbAddons.TabIndex = 1;
			this.lbAddons.SelectedIndexChanged += new System.EventHandler(this.lbAddons_SelectedIndexChanged);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(377, 329);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 25);
			this.btnClose.TabIndex = 8;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(231, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(231, 32);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(221, 20);
			this.txtName.TabIndex = 2;
			// 
			// lblInstalled
			// 
			this.lblInstalled.AutoSize = true;
			this.lblInstalled.Location = new System.Drawing.Point(231, 238);
			this.lblInstalled.Name = "lblInstalled";
			this.lblInstalled.Size = new System.Drawing.Size(63, 13);
			this.lblInstalled.TabIndex = 4;
			this.lblInstalled.Text = "Install Date:";
			// 
			// txtInstalled
			// 
			this.txtInstalled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInstalled.Location = new System.Drawing.Point(231, 254);
			this.txtInstalled.Name = "txtInstalled";
			this.txtInstalled.ReadOnly = true;
			this.txtInstalled.Size = new System.Drawing.Size(221, 20);
			this.txtInstalled.TabIndex = 6;
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(9, 16);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(44, 13);
			this.lblSearch.TabIndex = 6;
			this.lblSearch.Text = "Search:";
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(59, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(166, 20);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(231, 60);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(63, 13);
			this.lblDescription.TabIndex = 8;
			this.lblDescription.Text = "Description:";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(231, 76);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(221, 72);
			this.txtDescription.TabIndex = 3;
			// 
			// lblAuthor
			// 
			this.lblAuthor.AutoSize = true;
			this.lblAuthor.Location = new System.Drawing.Point(232, 155);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(41, 13);
			this.lblAuthor.TabIndex = 10;
			this.lblAuthor.Text = "Author:";
			// 
			// txtAuthor
			// 
			this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAuthor.Location = new System.Drawing.Point(231, 171);
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.ReadOnly = true;
			this.txtAuthor.Size = new System.Drawing.Size(221, 20);
			this.txtAuthor.TabIndex = 4;
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(232, 198);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(45, 13);
			this.lblVersion.TabIndex = 12;
			this.lblVersion.Text = "Version:";
			// 
			// txtVersion
			// 
			this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtVersion.Location = new System.Drawing.Point(232, 215);
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.ReadOnly = true;
			this.txtVersion.Size = new System.Drawing.Size(220, 20);
			this.txtVersion.TabIndex = 5;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(231, 329);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 25);
			this.btnDelete.TabIndex = 7;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// frmAddons
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(464, 366);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.txtVersion);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.txtAuthor);
			this.Controls.Add(this.lblAuthor);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.txtInstalled);
			this.Controls.Add(this.lblInstalled);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lbAddons);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAddons";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Addons";
			this.Load += new System.EventHandler(this.frmAddons_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbAddons;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblInstalled;
		private System.Windows.Forms.TextBox txtInstalled;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.TextBox txtAuthor;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.Button btnDelete;
	}
}