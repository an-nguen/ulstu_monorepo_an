using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_coursework.utils;

namespace TP_coursework
{
    public partial class MainForm : Form
    {
        // Свойства показывают правильность заполнения полей
        private bool reqFieldsIsValid = false;
        private bool nreqFieldsIsValid = false;

        public MainForm()
        {
            InitializeComponent();
            // Привязываем события полей ввода ФИО к одному методу
            maskedFieldLastName.MaskedTextBoxLeave += MaskedField_MaskedTextBoxLeave;
            maskedFieldName.MaskedTextBoxLeave += MaskedField_MaskedTextBoxLeave;
            maskedFieldMidName.MaskedTextBoxLeave += MaskedField_MaskedTextBoxLeave_nreq;
            maskedFieldLastName.OnLeave += MaskedField_OnLeave;
            maskedFieldName.OnLeave += MaskedField_OnLeave;
            maskedFieldMidName.OnLeave += MaskedField_OnLeave_nreq;
            maskedFieldLastName.setBackColorAll(Color.Transparent, Color.Aqua, Color.White);
            maskedFieldMidName.CanBeEmpty = true;
        }

        // Метод к которому привязаны события обязательных полей ввода данных
        private void MaskedField_OnLeave(object sender, Data data)
        {
            reqFieldsIsValid = data.IsValid;
        }
        // Метод к которому привязаны события необязательных полей ввода данных
        private void MaskedField_OnLeave_nreq(object sender, Data data)
        {
            if (!(sender is MaskedTextBox)) return;

            MaskedTextBox field = sender as MaskedTextBox;
            if (!string.IsNullOrEmpty(field.Text))
                nreqFieldsIsValid = data.IsValid;
            else
                nreqFieldsIsValid = true;
        }


        // Метод проверяет поля ввода данных на пустоту строк
        private bool fieldsIsEmpty()
        {
            if (string.IsNullOrEmpty(maskedFieldLastName.Text) |
                string.IsNullOrEmpty(maskedFieldName.Text) |
                string.IsNullOrEmpty(maskedFieldUniversity.Text) |
                !maskedFieldWay.MaskCompleted |
                !maskedFieldCourse.MaskCompleted)
                return true;
            else
                return false;
        }

        // Метод проверяет строку, принятый в аргумент метода, на то что в 
        // строке должны только встречаться латинские и русские символы
        private bool isValidField(String text)
        {
            return
                (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[A-Za-zА-Яа-я]+$")) 
                ? false : true;
        }

        private void MaskedField_MaskedTextBoxLeave(object sender, EventArgs e) { }

        private void MaskedField_MaskedTextBoxLeave_nreq(object sender, EventArgs e) { }

        // Данные студента которые потом сохраним в файл
        public void setStudentInfo()
        {
            DataLayer.studentInfoToSave = maskedFieldLastName.Text + ';' + maskedFieldName.Text + ';' +
                maskedFieldMidName.Text + ';' + maskedFieldWay.Text + ';' + maskedFieldCourse.Text + ';' 
                + maskedFieldUniversity.Text + ';';
        }

        /** События **/
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (!fieldsIsEmpty() & reqFieldsIsValid & nreqFieldsIsValid)
            {
                setStudentInfo();
                this.Hide();
                Program.form1.FormClosed += (s, args) => this.Close();
                Program.form1.Show();
            } else
            {
                MessageBox.Show("Заполните все поля. Также в полях ФИО не может быть чисел.");
            }
        }
    }
}
