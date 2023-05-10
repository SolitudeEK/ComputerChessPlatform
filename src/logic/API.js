import config from "./config.json";
import axios from 'axios';
class API {
    static async getEnginesInUse() {
        console.log("213");
        console.log(axios.defaults.headers.common['Authorization']);
        return await axios.get(config.API_URL + "/management/engines");
    }
    static setToken(token){
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + token;
    }
    static async upload(name, file) {
        const formData = new FormData();
        formData.append('file', file);
        await axios.post(config.API_URL + "/management/upload/" + name, formData).then((response) => {
                console.log("File uploaded successfully!");
            })
            .catch((error) => {
                console.error("Failed to upload file:", error);
            });
    }
    static async getEnginesToApprove() {
        return await axios.get(config.API_URL + "/management/newengines");
    }
    static async downloadEngine(name) {
        const response = await axios.get(config.API_URL + "/management/download/" + name, {
            responseType: 'blob', // This is important to indicate that the response type is a blob
        });
        const url = window.URL.createObjectURL(new Blob([response.data]));
        const link = document.createElement('a');
        link.href = url;
        link.setAttribute('download', name+".1-linux-bmi2");
        document.body.appendChild(link);
        link.click();
    }

    static async approveEngine(name) {
        await axios.post(config.API_URL + "/management/approve/" + name);
    }
}


export default API;