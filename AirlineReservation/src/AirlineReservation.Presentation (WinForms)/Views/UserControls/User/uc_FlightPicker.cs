using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.UserControls.User
{
    public partial class uc_FlightPicker : UserControl
    {
        private TextBox _active;
        private ToolStripDropDown _dropdown;
        private ToolStripControlHost _host;
        private Guna2DataGridView _grid;
        private System.Windows.Forms.Timer _debounce = new System.Windows.Forms.Timer { Interval = 150 };

        //public List<Airport> Airports { get; set; } = new(); // set từ ngoài

        //public event EventHandler<Airport> OriginSelected;
        //public event EventHandler<Airport> DestinationSelected;

        public uc_FlightPicker()
        {
            InitializeComponent();

            // events focus
            txtFrom.Enter += (s, e) => ShowSuggest((TextBox)s);
            txtTo.Enter += (s, e) => ShowSuggest((TextBox)s);

            txtFrom.TextChanged += (_, __) => Debounce();
            txtTo.TextChanged += (_, __) => Debounce();

            txtFrom.KeyDown += TextBox_KeyDown;
            txtTo.KeyDown += TextBox_KeyDown;

            btnSwap.Click += (_, __) => { (txtFrom.Text, txtTo.Text) = (txtTo.Text, txtFrom.Text); };

            BuildPopup();
        }

        private void BuildPopup()
        {
            _grid = new Guna2DataGridView
            {
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                ColumnHeadersVisible = false,
                MultiSelect = false,
                ScrollBars = ScrollBars.Vertical,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                EnableHeadersVisualStyles = false
            };
            // 1 cột giả (ta tự vẽ 2 dòng)
            _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "col", DataPropertyName = "Name" });

            // style tổng thể
            _grid.DefaultCellStyle.Padding = new Padding(14, 8, 14, 8);
            _grid.RowTemplate.Height = 58;
            _grid.CellPainting += Grid_CellPainting;
            _grid.CellDoubleClick += (_, __) => CommitSelection();
            _grid.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { CommitSelection(); e.Handled = true; } };

            _host = new ToolStripControlHost(_grid) { AutoSize = false, Margin = Padding.Empty, Padding = Padding.Empty };
            _dropdown = new ToolStripDropDown { AutoClose = true, Padding = Padding.Empty };
            _dropdown.Items.Add(_host);

            _debounce = new System.Windows.Forms.Timer { Interval = 150 };
            _debounce.Tick += (_, __) => { _debounce.Stop(); ApplyFilter(); };
        }

        private void ShowSuggest(TextBox tb)
        {
            _active = tb;
            // popup rộng bằng cả 2 textbox + nút swap
            int left = txtFrom.Left;
            int width = txtTo.Right - txtFrom.Left; // gồm cả btnSwap ở giữa
            int top = Math.Max(txtFrom.Bottom, txtTo.Bottom) + 6;

            var screen = this.PointToScreen(new Point(left, top));
            var size = new Size(width, 320);

            _host.Size = size;
            _grid.Size = size;

            ApplyFilter(); // fill lần đầu
            _dropdown.Show(screen);
            _grid.Focus();
            if (_grid.Rows.Count > 0) _grid.Rows[0].Selected = true;
        }

        private void Debounce()
        {
            if (_active == null) return;
            _debounce.Stop(); _debounce.Start();
        }

        private void ApplyFilter()
        {
            //if (_active == null) return;
            //string q = (_active.Text ?? "").Trim().ToLowerInvariant();

            //var filtered = Airports.Where(a => a.SearchKey.Contains(q)).Take(200).ToList();

            //_grid.SuspendLayout();
            //_grid.Rows.Clear();
            //foreach (var a in filtered)
            //    _grid.Rows.Add(a.Name); // data thật giữ riêng, ta vẽ bằng CellPainting

            //_grid.Tag = filtered; // nhét list vào Tag để CellPainting/Commit đọc
            //_grid.ResumeLayout();

            //if (filtered.Count == 0) _dropdown.Close();
        }

        private void CommitSelection()
        {
            //if (_grid.CurrentCell == null) return;
            //var data = _grid.Tag as List<Airport>;
            //if (data == null || _grid.CurrentCell.RowIndex < 0 || _grid.CurrentCell.RowIndex >= data.Count) return;

            //var a = data[_grid.CurrentCell.RowIndex];
            //_active.Text = $"{a.City} ({a.Code})";
            //_dropdown.Close();

            //if (_active == txtFrom) OriginSelected?.Invoke(this, a);
            //else DestinationSelected?.Invoke(this, a);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_dropdown.Visible)
            {
                if (e.KeyCode == Keys.Down) { _grid.Focus(); e.Handled = true; }
                else if (e.KeyCode == Keys.Escape) { _dropdown.Close(); e.Handled = true; }
            }
        }

        // —— Vẽ 2 dòng trong 1 cell (đẹp như mock) ——
        private void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex != 0) return;

            //e.Handled = true;

            //var data = (List<Airport>)_grid.Tag;
            //var a = data[e.RowIndex];

            //// nền
            //Color back = (e.State & DataGridViewElementStates.Selected) != 0
            //    ? Color.FromArgb(235, 245, 255)
            //    : Color.White;
            //using (var b = new SolidBrush(back)) e.Graphics.FillRectangle(b, e.CellBounds);

            //// gạch phân cách
            //using (var pen = new Pen(Color.FromArgb(235, 235, 235)))
            //    e.Graphics.DrawLine(pen, e.CellBounds.Left + 14, e.CellBounds.Bottom - 1, e.CellBounds.Right - 14, e.CellBounds.Bottom - 1);

            //// text
            //var rect = e.CellBounds; rect.Inflate(-14, -8);
            //// dòng 1: Name (đậm) + Code (căn phải)
            //using var fontName = new Font(e.CellStyle.Font, FontStyle.SemiBold);
            //using var fontCode = new Font(e.CellStyle.Font, FontStyle.Regular);
            //using var fontSub = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size - 1);
            //using var brMain = new SolidBrush(Color.Black);
            //using var brCode = new SolidBrush(Color.FromArgb(120, 0, 0, 0));
            //using var brSub = new SolidBrush(Color.FromArgb(140, 0, 0, 0));

            //string leftText = a.Name;
            //string rightCode = a.Code;
            //var szCode = e.Graphics.MeasureString(rightCode, fontCode);

            //// Name (trái)
            //var nameRect = new Rectangle(rect.Left, rect.Top, rect.Width - (int)szCode.Width - 16, (int)(rect.Height * 0.55));
            //e.Graphics.DrawString(leftText, fontName, brMain, nameRect, new StringFormat { Trimming = StringTrimming.EllipsisCharacter });

            //// Code (phải)
            //var codeRect = new Rectangle(rect.Right - (int)szCode.Width - 2, rect.Top, (int)szCode.Width + 2, nameRect.Height);
            //e.Graphics.DrawString(rightCode, fontCode, brCode, codeRect, new StringFormat { Alignment = StringAlignment.Near });

            //// dòng 2: City, Country (xám)
            //var subRect = new Rectangle(rect.Left, rect.Top + nameRect.Height - 2, rect.Width, rect.Height - nameRect.Height + 2);
            //e.Graphics.DrawString($"{a.City}, {a.Country}", fontSub, brSub, subRect,
            //    new StringFormat { Trimming = StringTrimming.EllipsisCharacter });
        }
    }
}
