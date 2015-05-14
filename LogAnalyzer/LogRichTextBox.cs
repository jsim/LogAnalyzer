using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace LogAnalyzer {
    class LogRichTextBox : RichTextBox {

        private string searchText = null;
        private int lastSearchPos = 0;

        public LogRichTextBox() {
            this.KeyUp += new KeyEventHandler( LogRichTextBox_KeyUp );
            this.WordWrap = false;
            this.ReadOnly = true;
            this.BackColor = Color.White;
            this.ShortcutsEnabled = true;
            this.DetectUrls = false;
            this.CausesValidation = false;
        }

        void LogRichTextBox_KeyUp( object sender, KeyEventArgs e ) {
            //WordWrap
            if ( e.KeyCode == Keys.W ) {
                this.WordWrap = !this.WordWrap;
            }
            else if ( e.KeyCode == Keys.O ) {//Open in new window
                doInclude();
            }
            else if ( e.KeyCode == Keys.I ) {//Open INVERT in new window
                doExclude();
            }
            else if ( e.KeyCode == Keys.Delete ) { //Delete block
                doBlockDelete();
            }
            else if ( e.Control && e.KeyCode == Keys.F ) {
                doFindText();
            }
            else if ( e.KeyCode == Keys.F3 ) {
                doNextFind();
            }
            else if ( e.KeyCode == Keys.G ) {
                doGrid();
            }
            else if ( e.KeyCode == Keys.D ) {
                doDistinct();
            }
            else if ( e.KeyCode == Keys.S ) {
                doBlockSplit();
            }
        }

        private void doInclude() {
            this.Cursor = Cursors.WaitCursor;

            string text = this.SelectedText;

            var fr = new LogForm( "CONTAINS", text );

            StringBuilder sb = new StringBuilder();
            foreach ( var line in this.Lines ) {
                if ( line.Contains( text ) ) {
                    sb.AppendLine( line );
                }
            }
            fr.AddText( sb.ToString() );
            fr.Show();

            this.Cursor = Cursors.Arrow;
        }

        private void doExclude() {
            this.Cursor = Cursors.WaitCursor;

            string text = this.SelectedText;

            var fr = new LogForm( "NOT CONTAINS", text );

            StringBuilder sb = new StringBuilder();
            foreach ( var line in this.Lines ) {
                if ( !line.Contains( text ) ) {
                    sb.AppendLine( line );
                }
            }
            fr.AddText( sb.ToString() );
            fr.Show();

            this.Cursor = Cursors.Arrow;
        }

        private void doBlockDelete() {
            int p1 = this.SelectionStart;
            int p2 = p1 + this.SelectionLength;

            int fll = getFirstLineLength();

            if ( p1 > fll || p2 > fll ) {
                MessageBox.Show( "Vyber pro BLOCK-DELETE lze delat pouze na prvnim radku!" );
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach ( var line in this.Lines ) {

                if ( p1 > 0 ) {

                    if ( line.Length < p1 ) {
                        sb.AppendLine( line );
                        continue;
                    }

                    string s1 = line.Substring( 0, p1 );
                    string s2 = string.Empty;

                    int x = line.Length;
                    if ( p2 < x ) {
                        s2 = line.Substring( p2, x - p2 );
                    }

                    sb.AppendLine( s1 + s2 );
                }
                else {
                    string s2 = string.Empty;
                    int x = line.Length;
                    if ( p2 < x ) {
                        s2 = line.Substring( p2, x - p2 );
                    }

                    sb.AppendLine( s2 );
                }

            }

            this.Clear();
            this.Text = sb.ToString();
        }

        private void doFindText() {
            using ( var fr = new TextForm() ) {
                if ( fr.ShowDialog() == DialogResult.OK ) {

                    if ( !fr.Value.Equals( searchText ) ) {
                        lastSearchPos = 0;
                    }

                    searchText = fr.Value;

                    lastSearchPos = this.Find( searchText, lastSearchPos, RichTextBoxFinds.None ) + 1;
                }
            }
        }

        private void doNextFind() {
            if ( searchText != null ) {
                lastSearchPos = this.Find( searchText, lastSearchPos, RichTextBoxFinds.None ) + 1;
            }
        }

        private void doGrid() {
            new GridForm( this.Lines, this.SelectedText ).Show();
        }

        private void doDistinct() {
            this.Cursor = Cursors.WaitCursor;

            var fr = new LogForm( "DISTINCT", string.Empty );

            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach ( var line in this.Lines ) {

                string key = line.Trim();

                if ( string.IsNullOrEmpty( key ) ) {
                    continue;
                }

                if ( map.ContainsKey( key ) ) {
                    map[key]++;
                }
                else {
                    map.Add( key, 1 );
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach ( var kvp in map.OrderBy( en => en.Value ) ) {
                sb.Append( kvp.Value.ToString() );
                sb.Append( "\t" );
                sb.AppendLine( kvp.Key );
            }
            sb.AppendLine( "\n" + map.Values.Sum().ToString() );

            fr.AddText( sb.ToString() );
            fr.Show();

            this.Cursor = Cursors.Arrow;
        }

        private void doBlockSplit() {
            if ( string.IsNullOrEmpty( this.SelectedText ) ) {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            string delimiter = this.SelectedText;

            List<StringBuilder> blocks = new List<StringBuilder>();

            foreach ( var line in this.Lines ) {

                string[] arr = split( line, delimiter );

                for ( int i = 0; i < arr.Length; i++ ) {

                    if ( blocks.Count < i + 1 ) {
                        blocks.Add( new StringBuilder() );
                    }

                    StringBuilder sb = blocks[i];

                    sb.AppendLine( arr[i] );
                }

            }

            foreach ( var sb in blocks ) {

                string s = sb.ToString().Trim();

                if ( string.IsNullOrEmpty( s ) ) {
                    continue;
                }

                var fr = new LogForm( "BLOCK-SPLIT", delimiter.ToString() );
                fr.AddText( s );
                fr.Show();
            }

            this.Cursor = Cursors.Arrow;
        }

        private string[] split( string line, string delimiter ) {
            string tmp = line;

            int len = delimiter.Length;
            int pos = tmp.IndexOf( delimiter );

            List<string> list = new List<string>();

            while ( pos != -1 ) {
                string cut = tmp.Substring( 0, pos );

                list.Add( cut );

                tmp = tmp.Substring( pos + len );

                pos = tmp.IndexOf( delimiter );

                if ( pos == -1 && !string.IsNullOrEmpty( tmp ) ) {
                    list.Add( tmp );
                }
            }

            return list.ToArray();
        }

        private int getFirstLineLength() {
            try {
                return this.Lines[0].Length + 1;
            } catch {
                return 0;
            }
        }
    }
}
