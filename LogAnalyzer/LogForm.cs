using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogAnalyzer {
    public partial class LogForm : Form {
        
        public LogForm(string mode, string value) {
            InitializeComponent();

            if ( string.IsNullOrEmpty( value ) ) {
                this.Text = mode;
            }
            else {
                this.Text = string.Concat( mode, ": ", value );
            }
        }

        internal void AddLine( string line ) {
            rtb.AppendText( line );
            rtb.AppendText( "\n" );
        }

        internal void AddText( string text ) {
            rtb.Text = text;
        }
    }
}
