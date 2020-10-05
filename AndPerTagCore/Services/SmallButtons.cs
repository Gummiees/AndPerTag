using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace AndPerTagCore.Services
{
    public static class SmallButtons
    {
        #region CONSTANTS

        public const string pathDeleteIcon = "Assets\\Images\\delete.png";
        public const string pathEditIcon = "Assets\\Images\\edit.png";

        private const string deleteColor = "#ff3e30";
        private const string editColor = "#7afffb";
        private const int smallButtonSize = 40;

        #endregion CONSTANTS

        /// <summary>
        /// Prints a small button with the edit aspect.
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="controls"></param>
        public static void PrintEditButton(int top, int left, ControlCollection controls)
        {
            PrintSmallButton(true, top, left, controls);
        }

        /// <summary>
        /// Prints a small button with the delete aspect.
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="controls"></param>
        public static void PrintDeleteButton(int top, int left, ControlCollection controls)
        {
            PrintSmallButton(false, top, left + smallButtonSize, controls);
        }

        /// <summary>
        /// Prints a small button.
        /// </summary>
        /// <param name="isEdit"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="controls"></param>
        public static void PrintSmallButton(bool isEdit, int top, int left, ControlCollection controls)
        {
            string iconPath = isEdit ? pathEditIcon : pathDeleteIcon;
            iconPath = $"{AppDomain.CurrentDomain.BaseDirectory}{iconPath}";
            Button button = new Button
            {
                Top = top,
                Left = left,
                BackColor = isEdit ? ColorTranslator.FromHtml(editColor) : ColorTranslator.FromHtml(deleteColor),
                Size = new Size(smallButtonSize, smallButtonSize),
                FlatStyle = FlatStyle.Flat,
                Image = Image.FromFile(iconPath),
                ImageAlign = ContentAlignment.MiddleCenter,
            };
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.Black;
            controls.Add(button);
        }
    }
}