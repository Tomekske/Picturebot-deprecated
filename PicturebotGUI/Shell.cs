using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PicturebotGUI
{
    public static class Shell
    {
        public static void Execute(string program, string arguments)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = program,
                        Arguments = arguments,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                ThreadStart ths = new ThreadStart(() =>
                {
                    process.Start();
                    process.WaitForExit();
                });

                Thread th = new Thread(ths);
                th.Start();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        public static void ExecuteNoThread(string program, string arguments)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = program,
                        Arguments = arguments,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };


                process.Start();
                process.WaitForExit();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        public static string ExectutePipeOuput(string program, string arguments)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = program,
                        Arguments = arguments,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    return process.StandardOutput.ReadLine();
                }

                process.WaitForExit();
            }

            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return string.Empty;
        }
    }
}
