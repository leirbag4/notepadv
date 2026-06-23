using System.ComponentModel;
using Notepadv.UI.Controls.ScrollBarAdvance;

namespace Notepadv.UI.Controls
{
    public class ScrollBarAdv : Control
    {
        #region VisualProperties
        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Arrow Color")]
        [Browsable(true)]
        public Color ArrowColor { get; set; } = CColor(200);

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Normal Color")]
        [Browsable(true)]
        public Color ThumbNormalColor { get { return thumbColors.NormalColor; } set { thumbColors.NormalColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Over Color")]
        [Browsable(true)]
        public Color ThumbOverColor { get { return thumbColors.OverColor; } set { thumbColors.OverColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Down Color")]
        [Browsable(true)]
        public Color ThumbDownColor { get { return thumbColors.DownColor; } set { thumbColors.DownColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Normal Color")]
        [Browsable(true)]
        public Color ButtonNormalColor { get { return buttonColors.NormalColor; } set { buttonColors.NormalColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Over Color")]
        [Browsable(true)]
        public Color ButtonOverColor { get { return buttonColors.OverColor; } set { buttonColors.OverColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Down Color")]
        [Browsable(true)]
        public Color ButtonDownColor { get { return buttonColors.DownColor; } set { buttonColors.DownColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Track Over to Button Color")]
        [Browsable(true)]
        public Color TrackOverToButtonColor { get { return buttonColors.ExtraColor; } set { buttonColors.ExtraColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Track Normal Color")]
        [Browsable(true)]
        public Color TrackNormalColor { get { return trackColors.NormalColor; } set { trackColors.NormalColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Track Over Color")]
        [Browsable(true)]
        public Color TrackOverColor { get { return trackColors.OverColor; } set { trackColors.OverColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Track Down Color")]
        [Browsable(true)]
        public Color TrackDownColor { get { return trackColors.DownColor; } set { trackColors.DownColor = value; } }
        #endregion

        #region CustomProperties
        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Orientation")]
        [Browsable(true)]
        public ScrollBarOrientation Orientation { get; set; } = ScrollBarOrientation.Vertical;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Minimum Thumb Size")]
        [Browsable(true)]
        public int MinThumbSize { get; set; } = 10;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Size")]
        [Browsable(true)]
        public int ButtonSize { get; set; } = 20;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Padding X")]
        [Browsable(true)]
        public int ThumbPaddingX { get { return thumb.paddingX; } set { thumb.paddingX = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Padding Y")]
        [Browsable(true)]
        public int ThumbPaddingY { get { return thumb.paddingY; } set { thumb.paddingY = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Allow Mouse Scrolling")]
        [Browsable(true)]
        public bool AllowMouseScrolling { get; set; } = true;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Minimum")]
        [Browsable(true)]
        public int Minimum { get { return minimum; } set { minimum = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Maximum")]
        [Browsable(true)]
        public int Maximum { get { return maximum; } set { maximum = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Small Change")]
        [Browsable(true)]
        public int SmallChange { get { return smallChange; } set { smallChange = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Large Change")]
        [Browsable(true)]
        public int LargeChange { get { return largeChange; } set { largeChange = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Value")]
        [Browsable(true)]
        public int Value { get { return _value; } set { int val = value; if (val < minimum) val = minimum; else if (val > (maximum - largeChange + 1)) val = (maximum - largeChange + 1); if (val == _value) return; SetValue((float)val); Invalidate(); } }
        #endregion

        #region Events
        [Localizable(true)]
        [Category("Extra Events")]
        [Description("Scroll Event")]
        [Browsable(true)]
        public event ScrollEvent Scroll;
        #endregion

        #region FieldsAndProps
        private int MaximumValue { get { return maximum - largeChange + 1; } }
        private int MaxRangeValue { get { return MaximumValue - minimum; } }

        private ColorState buttonColors = new ColorState(CColor(70), CColor(100), CColor(75), CColor(85));
        private ColorState trackColors = new ColorState(CColor(50), CColor(53), CColor(60));
        private ColorState thumbColors = new ColorState(CColor(130), CColor(120), CColor(100));
        private Bitmap arrowUp, arrowDown, arrowLeft, arrowRight;

        private ScrollBarElement upButton;
        private ScrollBarElement downButton;
        private ScrollBarElement thumb;
        private ScrollBarElement track;
        private ScrollBarElement upTrack;
        private ScrollBarElement downTrack;

        private ScrollBarElement leftButton;
        private ScrollBarElement rightButton;
        private ScrollBarElement leftTrack;
        private ScrollBarElement rightTrack;
        private ScrollBarElement buttonA;
        private ScrollBarElement buttonB;
        private ScrollBarElement trackA;
        private ScrollBarElement trackB;

        private ScrollBarElement[] elements;
        private int minimum = 0;
        private int maximum = 100;
        private int smallChange = 1;
        private int largeChange = 10;
        private int _value = 0;

        private int mouseX = 0;
        private int mouseY = 0;

        private bool _dragging = false;
        private int _dragPos = 0;
        private int _thumbStartPos = 0;
        private float floatPos = 0.0f;

        private System.Windows.Forms.Timer timer;
        private bool timerSmallStepActive = false;

        private const int TimerStartMillis = 500;
        private const int TimerStepMillis = 60;
        private const int TimerSmallStepMillis = 20;
        #endregion

        public ScrollBarAdv()
        {
            DoubleBuffered = true;

            CreateArrows();

            timer = new System.Windows.Forms.Timer();
            timer.Tick += OnTimerTick;
            timer.Interval = TimerStartMillis;

            upButton = new ScrollBarElement(buttonColors);
            downButton = new ScrollBarElement(buttonColors);
            thumb = new ScrollBarElement(thumbColors);
            track = new ScrollBarElement(trackColors);
            upTrack = new ScrollBarElement(trackColors);
            downTrack = new ScrollBarElement(trackColors);

            elements = new ScrollBarElement[] { upButton, downButton, thumb, upTrack, downTrack };

            leftButton = upButton;
            rightButton = downButton;
            leftTrack = upTrack;
            rightTrack = downTrack;
            buttonA = upButton;
            buttonB = downButton;
            trackA = upTrack;
            trackB = downTrack;

            Size = new Size(20, 100);
        }

        private void CreateArrows()
        {
            arrowUp = ScrollBarUtils.CreateUpArrow(11, 6, ArrowColor);

            Bitmap arrow = (Bitmap)arrowUp.Clone();

            arrow.RotateFlip(RotateFlipType.Rotate180FlipNone);
            arrowDown = new Bitmap(arrow);

            arrow.RotateFlip(RotateFlipType.Rotate90FlipNone);
            arrowLeft = new Bitmap(arrow);

            arrow.RotateFlip(RotateFlipType.Rotate180FlipNone);
            arrowRight = new Bitmap(arrow);
        }

        private static Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        private static Color CColor(int color)
        {
            return Color.FromArgb(color, color, color);
        }

        #region ExternalEvents
        protected override void OnMouseMove(MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            if (_dragging)
            {
                OnDragging(Orientation == ScrollBarOrientation.Horizontal ? mouseX : mouseY);
                Invalidate();
                return;
            }

            if (IsAnySelected())
                return;

            foreach (var elem in elements)
            {
                elem.MouseMove(mouseX, mouseY, e.Button == MouseButtons.Left);
            }

            if (trackA.IsOver || trackB.IsOver || thumb.IsOver)
            {
                buttonA.ExtraState = true;
                buttonB.ExtraState = true;
            }
            else
            {
                buttonA.ExtraState = false;
                buttonB.ExtraState = false;
            }

            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (IsAnySelected())
                return;

            foreach (var elem in elements)
            {
                elem.MouseLeave();
            }

            leftButton.ExtraState = false;
            rightButton.ExtraState = false;

            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            if (IsAnySelected())
                return;

            foreach (var elem in elements)
            {
                elem.MouseDown(mouseX, mouseY, e.Button == MouseButtons.Left);

                if (elem.Selected)
                {
                    if (elem == thumb)
                        StartDrag(Orientation == ScrollBarOrientation.Horizontal ? mouseX : mouseY);
                    else if ((elem == buttonA) || (elem == buttonB))
                        OnButtonDown();
                    else if ((elem == trackA) || (elem == trackB))
                        OnTrackDown();

                    break;
                }
            }

            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            if (_dragging)
                StopDrag(Orientation == ScrollBarOrientation.Horizontal ? mouseX : mouseY);

            foreach (var elem in elements)
            {
                if (elem.Selected)
                {
                    if (elem == buttonA)
                        OnButtonUp();
                    else if (elem == buttonB)
                        OnButtonUp();
                    else if ((elem == trackA) || (elem == trackB))
                        OnTrackUp();

                    elem.ResetSelection();
                }
            }

            foreach (var elem in elements)
            {
                elem.MouseUp(mouseX, mouseY);
            }

            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!AllowMouseScrolling)
                return;

            if (e.Delta < 0)
                SmallIncrement();
            else if (e.Delta > 0)
                SmallDecrement();

            base.OnMouseWheel(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RefreshAll();
        }
        #endregion

        private void SmallDecrement()
        {
            SetValue(_value - smallChange);
            Invalidate();
        }

        private void SmallIncrement()
        {
            SetValue(_value + smallChange);
            Invalidate();
        }

        private void LargeDecrement()
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {
                if (thumb.y < mouseY)
                {
                    timerSmallStepActive = true;
                    timer.Interval = TimerSmallStepMillis;
                    return;
                }
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                if (thumb.x < mouseX)
                {
                    timerSmallStepActive = true;
                    timer.Interval = TimerSmallStepMillis;
                    return;
                }
            }

            SetValue(_value - largeChange);
            Invalidate();
        }

        private void LargeIncrement()
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {
                if (thumb.bottom > mouseY)
                {
                    timerSmallStepActive = true;
                    timer.Interval = TimerSmallStepMillis;
                    return;
                }
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                if (thumb.right > mouseX)
                {
                    timerSmallStepActive = true;
                    timer.Interval = TimerSmallStepMillis;
                    return;
                }
            }

            SetValue(_value + largeChange);
            Invalidate();
        }

        private void TimerStart()
        {
            timerSmallStepActive = false;
            timer.Interval = TimerStartMillis;
            timer.Start();
        }

        private void TimerStop()
        {
            timer.Stop();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (timerSmallStepActive)
                timer.Interval = TimerSmallStepMillis;
            else
                timer.Interval = TimerStepMillis;

            if (buttonA.Selected)
                SmallDecrement();
            else if (buttonB.Selected)
                SmallIncrement();
            else if (trackA.Selected)
                LargeDecrement();
            else if (trackB.Selected)
                LargeIncrement();
        }

        private void OnButtonDown()
        {
            if (buttonA.Selected)
                SmallDecrement();
            else if (buttonB.Selected)
                SmallIncrement();

            TimerStart();
        }

        private void OnButtonUp()
        {
            TimerStop();
        }

        private void OnTrackDown()
        {
            if (trackA.Selected)
                LargeDecrement();
            else if (trackB.Selected)
                LargeIncrement();

            TimerStart();
        }

        private void OnTrackUp()
        {
            TimerStop();
        }

        private void OnDragging(int pos)
        {
            int freeTrack = 0;
            int maxRangeVal = 0;
            int currPos = 0;

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                thumb.y = _thumbStartPos + (pos - _dragPos);

                if (thumb.y < upButton.height)
                    thumb.y = upButton.height;
                else if (thumb.bottom > downButton.y)
                    thumb.bottom = downButton.y;

                freeTrack = track.height - thumb.height;
                maxRangeVal = MaxRangeValue;
                currPos = thumb.y - upButton.height;
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                thumb.x = _thumbStartPos + (pos - _dragPos);

                if (thumb.x < leftButton.width)
                    thumb.x = leftButton.width;
                else if (thumb.right > rightButton.x)
                    thumb.right = rightButton.x;

                freeTrack = track.width - thumb.width;
                maxRangeVal = MaxRangeValue;
                currPos = thumb.x - leftButton.width;
            }

            floatPos = ((float)maxRangeVal / freeTrack) * currPos;
            floatPos += minimum;
            int newVal = (int)Math.Round(floatPos);

            if (newVal < 0)
            {
                floatPos = minimum;
                newVal = minimum;
            }

            SetValueOnly(newVal);
        }

        private void StartDrag(int pos)
        {
            if (Orientation == ScrollBarOrientation.Vertical)
                _thumbStartPos = thumb.y;
            else if (Orientation == ScrollBarOrientation.Horizontal)
                _thumbStartPos = thumb.x;

            _dragPos = pos;
            _dragging = true;
        }

        private void StopDrag(int pos)
        {
            _dragPos = pos;
            _dragging = false;
            ReleaseAndClamp();
        }

        private void ReleaseAndClamp()
        {
            if (_value == minimum)
                SetValue(minimum);
            else if (_value == MaximumValue)
                SetValue(MaximumValue);
        }

        private bool IsAnySelected()
        {
            foreach (var elem in elements)
            {
                if (elem.Selected)
                    return true;
            }
            return false;
        }

        private void SetValue(float newValue)
        {
            if (newValue < minimum)
                newValue = minimum;
            else if (newValue > MaximumValue)
                newValue = MaximumValue;

            floatPos = newValue;
            newValue -= minimum;

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                int freeTrack = track.height - thumb.height;
                int maxRangeVal = MaxRangeValue;
                int currPos = (int)(newValue / (((float)maxRangeVal / freeTrack)));

                thumb.x = 0;
                thumb.y = currPos + upButton.height;

                if (thumb.height > track.height)
                {
                    thumb.height = track.height;
                    thumb.y = upButton.bottom;
                }
                else if (thumb.y < upButton.bottom)
                {
                    thumb.y = upButton.bottom;
                    floatPos = minimum;
                    SetValueOnly((int)floatPos);
                }
                else if (thumb.bottom > downButton.y)
                {
                    thumb.bottom = downButton.y;
                    floatPos = MaximumValue;
                    SetValueOnly((int)floatPos);
                }
                else
                    SetValueOnly((int)floatPos);
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                int freeTrack = track.width - thumb.width;
                int maxRangeVal = MaxRangeValue;
                int currPos = (int)((float)newValue / (((float)maxRangeVal / freeTrack)));

                thumb.x = currPos + leftButton.width;
                thumb.y = 0;

                if (thumb.width > track.width)
                {
                    thumb.width = track.width;
                    thumb.x = leftButton.right;
                }
                else if (thumb.x < leftButton.right)
                {
                    thumb.x = leftButton.right;
                    floatPos = minimum;
                    SetValueOnly((int)floatPos);
                }
                else if (thumb.right > rightButton.x)
                {
                    thumb.right = rightButton.x;
                    floatPos = MaximumValue;
                    SetValueOnly((int)floatPos);
                }
                else
                    SetValueOnly((int)floatPos);
            }
        }

        private void SetValueOnly(int newValue)
        {
            int oldValue = _value;
            _value = newValue;

            if ((Scroll != null) && (oldValue != _value))
                Scroll(oldValue, newValue);

            RefreshSplittedTracks();
        }

        private int CalcThumbSize()
        {
            int thumbSize = 0;

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                thumbSize = (int)((largeChange / (float)(maximum - minimum + 1)) * track.height);
                if (thumbSize > track.height)
                    thumbSize = track.height;
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                thumbSize = (int)((largeChange / (float)(maximum - minimum + 1)) * track.width);
                if (thumbSize > track.width)
                    thumbSize = track.width;
            }

            if (thumbSize < MinThumbSize)
                thumbSize = MinThumbSize;

            return thumbSize;
        }

        private void RefreshButtonsAndTrack()
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {
                upButton.SetSize(Width, ButtonSize);
                downButton.SetSize(Width, ButtonSize);

                upButton.SetPos(0, 0);
                downButton.SetPos(0, Height - downButton.height);

                track.SetPos(0, upButton.height);
                track.SetSize(Width, Height - (upButton.height + downButton.height));
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                leftButton.SetSize(ButtonSize, Height);
                rightButton.SetSize(ButtonSize, Height);

                leftButton.SetPos(0, 0);
                rightButton.SetPos(Width - rightButton.width, 0);

                track.SetPos(leftButton.width, 0);
                track.SetSize(Width - (leftButton.width + rightButton.width), Height);
            }
        }

        private void RefreshThumbSize()
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {
                thumb.width = Width;
                thumb.height = CalcThumbSize();
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                thumb.height = Height;
                thumb.width = CalcThumbSize();
            }
        }

        private void RefreshSplittedTracks()
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {
                upTrack.SetPos(0, upButton.bottom);
                upTrack.SetSize(Width, thumb.y - upButton.bottom);

                downTrack.SetPos(0, thumb.bottom);
                downTrack.SetSize(Width, downButton.y - thumb.bottom);
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                leftTrack.SetPos(leftButton.right, 0);
                leftTrack.SetSize(thumb.x - leftButton.right, Height);

                rightTrack.SetPos(thumb.right, 0);
                rightTrack.SetSize(rightButton.x - thumb.right, Height);
            }
        }

        public void RefreshAll()
        {
            RefreshButtonsAndTrack();
            RefreshThumbSize();
            SetValue(floatPos);
            RefreshSplittedTracks();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var elem in elements)
            {
                if (elem != thumb)
                    elem.Paint(g);
            }

            thumb.Paint(g);

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                upButton.PaintCenteredImage(g, arrowUp);
                downButton.PaintCenteredImage(g, arrowDown);
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                upButton.PaintCenteredImage(g, arrowLeft);
                downButton.PaintCenteredImage(g, arrowRight);
            }
        }
    }
}
