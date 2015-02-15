using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Collections;
using System.Windows.Forms;

namespace ExtendedExplorer
{
    public class PieChart : Chart
    {
        public void drawChart(SortedHashTable data, Graphics graphics)
        {
            int width = 400, height = 400; // geeft de breedte en de hoogte van de piechart
            Bitmap bitmap = new Bitmap(width, height); // maakt een nieuwe bitmap waar de chart op getekend wordt

            // tel de input values bij elkaar op om het totaal te krijgen
            long sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data.Values[i];
            }

            // Teken de piechart
            float start = 0.0f;
            float end = 0.0f;
            decimal current = 0.0m;
            for (int i = 0; i < data.Length; i++)
            {
                current += data.Values[i];
                start = end;
                end = (float)(current / sum) * 360.0f;
                graphics.FillPie(brushes[i % brushes.Length], 50, 25, width, height, start, end - start);
            }

            //teken de hele grafiek in de form
            graphics.DrawImageUnscaled(bitmap, 0, 0);
        }
    }
}