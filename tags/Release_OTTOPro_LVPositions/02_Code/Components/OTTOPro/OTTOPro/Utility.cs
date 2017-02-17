using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTTOPro
{
    class Utility
    {
        public static bool ValidateRequiredFields(List<Control> requiredFields)
        {
            bool IsValid = true;
            Control ctrlToFocus = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Please enter the following Values");
            sb.AppendLine();
            foreach (Control ctrl in requiredFields)
            {
                if (ctrl is TextEdit && ctrl.Text == string.Empty)
                {
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
                else if (ctrl is ComboBoxEdit && ((ComboBoxEdit)ctrl).SelectedItem == null)
                {
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
                else if (ctrl is ComboBoxEdit && ((ComboBoxEdit)ctrl).SelectedText.ToString() == "Select")
                {
                    IsValid = false;
                    sb.AppendLine(" * " + ctrl.Tag);
                    if (ctrlToFocus == null)
                        ctrlToFocus = ctrl;
                }
            }
            if (!IsValid)
            {
                XtraMessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlToFocus.Focus();
            }
            return IsValid;
        }

        public static void ShowError(Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ShowSucces(string Status)
        {
            XtraMessageBox.Show(Status, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
