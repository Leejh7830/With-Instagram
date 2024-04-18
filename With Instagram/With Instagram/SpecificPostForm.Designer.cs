
namespace With_Instagram
{
    partial class SpecificPostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.btnEnter1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "게시물 주소";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(39, 48);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(493, 25);
            this.txtAddr1.TabIndex = 1;
            // 
            // btnEnter1
            // 
            this.btnEnter1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter1.Location = new System.Drawing.Point(487, 114);
            this.btnEnter1.Name = "btnEnter1";
            this.btnEnter1.Size = new System.Drawing.Size(81, 45);
            this.btnEnter1.TabIndex = 15;
            this.btnEnter1.Text = "Enter";
            this.btnEnter1.UseVisualStyleBackColor = true;
            this.btnEnter1.Click += new System.EventHandler(this.btnEnter1_Click);
            // 
            // SpecificPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 171);
            this.Controls.Add(this.btnEnter1);
            this.Controls.Add(this.txtAddr1);
            this.Controls.Add(this.label1);
            this.Name = "SpecificPostForm";
            this.Text = "SpecificPostForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddr1;
        private System.Windows.Forms.Button btnEnter1;
    }
}