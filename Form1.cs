using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.FFMPEG;
using System.IO;
using System.Text.RegularExpressions;

namespace VideoRotate
{
    public partial class Form1 : Form
    {
        private int rotationsCount = 0;
        private const string FIRST_FRAME_FILE_NAME = "firstFrame_tmp.jpg";

        public const string TMP_OUTPUT_VIDEO_FILE = "tmp.mp4";
        public const string TMP_OUTPUT_AUDIO_FILE = "audio.mp3";

        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();

            firstFrameBox.BackColor = Color.Black;
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.DoWork +=
                 new DoWorkEventHandler(backgroundWorker_DoWork);

            backgroundWorker.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);

            backgroundWorker.RunWorkerCompleted +=
              new RunWorkerCompletedEventHandler(backgroundWorker_RunCompleted);
        }

        private void backgroundWorker_DoWork(object sender,
            DoWorkEventArgs e)
        {
            int orientation = rotationsCount;
            string originalVideo = videoTextBox.Text;
            string outputVideoFile = outputVideoFileTextBox.Text;
            MediaTools.RotateVideo(
                originalVideo, outputVideoFile, orientation,
                backgroundWorker);
        }

        private void backgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage);
            int percentValue = e.ProgressPercentage >= 100 ?
                100 : e.ProgressPercentage;
            progressLabel.Text = percentValue + " %";
            progressBar.Value = percentValue;

            if( percentValue == 100)
            {
                System.Threading.Thread.Sleep(4000);
                progressLabel.Text = "Done!";
                progressBar.Value = 0;
            }
        }

        private void ResetForm()
        {
            progressLabel.Text = "0 %";
            progressBar.Value = 0;

            if( File.Exists(FIRST_FRAME_FILE_NAME))
            {
                File.Delete(FIRST_FRAME_FILE_NAME);
            }
        }

        private void backgroundWorker_RunCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            // open folder with output video file
            FocusFile(outputVideoFileTextBox.Text);

            // delete temporary files
            File.Delete(TMP_OUTPUT_AUDIO_FILE);
            File.Delete(TMP_OUTPUT_VIDEO_FILE);
        }

        private void FocusFile(string file)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"/select, " + file);
        }

        private void clockwiseBtn_Click(object sender, EventArgs e)
        {
            rotationsCount++;
            Console.WriteLine(rotationsCount);
            // rotate first frame
            RotateFirstFrame(RotateFlipType.Rotate90FlipNone);
        }

        private void videoTextBox_TextChanged(object sender, EventArgs e)
        {
            string videoFileFullPath = videoTextBox.Text;
            if ( !String.IsNullOrWhiteSpace(videoFileFullPath) && File.Exists(videoFileFullPath))
            {
                Cursor.Current = Cursors.WaitCursor;

                // generate video output file name
                outputVideoFileTextBox.Text = GetOutputVideoFile(videoFileFullPath);

                // show first frame of choosen video
                VideoFileReader reader = new VideoFileReader();
                reader.Open(videoFileFullPath);

                // get first frame
                if(reader.FrameCount >= 1)
                {
                    ResetForm();

                    // get first frame
                    Bitmap firstFrame = reader.ReadVideoFrame();
                    firstFrame.Save(FIRST_FRAME_FILE_NAME);

                    // show first video frame inside picture box
                    firstFrame = MediaTools.PlaceImageInFrame(
                            firstFrame,
                            firstFrameBox.Width,
                            firstFrameBox.Height);
                    firstFrameBox.Image = firstFrame;
                }
                else
                {
                    // should be message indicating errors whild video loading
                    MessageBox.Show("Unable to load video " +
                        videoFileFullPath, "Input video error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private string GetOutputVideoFile(string fullPath)
        {
            string pattern = @"(.*)\.([^/.]*)";
            Match match = Regex.Match(fullPath, pattern);
            string outputFullPath = "";
            if (match.Success)
            {
                outputFullPath =
                    match.Groups[1].ToString() + "_rotated." + match.Groups[2].ToString();
            }

            return outputFullPath;
        }

        private void videoBrowseBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openVideoFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                videoTextBox.Text = openVideoFileDialog.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            if( !String.IsNullOrWhiteSpace(videoTextBox.Text)
                && !String.IsNullOrWhiteSpace(outputVideoFileTextBox.Text) 
              )
            {
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Input and/or output video files should not be empty",
                    "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void antiClockwiseBtn_Click(object sender, EventArgs e)
        {
            rotationsCount--;

            Console.WriteLine(rotationsCount);
            // rotate first frame
            RotateFirstFrame(RotateFlipType.Rotate270FlipNone);
        }

        private void RotateFirstFrame(RotateFlipType rotationType)
        {
            Bitmap firstFrameBmp = (Bitmap)Image.FromFile(FIRST_FRAME_FILE_NAME);
            firstFrameBmp.RotateFlip(rotationType);
            firstFrameBmp.Save(FIRST_FRAME_FILE_NAME);
            Image firstFrame = MediaTools.PlaceImageInFrame(
                firstFrameBmp,
                firstFrameBox.Width,
                firstFrameBox.Height);
            firstFrameBox.Image = firstFrame;
        }
    }
}
