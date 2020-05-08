using Picturebot.src.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Command
{
    public static class Shell
    {
        public static void Execute(string program, string arguments)
        {
            log4net.ILog _log = LogHelper.GetLogger();

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
            catch (Exception e)
            {
                _log.Error($"Unable to execute: \"{program} {arguments}\"", e);
            }
        }

        public static void ExecuteNoThread(string program, string arguments)
        {
            log4net.ILog _log = LogHelper.GetLogger();

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
            catch (Exception e)
            {
                _log.Error($"Unable to execute: \"{program} {arguments}\"", e);
            }
        }

        public static string ExectutePipeOuput(string program, string arguments)
        {
            log4net.ILog _log = LogHelper.GetLogger();

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

            catch (Exception e)
            {
                _log.Error($"Unable to execute: \"{program} {arguments}\"", e);
            }

            return string.Empty;
        }
    }
}
