using System.Drawing;
using System.Windows.Forms;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    public static class ResponsiveLayout
    {
        private static float _scaleX;
        private static float _scaleY;

        // Base resolution you designed your form on
        private const float BASE_WIDTH = 1920f;
        private const float BASE_HEIGHT = 1080f;

        public static void Initialize(Screen screen)
        {
            _scaleX = screen.Bounds.Width / BASE_WIDTH;
            _scaleY = screen.Bounds.Height / BASE_HEIGHT;
        }

        // Scale a font size relative to screen
        public static Font ScaleFont(string fontFamily, float baseFontSize, FontStyle style = FontStyle.Regular)
        {
            float scaledSize = baseFontSize * _scaleY;
            return new Font(fontFamily, scaledSize, style);
        }

        // Scale a size (width, height) relative to screen
        public static Size ScaleSize(int baseWidth, int baseHeight)
        {
            return new Size(
                (int)(baseWidth * _scaleX),
                (int)(baseHeight * _scaleY)
            );
        }

        // Scale a location (x, y) relative to screen
        public static Point ScaleLocation(int baseX, int baseY)
        {
            return new Point(
                (int)(baseX * _scaleX),
                (int)(baseY * _scaleY)
            );
        }

        // Center a control horizontally on screen
        public static int CenterHorizontal(int screenWidth, int controlWidth)
        {
            return (screenWidth - controlWidth) / 2;
        }

        // Center a control vertically on screen
        public static int CenterVertical(int screenHeight, int controlHeight)
        {
            return (screenHeight - controlHeight) / 2;
        }
    }
}