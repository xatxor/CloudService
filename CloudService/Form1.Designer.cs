
namespace CloudService
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.zipButton = new System.Windows.Forms.Button();
            this.selectedFilesLabel = new System.Windows.Forms.Label();
            this.selectedFilesTextbox = new System.Windows.Forms.TextBox();
            this.loadControl = new CloudService.LoadControl();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // openButton
            // 
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.openButton.Location = new System.Drawing.Point(15, 200);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(145, 42);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Загрузить файлы";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sendButton.Location = new System.Drawing.Point(15, 296);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(145, 42);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // zipButton
            // 
            this.zipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.zipButton.Location = new System.Drawing.Point(15, 248);
            this.zipButton.Name = "zipButton";
            this.zipButton.Size = new System.Drawing.Size(145, 42);
            this.zipButton.TabIndex = 2;
            this.zipButton.Text = "Сжать";
            this.zipButton.UseVisualStyleBackColor = true;
            this.zipButton.Click += new System.EventHandler(this.zipButton_Click);
            // 
            // selectedFilesLabel
            // 
            this.selectedFilesLabel.AutoSize = true;
            this.selectedFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectedFilesLabel.Location = new System.Drawing.Point(170, 23);
            this.selectedFilesLabel.Name = "selectedFilesLabel";
            this.selectedFilesLabel.Size = new System.Drawing.Size(137, 17);
            this.selectedFilesLabel.TabIndex = 3;
            this.selectedFilesLabel.Text = "Файлов выбрано: 0";
            // 
            // selectedFilesTextbox
            // 
            this.selectedFilesTextbox.Location = new System.Drawing.Point(173, 43);
            this.selectedFilesTextbox.Multiline = true;
            this.selectedFilesTextbox.Name = "selectedFilesTextbox";
            this.selectedFilesTextbox.ReadOnly = true;
            this.selectedFilesTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.selectedFilesTextbox.Size = new System.Drawing.Size(336, 295);
            this.selectedFilesTextbox.TabIndex = 4;
            this.selectedFilesTextbox.Enter += new System.EventHandler(this.selectedFilesTextbox_Enter);
            // 
            // loadControl
            // 
            this.loadControl.Location = new System.Drawing.Point(0, -1);
            this.loadControl.Name = "loadControl";
            this.loadControl.Size = new System.Drawing.Size(529, 364);
            this.loadControl.TabIndex = 5;
            this.loadControl.token = "AgAAAABPGUwfAAbUENAGNkexA0nfhkx4wvmr51s";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 361);
            this.Controls.Add(this.loadControl);
            this.Controls.Add(this.selectedFilesTextbox);
            this.Controls.Add(this.selectedFilesLabel);
            this.Controls.Add(this.zipButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.openButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button zipButton;
        private System.Windows.Forms.Label selectedFilesLabel;
        private System.Windows.Forms.TextBox selectedFilesTextbox;
        private LoadControl loadControl;
    }
}

