import Menu from "./pages/Menu"
import Game from "./pages/Game"
import { Route, Routes, BrowserRouter } from "react-router-dom";

function App() {
  return (
    <div className="App">
    <BrowserRouter>
      <Routes>
          <Route path="/" element={<Menu />}/>
          <Route path="/game" element={<Game />}/>
      </Routes>
    </BrowserRouter>
    </div>
  );
}

export default App;
