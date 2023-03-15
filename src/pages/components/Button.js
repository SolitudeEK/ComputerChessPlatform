import style from "../../styles/pages/Button.module.css"
import { Link } from "react-router-dom";

const Button = (props) => {
	return (<Link to={props.dest} className = {style.button}>
		{props.text}
	</Link>);
}

export default Button;