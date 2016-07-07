using System;
using AForge.Video.FFMPEG;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;

namespace VideoRotate
{
    class MediaTools
    {
        //public static string TMP_OUTPUT_VIDEO_FILE = "tmp.mp4";

        // place an image inside a frame:
        // the image is located in the middle of the frame on the black background
        public static Bitmap PlaceImageInFrame(
            Bitmap image,
            int frameWidth,
            int frameHeight
            )
        {
            Bitmap frameBmp =
                new Bitmap(image, frameWidth, frameHeight);

            // paint the frame in black
            SolidBrush BlackBrush = new SolidBrush(Color.Black);
            Graphics graphics = Graphics.FromImage(frameBmp);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.FillRectangle(
                BlackBrush, 0, 0, frameWidth, frameHeight);

            // resize the image
            Bitmap imageResized = ResizeImage(
                image,
                frameWidth,
                frameHeight);

            // get the image location inside the frame
            Point framePos =
                GetImageLocationInRectangle(
                    imageResized, frameWidth, frameHeight);

            // draw the image inside the frame
            graphics.DrawImage(
                imageResized,
                framePos.X, framePos.Y,
                imageResized.Width, imageResized.Height);

            graphics.Dispose();
            imageResized.Dispose();

            return frameBmp;
        }

        public static void RotateVideo(
            string originalVideoFile,
            string outputVideoFile,
            int orientation,
            BackgroundWorker worker
            )
        {
            // open original video
            VideoFileReader reader = new VideoFileReader();
            reader.Open(originalVideoFile);

            // set correct frame's size for rotated video
            int width = reader.Width;
            int height = reader.Height;
            // only if video's orientation has been changed from horizontal to vertical
            // then it makes sense to swap width and height
            if ((Math.Abs(orientation) % 4) % 2 == 1)
            {
                width = reader.Height;
                height = reader.Width;
            }

            // create new video
            VideoFileWriter writer = new VideoFileWriter();
            string tmpVideoFile = GetOutputVideoFile(outputVideoFile);
            writer.Open(Form1.TMP_OUTPUT_VIDEO_FILE,
                width, height, reader.FrameRate,
                VideoCodec.MPEG4, 10000000);

            // in order to rotate a video 
            // we need just rotate each of orihinal video's frames
            for (int i = 0; i < reader.FrameCount; i++)
            {
                Bitmap videoFrame = reader.ReadVideoFrame();
                Bitmap videoFrame_rotated =
                    RotateFrame(videoFrame, orientation);

                writer.WriteVideoFrame(videoFrame_rotated);

                videoFrame.Dispose();
                videoFrame_rotated.Dispose();

                int progress = (int)(100 * i / reader.FrameCount);
                worker.ReportProgress(progress);
            }
            writer.Close();

            // implement multiplexing:
            // merge audio stream from original video and rotated video
            FFMPEGWrapper.GetAudioFromVideo(originalVideoFile,
                Form1.TMP_OUTPUT_AUDIO_FILE);
            FFMPEGWrapper.Mupltiplexing(
                Form1.TMP_OUTPUT_VIDEO_FILE, 
                Form1.TMP_OUTPUT_AUDIO_FILE, 
                outputVideoFile);
            worker.ReportProgress(100);
            worker.Dispose();
        }

        private static string GetOutputVideoFile(string fullPath)
        {
            string pattern = @"(.*)\.([^/.]*)";
            Match match = Regex.Match(fullPath, pattern);
            string outputFullPath = "";
            if (match.Success)
            {
                outputFullPath =
                    match.Groups[1].ToString() + "_tmp." + match.Groups[2].ToString();
            }

            return outputFullPath;
        }

        private static VideoCodec GetVideoCodec(string codecName)
        {
            switch (codecName)
            {
                case "MPEG4": return VideoCodec.MPEG4;
                case "MPEG2": return VideoCodec.MPEG2;
                case "FLV1": return VideoCodec.FLV1;
                case "WMV1": return VideoCodec.WMV1;
                case "WMV2": return VideoCodec.WMV2;
                case "MSMPEG4v2": return VideoCodec.MSMPEG4v2;
                case "MSMPEG4v3": return VideoCodec.MSMPEG4v3;
                default: return VideoCodec.MPEG4;
            }
        }

        private static Bitmap RotateFrame(Bitmap frame, int orientation)
        {
            orientation = Math.Abs(orientation) % 4;
            switch (orientation)
            {
                case 1:
                    frame.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case 2:
                    frame.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case 3:
                    frame.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

                case 4:
                default:
                    frame.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
            }

            return frame;
        }

        // method returns image location in the middle of a rectangle
        private static Point GetImageLocationInRectangle(
                Bitmap bmpImage,
                int width,
                int height
            )
        {
            Point position = new Point();
            if (bmpImage.Width > bmpImage.Height)
            {
                position.Y = (height - bmpImage.Height) / 2;
            }
            else if (bmpImage.Height > bmpImage.Width)
            {
                position.X = (width - bmpImage.Width) / 2;
            }
            else
            {
                position.X = 0;
                position.Y = 0;
            }

            return position;
        }

        public static Bitmap ResizeImage(
                Bitmap img,
                int frameWidth,
                int frameHeight
            )
        {
            int imgHeight = img.Height;
            int imgWidth = img.Width;

            float newHeight, newWidth;

            // image rescaling
            if (imgHeight > imgWidth)
            {
                newHeight = frameHeight;
                newWidth = ((imgWidth * newHeight) / imgHeight);
            }
            else if (imgHeight < imgWidth)
            {
                newWidth = frameWidth;
                newHeight = ((imgHeight * newWidth) / imgWidth);
            }
            else
            {
                newHeight = frameHeight < frameWidth ?
                    frameHeight : frameWidth;
                newWidth = newHeight;
            }

            Bitmap newImg = new Bitmap(img, (int)newWidth, (int)newHeight);
            img.Dispose();

            return newImg;
        }
    }
}
