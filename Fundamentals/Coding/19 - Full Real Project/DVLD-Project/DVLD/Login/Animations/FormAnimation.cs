using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVLD.Login.Animations
{
    /// <summary>
    /// Provides animation effects for Windows Forms.
    /// </summary>
    public static class FormAnimation
    {
        // Animation constants
        public const int AW_HOR_POSITIVE = 0x00000001;
        public const int AW_HOR_NEGATIVE = 0x00000002;
        public const int AW_VER_POSITIVE = 0x00000004;
        public const int AW_VER_NEGATIVE = 0x00000008;
        public const int AW_CENTER = 0x00000010;
        public const int AW_HIDE = 0x00010000;
        public const int AW_ACTIVATE = 0x00020000;
        public const int AW_SLIDE = 0x00040000;
        public const int AW_BLEND = 0x00080000;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        /// <summary>
        /// Animates the form with the specified animation type and duration.
        /// </summary>
        /// <param name="form">The form to animate.</param>
        /// <param name="duration">Duration of the animation in milliseconds.</param>
        /// <param name="flags">Animation flags.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public static bool Animate(Form form, int duration, int flags)
        {
            if (form == null) return false;
            return AnimateWindow(form.Handle, duration, flags);
        }

        /// <summary>
        /// Fades the form in.
        /// </summary>
        /// <param name="form">The form to fade in.</param>
        /// <param name="duration">Duration of the animation in milliseconds.</param>
        public static void FadeIn(Form form, int duration = 200)
        {
            Animate(form, duration, AW_BLEND | AW_ACTIVATE);
        }

        /// <summary>
        /// Fades the form out.
        /// </summary>
        /// <param name="form">The form to fade out.</param>
        /// <param name="duration">Duration of the animation in milliseconds.</param>
        public static void FadeOut(Form form, int duration = 200)
        {
            Animate(form, duration, AW_BLEND | AW_HIDE);
        }

        /// <summary>
        /// Slides the form from center.
        /// </summary>
        /// <param name="form">The form to slide.</param>
        /// <param name="duration">Duration of the animation in milliseconds.</param>
        public static void SlideFromCenter(Form form, int duration = 200)
        {
            Animate(form, duration, AW_CENTER | AW_ACTIVATE);
        }
    }
}
