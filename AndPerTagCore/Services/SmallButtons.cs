using System;
using System.Drawing;
using System.Windows.Forms;

namespace AndPerTagCore.Services
{
    public static class SmallButtons
    {
        #region CONSTANTS
        private const string pathDeleteIcon = "Assets\\Images\\delete.png";
        private const string pathEditIcon = "Assets\\Images\\edit.png";

        private const string deleteColor = "#ff3e30";
        private const string editColor = "#7afffb";
        private const int smallButtonSize = 40;

        #endregion CONSTANTS

        /// <summary>
        /// Generates a small button with the edit aspect.
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        public static Button GetEditButton(string name, string tag, int top, int left)
        {
            return GetSmallButton(true, name, tag, top, left);
        }

        /// <summary>
        /// Generates a small button with the delete aspect.
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        public static Button GetDeleteButton(string name, string tag, int top, int left)
        {
            return GetSmallButton(false, name, tag, top, left + smallButtonSize);
        }

        /// <summary>
        /// Generates a small button.
        /// </summary>
        /// <param name="isEdit"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        private static Button GetSmallButton(bool isEdit, string name, string tag, int top, int left)
        {
            string iconPath = isEdit ? pathEditIcon : pathDeleteIcon;
            iconPath = $"{AppDomain.CurrentDomain.BaseDirectory}{iconPath}";
            Button button = new Button
            {
                Top = top,
                Left = left,
                Name = name,
                Tag = tag,
                BackColor = ColorTranslator.FromHtml(isEdit ? editColor : deleteColor),
                Size = new Size(smallButtonSize, smallButtonSize),
                FlatStyle = FlatStyle.Flat,
                Image = Image.FromFile(iconPath),
                ImageAlign = ContentAlignment.MiddleCenter,
            };
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.Black;
            return button;
        }
    }
}