import React from "react";
import { useKeycloak } from "@react-keycloak/web";
import API from "../../logic/API";
import style from "../../styles/pages/Nav.module.css";

const Nav = () => {
 const { keycloak, initialized } = useKeycloak();

if(keycloak.authenticated){
  API.setToken(keycloak.token);
}
 return (
   <div>
         <nav className={style.bar}>
           <div className={style.logbut}>
                 {!keycloak.authenticated && (
                   <button
                     type="button"
                     className={style.log}
                     onClick={() => keycloak.login()}
                   >
                     Login
                   </button>
                 )}

                 {!!keycloak.authenticated && (
                   <button
                     type="button"
                     className={style.log}
                     onClick={() => keycloak.logout()}
                   >
                     Logout ({keycloak.tokenParsed.preferred_username})
                   </button>
                 )}
           </div>
         </nav>
   </div>
 );
};

export default Nav;