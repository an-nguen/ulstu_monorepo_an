using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace TP_coursework
{
    /*
        TextField - используем в качестве наименования поля ввода
        MaskedTextBox - используем в качестве поле ввода
    */
    public partial class MaskedField : UserControl, INotifyPropertyChanged, ICustomizable
    {
        /** ----------------------- Конструкторы ----------------------- **/
        // Конструктор без параметров
        public MaskedField()
        {
            InitializeComponent();
            // Используем его как наименования поля ввода
            fieldName.ReadOnly = true;
            // Устанавливаем стандартный цвет эл. textBox.backColor
            fieldName.ForeColor = this.foreColor;
            // Устанавливаем стандартный текст textBox
            fieldName.Text = this.textFieldName;
        }

        // this() - вызывает конструктор без параметров
        public MaskedField(string fieldNameValue) : this()
        {
            this.textFieldName = fieldNameValue;
        }


        /** ----------------------- Свойства ----------------------- **/
        /* ----- Собственные свойства ----- */
        private string textFieldName;
        private bool onlyLetters;

        // Текст в поле наименования
        [Browsable(true), Category("Данные"), DefaultValue("default text"),
            Description("Set default value of TextBox")]
        public string TextFieldName
        {
            get { return textFieldName; }
            set
            {
                textFieldName = value;
                OnPropertyChanged();
            }
        }

        [Browsable(true), Category("Данные")]
        public bool OnlyLetters
        {
            get { return onlyLetters; }
            set
            {
                onlyLetters = value;
                OnPropertyChanged();
            }
        }

        [Browsable(true), Category("Данные")]
        public bool CanBeEmpty
        {
            get; set;
        }

        /* ----- Вспомогательные свойства ----- */
        private Color foreColor;
        private Font textFont;

        // Цвет текста в поле наименования
        [Browsable(true), Category("Данные"), DefaultValue(typeof(Color), "White"),
            Description("Set default text color")]
        public Color TextColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                OnPropertyChanged();
            }
        }

        [Browsable(true), Category("Данные"), DefaultValue(typeof(Font), "White"),
             Description("Set default text font")]
        public Font TextFont
        {
            get { return textFont; }
            set { textFont = value; }
        }

        /* ----- Сопостовляемые свойства ----- */
        // Цвет элемента управления - поле наименования
        [Browsable(true), Category("Данные"), DefaultValue(typeof(Color), "Gray"), 
            Description("Set default background color of TextBox")]
        public Color BackColorFieldName
        {
            get { return this.fieldName.BackColor; }
            set { this.fieldName.BackColor = value; }
        }

        // Цвет родительского элемента на которой находится поля
        [Browsable(true), Category("Данные"), DefaultValue(typeof(Color), "White"),
            Description("Set default text color of TextBox")]
        public Color RootBackColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        /** Поля для работы с MaskedTextBox **/
        // Маска поле ввода
        [Browsable(true), Category("Данные"), Description("Set mask of maskedTextBox")]
        public string InputMaskFormat
        {
            get { return maskedTextBox.Mask; }
            set { maskedTextBox.Mask = value; }
        }

        // Введённый текст в поле ввода
        [Browsable(false)]
        public override string Text
        {
            get { return maskedTextBox.Text; }
            set {
                maskedTextBox.Text = value;
            }
        }

        public bool MaskCompleted { get { return maskedTextBox.MaskCompleted; } }

        /** ----------------------- Методы ----------------------- **/
        public void setBackColorAll(Color BackColor,
                            Color BackColorTextField,
                            Color BackColorMaskedTextField
    )
        {
            this.BackColor = BackColor;
            this.setBackColor(BackColorTextField);
            this.maskedTextBox.BackColor = BackColorMaskedTextField;
        }

        public void setErrorColor(Color BackColorMaskedFieldIfError,
                                  Color ForeColorMaskedFieldIfError,
                                  Color BackColorMaskedFieldDefault,
                                  Color ForeColorMaskedFieldDefault,
                                  Func<bool> exp)
        {
            if (!exp())
            {
                this.maskedTextBox.BackColor = BackColorMaskedFieldIfError;
                this.maskedTextBox.ForeColor = ForeColorMaskedFieldIfError;
            }
            else
            {
                this.maskedTextBox.BackColor = BackColorMaskedFieldDefault;
                this.maskedTextBox.ForeColor = ForeColorMaskedFieldDefault;
            }
        }

        private bool isValidField()
        {
            if (string.IsNullOrEmpty(Text) & CanBeEmpty) return true;
            else return (!System.Text.RegularExpressions.Regex.IsMatch(maskedTextBox.Text, @"^[A-Za-zА-Яа-я]+$"))
                ? false : true;
        }

        /** Операции с элементом textBox **/
        /* Задание цвета поля элемента textBox */
        public void setBackColor(Color backColor)
        {
            fieldName.BackColor = backColor;
        }
        public void setFieldNameForeColor(Color foreColor)
        {
            fieldName.ForeColor = foreColor;
        }

        /* Задание названия поля элемента textBox */
        public void setFieldNameText(string name)
        {
            fieldName.Text = name;
            OnChangedEvent(this, null);
        }

        // Устанавливает цвет текста для поле ввода
        public void setForeColor(Color ForeColor)
        {
            this.maskedTextBox.ForeColor = ForeColor;
        }
        // Получает цвет текста для поле ввода
        public Color getBackColor()
        {
            return this.fieldName.BackColor;
        }
        // Получает цвет текста для поле ввода
        public Color getForeColor()
        {
            return this.maskedTextBox.ForeColor;
        }

        // Устанавливает шрифт текста для поле ввода
        public void setFont(Font font)
        {
            this.maskedTextBox.Font = font;
        }

        // Получает шрифт текста для поле ввода
        public Font getFont()
        {
            return this.maskedTextBox.Font;
        }


        /** ----------------------- События ----------------------- **/
        public delegate void TextOnChangedHandler(object sender, EventArgs args);
        public delegate void OnLeaveHandler(object sender, Data data);

        public event TextOnChangedHandler OnChanged;
        public event OnLeaveHandler OnLeave;

        public event EventHandler MaskedTextBoxLeave;
        public event EventHandler MaskedTextBoxTextChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnLeaveEvent(object sender, Data data)
        {
            if (OnLeave != null)
            {
                this.OnLeave(sender, data);
            }
        }

        protected virtual void OnChangedEvent(object sender, EventArgs e)
        {
            if (OnChanged != null)
            {
                this.OnChanged(sender, e);
            }
        }

        private void maskedTextBox_Leave(object sender, EventArgs e)
        {
            OnLeaveEvent(sender, new Data(isValidField()));

            if (onlyLetters)
                setErrorColor(Color.Red, Color.Black, Color.White, Color.Black, isValidField);
            
            if (this.MaskedTextBoxLeave != null)
                this.MaskedTextBoxLeave(this, e);
        }

        private void maskedTextBox_TextChanged(object sender, EventArgs e)
        {
            OnChangedEvent(sender, e);

            if (this.MaskedTextBoxTextChanged != null)
                this.MaskedTextBoxTextChanged(this, e);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            switch (propertyName)
            {
                case "TextFieldName":
                    setFieldNameText(TextFieldName);
                    break;
                case "TextColor":
                    setFieldNameForeColor(TextColor);
                    break;
                case "TextFont":
                    this.setFont(TextFont);
                    this.fieldName.Font = TextFont;
                    break;
                case "BackColorFieldName":
                    setBackColor(BackColorFieldName);
                    break;
            }
        }
    }

    /** ----------------------- Интерфейс ----------------------- **/
    interface ICustomizable
    {
        void setBackColor(Color BackColor);
        Color getBackColor();

        void setForeColor(Color ForeColor);
        Color getForeColor();

        void setFont(Font font);
        Font getFont();
    }

    public class Data
    {
        private bool isValid;

        public bool IsValid
        {
            get { return isValid; }
            set { this.isValid = value; }
        }

        public Data() { }
        public Data(bool isValid)
        {
            this.isValid = isValid;
        }
    }
}
