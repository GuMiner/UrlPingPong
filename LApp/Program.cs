using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

const int overallLength = 50;

Random random = new Random(4321);

char GetRandomChar()
{
    return (char)random.Next(32, 256);
}

char[] GetRandomChars(int length)
{
    char[] chars = new char[length];
    for (int i = 0; i < length; i++)
    {
        chars[i] = GetRandomChar();
    }

    return chars;
}

string GetBlankChars(int length)
{
    return new string(' ', length);
}

void WriteMirroredLine(int middleBlankLength)
{
    Console.Write(GetRandomChars(overallLength/2 - middleBlankLength / 2));
    Console.Write(GetBlankChars(middleBlankLength));
    Console.Write(GetRandomChars(overallLength/2 - middleBlankLength / 2));
    Console.WriteLine();
}

void WriteDoubledMirroredLine(int middleBlankLength, int centerLength)
{
    Console.Write(GetRandomChars(overallLength / 2 - middleBlankLength / 2));
    Console.Write(GetBlankChars(middleBlankLength/2 - centerLength/2));
    Console.Write(GetRandomChars(centerLength));
    Console.Write(GetBlankChars(middleBlankLength / 2 - centerLength/2));
    Console.Write(GetRandomChars(overallLength / 2 - middleBlankLength / 2));
    Console.WriteLine();
}

void HeartV1()
{
    // 10 💓
    WriteMirroredLine(0);

    WriteDoubledMirroredLine(30, 8);
    WriteDoubledMirroredLine(30, 4);
    WriteDoubledMirroredLine(30, 2);
    WriteMirroredLine(30);
    WriteMirroredLine(27);
    WriteMirroredLine(24);
    WriteMirroredLine(21);
    WriteMirroredLine(18);
    WriteMirroredLine(15);
    WriteMirroredLine(12);
    WriteMirroredLine(9);
    WriteMirroredLine(6);
    WriteMirroredLine(3);
    WriteMirroredLine(0);
}

void DrawChar()
{
    int intWidth;
    int intHeight;
    string s = "🌼";
    Bitmap objBmpImage = new Bitmap(1, 1);

    Font font = new Font("Segoe UI", 32);
    // Create a graphics object to measure the text's width and height.
    Graphics objGraphics = Graphics.FromImage(objBmpImage);
    // This is where the bitmap size is determined.                
    intWidth = (int)objGraphics.MeasureString(s, font).Width;
    intHeight = (int)objGraphics.MeasureString(s, font).Height;

    // Create the bmpImage again with the correct size for the text and font.
    objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

    objGraphics = Graphics.FromImage(objBmpImage);
    // Set Background color
    objGraphics.Clear(Color.White);
    objGraphics.SmoothingMode = SmoothingMode.None;
    objGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
    objGraphics.DrawString(s, font, new SolidBrush(Color.Black), 0, 0);
    objGraphics.Flush();
    // 🌼
    for (int i = 0; i < objBmpImage.Height; i++)
    {
        for (int j = 0; j < objBmpImage.Width; j++)
        {
            var color = objBmpImage.GetPixel(j, i);
            if (color.R == 255 && color.G == 255 && color.B == 255)
            {
                Console.Write(GetRandomChar());
            }
            else
            {
                Console.Write("");
            }
        }
        Console.WriteLine();
    }
}

while (true)
{

    Console.CursorLeft = 0;
    Console.CursorTop = 0;
    // HeartV1();
    DrawChar();

    Thread.Sleep(333);
}
