import React, { useState, useEffect } from 'react';
import API from "../logic/API"
import Select from 'react-select';
import Convertor from "./utils/Convertor";

const CreateGame = () => {
    const [engines, setEngines] = useState([]);
    useEffect(() => {
        API.getEnginesInUse().then(function(a) {
            setEngines(Convertor.toOptions(a.data.engines))
        });
    }, []);
    const handleChangeOne = e => {
        console.log(e.label);
    }
    const handleChangeTwo = e => {
        console.log(e.label);
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
        </div>
    );
}

export default CreateGame;