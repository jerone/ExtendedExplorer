using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace ExtendedExplorer {
    sealed class ListViewItemComparer : IComparer {
        private int WelkeKolom;
        private SortOrder WelkeKantOp;

        public ListViewItemComparer() {
            WelkeKolom = 0;
            WelkeKantOp = SortOrder.Ascending;
        }

        public int Welkekolom {
            set { WelkeKolom = value; }
            get { return WelkeKolom; }
        }

        public SortOrder Welkekant {
            set { WelkeKantOp = value; }
            get { return WelkeKantOp; }
        }

        public int Compare(object x, object y) {
            string listviewXstr = ((ListViewItem)x).SubItems[WelkeKolom].Text;
            string listviewYstr = ((ListViewItem)y).SubItems[WelkeKolom].Text;

            int IntVergelijkingsResultaat;

            decimal dec_x; // double heeft geen compare methode
            decimal dec_y;
            DateTime dat_x;
            DateTime dat_y;

            if(Decimal.TryParse(listviewXstr.Replace(",", "").Replace(" KB", "").Replace("%", ""), out dec_x) && Decimal.TryParse(listviewYstr.Replace(",", "").Replace(" KB", "").Replace("%", ""), out dec_y)) {  // voor filesize en percentage;
                IntVergelijkingsResultaat = Decimal.Compare(dec_x, dec_y);
            }
            else if(DateTime.TryParse(listviewXstr, out dat_x) && DateTime.TryParse(listviewYstr, out dat_y)) {  // voor datum + tijd;
                IntVergelijkingsResultaat = DateTime.Compare(dat_x, dat_y);
            }
            else {  // voor de rest;
                IntVergelijkingsResultaat = String.Compare(listviewXstr, listviewYstr);
            }

            if(WelkeKantOp == SortOrder.Ascending) {
                return IntVergelijkingsResultaat;
            }
            else if(WelkeKantOp == SortOrder.Descending) {
                return (-IntVergelijkingsResultaat);
            }
            else { // Sortorder kan ook op None staan
                return 0;
            }
        }
    }
}