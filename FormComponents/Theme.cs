using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentOwl.BetterListView;

namespace XBLMarketplace_For_PC.FormComponents
{
    /// <summary>
    /// Applies a flat, modern look (Segoe UI, Xbox green accent) to a form at runtime,
    /// so the designer files stay untouched.
    /// </summary>
    public static class Theme
    {
        public static readonly Color Accent = Color.FromArgb(16, 124, 16);
        public static readonly Color AccentHover = Color.FromArgb(14, 106, 14);
        public static readonly Color AccentPressed = Color.FromArgb(11, 86, 11);
        public static readonly Color Background = Color.FromArgb(240, 240, 240);
        public static readonly Color Surface = Color.White;
        public static readonly Color Border = Color.FromArgb(204, 204, 204);
        public static readonly Color HoverSurface = Color.FromArgb(229, 241, 229);
        public static readonly Color Text = Color.FromArgb(27, 27, 27);
        public static readonly Color MutedText = Color.FromArgb(96, 96, 96);
        public static readonly Color Track = Color.FromArgb(225, 225, 225);

        public static readonly Font BaseFont = new Font("Segoe UI", 9F);
        public static readonly Font HeaderFont = new Font("Segoe UI Semilight", 15F);
        public static readonly Font SubHeaderFont = new Font("Segoe UI", 8.25F);

        /// <summary>
        /// Styles the form and all of its child controls. Buttons listed in
        /// <paramref name="primaryButtons"/> get the filled accent style.
        /// </summary>
        public static void Apply(Form form, params Button[] primaryButtons)
        {
            var primary = new HashSet<Button>(primaryButtons);
            form.Font = BaseFont;
            form.BackColor = Background;
            form.ForeColor = Text;
            ApplyTo(form.Controls, primary);
        }

        /// <summary>
        /// Adds a slim branded header bar above the form's content.
        /// </summary>
        public static void AddHeader(Form form, string title, string subtitle)
        {
            const int height = 56;
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = height,
                BackColor = Accent,
                Padding = new Padding(16, 0, 16, 0)
            };
            header.Paint += (s, e) =>
            {
                var bounds = header.ClientRectangle;
                bounds.Inflate(-16, 0);
                var titleSize = TextRenderer.MeasureText(title, HeaderFont);
                TextRenderer.DrawText(e.Graphics, title, HeaderFont, bounds, Color.White,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
                var subBounds = new Rectangle(bounds.Left + titleSize.Width + 4, bounds.Top, bounds.Width - titleSize.Width - 4, bounds.Height);
                TextRenderer.DrawText(e.Graphics, subtitle, SubHeaderFont, subBounds, Color.FromArgb(200, 230, 200),
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis);
            };
            form.Controls.Add(header);
            form.ClientSize = new Size(form.ClientSize.Width, form.ClientSize.Height + height);
        }

        private static void ApplyTo(Control.ControlCollection controls, HashSet<Button> primary)
        {
            foreach (Control control in controls)
            {
                ApplyTo(control, primary);
                if (control.HasChildren) ApplyTo(control.Controls, primary);
            }
        }

        private static void ApplyTo(Control control, HashSet<Button> primary)
        {
            if (control is Button button) StyleButton(button, primary.Contains(button));
            else if (control is TabControl tabs) StyleTabs(tabs);
            else if (control is TabPage page)
            {
                page.UseVisualStyleBackColor = false;
                page.BackColor = Background;
                page.ForeColor = Text;
            }
            else if (control is GroupBox group)
            {
                group.ForeColor = Accent;
                group.BackColor = Background;
            }
            else if (control is RichTextBox rich)
            {
                rich.BorderStyle = BorderStyle.None;
                rich.BackColor = Surface;
                rich.ForeColor = Text;
            }
            else if (control is TextBox textBox)
            {
                textBox.ForeColor = Text;
                if (textBox.ReadOnly && !textBox.Multiline)
                {
                    // Read-only fields read as values, not inputs.
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.BackColor = EffectiveBackColor(control.Parent);
                }
                else
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Surface;
                }
            }
            else if (control is ComboBox combo)
            {
                combo.FlatStyle = FlatStyle.Flat;
                combo.BackColor = Surface;
                combo.ForeColor = Text;
            }
            else if (control is NumericUpDown numeric)
            {
                numeric.BorderStyle = BorderStyle.FixedSingle;
                numeric.BackColor = Surface;
                numeric.ForeColor = Text;
            }
            else if (control is StatusStrip strip)
            {
                strip.Renderer = new FlatStripRenderer();
                strip.BackColor = Background;
                strip.ForeColor = MutedText;
                strip.SizingGrip = false;
            }
            else if (control is BetterListView list)
            {
                list.BackColor = Surface;
                list.ForeColor = Text;
            }
            else if (control is Label label)
            {
                label.ForeColor = Text;
            }
            else if (control is TableLayoutPanel || control is Panel)
            {
                control.BackColor = Color.Transparent;
                control.ForeColor = Text;
            }
        }

        private static Color EffectiveBackColor(Control control)
        {
            for (var c = control; c != null; c = c.Parent)
            {
                if (c.BackColor.A == 255) return c.BackColor;
            }
            return Background;
        }

        private static void StyleButton(Button button, bool isPrimary)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 1;
            if (isPrimary)
            {
                button.BackColor = Accent;
                button.ForeColor = Color.White;
                button.FlatAppearance.BorderColor = Accent;
                button.FlatAppearance.MouseOverBackColor = AccentHover;
                button.FlatAppearance.MouseDownBackColor = AccentPressed;
            }
            else
            {
                button.BackColor = Surface;
                button.ForeColor = Text;
                button.FlatAppearance.BorderColor = Border;
                button.FlatAppearance.MouseOverBackColor = HoverSurface;
                button.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 228, 204);
            }
            ApplyEnabledLook(button, isPrimary);
            button.EnabledChanged += (s, e) => ApplyEnabledLook(button, isPrimary);
        }

        //Flat buttons keep their colors when disabled, so a disabled primary button still looked clickable
        private static void ApplyEnabledLook(Button button, bool isPrimary)
        {
            button.FlatAppearance.BorderColor = button.Enabled ? (isPrimary ? Accent : Border) : Track;
            if (isPrimary) button.BackColor = button.Enabled ? Accent : Track;
            button.Cursor = button.Enabled ? Cursors.Hand : Cursors.Default;
        }

        private static void StyleTabs(TabControl tabs)
        {
            tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabs.SizeMode = TabSizeMode.Fixed;
            tabs.ItemSize = new Size(130, 32);
            tabs.Padding = new Point(12, 4);
            tabs.DrawItem += DrawTab;
        }

        private static void DrawTab(object sender, DrawItemEventArgs e)
        {
            var tabs = (TabControl) sender;
            var page = tabs.TabPages[e.Index];
            bool selected = e.Index == tabs.SelectedIndex;
            var bounds = tabs.GetTabRect(e.Index);

            using (var back = new SolidBrush(selected ? Background : Color.FromArgb(230, 230, 230)))
            {
                e.Graphics.FillRectangle(back, bounds);
            }
            if (selected)
            {
                using (var bar = new SolidBrush(Accent))
                {
                    e.Graphics.FillRectangle(bar, bounds.Left, bounds.Bottom - 3, bounds.Width, 3);
                }
            }

            using (var font = new Font(tabs.Font, selected ? FontStyle.Bold : FontStyle.Regular))
            {
                TextRenderer.DrawText(e.Graphics, page.Text, font, bounds, selected ? Accent : MutedText,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
            }
        }

        /// <summary>
        /// Draws a flat progress bar with a centred percentage label.
        /// </summary>
        public static void DrawProgress(Graphics graphics, Rectangle bounds, int percent, Font font)
        {
            percent = Math.Max(0, Math.Min(100, percent));
            using (var track = new SolidBrush(Track))
            {
                graphics.FillRectangle(track, bounds);
            }
            int fillWidth = bounds.Width * percent / 100;
            if (fillWidth > 0)
            {
                using (var fill = new SolidBrush(Accent))
                {
                    graphics.FillRectangle(fill, bounds.Left, bounds.Top, fillWidth, bounds.Height);
                }
            }
            if (bounds.Height >= 12)
            {
                TextRenderer.DrawText(graphics, percent + "%", font, bounds, percent >= 50 ? Color.White : Text,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
            }
        }

        private class FlatStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                using (var back = new SolidBrush(e.ToolStrip.BackColor))
                {
                    e.Graphics.FillRectangle(back, e.AffectedBounds);
                }
                using (var line = new Pen(Border))
                {
                    e.Graphics.DrawLine(line, 0, 0, e.ToolStrip.Width, 0);
                }
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
            }
        }
    }
}
