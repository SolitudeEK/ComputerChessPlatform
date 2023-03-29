using EngineStorage;
using Grpc.Core;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace EngineManagement
{
    public class Manager : IManager
    {
        private Engine playerOne { get; set; }
        private Engine playerTwo { get; set; }
        private IStorage storage { get; set; }
        private IList<string> Moves { get; set; }
        public event EventHandler MoveMade;
        public TaskCompletionSource<bool> Finished { get; set; }
        public Manager(IStorage storage)
        {
            this.storage = storage;
        }
        public void CreateGame(string firstEngine, string secondEngine)
        {
            Moves = new List<string>();
            Finished = new TaskCompletionSource<bool>();
            playerOne = new Engine(storage.GetEnginePath(firstEngine));
            playerTwo = new Engine(storage.GetEnginePath(secondEngine));
            playerOne.Subscribe(this);
            playerTwo.Subscribe(this);

        }
        internal void Output(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data.Contains("bestmove"))
            {
                Moves.Add(outLine.Data.Split(' ')[1]);
                if (outLine.Data.Split(' ')[1] != "0000" &&
                    outLine.Data.Split(' ')[1] != "(none)")
                {
                    this.StartGame(); //TODO Chek if moves repeat
                    MoveMade(this, null);
                }
                else
                    Finished?.TrySetResult(true);
            }
        }

        public string GetLastMove()
            => Moves.Last();

        public void StartGame()
        {
            if (Moves.Count % 2 == 0)
                playerOne.Move(string.Join(" ", Moves));
            else
                playerTwo.Move(string.Join(" ", Moves));
        }
    }
}

