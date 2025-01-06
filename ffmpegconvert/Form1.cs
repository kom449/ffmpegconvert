using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ffmpegconvert
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> fileMap = new Dictionary<string, string>(); // Stores full paths and file names
        private string outputFolder = ""; // Stores the selected output folder
        private string ffmpegPath = "ffmpeg.exe"; // Default FFmpeg path
        private Dictionary<string, string> bitDepthFormats = new Dictionary<string, string>
        {
            { "16-bit", "s16" },
            { "24-bit", "s24" },
            { "32-bit", "s32" }
        };

        public Form1()
        {
            InitializeComponent();
            ResetState();
            this.FormClosing += Form1_FormClosing;
            cmbOutputFormat.SelectedIndexChanged += CmbOutputFormat_SelectedIndexChanged;
            ffmpegPath = Path.Combine(Application.StartupPath, "ffmpeg.exe");

            if (File.Exists(ffmpegPath))
            {
                lblFFmpegPath.Text = "FFmpeg Found";
            }
            else
            {
                lblFFmpegPath.Text = "FFmpeg Not Found";
                MessageBox.Show("FFmpeg executable (ffmpeg.exe) is missing from the program's directory. Please add it and restart the program.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbOutputFormat.Items.AddRange(new string[] { "MP3", "WAV", "AAC", "FLAC", "OGG", "AIFF", "ALAC" });
            cmbOutputFormat.SelectedIndex = 0; // Default to MP3
            cmbOutputFormat.SelectedIndexChanged += CmbOutputFormat_SelectedIndexChanged; // Add dynamic behavior for format changes

            cmbSampleRate.Items.AddRange(new string[] { "22050 Hz", "32000 Hz", "44100 Hz", "48000 Hz", "88200 Hz", "96000 Hz" });
            cmbSampleRate.SelectedIndex = 2; // Default to 44100 Hz

            cmbBitrate.Items.AddRange(new string[]{ "64 kbps", "96 kbps", "128 kbps", "192 kbps", "256 kbps", "320 kbps (Lossy)", "500 kbps (Lossy)", "1000 kbps (Lossless)", "1500 kbps (Lossless)", "2000 kbps (Lossless)", "3000 kbps (Lossless)" });
            cmbBitrate.SelectedIndex = 5; // Default to 320 kbps

            cmbChannels.Items.AddRange(new string[] { "Mono", "Stereo" });
            cmbChannels.SelectedIndex = 1; // Default to "Stereo"

            cmbCodec.Items.AddRange(new string[] { "aac", "mp3", "flac", "pcm_s16le", "pcm_s24le", "pcm_s32le", "opus" });
            cmbCodec.SelectedIndex = 0; // Default to "aac"

            cmbBitDepth.Items.AddRange(new string[] { "16-bit", "24-bit", "32-bit" });
            cmbBitDepth.SelectedIndex = 0; // Default to 16-bit

            cmbCompressionLevel.Items.AddRange(new string[] { "Level 0 (Fastest)", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5 (Default)", "Level 6", "Level 7", "Level 8 (Maximum)" });
            cmbCompressionLevel.SelectedIndex = 5; // Default to Level 5

            cmbContainer.Items.AddRange(new string[] { "MKV/MKA", "MP4/M4A", "FLV/F4V", "3GP/3G2", "MPG", "PS/TS Stream", "M2TS", "VOB", "RMVB", "WebM", "OGG" });
            cmbContainer.SelectedIndex = 0; // Default to MKV/MKA
        }

        private void CmbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFormat = cmbOutputFormat.SelectedItem.ToString().ToLower();

            cmbCodec.Items.Clear();
            cmbBitrate.Items.Clear();
            cmbBitDepth.Items.Clear();

            switch (selectedFormat)
            {
                case "mp3":
                    cmbCodec.Items.Add("mp3");
                    cmbCodec.SelectedIndex = 0;
                    cmbBitrate.Items.AddRange(new string[] { "64 kbps", "96 kbps", "128 kbps", "192 kbps", "256 kbps", "320 kbps" });
                    cmbBitrate.SelectedIndex = 5; // Default to 320 kbps
                    cmbBitDepth.Items.Add("N/A"); 
                    cmbBitDepth.SelectedIndex = 0;
                    break;

                case "wav":
                    cmbCodec.Items.AddRange(new string[] { "pcm_s16le", "pcm_s24le", "pcm_s32le" });
                    cmbCodec.SelectedIndex = 0;
                    cmbBitrate.Items.Add("N/A");
                    cmbBitrate.SelectedIndex = 0;
                    cmbBitDepth.Items.AddRange(new string[] { "16-bit", "24-bit", "32-bit" });
                    cmbBitDepth.SelectedIndex = 0; // Default to 16-bit
                    break;

                case "aac":
                    cmbCodec.Items.Add("aac");
                    cmbCodec.SelectedIndex = 0;
                    cmbBitrate.Items.AddRange(new string[] { "96 kbps", "128 kbps", "192 kbps", "256 kbps", "320 kbps" });
                    cmbBitrate.SelectedIndex = 4; // Default to 320 kbps
                    cmbBitDepth.Items.Add("N/A");
                    cmbBitDepth.SelectedIndex = 0;
                    break;

                case "flac":
                    cmbCodec.Items.Add("flac");
                    cmbCodec.SelectedIndex = 0;
                    cmbBitrate.Items.Add("Lossless"); // FLAC is always lossless
                    cmbBitrate.SelectedIndex = 0;
                    cmbBitDepth.Items.AddRange(new string[] { "16-bit", "24-bit", "32-bit" });
                    cmbBitDepth.SelectedIndex = 0; // Default to 16-bit
                    break;

                case "ogg":
                    cmbCodec.Items.AddRange(new string[] { "vorbis", "opus" });
                    cmbCodec.SelectedIndex = 0;
                    cmbBitrate.Items.AddRange(new string[] { "64 kbps", "96 kbps", "128 kbps", "192 kbps", "256 kbps" });
                    cmbBitrate.SelectedIndex = 4; // Default to 256 kbps
                    cmbBitDepth.Items.Add("N/A");
                    cmbBitDepth.SelectedIndex = 0;
                    break;

                default:
                    // Default case for unsupported formats
                    cmbCodec.Items.Add("aac");
                    cmbCodec.SelectedIndex = 0;
                    cmbBitrate.Items.AddRange(new string[] { "64 kbps", "96 kbps", "128 kbps", "192 kbps", "256 kbps" });
                    cmbBitrate.SelectedIndex = 4;
                    cmbBitDepth.Items.Add("N/A");
                    cmbBitDepth.SelectedIndex = 0;
                    break;
            }
        }

        private void btnSelectInputFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Audio Files|*.mp3;*.wav;*.flac;*.aac|All Files|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(filePath);

                    if (!fileMap.ContainsKey(filePath))
                    {
                        fileMap.Add(filePath, fileName);
                        lstInputFiles.Items.Add(fileName);
                    }
                }
            }
        }

        private void btnSelectOutputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolder = folderBrowserDialog.SelectedPath;
                string folderName = Path.GetFileName(outputFolder.TrimEnd(Path.DirectorySeparatorChar));
                lblOutputFolder.Text = $"Output Folder: {folderName}";
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lstInputFiles.SelectedItem != null)
            {
                string selectedFileName = lstInputFiles.SelectedItem.ToString();
                string filePathToRemove = null;

                foreach (var kvp in fileMap)
                {
                    if (kvp.Value == selectedFileName)
                    {
                        filePathToRemove = kvp.Key;
                        break;
                    }
                }

                if (filePathToRemove != null)
                {
                    fileMap.Remove(filePathToRemove);
                }

                lstInputFiles.Items.Remove(selectedFileName);
            }
            else
            {
                MessageBox.Show("Please select a file to remove.");
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstInputFiles.Items.Clear();
            fileMap.Clear();
        }

        private void btnSetFFmpegPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable Files|*.exe"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ffmpegPath = openFileDialog.FileName;
                lblFFmpegPath.Text = $"FFmpeg Path: {ffmpegPath}";
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            if (lstInputFiles.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one input file.");
                return;
            }

            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                MessageBox.Show("Please select an output folder.");
                return;
            }

            if (cmbOutputFormat.SelectedItem == null || cmbCodec.SelectedItem == null || cmbSampleRate.SelectedItem == null ||
                cmbBitrate.SelectedItem == null || cmbChannels.SelectedItem == null)
            {
                MessageBox.Show("Please ensure all format options are selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnConvert.Enabled = false;
            btnClearAll.Enabled = false;

            string outputFormat = cmbOutputFormat.SelectedItem.ToString().ToLower();
            string codec = cmbCodec.SelectedItem.ToString().ToLower();
            string sampleRate = cmbSampleRate.SelectedItem.ToString().Split(' ')[0];
            string bitrate = cmbBitrate.SelectedItem.ToString().Split(' ')[0];
            string channels = cmbChannels.SelectedItem.ToString().ToLower() == "mono" ? "1" : "2";
            string bitDepth = cmbBitDepth.SelectedItem != null ? cmbBitDepth.SelectedItem.ToString() : null;
            string compressionLevel = null;

            if (codec == "flac" && cmbCompressionLevel.SelectedItem != null)
            {
                compressionLevel = cmbCompressionLevel.SelectedItem.ToString().Split(' ')[1];
            }

            progressBar.Maximum = fileMap.Count;
            progressBar.Value = 0;

            foreach (string inputFile in fileMap.Keys)
            {
                string outputFile;
                string command = ""; // Declare and initialize command here

                // Special handling for WAV
                if (outputFormat == "wav")
                {
                    outputFile = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(inputFile) + ".wav"
                    );

                    if (codec != "pcm_s16le" && codec != "pcm_s24le" && codec != "pcm_s32le")
                    {
                        codec = "pcm_s16le";
                        Debug.WriteLine($"Invalid codec for WAV. Defaulting to: {codec}");
                    }

                    // Validate bit depth and sample format
                    if (bitDepth != null)
                    {
                        string sampleFmt = bitDepth switch
                        {
                            "16-bit" => "s16",
                            "24-bit" => "s24",
                            "32-bit" => "s32",
                            _ => "s16" // Default to 16-bit
                        };

                        if (codec == "pcm_s16le" && sampleFmt != "s16")
                        {
                            sampleFmt = "s16";
                        }
                        else if (codec == "pcm_s24le" && sampleFmt != "s24")
                        {
                            sampleFmt = "s24";
                        }
                        else if (codec == "pcm_s32le" && sampleFmt != "s32")
                        {
                            sampleFmt = "s32";
                        }

                        command += $" -sample_fmt {sampleFmt}";
                    }
                }
                else
                {
                    string container = cmbContainer.SelectedItem.ToString().Split('/')[0].ToLower();
                    outputFile = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(inputFile) + $".{container}"
                    );
                }

                // Construct FFmpeg command
                command = $"-i \"{inputFile}\" -acodec {codec} -ar {sampleRate} -ac {channels}";

                // Add bitrate for non-WAV formats
                if (outputFormat != "wav" && codec != "pcm_s16le" && codec != "pcm_s24le" && codec != "pcm_s32le")
                {
                    command += $" -b:a {bitrate}k";
                }

                // Add FLAC compression level
                if (codec == "flac" && compressionLevel != null)
                {
                    command += $" -compression_level {compressionLevel}";
                }

                command += $" \"{outputFile}\"";

                Debug.WriteLine($"Final FFmpeg Command: {command}");

                // Update the status label with the current file name
                string currentFileName = Path.GetFileName(inputFile);
                lblStatus.Invoke((MethodInvoker)(() => lblStatus.Text = $"Converting: {currentFileName}"));

                try
                {
                    await RunFFmpegCommandAsync(command);
                    progressBar.Invoke((MethodInvoker)(() => progressBar.Value += 1));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Conversion failed for file {inputFile}: {ex.Message}");
                }
            }

            MessageBox.Show("Conversion complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnConvert.Enabled = true;
            btnClearAll.Enabled = true;
            lblStatus.Text = "Status: Ready";
        }


        private async Task RunFFmpegCommandAsync(string command)
        {
            try
            {
                Debug.WriteLine($"Preparing to execute FFmpeg Command: {command}");
                Debug.WriteLine($"Constructed FFmpeg Command: {command}");

                await Task.Run(() =>
                {
                    Process ffmpeg = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = ffmpegPath,
                            Arguments = command,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        }
                    };

                    ffmpeg.OutputDataReceived += (sender, args) =>
                    {
                        if (!string.IsNullOrWhiteSpace(args.Data))
                            Debug.WriteLine($"[FFmpeg Output]: {args.Data}");
                    };

                    ffmpeg.ErrorDataReceived += (sender, args) =>
                    {
                        if (!string.IsNullOrWhiteSpace(args.Data))
                            Debug.WriteLine($"[FFmpeg Error]: {args.Data}");
                    };

                    Debug.WriteLine("Starting FFmpeg process...");
                    ffmpeg.Start();
                    Debug.WriteLine("FFmpeg process started successfully.");

                    ffmpeg.BeginOutputReadLine();
                    ffmpeg.BeginErrorReadLine();
                    ffmpeg.WaitForExit();

                    Debug.WriteLine($"FFmpeg process exited with code: {ffmpeg.ExitCode}");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Exception: {ex}");
            }
        }

        private void TerminateFFmpeg()
        {
            foreach (var process in Process.GetProcessesByName("ffmpeg"))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch
                {
                    // Ignore exceptions if the process cannot be killed
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TerminateFFmpeg();
        }

        private void ResetState()
        {
            fileMap.Clear();
            lstInputFiles.Items.Clear();
            lblStatus.Text = "Status: Ready";
            progressBar.Value = 0;
        }


    }
}
