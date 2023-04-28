import config from "./config.json";
const { EngineManagementClient } = require('../proto/output/EngineManagement_grpc_web_pb.js');
const { CreateGameRequest } = require('../proto/output/EngineManagement_pb.js');

class GameProcessor{
	constructor(nameOne, nameTwo){
		var client = new EngineManagementClient(config.GAME_URL);
		var request = new CreateGameRequest();
		request.setNameone(nameOne);
		request.setNametwo(nameTwo);
		return client.createGame(request);
	}
}

export default GameProcessor;