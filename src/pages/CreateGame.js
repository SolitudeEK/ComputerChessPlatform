import React, { useState, useEffect } from 'react';
import API from "../logic/API";
import Select from 'react-select';
import Convertor from "./utils/Convertor";
import Button from "./components/Button";

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
        <div>
          <Select
            placeholder="Select Option"
            options={engines}
            onChange={handleChangeOne}/>
          <Select
            placeholder="Select Option"
            options={engines}
            onChange={handleChangeTwo}/>
            <Button text="start" dest="/game" data={[one, two]} />
        </div>
    );
}

export default CreateGame;