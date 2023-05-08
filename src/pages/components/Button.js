import style from "../../styles/pages/Button.module.css"
import { Link } from "react-router-dom";
import React, { useState } from 'react';

const Button = (props) => {
    const { data } = props;
    return (<Link to={{
		pathname: props.dest		
	}} state= {data} 
		className = {style.button}>
		{props.text}
	</Link>);
}

export default Button;