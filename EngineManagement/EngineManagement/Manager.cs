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
        private IList<string> moves { get; set; }
        public event EventHandler MoveMade;
        public TaskCompletionSource<bool> Finished { get; set; }
        public Manager(IStorage storage)
        {
            this.storage = storage;
        }
        public void CreateGame(string firstEngine, string secondEngine)
        {
            moves = new List<string>();
            Finished = new TaskCompletionSource<bool>();
            playerOne = new Engine(storage.GetEnginePath(firstEngine));
            playerTwo = new Engine(storage.GetEnginePath(secondEngine));
            playerOne.Subscribe(this);
            playerTwo.Subscribe(this);

        }
        internal void Output(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data != null)
            {
                if (outLine.Data.Contains("bestmove"))
                {
                    moves.Add(outLine.Data.Split(' ')[1]);
                    if (outLine.Data.Split(' ')[1] != "0000" &&
                        outLine.Data.Split(' ')[1] != "(none)")
                    {
                        if (!Repeated())
                        {
                            this.StartGame();
                            MoveMade(this, null);
                        }
                        else
                            Finished?.TrySetResult(true);
                    }
                    else
                        Finished?.TrySetResult(true);
                }
            }
        }

        public string GetLastMove()
            => moves.Last();

        public void StartGame()
        {
            if (moves.Count % 2 == 0)
                playerOne.Move(string.Join(" ", moves));
            else
                playerTwo.Move(string.Join(" ", moves));
        }

        private bool Repeated()
        {
            int num = moves.Count - 1;
            if (num > 5)
                return moves[num] == moves[num - 2] && moves[num] == moves[num - 4]
                && moves[num - 1] == moves[num - 3] && moves[num - 1] == moves[num - 5];
            return false;
        }

    }
}

