import style from "../../styles/pages/DragDropFile.module.css"
import React, { useState } from "react";
import { FileUploader } from "react-drag-drop-files";
import API from "../../logic/API"
const fileTypes = ["1-linux-bmi2", "04-x86-64-avx2"];

function DragDropFile() {
  const [file, setFile] = useState(null);
  const [input, setInput] = useState("name");
  const handleChange = (file) => {
    setFile(file);
  };
  function sendEngine () {
    API.upload(input, file);
  }
  return (
    <div>
      <label className= {style.engineName}>
        engine name:
        <input type="text" name="name" className={style.inputEngine } value={input} onInput={e => setInput(e.target.value)}/>
      </label>
      <FileUploader handleChange={handleChange} name="file" types={fileTypes} classes={style.fileUpload}/>
      <div onClick={sendEngine} className={style.inputButton}> send</div>
    </div >);
}

export default DragDropFile;