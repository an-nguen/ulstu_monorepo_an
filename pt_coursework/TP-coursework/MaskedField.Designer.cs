namespace TP_coursework
{
    partial class MaskedField
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldName = new System.Windows.Forms.TextBox();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // fieldName
            // 
            this.fieldName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldName.Location = new System.Drawing.Point(5, 5);
            this.fieldName.Margin = new System.Windows.Forms.Padding(5);
            this.fieldName.MinimumSize = new System.Drawing.Size(60, 20);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(190, 26);
            this.fieldName.TabIndex = 0;
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox.Location = new System.Drawing.Point(205, 5);
            this.maskedTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.maskedTextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(190, 26);
            this.maskedTextBox.TabIndex = 1;
            this.maskedTextBox.TextChanged += new System.EventHandler(this.maskedTextBox_TextChanged);
            this.maskedTextBox.Leave += new System.EventHandler(this.maskedTextBox_Leave);
            // 
            // MaskedField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.maskedTextBox);
            this.Controls.Add(this.fieldName);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MaskedField";
            this.Size = new System.Drawing.Size(400, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fieldName;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
    }
}
