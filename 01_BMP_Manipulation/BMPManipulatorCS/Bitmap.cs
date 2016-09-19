using System;
using System.IO;
using System.Linq;

namespace ConsoleApplication {
    public class Bitmap {

        public const int BMP_WIDTH = 40;
        public const int DIGIT_WIDTH = 8;
        public const int DIGIT_HEIGHT = 18;
        private const int PIXEL_START = 1078;
        public const int NUM_COLOR = 0;

        private byte[] data;

        public Bitmap(byte[] data) {
            this.data = data;
        }

        override public String ToString() {
            string fileString = null;
            fileString += "Header:\n" + BitConverter.ToString(new ArraySegment<byte>(data, 0, 14).ToArray())
                                                    .Replace("-", string.Empty) + "\n";
            fileString += "Info:\n" + BitConverter.ToString(new ArraySegment<byte>(data, 14, 40).ToArray())
                                                    .Replace("-", string.Empty) + "\n";
            fileString += "ColorTable:\n" + BitConverter.ToString(new ArraySegment<byte>(data, 54, 1023).ToArray())
                                                    .Replace("-", string.Empty) + "\n";
            fileString += "PixelArray:\n" + BitConverter.ToString(new ArraySegment<byte>(data, 1078, data.Length-1078).ToArray())
                                                    .Replace("-", string.Empty) + "\n";
            return fileString;
        }

        public void draw(int num) {
            int baseStart = 1494, baseEnd = 1502;
            switch (num) {
                case 0: 
                    DrawHelper.drawHorizontal(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart);
                    DrawHelper.drawVertical(data, baseEnd);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 1:
                    DrawHelper.drawHorizontal(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart+5);
                    DrawHelper.drawHorizontal(data, baseStart+1+DIGIT_HEIGHT*BMP_WIDTH, baseStart+5+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 2:
                    DrawHelper.drawHorizontal(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH, baseStart+DIGIT_WIDTH+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH+DIGIT_HEIGHT/2*BMP_WIDTH, baseStart+DIGIT_WIDTH+DIGIT_HEIGHT*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 3:
                    DrawHelper.drawHorizontal(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 4:
                    // Move 3 pixels to the left (it looks off otherwise because of the diagonal line)
                    baseStart -= 3;
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH);
                    //DrawHelper.drawDiagonal(data, baseStart+DIGIT_WIDTH+DIGIT_HEIGHT/2*BMP_WIDTH);
                    int row = 0;
                    for (int i = PIXEL_START; i < data.Length; i++) {
                        if (i == baseStart+DIGIT_WIDTH+row*BMP_WIDTH && row < DIGIT_HEIGHT) {
                            row++;
                            // draw diagonal line in relation to current row
                            if (i >= baseStart+DIGIT_WIDTH+DIGIT_HEIGHT/2*BMP_WIDTH) {
                                if (row < DIGIT_HEIGHT)
                                    // The index is determined by adding the index of the very left starting point of the digit on 
                                    // the current row to the difference in pixels between the center of the digit and the current row
                                    // Yep, that's some serious clusterfuck right there.
                                    data[baseStart+row*BMP_WIDTH+(row-DIGIT_HEIGHT/2)] = NUM_COLOR;
                            }
                        }
                    }
                    break;
                case 5:
                    DrawHelper.drawHorizontal(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH, baseStart+DIGIT_WIDTH+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawVertical(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 6:
                    DrawHelper.drawHorizontal(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH, baseStart+DIGIT_WIDTH+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 7:
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 8:
                    DrawHelper.drawHorizontal(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart);
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                case 9:
                    DrawHelper.drawVertical(data, baseStart+DIGIT_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH);
                    DrawHelper.drawHorizontal(data, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    DrawHelper.drawVertical(data, baseStart+DIGIT_HEIGHT/2*BMP_WIDTH, baseStart+DIGIT_HEIGHT*BMP_WIDTH);
                    break;
                default:
                    Console.WriteLine("Not a valid number.");
                    break;
            }
        }

        public void save(int num) {
            File.WriteAllBytes("bitmaps/icon"+num+".bmp", data);
        }

        public byte[] getImgData() {
            return data;
        }
    }
}