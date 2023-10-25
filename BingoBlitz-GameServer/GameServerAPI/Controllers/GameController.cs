using BingoBlitz_GameService;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace BingoBlitz_GameServer.Controllers
{
    [ApiController]
    [Route("api/game/")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly Connector _connector;

        public GameController(ILogger<GameController> logger, Connector connector)
        {
            _logger = logger;
            _connector = connector;
        }

        [HttpPost]
        [Route("join")]
        public string JoinGame(string gameId)
        {
            if (gameId.Length != 6) return "No game found with the supplied code";

            return $"Joined game with ID {gameId}";
        }

        [HttpPost]
        [Route("save")]
        public ActionResult<string> SaveGame(string gameData)
        {
            if (_connector == null || _connector.Connection == null || !_connector.Connection.IsOpen)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service temporarily offline. Please try again later.");
            }

            using IModel channel = _connector.Connection.CreateModel();

            channel.QueueDeclare(queue: "game_data",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            byte[] body = Encoding.UTF8.GetBytes(gameData);

            channel.BasicPublish(exchange: "",
                routingKey: "game_data",
                basicProperties: null,
                body: body);

            return StatusCode(StatusCodes.Status202Accepted, "Game data has been accepted and is being handled.");
        }
    }
}