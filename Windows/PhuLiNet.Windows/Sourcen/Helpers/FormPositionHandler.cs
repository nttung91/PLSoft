using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Technical.Settings;
using Technical.Settings.Contracts;

namespace Windows.Core.Helpers
{
    internal class FormPositionHandler
    {
        private const int ScreenBorderDistance = 100;

        private readonly Form _form;
        private bool _rememberPosition = true;

        public bool RememberPosition
        {
            get { return _rememberPosition; }
            set { _rememberPosition = value; }
        }

        internal FormPositionHandler(Form form)
        {
            _form = form;
        }

        private string GetFormId()
        {
            return _form.GetType().FullName;
        }

        /// <summary>
        /// Schreibt die Position und Grösse des Forms
        /// </summary>
        public void SavePosition()
        {
            if (_rememberPosition &&
                ((_form.Modal && _form.WindowState != FormWindowState.Maximized) ||
                 (_form.IsMdiContainer && _form.WindowState != FormWindowState.Maximized)))
            {
                SavePosition(GetFormId(), new Rectangle(_form.Location, _form.Size));
            }
            else
            {
                DeletePosition(GetFormId());
            }
        }

        private Rectangle LoadPosition()
        {
            var formArea = new Rectangle();

            if (_rememberPosition)
            {
                formArea = ReadPosition(GetFormId());
            }

            return formArea;
        }

        private void DeletePosition(string formName)
        {
            var settingsProvider = Provider.Get();
            if (settingsProvider != null)
            {
                var section = settingsProvider.LoadSingleSetting("WindowPositions", formName);

                if (section.ContainsSetting(formName))
                {
                    section.GetSetting<string>(formName).Value = null;
                    settingsProvider.SaveSection(section);
                }
            }
        }

        private void SavePosition(string formName, Rectangle formArea)
        {
            var value = new StringBuilder();
            value.Append(formArea.Location.X.ToString(CultureInfo.InvariantCulture));
            value.Append(";");
            value.Append(formArea.Location.Y.ToString(CultureInfo.InvariantCulture));
            value.Append(";");
            value.Append(formArea.Size.Width.ToString(CultureInfo.InvariantCulture));
            value.Append(";");
            value.Append(formArea.Size.Height.ToString(CultureInfo.InvariantCulture));

            var settingsProvider = Provider.Get();
            if (settingsProvider != null)
            {
                var section = settingsProvider.LoadSingleSetting("WindowPositions", formName);

                if (!section.ContainsSetting(formName))
                {
                    var sectionAdmin = section as IConfigSectionAdmin;
                    if (sectionAdmin != null) sectionAdmin.AddSetting<string>(formName, null);
                }
                section.GetSetting<string>(formName).Value = value.ToString();
                settingsProvider.SaveSection(section);
            }
        }

        private Rectangle ReadPosition(string formName)
        {
            var formArea = new Rectangle();

            var settingsProvider = Provider.Get();
            if (settingsProvider != null)
            {
                var section = settingsProvider.LoadSingleSetting("WindowPositions", formName);

                if (section.ContainsSetting(formName))
                {
                    object value = section.GetSetting<string>(formName).Value;
                    if (value != null)
                    {
                        string[] vals = value.ToString().Split(';');
                        var p = new Point(Convert.ToInt32(vals[0]), Convert.ToInt32(vals[1]));
                        formArea.Location = p;

                        var s = new Size(Convert.ToInt32(vals[2]), Convert.ToInt32(vals[3]));
                        formArea.Size = s;
                    }
                }
            }

            return formArea;
        }

        public void SetPositionToCursor()
        {
            _form.Location = Cursor.Position;
        }

        public void SetPositionToMidCursor()
        {
            int halfWith = _form.Width/2;
            int halfHeight = _form.Height/2;

            _form.Location = new Point(Cursor.Position.X - halfWith, Cursor.Position.Y - halfHeight);
        }

        private void SetDialogPosition()
        {
            Rectangle formArea = LoadPosition();

            if (!formArea.IsEmpty)
            {
                _form.Location = formArea.Location;
                _form.Size = formArea.Size;

                if (IsOutOfScreen())
                {
                    SetDialogPositionToCursor();
                }
            }
            else
            {
                SetDialogPositionToCursor();
            }
        }

        private void SetDialogPositionToCursor()
        {
            SetPositionToMidCursor();

            if (IsOutOfScreen())
            {
                MoveIntoScreen();
            }
            else
            {
                ApplyScreenBorderDistance();
            }
        }

        private void SetMdiChildPosition()
        {
            _form.WindowState = FormWindowState.Maximized;
        }

        private void SetMdiContainerPosition()
        {
            Rectangle formArea = LoadPosition();

            if (!formArea.IsEmpty)
            {
                _form.Location = formArea.Location;
                _form.Size = formArea.Size;

                if (IsOutOfScreen())
                {
                    MoveIntoScreen();
                }
            }
            else
            {
                _form.WindowState = FormWindowState.Maximized;
            }
        }

        public void SetDefaultPosition()
        {
            if (_form.IsMdiContainer)
            {
                SetMdiContainerPosition();
            }
            else if (_form.IsMdiChild)
            {
                SetMdiChildPosition();
            }
            else if (_form.Modal)
            {
                SetDialogPosition();
            }
            else if (!_form.IsMdiChild && _form.Owner != null)
            {
                SetDialogPosition();
            }
            else if (!_form.IsMdiChild &&
                     (_form.FormBorderStyle == FormBorderStyle.FixedToolWindow ||
                      _form.FormBorderStyle == FormBorderStyle.SizableToolWindow))
            {
                SetDialogPosition();
            }
        }

        public bool IsOutOfScreen()
        {
            bool outOfScreen = false;

            Screen screen = Screen.FromPoint(_form.Location);

            if (screen != null)
            {
                outOfScreen = IsOutOfScreen(new Rectangle(_form.Location, _form.Size), screen);
            }

            return outOfScreen;
        }

        public void MoveIntoScreen()
        {
            if (IsOutOfScreen())
            {
                Screen screen = Screen.FromPoint(_form.Location);

                if (screen != null)
                {
                    Rectangle newPosition = GetNewPosition(screen, new Rectangle(_form.Location, _form.Size));
                    _form.Location = newPosition.Location;
                    _form.Size = newPosition.Size;
                }
            }
        }

        private void ApplyScreenBorderDistance()
        {
            Screen screen = Screen.FromPoint(_form.Location);

            if (screen != null)
            {
                Rectangle newPosition = GetNewPositionWithScreenBorderDistance(screen,
                    new Rectangle(_form.Location, _form.Size));
                _form.Location = newPosition.Location;
                _form.Size = newPosition.Size;
            }
        }

        private Rectangle GetNewPosition(Screen screen, Rectangle formArea)
        {
            var newPosition = new Rectangle(formArea.X, formArea.Y, formArea.Width, formArea.Height);
            Rectangle intersection = Rectangle.Intersect(formArea, screen.Bounds);

            if (intersection.Width != 0 && intersection.Height != 0)
            {
                newPosition = new Rectangle(formArea.X + (formArea.Width - intersection.Width),
                    formArea.Y + (formArea.Height - intersection.Height),
                    formArea.Width,
                    formArea.Height);
            }

            if (newPosition.X > screen.Bounds.Width)
            {
                newPosition.X = screen.Bounds.Width - formArea.Width;
            }
            else if (newPosition.X < 0)
            {
                newPosition.X = ScreenBorderDistance;
            }

            if (newPosition.Y > screen.Bounds.Height)
            {
                newPosition.Y = screen.Bounds.Height - formArea.Height;
            }
            else if (newPosition.Y < 0)
            {
                newPosition.Y = ScreenBorderDistance;
            }

            newPosition = GetNewPositionWithScreenBorderDistance(screen, newPosition);

            return newPosition;
        }

        private Rectangle GetNewPositionWithScreenBorderDistance(Screen screen, Rectangle position)
        {
            var newPosition = new Rectangle(position.Location, position.Size);

            if (newPosition.X + newPosition.Width + ScreenBorderDistance > screen.Bounds.Width)
                newPosition.X = screen.Bounds.Width - newPosition.Width - ScreenBorderDistance;

            if (newPosition.Y + newPosition.Height + ScreenBorderDistance > screen.Bounds.Height)
                newPosition.Y = screen.Bounds.Height - newPosition.Height - ScreenBorderDistance;

            if (newPosition.X < ScreenBorderDistance) newPosition.X = ScreenBorderDistance;
            if (newPosition.Y < ScreenBorderDistance) newPosition.Y = ScreenBorderDistance;

            if (newPosition.Width > screen.Bounds.Width)
                newPosition.Width = screen.Bounds.Width - (ScreenBorderDistance*2);

            if (newPosition.Height > screen.Bounds.Height)
                newPosition.Height = screen.Bounds.Height - (ScreenBorderDistance*2);

            return newPosition;
        }

        private bool IsOutOfScreen(Rectangle formArea, Screen screen)
        {
            Debug.Assert(formArea != null, "formArea is null");
            Debug.Assert(screen != null, "screen is null");

            bool outOfScreen = false;

            Rectangle intersection = Rectangle.Intersect(formArea, screen.Bounds);

            if (intersection != formArea)
            {
                outOfScreen = true;
            }

            return outOfScreen;
        }
    }
}