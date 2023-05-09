import Menu from "./pages/Menu";
import Game from "./pages/Game";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import CreateGame from "./pages/CreateGame";
import AuthorizedRoute from "./logic/AuthorizedRoute";
import PrivateRoute from "./logic/PrivateRoute";
import Admin from "./pages/Admin";
import Plug from "./pages/Plug";
import Nav from "./pages/components/Nav";
import keycloak from "./logic/Keycloak";
import { Route, Routes, BrowserRouter } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <ReactKeycloakProvider authClient={keycloak}>
      <Nav />
        <BrowserRouter>
          <Routes>
              <Route path="/" element={<Menu />}/>
              <Route path="/game" element={<Game authed={true}/>}/>
              <Route path="/creategame" element={<CreateGame authed={true}/>}/>
              <Route path="/plug" element={<AuthorizedRoute><Plug /></AuthorizedRoute>}/>
              <Route path="/admin" element={<PrivateRoute><Admin /></PrivateRoute>}/>
          </Routes>
        </BrowserRouter>
        </ReactKeycloakProvider>
    </div>
  );
}

export default App;
