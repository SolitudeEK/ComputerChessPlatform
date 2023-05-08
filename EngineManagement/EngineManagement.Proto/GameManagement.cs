using Grpc.Core;
using System.Collections.Specialized;
using System.Diagnostics;

namespace EngineManagement.Proto
{
    public class GameManagement : EngineManagement.EngineManagementBase
    {
        private IManager game { get; set; }

        public GameManagement(IManager game)
        {
            this.game = game;
        }
        public override Task CreateGame(CreateGameRequest request, IServerStreamWriter<Move> responseStream, ServerCallContext context)
        {
            game.CreateGame(request.NameOne, request.NameTwo);
            void OnListChanged(object sender, EventArgs e)
            {
                responseStream.WriteAsync(game.GetLastMove().ToMove());
            }
            game.MoveMade += OnListChanged;
            game.StartGame();
            return Task.WhenAny(game.Finished.Task, Task.Delay(25000));
        }


    }
    internal static class Converter
    {

        public static Move ToMove(this string move)
            => move.Length == 4 ? new Move { From = move.Substring(0, 2), To = move.Substring(2, 2) } : 
            new Move { From = move.Substring(0, 2), To = move.Substring(2, 2), Transform = move[4].ToString() };
    }
}