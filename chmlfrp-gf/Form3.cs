using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chmlfrp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DownloadFilesAsync();
            byte123.Text= $"0 / 0kb ";
        }

        private async void DownloadFilesAsync()
        {
            string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string downloadDirectory = Path.Combine(appDirectory, "frp");

            if (!Directory.Exists(downloadDirectory))
                Directory.CreateDirectory(downloadDirectory);

            string[] fileUrls =
            {
                "https://sweatent.link/frp/frpc.exe",
                "https://sweatent.link/frp/frpc.ini"
            };

            foreach (var url in fileUrls)
            {
                string fileName = Path.GetFileName(url);
                string localPath = Path.Combine(downloadDirectory, fileName);
                await DownloadFileAsync(url, localPath);
            }
        }

        async Task DownloadFileAsync(string url, string localPath)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    using (Stream stream = await response.Content.ReadAsStreamAsync(),
                              fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        long totalBytes = response.Content.Headers.ContentLength ?? -1;
                        long totalBytesRead = 0;

                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalBytesRead += bytesRead;

                            // 假设有一个ProgressBar控件名叫progressBar1和一个Label控件名叫lblProgress
                            UpdateProgress(totalBytesRead, totalBytes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"下载失败: {ex.Message}");
                }
            }
        }

        // 假设的方法用于更新UI中的进度信息
        private void UpdateProgress(long bytesDownloaded, long totalBytes)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(bytesDownloaded, totalBytes)));
                return;
            }

            if (totalBytes > 8)
            {
                jindu.Value = (int)(bytesDownloaded*100  / totalBytes);
                byte123.Text = $"{bytesDownloaded/1024} / {totalBytes/1024}kb ";
            }
            else
            {
                MessageBox.Show($"补全成功，请手动重启客户端");
                // 获取当前进程的名称
                string processName = Process.GetCurrentProcess().ProcessName;
                // 获取同名进程的数量
                int count = Process.GetProcessesByName(processName).Length;
                // 关闭程序
                Process.GetCurrentProcess().Kill();
                
            }
        }
    }
}