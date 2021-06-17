
namespace Snake_Wars
{
    //主菜单
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.Title = new System.Windows.Forms.Label();
            this.Rules = new System.Windows.Forms.Label();
            this.RankingList = new System.Windows.Forms.Label();
            this.Enter = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("方正粗黑宋简体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Title.Location = new System.Drawing.Point(119, 90);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(522, 97);
            this.Title.TabIndex = 0;
            this.Title.Text = "贪吃蛇大作战";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.Click += new System.EventHandler(this.label1_Click);
            // 
            // Rules
            // 
            this.Rules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules.AutoSize = true;
            this.Rules.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rules.Location = new System.Drawing.Point(637, 505);
            this.Rules.Name = "Rules";
            this.Rules.Size = new System.Drawing.Size(133, 30);
            this.Rules.TabIndex = 1;
            this.Rules.Text = "游戏规则";
            this.Rules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rules.Click += new System.EventHandler(this.Rules_Click);
            // 
            // RankingList
            // 
            this.RankingList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RankingList.AutoSize = true;
            this.RankingList.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RankingList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RankingList.Location = new System.Drawing.Point(637, 461);
            this.RankingList.Name = "RankingList";
            this.RankingList.Size = new System.Drawing.Size(133, 30);
            this.RankingList.TabIndex = 1;
            this.RankingList.Text = "  排行榜";
            this.RankingList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RankingList.Click += new System.EventHandler(this.Ranking_Click);
            // 
            // Enter
            // 
            this.Enter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Enter.AutoSize = true;
            this.Enter.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Enter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Enter.Location = new System.Drawing.Point(290, 323);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(180, 50);
            this.Enter.TabIndex = 2;
            this.Enter.Text = "进入游戏";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exit
            // 
            this.Exit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exit.AutoSize = true;
            this.Exit.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Exit.Location = new System.Drawing.Point(290, 455);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(180, 50);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "退出游戏";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.button3_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.RankingList);
            this.Controls.Add(this.Rules);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "贪吃蛇大作战";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Rules;
        private System.Windows.Forms.Label RankingList;
        private new System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Button Exit;
    }
}