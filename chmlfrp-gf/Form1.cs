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
            // ��ȡ��ǰ���̵�����
            string processName = Process.GetCurrentProcess().ProcessName;
            // ��ȡͬ�����̵�����
            int count = Process.GetProcessesByName(processName).Length;
            // �����������1���رճ���
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

            // ��ʾ�ڶ�������
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

                    label4.Text = "��";
                    buquan.Visible = false;


                }
                else
                {
                    label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 8);
                    label4.Text = "ȱ�ٳ������壬��鿴��߽̳��ٲ���";
                    DialogResult result = MessageBox.Show("δ��⵽frp���Ƿ�ȫfrp��", "ѡ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            buquanjb();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"������ȫ�ű�����: {ex.Message}");
                        }

                    }
                    buquan.Visible = true;

                }
            }
            else
            {
                label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9);
                label4.Text = "��";
                DialogResult result = MessageBox.Show("δ��⵽frp���Ƿ�ȫfrp��", "ѡ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        buquanjb();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ȫ�ű�����: {ex.Message}");
                    }
                }
                buquan.Visible = true;
            }
        }
        public static void KillFrpProcess()
        {
            // ��ȡ�����������еĽ���
            Process[] processes = Process.GetProcessesByName("frpc");

            // ����ҵ�����һ�����̣����Խ�������
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
                        MessageBox.Show($"�� ID: {process.Id}ò�ƹر�ʧ��ȥ������ϵ����Ա");
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

            if (button2.Text == "����ӳ��")
            {
                rizhi.Clear();
                bool canConnect = CanConnectToInternet();

                if (canConnect)
                {
                    if (label4.Text == "��")
                    {
                        if (!string.IsNullOrWhiteSpace(this.textBox1.Text))
                        {
                            string textBoxContent = textBox1.Text;
                            button2.Text = "�ر����";
                            cmd123.Start();

                            cmd123.StandardInput.WriteLine("cd frp");
                            cmd123.StandardInput.WriteLine("frpc.exe -c frpc.ini");

                            // �����ļ�
                            using (StreamWriter writer = new StreamWriter(frpcIni))
                            {
                                writer.Write(textBoxContent);
                            }
                            string line;
                            cmd123.StartInfo.UseShellExecute = false;

                            // ʵ���첽��ȡ�����ί��
                            cmd123.OutputDataReceived += (s, ea) =>
                            {
                                if (ea.Data != null)
                                {
                                    string line = ea.Data;
                                    rizhi.BeginInvoke(new Action(() =>
                                    {
                                        rizhi.AppendText(ProcessOutput(line) + Environment.NewLine);
                                    }));
                                    // ����OutputDataReceived��
                                }
                            };
                            cmd123.ErrorDataReceived += (s, ea) =>
                            {
                                if (ea.Data != null)
                                {
                                    // ����������
                                    Console.Error.WriteLine(ea.Data);
                                }
                            };
                            cmd123.BeginOutputReadLine();
                        }
                        else
                        {
                            MessageBox.Show("�����������ļ�", "ϵͳ��ʾ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("���Ȳ�ȫ�ļ�", "ϵͳ��ʾ");
                    }
                }
                else
                {
                    MessageBox.Show("δ��������������", "ϵͳ��ʾ");
                }
            }
            else
            {
                try
                {
                    cmd123.Kill();
                    rizhi.AppendText("�ɹ��ر����" + Environment.NewLine);
                }
                catch
                {
                    rizhi.AppendText("���Եڶ��ιر����" + Environment.NewLine);
                    try
                    {
                        KillFrpProcess();
                        rizhi.AppendText("�ɹ��ر����" + Environment.NewLine);
                    }
                    catch
                    {
                        rizhi.AppendText("���Եڶ��ιر����ʧ��" + Environment.NewLine);
                    }
                }


                button2.Text = "����ӳ��";

            }
        }
        
        
        private void buquanjb()
        {
            Form form3 = new Form3();

            // ��ʾ�ڶ�������
            form3.Show();
        }

        // ��������е�������Ϣ���ʽ
        private string ProcessOutput(string input)
        {
            string pattern = @"\[(.{16,})\]";
            return Regex.Replace(input, pattern, match => match.Groups[1].Value.Length > 15 ? "[****token�Զ�������****]" : match.Value);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button2.Text != "����ӳ��")
            {
                e.Cancel = true; // ȡ���رղ���
                MessageBox.Show("���ȹر�ӳ��", "ϵͳ��ʾ");
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
                MessageBox.Show($"������ȫ�ű�����: {ex.Message}");
            }
        
        }
    }
}
