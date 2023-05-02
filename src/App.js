import Menu from "./pages/Menu"
import Game from "./pages/Game"
import CreateGame from "./pages/CreateGame"
import Plug from "./pages/Plug"
import { Route, Routes, BrowserRouter } from "react-router-dom";

function App() {
  return (
    <div className="App">
    <BrowserRouter>
      <Routes>
          <Route path="/" element={<Menu />}/>
          <Route path="/game" element={<Game />}/>
          <Route path="/creategame" element={<CreateGame />}/>
          <Route path="/plug" element={<Plug />}/>
      </Routes>
    </BrowserRouter>
    </div>
  );
}

export default App;
