namespace TP_coursework
{
    partial class MainForm
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelData = new System.Windows.Forms.Label();
            this.maskedFieldUniversity = new TP_coursework.MaskedField();
            this.maskedFieldCourse = new TP_coursework.MaskedField();
            this.maskedFieldMidName = new TP_coursework.MaskedField();
            this.maskedFieldName = new TP_coursework.MaskedField();
            this.maskedFieldLastName = new TP_coursework.MaskedField();
            this.maskedFieldWay = new TP_coursework.MaskedField();
            this.labelHello = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNext.Location = new System.Drawing.Point(918, 652);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "Далее";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(12, 652);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.BackColor = System.Drawing.Color.Transparent;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelData.ForeColor = System.Drawing.SystemColors.Control;
            this.labelData.Location = new System.Drawing.Point(143, 158);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(357, 37);
            this.labelData.TabIndex = 8;
            this.labelData.Text = "Укажите ваши данные:";
            // 
            // maskedFieldUniversity
            // 
            this.maskedFieldUniversity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedFieldUniversity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maskedFieldUniversity.BackColor = System.Drawing.Color.Transparent;
            this.maskedFieldUniversity.BackColorFieldName = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.maskedFieldUniversity.InputMaskFormat = "";
            this.maskedFieldUniversity.Location = new System.Drawing.Point(150, 411);
            this.maskedFieldUniversity.Margin = new System.Windows.Forms.Padding(5);
            this.maskedFieldUniversity.Name = "maskedFieldUniversity";
            this.maskedFieldUniversity.OnlyLetters = false;
            this.maskedFieldUniversity.RootBackColor = System.Drawing.Color.Transparent;
            this.maskedFieldUniversity.Size = new System.Drawing.Size(704, 30);
            this.maskedFieldUniversity.TabIndex = 7;
            this.maskedFieldUniversity.TextColor = System.Drawing.Color.Empty;
            this.maskedFieldUniversity.TextFieldName = "Название ВУЗа";
            this.maskedFieldUniversity.TextFont = null;
            // 
            // maskedFieldCourse
            // 
            this.maskedFieldCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedFieldCourse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maskedFieldCourse.BackColor = System.Drawing.Color.Transparent;
            this.maskedFieldCourse.BackColorFieldName = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.maskedFieldCourse.InputMaskFormat = "0";
            this.maskedFieldCourse.Location = new System.Drawing.Point(150, 371);
            this.maskedFieldCourse.Margin = new System.Windows.Forms.Padding(5);
            this.maskedFieldCourse.Name = "maskedFieldCourse";
            this.maskedFieldCourse.OnlyLetters = false;
            this.maskedFieldCourse.RootBackColor = System.Drawing.Color.Transparent;
            this.maskedFieldCourse.Size = new System.Drawing.Size(704, 30);
            this.maskedFieldCourse.TabIndex = 4;
            this.maskedFieldCourse.TextColor = System.Drawing.Color.Empty;
            this.maskedFieldCourse.TextFieldName = "Курс";
            this.maskedFieldCourse.TextFont = null;
            // 
            // maskedFieldMidName
            // 
            this.maskedFieldMidName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedFieldMidName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maskedFieldMidName.BackColor = System.Drawing.Color.Transparent;
            this.maskedFieldMidName.BackColorFieldName = System.Drawing.SystemColors.Control;
            this.maskedFieldMidName.InputMaskFormat = "";
            this.maskedFieldMidName.Location = new System.Drawing.Point(150, 291);
            this.maskedFieldMidName.Margin = new System.Windows.Forms.Padding(5);
            this.maskedFieldMidName.Name = "maskedFieldMidName";
            this.maskedFieldMidName.OnlyLetters = true;
            this.maskedFieldMidName.RootBackColor = System.Drawing.Color.Transparent;
            this.maskedFieldMidName.Size = new System.Drawing.Size(704, 30);
            this.maskedFieldMidName.TabIndex = 3;
            this.maskedFieldMidName.TextColor = System.Drawing.Color.Empty;
            this.maskedFieldMidName.TextFieldName = "Отчество";
            this.maskedFieldMidName.TextFont = null;
            // 
            // maskedFieldName
            // 
            this.maskedFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedFieldName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maskedFieldName.BackColor = System.Drawing.Color.Transparent;
            this.maskedFieldName.BackColorFieldName = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.maskedFieldName.InputMaskFormat = "";
            this.maskedFieldName.Location = new System.Drawing.Point(150, 251);
            this.maskedFieldName.Margin = new System.Windows.Forms.Padding(5);
            this.maskedFieldName.Name = "maskedFieldName";
            this.maskedFieldName.OnlyLetters = true;
            this.maskedFieldName.RootBackColor = System.Drawing.Color.Transparent;
            this.maskedFieldName.Size = new System.Drawing.Size(704, 30);
            this.maskedFieldName.TabIndex = 2;
            this.maskedFieldName.TextColor = System.Drawing.Color.Empty;
            this.maskedFieldName.TextFieldName = "Имя";
            this.maskedFieldName.TextFont = null;
            // 
            // maskedFieldLastName
            // 
            this.maskedFieldLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedFieldLastName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maskedFieldLastName.BackColor = System.Drawing.Color.Transparent;
            this.maskedFieldLastName.BackColorFieldName = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.maskedFieldLastName.InputMaskFormat = "";
            this.maskedFieldLastName.Location = new System.Drawing.Point(150, 211);
            this.maskedFieldLastName.Margin = new System.Windows.Forms.Padding(5);
            this.maskedFieldLastName.Name = "maskedFieldLastName";
            this.maskedFieldLastName.OnlyLetters = true;
            this.maskedFieldLastName.RootBackColor = System.Drawing.Color.Transparent;
            this.maskedFieldLastName.Size = new System.Drawing.Size(704, 30);
            this.maskedFieldLastName.TabIndex = 1;
            this.maskedFieldLastName.TextColor = System.Drawing.Color.Empty;
            this.maskedFieldLastName.TextFieldName = "Фамилия";
            this.maskedFieldLastName.TextFont = null;
            // 
            // maskedFieldWay
            // 
            this.maskedFieldWay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedFieldWay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.maskedFieldWay.BackColor = System.Drawing.Color.Transparent;
            this.maskedFieldWay.BackColorFieldName = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.maskedFieldWay.InputMaskFormat = "000000";
            this.maskedFieldWay.Location = new System.Drawing.Point(150, 331);
            this.maskedFieldWay.Margin = new System.Windows.Forms.Padding(5);
            this.maskedFieldWay.Name = "maskedFieldWay";
            this.maskedFieldWay.OnlyLetters = false;
            this.maskedFieldWay.RootBackColor = System.Drawing.Color.Transparent;
            this.maskedFieldWay.Size = new System.Drawing.Size(704, 30);
            this.maskedFieldWay.TabIndex = 9;
            this.maskedFieldWay.TextColor = System.Drawing.Color.Empty;
            this.maskedFieldWay.TextFieldName = "№ Направления";
            this.maskedFieldWay.TextFont = null;
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.BackColor = System.Drawing.Color.Transparent;
            this.labelHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHello.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHello.Location = new System.Drawing.Point(143, 59);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(235, 37);
            this.labelHello.TabIndex = 10;
            this.labelHello.Text = "Здравствуйте!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_coursework.Properties.Resources.ulyanovsk_politeh_blurred;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 687);
            this.Controls.Add(this.labelHello);
            this.Controls.Add(this.maskedFieldWay);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.maskedFieldUniversity);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.maskedFieldCourse);
            this.Controls.Add(this.maskedFieldMidName);
            this.Controls.Add(this.maskedFieldName);
            this.Controls.Add(this.maskedFieldLastName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "MainForm";
            this.Text = "App - Соц.опрос студентов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedField maskedFieldLastName;
        private MaskedField maskedFieldName;
        private MaskedField maskedFieldMidName;
        private MaskedField maskedFieldCourse;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonExit;
        private MaskedField maskedFieldUniversity;
        private System.Windows.Forms.Label labelData;
        private MaskedField maskedFieldWay;
        private System.Windows.Forms.Label labelHello;
    }
}

