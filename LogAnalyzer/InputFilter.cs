using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAnalyzer {
    
    class InputFilter {

        private List<string> want = new List<string>();
        private List<string> dontWant = new List<string>();

        public InputFilter(string settings) {
            string[] lines = settings.Split( new char[] { (char)0x0D, (char)0x0A } );

            foreach ( var line in lines ) {

                if ( line.StartsWith( "+" ) ) {
                    want.Add( line.Substring( 1 ) );
                }
                else if ( line.StartsWith( "-" ) ) {
                    dontWant.Add( line.Substring( 1 ) );
                }

            }
        }


        internal bool Keep( string line ) {

            foreach ( var s in dontWant ) {
                if ( line.Contains( s ) ) {
                    return false;
                }
            }

            if ( want.Count == 0 ) {
                return true;
            }

            foreach ( var s in want ) {
                if ( line.Contains( s ) ) {
                    return true;
                }
            }

            return false;
        }
    }

}
