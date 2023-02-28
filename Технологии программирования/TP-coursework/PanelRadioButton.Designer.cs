namespace TP_coursework
{
    partial class PanelRadioButton
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
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.panel0 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Location = new System.Drawing.Point(4, 4);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(85, 17);
            this.radioButton0.TabIndex = 0;
            this.radioButton0.TabStop = true;
            this.radioButton0.Text = "radioButton0";
            this.radioButton0.UseVisualStyleBackColor = true;
            this.radioButton0.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // panel0
            // 
            this.panel0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel0.AutoSize = true;
            this.panel0.Location = new System.Drawing.Point(4, 27);
            this.panel0.Name = "panel0";
            this.panel0.Size = new System.Drawing.Size(473, 210);
            this.panel0.TabIndex = 2;
            // 
            // PanelRadioButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel0);
            this.Controls.Add(this.radioButton0);
            this.Name = "PanelRadioButton";
            this.Size = new System.Drawing.Size(480, 240);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.Panel panel0;
    }
}
