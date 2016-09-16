using System;

namespace ConsoleApplication {
    public class DrawHelper {

        // Draws a horizontal line ranging from start to end
        public static void drawHorizontal(byte[] data, int start, int end = -1) {
            if (end == -1) {
                end = start+Bitmap.DIGIT_WIDTH;
            }
            if (((start+Bitmap.DIGIT_WIDTH)-start) >= 40) {
                Console.WriteLine("Error. Horizontal lines cannot be wider than the image");
                return;
            }
            for (int i = start; i <= end; i++) {
                data[i] = Bitmap.NUM_COLOR;
            }
        }

        // Draws a vertical line ranging from start to end
        public static void drawVertical(byte[] data, int start, int end = -1) {
            if (end == -1) {
                end = start+Bitmap.DIGIT_HEIGHT*Bitmap.BMP_WIDTH;
            }
            int row = 0;
            for (int i = start; i <= end; i++) {
                if (i == start+row*Bitmap.BMP_WIDTH && row <= end) {
                    data[i] = Bitmap.NUM_COLOR;
                    row++;
                }
            }
        }
    }
}