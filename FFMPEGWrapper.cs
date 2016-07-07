using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace VideoRotate
{
    class FFMPEGWrapper
    {
        private static string BASE_DIRECTORY =
            Path.GetDirectoryName(Application.ExecutablePath);

        public static void GetAudioFromVideo(
            string inputVideoFile,
            string audioFile)
        {
            string audioFilePath = BASE_DIRECTORY + @"\" + audioFile;
            string arguments = " -i \"" + inputVideoFile +
                "\" -q:a 0 -map a -y \"" + audioFilePath + "\"";
            RunCommand(arguments);
        }

        public static void Mupltiplexing(
            string videoFile,
            string audioFile,
            string outputFile)
        {
            string arguments = " -i \"" + audioFile +
                "\" -i \"" + videoFile + "\" -y \"" + outputFile + "\"";
            RunCommand(arguments);
        }

        private static void RunCommand(
            string commandArguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = Path.GetFullPath(
                Path.Combine(BASE_DIRECTORY, @"..\..\FFMPEG\ffmpeg.exe"));
            startInfo.Arguments = commandArguments;

            Process process = Process.Start(startInfo);

            process.Start();
            process.WaitForExit();
        }

    }
}
