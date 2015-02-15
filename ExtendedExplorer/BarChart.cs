using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Collections;
using System.Windows.Forms;

namespace ExtendedExplorer
{
    public class BarChart : Chart
    {
        public void drawChart(SortedHashTable data, Graphics graphics)
        {
            int chartWidth = 400, chartHeight = 400; // geeft de breedte en de hoogte van de barchart
            Bitmap bitmap = new Bitmap(chartWidth, chartHeight); // maakt een nieuwe bitmap waar de chart op getekend wordt
            Pen pen = new Pen(Color.Black, 1);  // frame lines;
            SolidBrush brush = new SolidBrush(Color.Green);  // text;
            Font font = new Font("Verdana", 10);  // font;
            SizeF fontSize; // berekent de hoogte, de breedte en de schaal van de grafiek voor het tekenen van de waarden op de assen.

            long bytes = 0, max = 0;// waarde die heb je nodig voor de fontsize te berekenen
            long steps = 5, step = 1;// waarde die je nodig hebt voor de berekening van de fontsize

            long x1 = 100, x2 = x1 + 20;// waarde voor de X-as, x1 is de afstand tussen de splitcontainer en de y as.
            long y1 = 150, y2 = 390;// waarde voor de y-as
            long inc = 40, l = 0, y = 390; // waarden voor de bars. inc is beginpunt op de x as.
            long factor = 0, y3 = 0;// waarde voor de bars. factor is de grootte per Bar dmv. de hashtable.

            // bereken de max waarde in de array
            for (int j = 0; j < data.Length; j++)
            {
                if (max < data.Values[j])
                    max = data.Values[j];
            }

            bytes = max / steps;  // verdeel de max waarde in 5 sub waarden

            //markeer de waarde in de grafiek
            while (step <= steps)
            {
                y = y - 40;//
                fontSize = graphics.MeasureString(Convert.ToString(bytes * step), font);
                graphics.DrawString(Convert.ToString(bytes * step), font, brush, x1 - fontSize.Width, y - (fontSize.Height / 2));// tekent de tekst met de waarden op de y as.
                graphics.DrawLine(pen, x1 - 5, y, x1 + 5, y); // tekent de horizontale streepjes op de y as.
                step++;
            }

            graphics.DrawString("0", font, brush, x1 - graphics.MeasureString("0", font).Width, y2);  // 0 punt;

            for (int i = 0; i < data.Length; i++)
            {
                x2 += inc;// berekenen van de breedte voor de bars op de x-as. inc is beginpunt, x2 is de breedte. deze wordt met inc opgeteld om zo een nieuwe Bar te kunnen tekenen.
            }

            l = x1; // geeft de waarde van x1 over aan l. x1 mag niet veranderen, daarom een hulpvariabele.

            // teken de bars voor elke waarde uit de array
            for (int m = data.Length - 1; m >= 0; m--)
            {
                factor = (data.Values[m] * 40) / bytes;
                l += inc;
                y3 = y2 - factor;
                Brush theBrush = (!data.IsGrouped | m < data.Keys.Length - 1) ? brushes[m % brushes.Length] : Brushes.Gold; // Neemt een brush uit de brush array op volgorde.
                graphics.FillRectangle(theBrush, l - 10, y3, 20, factor); // kleur de bars in.
                graphics.DrawRectangle(pen, l - 10, y3, 20, factor); // teken de bars
            }

            //teken de x as en de y as
            graphics.DrawLine(pen, new Point(Convert.ToInt32(x1), Convert.ToInt32(y1)), new Point(Convert.ToInt32(x1), Convert.ToInt32(y2)));
            graphics.DrawLine(pen, new Point(Convert.ToInt32(x1), Convert.ToInt32(y2)), new Point(Convert.ToInt32(x2), Convert.ToInt32(y2)));

            //teken de hele grafiek op het form
            graphics.DrawImageUnscaled(bitmap, 0, 0);
        }
    }
}