﻿
namespace With_Instagram
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ViewLogin = new System.Windows.Forms.GroupBox();
            this.btnSpecificPost = new System.Windows.Forms.Button();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPW1 = new System.Windows.Forms.TextBox();
            this.txtID1 = new System.Windows.Forms.TextBox();
            this.cboxID1 = new System.Windows.Forms.ComboBox();
            this.insPW = new System.Windows.Forms.Label();
            this.insID = new System.Windows.Forms.Label();
            this.btnLike = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ViewExplore = new System.Windows.Forms.GroupBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnUnfollow = new System.Windows.Forms.Button();
            this.btnFollow = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.ViewLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.ViewExplore.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewLogin
            // 
            this.ViewLogin.Controls.Add(this.btnSpecificPost);
            this.ViewLogin.Controls.Add(this.btnExit2);
            this.ViewLogin.Controls.Add(this.dgvUser);
            this.ViewLogin.Controls.Add(this.btnConnect);
            this.ViewLogin.Controls.Add(this.btnDelete);
            this.ViewLogin.Controls.Add(this.btnSave);
            this.ViewLogin.Controls.Add(this.txtPW1);
            this.ViewLogin.Controls.Add(this.txtID1);
            this.ViewLogin.Controls.Add(this.cboxID1);
            this.ViewLogin.Controls.Add(this.insPW);
            this.ViewLogin.Controls.Add(this.insID);
            this.ViewLogin.Location = new System.Drawing.Point(12, 12);
            this.ViewLogin.Name = "ViewLogin";
            this.ViewLogin.Size = new System.Drawing.Size(649, 439);
            this.ViewLogin.TabIndex = 0;
            this.ViewLogin.TabStop = false;
            this.ViewLogin.Text = "LoginView";
            // 
            // btnSpecificPost
            // 
            this.btnSpecificPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpecificPost.Location = new System.Drawing.Point(505, 21);
            this.btnSpecificPost.Name = "btnSpecificPost";
            this.btnSpecificPost.Size = new System.Drawing.Size(138, 44);
            this.btnSpecificPost.TabIndex = 15;
            this.btnSpecificPost.Text = "Specific Post";
            this.btnSpecificPost.UseVisualStyleBackColor = true;
            this.btnSpecificPost.Click += new System.EventHandler(this.btnSpecificPost_Click);
            // 
            // btnExit2
            // 
            this.btnExit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit2.Location = new System.Drawing.Point(6, 375);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(81, 45);
            this.btnExit2.TabIndex = 14;
            this.btnExit2.Text = "Exit";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(256, 21);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 27;
            this.dgvUser.Size = new System.Drawing.Size(243, 405);
            this.dgvUser.TabIndex = 8;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUser_CellClick);
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(43, 222);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 44);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(146, 172);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(43, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 44);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtPW1
            // 
            this.txtPW1.Location = new System.Drawing.Point(77, 130);
            this.txtPW1.Name = "txtPW1";
            this.txtPW1.Size = new System.Drawing.Size(166, 25);
            this.txtPW1.TabIndex = 4;
            // 
            // txtID1
            // 
            this.txtID1.Location = new System.Drawing.Point(77, 92);
            this.txtID1.Name = "txtID1";
            this.txtID1.Size = new System.Drawing.Size(166, 25);
            this.txtID1.TabIndex = 3;
            // 
            // cboxID1
            // 
            this.cboxID1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxID1.FormattingEnabled = true;
            this.cboxID1.Location = new System.Drawing.Point(43, 47);
            this.cboxID1.Name = "cboxID1";
            this.cboxID1.Size = new System.Drawing.Size(200, 23);
            this.cboxID1.TabIndex = 2;
            this.cboxID1.SelectedIndexChanged += new System.EventHandler(this.CboxID1_SelectedIndexChanged);
            // 
            // insPW
            // 
            this.insPW.AutoSize = true;
            this.insPW.Location = new System.Drawing.Point(40, 133);
            this.insPW.Name = "insPW";
            this.insPW.Size = new System.Drawing.Size(31, 15);
            this.insPW.TabIndex = 1;
            this.insPW.Text = "PW";
            // 
            // insID
            // 
            this.insID.AutoSize = true;
            this.insID.Location = new System.Drawing.Point(51, 95);
            this.insID.Name = "insID";
            this.insID.Size = new System.Drawing.Size(20, 15);
            this.insID.TabIndex = 0;
            this.insID.Text = "ID";
            // 
            // btnLike
            // 
            this.btnLike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLike.Location = new System.Drawing.Point(29, 35);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(81, 45);
            this.btnLike.TabIndex = 9;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(667, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 483);
            this.panel1.TabIndex = 11;
            // 
            // ViewExplore
            // 
            this.ViewExplore.Controls.Add(this.btnStop);
            this.ViewExplore.Controls.Add(this.txtCount);
            this.ViewExplore.Controls.Add(this.btnUnfollow);
            this.ViewExplore.Controls.Add(this.btnFollow);
            this.ViewExplore.Controls.Add(this.btnExit);
            this.ViewExplore.Controls.Add(this.btnLogout);
            this.ViewExplore.Controls.Add(this.btnLike);
            this.ViewExplore.Location = new System.Drawing.Point(683, 12);
            this.ViewExplore.Name = "ViewExplore";
            this.ViewExplore.Size = new System.Drawing.Size(634, 426);
            this.ViewExplore.TabIndex = 12;
            this.ViewExplore.TabStop = false;
            this.ViewExplore.Text = "ExploreView";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(116, 46);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(81, 25);
            this.txtCount.TabIndex = 15;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUnfollow
            // 
            this.btnUnfollow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnfollow.Location = new System.Drawing.Point(116, 86);
            this.btnUnfollow.Name = "btnUnfollow";
            this.btnUnfollow.Size = new System.Drawing.Size(81, 45);
            this.btnUnfollow.TabIndex = 13;
            this.btnUnfollow.Text = "UnFollow";
            this.btnUnfollow.UseVisualStyleBackColor = true;
            // 
            // btnFollow
            // 
            this.btnFollow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFollow.Location = new System.Drawing.Point(29, 86);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(81, 45);
            this.btnFollow.TabIndex = 12;
            this.btnFollow.Text = "Follow";
            this.btnFollow.UseVisualStyleBackColor = true;
            this.btnFollow.Click += new System.EventHandler(this.btnFollow_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(29, 366);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 45);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(29, 315);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(81, 45);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(29, 264);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 45);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 486);
            this.Controls.Add(this.ViewExplore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ViewLogin);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ViewLogin.ResumeLayout(false);
            this.ViewLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ViewExplore.ResumeLayout(false);
            this.ViewExplore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ViewLogin;
        private System.Windows.Forms.ComboBox cboxID1;
        private System.Windows.Forms.Label insPW;
        private System.Windows.Forms.Label insID;
        private System.Windows.Forms.TextBox txtPW1;
        private System.Windows.Forms.TextBox txtID1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox ViewExplore;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnUnfollow;
        private System.Windows.Forms.Button btnFollow;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnSpecificPost;
        private System.Windows.Forms.Button btnStop;
    }
}

