using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogAnalyzer {
    public partial class TextForm : Form {

        public string Value {
            get {
                return textBox1.Text;
            }
            set {
                textBox1.Text = value;
            }
        }

        public TextForm() {
            InitializeComponent();
        }

        private void TextForm_Load( object sender, EventArgs e ) {
            textBox1.Select();
        }

        private void textBox1_KeyUp( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Return ) {
                bOk.PerformClick();
            }
        }
    }
}
