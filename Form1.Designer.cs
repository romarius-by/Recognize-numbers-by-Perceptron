﻿namespace Kovaleva_lab_sem6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonUploadImage = new System.Windows.Forms.Button();
            this.uploadImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBoxBit = new System.Windows.Forms.ListBox();
            this.buttonCreateConsts = new System.Windows.Forms.Button();
            this.buttonTeachA = new System.Windows.Forms.Button();
            this.buttonTeachB = new System.Windows.Forms.Button();
            this.buttonTeachC = new System.Windows.Forms.Button();
            this.buttonTeachD = new System.Windows.Forms.Button();
            this.buttonRecognize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonUploadImage
            // 
            this.buttonUploadImage.Location = new System.Drawing.Point(12, 183);
            this.buttonUploadImage.Name = "buttonUploadImage";
            this.buttonUploadImage.Size = new System.Drawing.Size(165, 45);
            this.buttonUploadImage.TabIndex = 1;
            this.buttonUploadImage.Text = "Upload";
            this.buttonUploadImage.UseVisualStyleBackColor = true;
            this.buttonUploadImage.Click += new System.EventHandler(this.ButtonUploadImage_Click);
            // 
            // uploadImageDialog
            // 
            this.uploadImageDialog.FileName = "openFileDialog1";
            // 
            // listBoxBit
            // 
            this.listBoxBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxBit.FormattingEnabled = true;
            this.listBoxBit.ItemHeight = 15;
            this.listBoxBit.Location = new System.Drawing.Point(224, 3);
            this.listBoxBit.Name = "listBoxBit";
            this.listBoxBit.Size = new System.Drawing.Size(411, 289);
            this.listBoxBit.TabIndex = 2;
            // 
            // buttonCreateConsts
            // 
            this.buttonCreateConsts.Enabled = false;
            this.buttonCreateConsts.Location = new System.Drawing.Point(650, 396);
            this.buttonCreateConsts.Name = "buttonCreateConsts";
            this.buttonCreateConsts.Size = new System.Drawing.Size(138, 42);
            this.buttonCreateConsts.TabIndex = 3;
            this.buttonCreateConsts.Text = "Create Constants";
            this.buttonCreateConsts.UseVisualStyleBackColor = true;
            this.buttonCreateConsts.Click += new System.EventHandler(this.ButtonCreateConsts_Click);
            // 
            // buttonTeachA
            // 
            this.buttonTeachA.Enabled = false;
            this.buttonTeachA.Location = new System.Drawing.Point(12, 396);
            this.buttonTeachA.Name = "buttonTeachA";
            this.buttonTeachA.Size = new System.Drawing.Size(138, 42);
            this.buttonTeachA.TabIndex = 4;
            this.buttonTeachA.Text = "Teach A";
            this.buttonTeachA.UseVisualStyleBackColor = true;
            // 
            // buttonTeachB
            // 
            this.buttonTeachB.Enabled = false;
            this.buttonTeachB.Location = new System.Drawing.Point(156, 396);
            this.buttonTeachB.Name = "buttonTeachB";
            this.buttonTeachB.Size = new System.Drawing.Size(138, 42);
            this.buttonTeachB.TabIndex = 5;
            this.buttonTeachB.Text = "Teach B";
            this.buttonTeachB.UseVisualStyleBackColor = true;
            // 
            // buttonTeachC
            // 
            this.buttonTeachC.Enabled = false;
            this.buttonTeachC.Location = new System.Drawing.Point(300, 396);
            this.buttonTeachC.Name = "buttonTeachC";
            this.buttonTeachC.Size = new System.Drawing.Size(138, 42);
            this.buttonTeachC.TabIndex = 6;
            this.buttonTeachC.Text = "Teach C";
            this.buttonTeachC.UseVisualStyleBackColor = true;
            // 
            // buttonTeachD
            // 
            this.buttonTeachD.Enabled = false;
            this.buttonTeachD.Location = new System.Drawing.Point(444, 396);
            this.buttonTeachD.Name = "buttonTeachD";
            this.buttonTeachD.Size = new System.Drawing.Size(138, 42);
            this.buttonTeachD.TabIndex = 7;
            this.buttonTeachD.Text = "Teach D";
            this.buttonTeachD.UseVisualStyleBackColor = true;
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Enabled = false;
            this.buttonRecognize.Location = new System.Drawing.Point(650, 12);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(138, 42);
            this.buttonRecognize.TabIndex = 8;
            this.buttonRecognize.Text = "Recognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.ButtonRecognize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.buttonTeachD);
            this.Controls.Add(this.buttonTeachC);
            this.Controls.Add(this.buttonTeachB);
            this.Controls.Add(this.buttonTeachA);
            this.Controls.Add(this.buttonCreateConsts);
            this.Controls.Add(this.listBoxBit);
            this.Controls.Add(this.buttonUploadImage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonUploadImage;
        private System.Windows.Forms.OpenFileDialog uploadImageDialog;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBoxBit;
        private System.Windows.Forms.Button buttonCreateConsts;
        private System.Windows.Forms.Button buttonTeachA;
        private System.Windows.Forms.Button buttonTeachB;
        private System.Windows.Forms.Button buttonTeachC;
        private System.Windows.Forms.Button buttonTeachD;
        private System.Windows.Forms.Button buttonRecognize;
    }
}
