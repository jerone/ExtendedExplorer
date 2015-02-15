using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExtendedExplorer
{
    public partial class Legend : Form
    {
        #region public method

        public Legend()
        {
            InitializeComponent();
        }

        #endregion

        #region public Paint

        public void Legend_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj; // maakt een nieuw graphic object aan om te tekenen

            graphicsObj = this.CreateGraphics(); // hier wordt het graphic object gecreëerd

            const float SPACE_RATIO = 0.02f; // constante waarde voor de ruimte tussen legenda en de linkerkant 
            int X = (int)(SPACE_RATIO * Width); // dit is de beginbreedte van het object waar getekend zal worden
            int Y = 20; // dit is de beginhoogte van het object waar getekend zal worden

            // hier wordt de legenda ontworpen, berekend en uiteindelijk getekend per data
            for (int i = data.Length - 1; i > -1; i--) // deze loop zal door blijven gaan totdat er geen data meer in de hashtable te vinden is
            {
                float percent = data.Values[i] * 100 / (float)data.TotalValue; // hier wordt van de HashTable opgevraagd hoeveel procent de data in beslag neemt
                string strPercent = percent.ToString("#0.00") + "%"; // hier wordt het aantal percentage naar een string geschreven
                string nameText = (data.Keys[i] != "") ? data.Keys[i] : "Without extension"; // hier wordt de bestandsnaam opgevraagd zonder extensie
                string sizeText = data.Values[i].ToString(); // hier wordt de grootte van het bestand opgevraagd
                string legendText = nameText + " [" + sizeText + "] (" + strPercent + ")"; // hier wordt de tekst regel van de legenda gemaakt

                Brush theBrush = (!data.IsGrouped | i < data.Keys.Length - 1) ? brushes[i % brushes.Length] : Brushes.Gold; // hier wordt een brush toegekend vanuit de brush array(passend bij de brush van de grafiek)

                graphicsObj.FillRectangle(theBrush, X, Y, 14, 14); // hier worden de kleine vierkantjes met de kleur getekend
                graphicsObj.DrawString(legendText, new Font("Arial", 9), Brushes.Black, X + 20, Y); // hier wordt de legenda tekst geschreven achter de vierkantjes
                Y += 20; // dit is voor een nieuwe regel
            }
        }

        #endregion

        #region public fields - properties

        public SortedHashTable data; // aanmaken van de hashtable om hier te gebruiken
        public SortedHashTable Data // het vullen van de hashtable met dezelfde gegevens als de andere hashtable in Charts.cs
        {
            set
            {
                data = value;
            }
        }

        public Brush[] brushes; // het aanmaken van de brush array om hier te gebruiken
        public Brush[] brushen // het vullen van de brush array met dezelfde gegevens als de andere brush array in Charts.cs
        {
            set
            {
                brushes = value;
            }
        }

        #endregion
    }
}
