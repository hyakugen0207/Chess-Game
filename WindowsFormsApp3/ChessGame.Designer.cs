namespace WindowsFormsApp3
{
    partial class ChessGame
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGame));
            this.UserRoundLabel = new System.Windows.Forms.Label();
            this.WhiteWinLabel = new System.Windows.Forms.Label();
            this.BlackWinLabel = new System.Windows.Forms.Label();
            this.pawnChangeJob1 = new WindowsFormsApp3.PawnChangeJob();
            this.chessboard1 = new WindowsFormsApp3.Chessboard();
            this.SuspendLayout();
            // 
            // UserRoundLabel
            // 
            this.UserRoundLabel.AutoSize = true;
            this.UserRoundLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserRoundLabel.Font = new System.Drawing.Font("思源黑體 TW Regular", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UserRoundLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.UserRoundLabel.Location = new System.Drawing.Point(307, 28);
            this.UserRoundLabel.Name = "UserRoundLabel";
            this.UserRoundLabel.Size = new System.Drawing.Size(253, 59);
            this.UserRoundLabel.TabIndex = 1;
            this.UserRoundLabel.Text = "輪到玩家[白]";
            this.UserRoundLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // WhiteWinLabel
            // 
            this.WhiteWinLabel.AutoSize = true;
            this.WhiteWinLabel.BackColor = System.Drawing.Color.Transparent;
            this.WhiteWinLabel.Font = new System.Drawing.Font("思源黑體 TW Regular", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WhiteWinLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.WhiteWinLabel.Location = new System.Drawing.Point(23, 28);
            this.WhiteWinLabel.Name = "WhiteWinLabel";
            this.WhiteWinLabel.Size = new System.Drawing.Size(205, 49);
            this.WhiteWinLabel.TabIndex = 3;
            this.WhiteWinLabel.Text = "玩家白：0勝";
            this.WhiteWinLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // BlackWinLabel
            // 
            this.BlackWinLabel.AutoSize = true;
            this.BlackWinLabel.BackColor = System.Drawing.Color.Transparent;
            this.BlackWinLabel.Font = new System.Drawing.Font("思源黑體 TW Regular", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BlackWinLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.BlackWinLabel.Location = new System.Drawing.Point(653, 28);
            this.BlackWinLabel.Name = "BlackWinLabel";
            this.BlackWinLabel.Size = new System.Drawing.Size(205, 49);
            this.BlackWinLabel.TabIndex = 4;
            this.BlackWinLabel.Text = "玩家黑：0勝";
            this.BlackWinLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // pawnChangeJob1
            // 
            this.pawnChangeJob1.Location = new System.Drawing.Point(-10, 451);
            this.pawnChangeJob1.Name = "pawnChangeJob1";
            this.pawnChangeJob1.Size = new System.Drawing.Size(904, 100);
            this.pawnChangeJob1.TabIndex = 5;
            this.pawnChangeJob1.Load += new System.EventHandler(this.pawnChangeJob1_Load);
            // 
            // chessboard1
            // 
            this.chessboard1.BackColor = System.Drawing.Color.Transparent;
            this.chessboard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chessboard1.BackgroundImage")));
            this.chessboard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chessboard1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.chessboard1.Location = new System.Drawing.Point(-10, 100);
            this.chessboard1.Margin = new System.Windows.Forms.Padding(0);
            this.chessboard1.Name = "chessboard1";
            this.chessboard1.Size = new System.Drawing.Size(904, 904);
            this.chessboard1.TabIndex = 0;
            this.chessboard1.Load += new System.EventHandler(this.chessboard1_Load);
            this.chessboard1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chessboard1_MouseClick);
            // 
            // ChessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(886, 953);
            this.Controls.Add(this.pawnChangeJob1);
            this.Controls.Add(this.BlackWinLabel);
            this.Controls.Add(this.WhiteWinLabel);
            this.Controls.Add(this.UserRoundLabel);
            this.Controls.Add(this.chessboard1);
            this.MaximumSize = new System.Drawing.Size(904, 1000);
            this.Name = "ChessGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "西洋棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Chessboard chessboard1;
        private System.Windows.Forms.Label UserRoundLabel;
        private System.Windows.Forms.Label WhiteWinLabel;
        private System.Windows.Forms.Label BlackWinLabel;
        private PawnChangeJob pawnChangeJob1;
    }
}

