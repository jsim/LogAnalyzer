using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace LogAnalyzer {

    public partial class Form1 : Form {

        private string workPath;

        public Form1() {
            InitializeComponent();

            string strAppDir = Path.GetDirectoryName( Assembly.GetExecutingAssembly().GetName().CodeBase );
            Uri uri = new Uri( strAppDir );
            workPath = uri.LocalPath;

            rtb.DragDrop += new DragEventHandler( richTextBox1_DragDrop );
            rtb.DragEnter += new DragEventHandler( rtb_DragEnter );
            rtb.AllowDrop = true;
        }

        void rtb_DragEnter( object sender, DragEventArgs e ) {
            e.Effect = DragDropEffects.Copy;
        }

        void richTextBox1_DragDrop( object sender, DragEventArgs e ) {
            object filename = e.Data.GetData( "FileDrop" );
            if ( filename != null ) {
                var list = filename as string[];

                if ( list != null && !string.IsNullOrWhiteSpace( list[0] ) ) {
                    rtb.Clear();
                    this.Enabled = false;
                    Application.DoEvents();

                    try {
                        loadFile(list[0]);
                    } finally {
                        this.Enabled = true;
                    }
                }

            }
        }

        private void Form1_Load( object sender, EventArgs e ) {
            reloadDir();

            loadPrefilters();
        }

        private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
            Properties.Settings.Default.Save();
        }

        private void bDir_Click( object sender, EventArgs e ) {
            folderDialog.SelectedPath = tbDir.Text;

            if ( folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                tbDir.Text = folderDialog.SelectedPath;
                reloadDir();
            }
        }

        private void reloadDir() {
            try {
                clbFiles.Items.Clear();

                var files = Directory.GetFiles( tbDir.Text );
                foreach ( var file in files.OrderBy( en => en ) ) {
                    clbFiles.Items.Add( Path.GetFileName( file ) );
                }
            } catch { }
        }

        private void clbFiles_SelectedIndexChanged( object sender, EventArgs e ) {
            loadLogFiles();
        }

        private void loadLogFiles() {
            string[] files = getSelectedFiles();

            rtb.Clear();

            this.Enabled = false;
            Application.DoEvents();

            try {
                foreach ( var file in files ) {
                    string filename = Path.Combine( tbDir.Text, file );

                    loadFile( filename );
                }
            } finally {
                this.Enabled = true;
            }
        }

        private void loadFile( string filename ) {
            try {
                var inputFilter = new InputFilter( rtbPrefilter.Text );

                using ( StreamReader sr = new StreamReader( filename ) ) {
                    String line = sr.ReadLine();

                    //Timto se preskoci prazdna radky na zacatku souboru (mame sve duvody)
                    while ( line != null ) {
                        if ( string.IsNullOrEmpty( line ) ) {
                            line = sr.ReadLine();
                        }
                        else {
                            break;
                        }
                    }

                    StringBuilder sb = new StringBuilder();

                    while ( line != null ) {

                        if ( inputFilter.Keep( line ) ) {
                            sb.AppendLine( line );
                        }

                        line = sr.ReadLine();
                    }

                    rtb.Text = sb.ToString();
                }
            } catch { }
        }

        private string[] getSelectedFiles() {
            List<string> items = new List<string>();

            string current = (string)clbFiles.Items[clbFiles.SelectedIndex];

            items.Add( current );

            foreach ( string file in clbFiles.CheckedItems ) {

                if ( !file.Equals( current ) ) {
                    items.Add( file );
                }

            }

            items.Sort();
            return items.ToArray();
        }

        private void tbDir_KeyUp( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Return ) {
                reloadDir();
            }
        }

        private void rtbPrefilter_KeyDown( object sender, KeyEventArgs e ) {
            if ( e.Control ) {

                if ( e.KeyCode == Keys.S ) {
                    savePrefilter();
                }
                else if ( e.KeyCode == Keys.Delete ) {
                    deletePrefilter();
                }

            }
        }

        private void deletePrefilter() {
            if ( !string.IsNullOrEmpty( cbPrefilter.Text ) ) {

                string filename = Path.Combine( workPath, cbPrefilter.Text );

                if ( File.Exists( filename ) ) {

                    var dr = MessageBox.Show( "Smazat prefilter " + filename + "?", "Smazat?", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

                    if ( dr == System.Windows.Forms.DialogResult.Yes ) {
                        File.Delete( filename );

                        loadPrefilters();
                    }
                }

            }
        }

        private void savePrefilter() {
            string filter = rtbPrefilter.Text;

            if ( string.IsNullOrEmpty( filter ) ) {
                return;
            }

            string filename = Path.Combine( workPath, getPrefilterName( rtbPrefilter.Lines ) + ".pf" );

            rtbPrefilter.SaveFile( filename );

            loadPrefilters();
        }

        private string getPrefilterName( string[] lines ) {
            foreach ( var s in lines ) {
                if ( !string.IsNullOrEmpty( s ) ) {
                    return s;
                }
            }

            throw new InvalidOperationException( "Cannot get filter name from empty text!" );
        }

        private void loadPrefilters() {

            cbPrefilter.Items.Clear();
            cbPrefilter.Items.Add( string.Empty );

            foreach ( var file in Directory.GetFiles( workPath ) ) {
                if ( file.EndsWith( ".pf" ) ) {
                    cbPrefilter.Items.Add( Path.GetFileName( file ) );
                }
            }

            cbPrefilter.SelectedIndex = 0;
        }

        private void cbPrefilter_SelectedIndexChanged( object sender, EventArgs e ) {

            rtbPrefilter.Clear();

            if ( !string.IsNullOrEmpty( cbPrefilter.Text ) ) {

                string filename = Path.Combine( workPath, cbPrefilter.Text );

                if ( File.Exists( filename ) ) {
                    rtbPrefilter.LoadFile( filename );
                }

            }
        }
    }
}
