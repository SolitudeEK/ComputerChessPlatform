using System.Diagnostics;

namespace EngineManagement
{
    public class Engine
    {
        private Process process { get; set; }
        private StreamWriter streamWriter { get; set; }

        public delegate void Output(object sendingProcess, DataReceivedEventArgs outLine);
        public Engine(string location)
        {
            Console.WriteLine("Engine Created");
            process = new Process();
            process.StartInfo.FileName = location;
            process.StartInfo.FileName = location;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            streamWriter = process.StandardInput;
            streamWriter.WriteLine("uci");
            streamWriter.WriteLine("ucinewgame");
            streamWriter.WriteLine("position startpos");
        }

        public void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data.Contains("bestmove"))
            {
                Console.WriteLine(outLine.Data.Split(" ")[1]);
            }
        }
        public void Subscribe(Manager m)
        {
            process.OutputDataReceived += new DataReceivedEventHandler(m.Output);
        }
        public void Move(string moves)
        {
            streamWriter.WriteLine($"position startpos moves {moves}");
            streamWriter.WriteLine("go movetime 100");

        }
    }
}
