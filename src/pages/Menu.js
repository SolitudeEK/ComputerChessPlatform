import style from "../styles/pages/Menu.module.css"
import Button from "./components/Button"
import { useKeycloak } from "@react-keycloak/web"
const Menu = () => {
    const { keycloak } = useKeycloak();
    const renderAdmin = () => {
        if (keycloak.hasRealmRole("app_admin"))
            return (<Button text="engine manager" dest="/admin"/>);
        else
            return null;
    }
    const renderPlug = () => {
        if (keycloak.authenticated)
            return (<Button text="plug engine" dest="/plug"/>);
        else
            return null;
    }
    return (
        <div className={style.menu}>
      <div className={style.menu_box}>
        <Button text="start game" dest="/creategame"/>
        {renderPlug()}
        <Button text="statistics" dest="/menu"/>
        {renderAdmin()}
      </div>
    </div>
    );
}

export default Menu;