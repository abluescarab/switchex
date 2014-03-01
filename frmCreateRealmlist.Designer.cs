namespace Switchex {
	partial class frmCreateRealmlist {
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnUS = new System.Windows.Forms.Button();
			this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
			this.btnNo = new System.Windows.Forms.Button();
			this.btnEU = new System.Windows.Forms.Button();
			this.tlpButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(269, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Realmlist.wtf does not exist. Would you like to create it?\r\n";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnUS
			// 
			this.btnUS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUS.Location = new System.Drawing.Point(3, 3);
			this.btnUS.Name = "btnUS";
			this.btnUS.Size = new System.Drawing.Size(109, 26);
			this.btnUS.TabIndex = 1;
			this.btnUS.Text = "Yes, US version";
			this.btnUS.UseVisualStyleBackColor = true;
			this.btnUS.Click += new System.EventHandler(this.btnUS_Click);
			// 
			// tlpButtons
			// 
			this.tlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpButtons.ColumnCount = 3;
			this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpButtons.Controls.Add(this.btnNo, 2, 0);
			this.tlpButtons.Controls.Add(this.btnEU, 1, 0);
			this.tlpButtons.Controls.Add(this.btnUS, 0, 0);
			this.tlpButtons.Location = new System.Drawing.Point(12, 36);
			this.tlpButtons.Name = "tlpButtons";
			this.tlpButtons.RowCount = 1;
			this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpButtons.Size = new System.Drawing.Size(346, 32);
			this.tlpButtons.TabIndex = 2;
			// 
			// btnNo
			// 
			this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNo.Location = new System.Drawing.Point(233, 3);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(110, 26);
			this.btnNo.TabIndex = 3;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnEU
			// 
			this.btnEU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEU.Location = new System.Drawing.Point(118, 3);
			this.btnEU.Name = "btnEU";
			this.btnEU.Size = new System.Drawing.Size(109, 26);
			this.btnEU.TabIndex = 2;
			this.btnEU.Text = "Yes, EU version";
			this.btnEU.UseVisualStyleBackColor = true;
			this.btnEU.Click += new System.EventHandler(this.btnEU_Click);
			// 
			// frmCreateRealmlist
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnNo;
			this.ClientSize = new System.Drawing.Size(370, 80);
			this.ControlBox = false;
			this.Controls.Add(this.tlpButtons);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCreateRealmlist";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create Realmlist";
			this.Load += new System.EventHandler(this.frmCreateRealmlist_Load);
			this.tlpButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnUS;
		private System.Windows.Forms.TableLayoutPanel tlpButtons;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnEU;
	}
}