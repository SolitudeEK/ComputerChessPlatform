import Engine from "./components/Engine";
import { useState, useEffect } from 'react';
import API from "../logic/API";

const Admin = () =>{
	const [engines, setEngines] = useState([]);
	useEffect(() => { 
		API.getEnginesToApprove().then(function(res) {
            setEngines(res.data.engines.map(elm => <Engine key = {elm} name = {elm}/>))
        });
	}, []);
	return(
		<div>
		{engines}
		</div>
		);
}
export default Admin;