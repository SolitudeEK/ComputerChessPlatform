import Keycloak from "keycloak-js";
const keycloak = new Keycloak({
    url: "http://localhost:5003/auth/",
    realm: "Chess",
    clientId: "react_auth",
});

export default keycloak;