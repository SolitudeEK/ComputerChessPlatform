using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineManagement
{
    public interface IManager
    {
        public event EventHandler MoveMade;
        public TaskCompletionSource<bool> Finished { get; set; }
        public void CreateGame(string firstEngine, string secondEngine);
        public void StartGame();
        public string GetLastMove();
    }
}
