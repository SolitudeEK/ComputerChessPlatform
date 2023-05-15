import Engine from "./components/Engine";
import { useState, useEffect } from 'react';
import API from "../logic/API";
import style from "../styles/pages/Admin.module.css"

const Admin = () =>{
	const [engines, setEngines] = useState([]);
	useEffect(() => { 
		API.getEnginesToApprove().then(function(res) {
            setEngines(res.data.engines.map(elm => <Engine key = {elm} name = {elm}/>))
        });
	}, []);
	return(
		<div className = {style.engpos}>
		{engines}
		</div>
		);
}
export default Admin;