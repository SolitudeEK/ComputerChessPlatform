import { useKeycloak } from "@react-keycloak/web";

const PrivateRoute = ({ children }) => {
    const { keycloak } = useKeycloak();
    const isAdmin = keycloak.hasRealmRole("app_admin");

    return isAdmin ? children : null;
};

export default PrivateRoute;