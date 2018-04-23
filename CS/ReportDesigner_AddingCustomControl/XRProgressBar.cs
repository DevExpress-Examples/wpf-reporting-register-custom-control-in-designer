using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace ReportDesigner_AddingCustomControl {
    [ToolboxItem(true)]
    public class XRProgressBar : XRControl {
        private float pos = 0;
        private float maxVal = 100;

        [DefaultValue(100), XtraSerializableProperty]
        public float MaxValue {
            get { return this.maxVal; }
            set {
                if (value <= 0)
                    return;
                this.maxVal = value;
            }
        }

        [DefaultValue(0), Bindable(true), XtraSerializableProperty]
        public float Position {
            get { return this.pos; }
            set {
                if (value < 0 || value > maxVal)
                    return;
                this.pos = value;
            }
        }
        [Browsable(false)]
        public override string Text {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public XRProgressBar() {
            this.ForeColor = SystemColors.Highlight;
        }

        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks) {
            return new PanelBrick(this);
        }

        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps) {
            base.PutStateToBrick(brick, ps);
            PanelBrick panel = (PanelBrick)brick;
            VisualBrick progressBar = new VisualBrick(this);
            progressBar.Sides = BorderSide.None;
            progressBar.BackColor = panel.Style.ForeColor;
            progressBar.Rect = new RectangleF(0, 0, panel.Rect.Width * (Position / MaxValue),
                panel.Rect.Height);
            panel.Bricks.Add(progressBar);
        }
    }
}
