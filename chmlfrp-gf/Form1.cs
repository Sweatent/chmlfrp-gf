using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Unicode;
using static System.Net.WebRequestMethods;
using System;
using System.Windows.Forms;
using File = System.IO.File;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;
using System.Reflection.PortableExecutable;
using System.Net;
using STTech.CodePlus.Threading;
using System.Security.Policy;
using chmlfrp;




namespace chmlfrp_green_fast
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            // 获取当前进程的名称
            string processName = Process.GetCurrentProcess().ProcessName;
            // 获取同名进程的数量
            int count = Process.GetProcessesByName(processName).Length;
            // 如果数量大于1，关闭程序
            if (count > 1)
            {
                Process.GetCurrentProcess().Kill();
            }
        }
        static bool CanConnectToInternet()
        {
            try
            {
                Ping ping = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "abcdefghijklmnopqrstuvwxyz";
                byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
                int timeout = 1000;
                PingReply reply = ping.Send("www.baidu.com", timeout, buffer, options);
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://panel.chmlfrp.cn/tunnelm/config",
                UseShellExecute = true
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();

            // 显示第二个窗体
            form2.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        string frpcIni = "";
        private void main_Load(object sender, EventArgs e)
        {
            string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string frpFolder = Path.Combine(appDirectory, "frp");

            if (Directory.Exists(frpFolder))
            {
                string frpcExe = Path.Combine(frpFolder, "frpc.exe");
                frpcIni = Path.Combine(frpFolder, "frpc.ini");

                if (System.IO.File.Exists(frpcExe) && System.IO.File.Exists(frpcIni))
                {
                    label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9);

                    label4.Text = "是";
                    buquan.Visible = false;


                }
                else
                {
                    label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 8);
                    label4.Text = "缺少程序主体，请查看左边教程再操作";
                    DialogResult result = MessageBox.Show("未检测到frp，是否补全frp？", "选择", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            buquanjb();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"启动补全脚本出错: {ex.Message}");
                        }

                    }
                    buquan.Visible = true;

                }
            }
            else
            {
                label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9);
                label4.Text = "否";
                DialogResult result = MessageBox.Show("未检测到frp，是否补全frp？", "选择", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        buquanjb();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"启动补全脚本出错: {ex.Message}");
                    }
                }
                buquan.Visible = true;
            }
        }
        public static void KillFrpProcess()
        {
            // 获取所有正在运行的进程
            Process[] processes = Process.GetProcessesByName("frpc");

            // 如果找到至少一个进程，尝试结束它们
            if (processes.Length > 0)
            {
                foreach (Process process in processes)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show($"此 ID: {process.Id}貌似关闭失败去，请联系管理员");
                    }
                }
                return;
            }
            return;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process cmd123 = new Process();
            cmd123.StartInfo.FileName = "cmd.exe";
            cmd123.StartInfo.UseShellExecute = false;
            cmd123.StartInfo.RedirectStandardInput = true;
            cmd123.StartInfo.RedirectStandardOutput = true;
            cmd123.StartInfo.RedirectStandardError = true;
            cmd123.StartInfo.CreateNoWindow = true;
            cmd123.StartInfo.RedirectStandardOutput = true;
            cmd123.StartInfo.StandardOutputEncoding = Encoding.UTF8;

            if (button2.Text == "启动映射")
            {
                rizhi.Clear();
                bool canConnect = CanConnectToInternet();

                if (canConnect)
                {
                    if (label4.Text == "是")
                    {
                        if (!string.IsNullOrWhiteSpace(this.textBox1.Text))
                        {
                            string textBoxContent = textBox1.Text;
                            button2.Text = "关闭隧道";
                            cmd123.Start();

                            cmd123.StandardInput.WriteLine("cd frp");
                            cmd123.StandardInput.WriteLine("frpc.exe -c frpc.ini");

                            // 保存文件
                            using (StreamWriter writer = new StreamWriter(frpcIni))
                            {
                                writer.Write(textBoxContent);
                            }
                            string line;
                            cmd123.StartInfo.UseShellExecute = false;

                            // 实现异步读取输出的委托
                            cmd123.OutputDataReceived += (s, ea) =>
                            {
                                if (ea.Data != null)
                                {
                                    string line = ea.Data;
                                    rizhi.BeginInvoke(new Action(() =>
                                    {
                                        rizhi.AppendText(ProcessOutput(line) + Environment.NewLine);
                                    }));
                                    // 订阅OutputDataReceived事
                                }
                            };
                            cmd123.ErrorDataReceived += (s, ea) =>
                            {
                                if (ea.Data != null)
                                {
                                    // 处理错误输出
                                    Console.Error.WriteLine(ea.Data);
                                }
                            };
                            cmd123.BeginOutputReadLine();
                        }
                        else
                        {
                            MessageBox.Show("请输入配置文件", "系统提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先补全文件", "系统提示");
                    }
                }
                else
                {
                    MessageBox.Show("未联网，请先联网", "系统提示");
                }
            }
            else
            {
                try
                {
                    cmd123.Kill();
                    rizhi.AppendText("成功关闭隧道" + Environment.NewLine);
                }
                catch
                {
                    rizhi.AppendText("尝试第二次关闭隧道" + Environment.NewLine);
                    try
                    {
                        KillFrpProcess();
                        rizhi.AppendText("成功关闭隧道" + Environment.NewLine);
                    }
                    catch
                    {
                        rizhi.AppendText("尝试第二次关闭隧道失败" + Environment.NewLine);
                    }
                }


                button2.Text = "启动映射";

            }
        }
        
        
        private void buquanjb()
        {
            Form form3 = new Form3();

            // 显示第二个窗体
            form3.Show();
        }

        // 处理输出中的敏感信息或格式
        private string ProcessOutput(string input)
        {
            string pattern = @"\[(.{16,})\]";
            return Regex.Replace(input, pattern, match => match.Groups[1].Value.Length > 15 ? "[****token自动保护中****]" : match.Value);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button2.Text != "启动映射")
            {
                e.Cancel = true; // 取消关闭操作
                MessageBox.Show("请先关闭映射", "系统提示");
            }
        }

        private void buquan_Click(object sender, EventArgs e)
        {

            try
            {
                buquanjb();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动补全脚本出错: {ex.Message}");
            }
        
        }
    }
}
