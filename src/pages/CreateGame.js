import React, { useState, useEffect } from 'react';
import API from "../logic/API";
import Select from 'react-select';
import Convertor from "./utils/Convertor";
import Button from "./components/Button";
import style from "../styles/pages/CreateGame.module.css"

const CreateGame = () => {
    const [engines, setEngines] = useState([]);
    const [one, setOne] = useState("");
    const [two, setTwo] = useState("");
    useEffect(() => {
        API.getEnginesInUse().then(function(res) {
            setEngines(Convertor.toOptions(res.data.engines))
        });
    }, []);
    const handleChangeOne = e => {
        setOne(e.label);
    }
    const handleChangeTwo = e => {
        setTwo(e.label);
    }
    return (
        <div className={style.options}>
            <Select 
                placeholder="Select Option"
                options={engines}
                onChange={handleChangeOne}/>
            <h1/>
            <Select
                placeholder="Select Option"
                options={engines}
                onChange={handleChangeTwo}/>
            <div className={style.buttonPos}>
                <Button text="start" dest="/game" data={[one, two]} />
            </div>
        </div>
    );
}

export default CreateGame;