using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogAnalyzer {
    public partial class GridForm : Form {

        public GridForm( string[] lines, string separator ) {
            InitializeComponent();

            parse( lines, separator );
        }

        private void parse( string[] lines, string separator ) {

            dgv.Rows.Clear();
            dgv.Columns.Clear();

            if ( lines == null || lines.Length == 0 ) {
                return;
            }

            int columns = getColumnsCount( lines, separator );

            if ( columns == 0 ) {
                return;
            }

            for ( int c = 0; c < columns; c++ ) {
                string s = string.Concat( "C", c );
                int columnsIndex = dgv.Columns.Add( s, s );
                dgv.Columns[columnsIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            char[] sep = separator.ToCharArray();

            foreach ( var line in lines ) {

                if ( string.IsNullOrEmpty( line.Trim() ) ) {
                    continue;
                }

                string[] arr = line.Split( sep );

                if ( arr.Length > columns ) {

                    int rowIndex = dgv.Rows.Add( new object[columns] );

                    for ( int c = 0; c < columns; c++ ) {
                        dgv.Rows[rowIndex].Cells[c].Value = arr[c];
                    }
                }
                else {
                    dgv.Rows.Add( arr );
                }
            }
        }

        private int getColumnsCount( string[] lines, string separator ) {

            char[] sep = separator.ToCharArray();

            foreach ( var line in lines ) {
                if ( line.Contains( separator ) ) {
                    string[] arr = line.Split( sep );
                    return arr.Length;
                }
            }

            return 0;
        }


    }
}
