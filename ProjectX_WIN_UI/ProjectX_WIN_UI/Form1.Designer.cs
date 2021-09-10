using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System;
namespace ProjectX_WIN_UI
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
            this.Console = new System.Windows.Forms.Label();
            this.background_CPPCSCOM = new System.ComponentModel.BackgroundWorker();
            this.UILoader = new System.ComponentModel.BackgroundWorker();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.AutoSize = true;
            this.Console.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Console.Location = new System.Drawing.Point(0, 0);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(16, 15);
            this.Console.TabIndex = 0;
            this.Console.Text = "...";
            // 
            // background_CPPCSCOM
            // 
            this.background_CPPCSCOM.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CPPCSCOM_DoWork);
            // 
            // UILoader
            // 
            this.UILoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UILoader_DoWork);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1183, 506);
            this.MainPanel.TabIndex = 1;
            this.MainPanel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.ClientSize = new System.Drawing.Size(1184, 506);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.Console);
            this.Name = "Form1";
            this.Text = "ProjectX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Console;
        private System.ComponentModel.BackgroundWorker background_CPPCSCOM;
        private System.ComponentModel.BackgroundWorker UILoader;
        private System.Windows.Forms.Panel MainPanel;
    }
}

