﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace GroupBoxTest
{
    class MyGroupBox : GroupBox
    {
        private Color _borderColor;

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                if (BorderColor == value) return;
                _borderColor = value;
                Refresh();
            }
        }

        public MyGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            _borderColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var sizeF = e.Graphics.MeasureString(Text, Font);
            var borderRect = ClientRectangle;
            borderRect.Y += (int)Math.Ceiling(sizeF.Height) / 2;
            borderRect.Height -= (int)Math.Ceiling(sizeF.Height) / 2;
            ControlPaint.DrawBorder(e.Graphics, borderRect, _borderColor, ButtonBorderStyle.Solid);
            var textRect = ClientRectangle;
            textRect.X += 6;
            textRect.Width = (int)Math.Ceiling(sizeF.Width);
            textRect.Height = (int)Math.Ceiling(sizeF.Height);
            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRect);
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRect);
        }
    }
}
