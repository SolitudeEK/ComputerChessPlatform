import config from "./config.json";
import axios from 'axios';

class API {
    static async getEnginesInUse() {
        return await axios.get(config.API_URL + "/management/engines")    
    }
}


export default API;