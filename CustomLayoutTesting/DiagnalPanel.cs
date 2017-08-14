using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomLayoutTesting
{
    public class DiagnalPanel: Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var size = new Size();

            foreach(UIElement c in InternalChildren)
            {
                c.Measure(availableSize);
                size.Width += c.DesiredSize.Width;
                size.Height += c.DesiredSize.Height;
            }

            return size;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var l = new Point();
            foreach (UIElement c in InternalChildren)
            {
                c.Arrange(new Rect(l, c.DesiredSize));
                l.X += c.DesiredSize.Width;
                l.Y += c.DesiredSize.Height;
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}
