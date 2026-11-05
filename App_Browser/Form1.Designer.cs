namespace App_Browser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView2Control = new Microsoft.Web.WebView2.WinForms.WebView2();
            buttonPrev = new Button();
            buttonNext = new Button();
            buttonReload = new Button();
            buttonSearch = new Button();
            textBoxAddress = new TextBox();
            groupBox1 = new GroupBox();
            listBoxHistoryItems = new ListBox();
            ((System.ComponentModel.ISupportInitialize)webView2Control).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // webView2Control
            // 
            webView2Control.AllowExternalDrop = true;
            webView2Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView2Control.CreationProperties = null;
            webView2Control.DefaultBackgroundColor = Color.White;
            webView2Control.Location = new Point(0, 99);
            webView2Control.Name = "webView2Control";
            webView2Control.Size = new Size(946, 1065);
            webView2Control.TabIndex = 0;
            webView2Control.ZoomFactor = 1D;
            // 
            // buttonPrev
            // 
            buttonPrev.Location = new Point(12, 12);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(48, 43);
            buttonPrev.TabIndex = 1;
            buttonPrev.Text = "◀";
            buttonPrev.UseVisualStyleBackColor = true;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(78, 12);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(48, 43);
            buttonNext.TabIndex = 2;
            buttonNext.Text = "▶";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonReload
            // 
            buttonReload.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonReload.Location = new Point(144, 12);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(48, 43);
            buttonReload.TabIndex = 3;
            buttonReload.Text = "↻";
            buttonReload.UseVisualStyleBackColor = true;
            buttonReload.Click += buttonReload_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(836, 16);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(84, 39);
            buttonSearch.TabIndex = 4;
            buttonSearch.Text = "🔍";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(217, 16);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(613, 39);
            textBoxAddress.TabIndex = 5;
            textBoxAddress.KeyDown += textBoxAddress_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(listBoxHistoryItems);
            groupBox1.Location = new Point(952, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(448, 1135);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "History:";
            // 
            // listBoxHistoryItems
            // 
            listBoxHistoryItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxHistoryItems.FormattingEnabled = true;
            listBoxHistoryItems.Location = new Point(13, 33);
            listBoxHistoryItems.Name = "listBoxHistoryItems";
            listBoxHistoryItems.Size = new Size(429, 1092);
            listBoxHistoryItems.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 1163);
            Controls.Add(groupBox1);
            Controls.Add(textBoxAddress);
            Controls.Add(buttonSearch);
            Controls.Add(buttonReload);
            Controls.Add(buttonNext);
            Controls.Add(buttonPrev);
            Controls.Add(webView2Control);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView2Control).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Control;
        private Button buttonPrev;
        private Button buttonNext;
        private Button buttonReload;
        private Button buttonSearch;
        private TextBox textBoxAddress;
        private GroupBox groupBox1;
        private ListBox listBoxHistoryItems;
    }
}
