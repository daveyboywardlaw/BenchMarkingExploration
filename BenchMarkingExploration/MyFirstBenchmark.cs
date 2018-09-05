using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace BenchMarkingExploration
{
    [SimpleJob(launchCount: 1, warmupCount: 3, targetCount: 4, invocationCount: 5)]
    //[ShortRunJob]
    public class MyFirstBenchmark
    {
        [GlobalSetup()]
        public void GlobalSetup()
        {
        }

        [GlobalCleanup()]
        public void GlobalCleanup()
        {
            Process[] proc = Process.GetProcessesByName("notepad");
            int i = 0;
            foreach (var item in proc)
            {
                proc[i].Kill();
                i++;
            }
            //Console.ReadLine();
        }

        [Benchmark(Description = "Open Notepad ++")]
        public void OpenNotePad()
        {
            ProcessStartInfo NotePad = new ProcessStartInfo();
            NotePad.FileName = "notepad.exe";
            Process.Start(NotePad);

           }

    }
}
