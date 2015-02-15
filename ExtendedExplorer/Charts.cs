using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Collections;
using System.Windows.Forms;


namespace ExtendedExplorer
{
    // basis class voor het tekenen van de charts
    public class Chart : Control
    {
        #region private constant

        // de constante waarden voor het groeperen van data
        // het groeperen van data is het "samensmelten" van data die klein zijn
        private const int MINIMUM_PIECE = 1; // het minimim aantal data wat samengevoegd kan zijn
        private const int SMALLEST_DISPLAY_IN_PERCENT = 2; // het minimum aantal procent dat zelfstandig getoond kan worden. kleiner als deze waarde wordt samengevoegd.

        #endregion

        #region private boolean

        private bool isSortedDesc = true;
        private bool isStretch = true; // boolean voor breedte en de hoogte aan te passen in de OnPaint event
        private bool _firstDraw = true; // boolean voor het resizen in de public void draw ()

        #endregion

        #region Fields - properties

        // de data na het sorteren en groeperen
        public SortedHashTable data;

        // de chartDrawing data die getekend wordt in de graphic object
        public IDictionary Data
        {
            set
            {
                data = new SortedHashTable(value); // er wordt een nieuwe hashtable aangemaakt (sorted)
                data.sortValuesDesc(); // de data is gesorteerd op afnemende waarde
                data.groupValues(MINIMUM_PIECE, SMALLEST_DISPLAY_IN_PERCENT); // de data is gegroepeerd zoals aangegeven bij de constante waarde
            }
        }

        protected Legend legend; // hier wordt een legend aangemaakt om de legend gegevens hier te gebruiken 
        public Legend draw2Legend // hier wordt de legend ingevuld met dezelfde gegevens als in Legend.cs
        {
            set
            {
                legend = value;
            }
        }

        public ChartView view; // hier wordt een ChartView aangemaakt om die gegevens ook hier te gebruiken
        public ChartView View // hier wordt de ChartView gevuld met dezelfde gegevens als bij de Bar en Pie chart
        {
            set
            {
                view = value;
            }
        }

        #endregion

        #region public variable

        

        // de variabelen voor het tekenen van de chartDrawing
        public int chartWidth; // chartWidth is een int en met de public kan het door dit hele document gebruikt worden.
        public Graphics graphics; // een nieuwe graphics om te kunnen tekenen.
        public Brush[] brushes =
        {
                  Brushes.Red, Brushes.Orange, Brushes.Green, Brushes.Blue, 
				  Brushes.LightSlateGray, Brushes.Crimson, Brushes.DarkKhaki,
				  Brushes.Olive, Brushes.MediumSeaGreen, Brushes.LightCoral,
				  Brushes.Silver, Brushes.Chocolate 
        }; // en hier is de brush array die vanwege de public state in het hele document gebruikt kan worden.

        #endregion

        #region private method

        // de parentresize painteventhandler
        private void parentResized(Object o, EventArgs e)
        {
            // container wordt alleen bij het aanroepen van deze painteventhandler leeggemaakt en moet opniew getekend worden
            Invalidate();
        }

        #endregion

        #region protected override methods

        // deze methode is een template methode
        // het geeft in grote stappen weer hoe je een complete chartDrawing moet tekenen
        protected override void OnPaint(PaintEventArgs e)
        {
            if (data != null) // hij gaat pas tekenen als de data in de hashtable ongelijk is aan 0
            {
                if (isStretch) // hij kijkt nu of de isStretch boolean true is
                {
                    Width = Parent.Width; // de breedte wordt de control breedte
                    Height = Parent.Height; // de hoogte wordt de control hoogte
                }

                graphics = e.Graphics; // de public graphic variable wordt hier gebruikt en gevuld met e.Graphics
                graphics.SmoothingMode = SmoothingMode.AntiAlias; // de tekenins wordt een beetje zachter gemaakt
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit; // de tekst wordt beter getekend maar kost meer vermogen
                graphics.Clear(Color.White); // graphics wordt helemaal leeggemaakt en met een wit achtergrond gevuld

                try
                {
                    drawChart(); // probeert drawChart uit te voeren
                    legend.data = data; // geeft aan dat de data in Charts.cs (dit document) hetzelfde moet worden als legend.data
                    legend.brushes = brushes; // geeft aan dat brushes in Charts.cs (it document) hetzelfde moet worden als legend.brushes
                }
                catch
                {
                }
            }
        }

        #endregion

        #region protected virtual method

        // creëer een bitmap instantie
        protected virtual void drawChart()
        {
            switch (view) // dit is de switch die aangeeft welke chartview (case) hij verder mee moet gaan
            {
                case ChartView.Pie: // de Pie chart case
                    PieChart test = new PieChart(); // er wordt een nieuwe piechart aangemaakt genaamd test
                    test.drawChart(data, graphics); // hier wordt de test(piechart) gevuld met de data en graphics uit de drawChart uit de PieChart.cs
                    break; // geeft aan dat de case geindigd is
                case ChartView.Bar: // de Bar chart case
                    BarChart temp = new BarChart(); // er wordt een nieuwe barchart aangemaakt genaamd temp
                    temp.drawChart(data, graphics); // hier wordt de temp(barchart) gevuld met de data en graphics uit de drawChart uit de BarChart.cs
                    break; // geeft aan dat de case geindigd is
            }
        }

        #endregion

        #region public methods

        public void draw()
        {
            // Als de container resize dan wordt de chartDrawing ook geresized
            if (_firstDraw && Parent != null) // hier wordt vergeleken of de _firstdraw en de Parent niet leeg zijn dus een waarde hebben
            {
                ((Control)Parent).Resize += new EventHandler(parentResized); // hier wordt de parent control geresized met een nieuwe eventhandler
                _firstDraw = false; // de firstdraw boolean wordt op false gezet
            }

            Invalidate(); // de control wordt hier gereset en moet opnieuw getekend worden (op de geresized container)
        }

        public Chart() // method voor het aangeven van de breedte en de hoogte van de Chart
        {
            Width = 300;
            Height = 100;
        }

        #endregion
    }
}