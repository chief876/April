using April.Custom.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace April.Custom.CustomForms
{
    public class CustomTextBox : TextBox, ICheckableControl
    {
        //private bool emptyDataCheck;
        public bool EmptyDataCheck {
            get;
            set;
        }
        /*{
            get
            {
                if (string.IsNullOrEmpty(this.Text))
                {
                    emptyDataCheck = true;
                }
                else
                {
                    emptyDataCheck = false;
                }
                return emptyDataCheck;
            }
            set
            {
                emptyDataCheck = value;
            }
        }*/
        public CustomTextBox()
        {
            EmptyDataCheck = true;
            this.TextChanged += CustomTextBox_TextChanged;
        }

        private void CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                EmptyDataCheck = true;
            }
            else
            {
                EmptyDataCheck = false;
            }
        }

        public bool Check()
        {
            if (!EmptyDataCheck) return true;
            if (this.Text != null && this.Text != string.Empty) return true;

            //if (showMessage) MessageBox.Show(EmptyDataText);
            return false;
        }

    }
}
