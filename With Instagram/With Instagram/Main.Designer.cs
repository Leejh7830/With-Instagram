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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxID1 = new System.Windows.Forms.ComboBox();
            this.insPW = new System.Windows.Forms.Label();
            this.insID = new System.Windows.Forms.Label();
            this.txtID1 = new System.Windows.Forms.TextBox();
            this.txtPW1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtPW1);
            this.groupBox1.Controls.Add(this.txtID1);
            this.groupBox1.Controls.Add(this.cboxID1);
            this.groupBox1.Controls.Add(this.insPW);
            this.groupBox1.Controls.Add(this.insID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cboxID1
            // 
            this.cboxID1.FormattingEnabled = true;
            this.cboxID1.Location = new System.Drawing.Point(43, 57);
            this.cboxID1.Name = "cboxID1";
            this.cboxID1.Size = new System.Drawing.Size(200, 23);
            this.cboxID1.TabIndex = 2;
            this.cboxID1.SelectedIndexChanged += new System.EventHandler(this.cboxID1_SelectedIndexChanged);
            // 
            // insPW
            // 
            this.insPW.AutoSize = true;
            this.insPW.Location = new System.Drawing.Point(65, 133);
            this.insPW.Name = "insPW";
            this.insPW.Size = new System.Drawing.Size(31, 15);
            this.insPW.TabIndex = 1;
            this.insPW.Text = "PW";
            // 
            // insID
            // 
            this.insID.AutoSize = true;
            this.insID.Location = new System.Drawing.Point(76, 95);
            this.insID.Name = "insID";
            this.insID.Size = new System.Drawing.Size(20, 15);
            this.insID.TabIndex = 0;
            this.insID.Text = "ID";
            // 
            // txtID1
            // 
            this.txtID1.Location = new System.Drawing.Point(112, 92);
            this.txtID1.Name = "txtID1";
            this.txtID1.Size = new System.Drawing.Size(131, 25);
            this.txtID1.TabIndex = 3;
            // 
            // txtPW1
            // 
            this.txtPW1.Location = new System.Drawing.Point(112, 130);
            this.txtPW1.Name = "txtPW1";
            this.txtPW1.Size = new System.Drawing.Size(131, 25);
            this.txtPW1.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(146, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 44);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(249, 183);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(146, 233);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 44);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboxID1;
        private System.Windows.Forms.Label insPW;
        private System.Windows.Forms.Label insID;
        private System.Windows.Forms.TextBox txtPW1;
        private System.Windows.Forms.TextBox txtID1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnConnect;
    }
}
