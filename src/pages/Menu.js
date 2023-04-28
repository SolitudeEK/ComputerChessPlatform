import style from "../styles/pages/Menu.module.css"
import Button from "./components/Button"

const Menu = () => {
  return (
    <div className={style.menu}>
      <div className={style.menu_box}>
        <Button text="start game" dest="/game"/>
        <Button text="plug engine" dest="/plug"/>
        <Button text="statistics" dest="/menu"/>
      </div>
    </div>
  );
}

export default Menu;