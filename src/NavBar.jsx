import { BrowserRouter, Link } from "react-router-dom";
import { Navigate } from "react-router-dom";
const NavBar =()=>{
    return(
        <nav>
        <ul className="navbar">
            <li> <Link className="nav-bar-link" to="/">Home</Link></li>
            <li><Link className="nav-bar-link" to="/transunitslist" >Trans Units</Link></li>
            <li><Link className="nav-bar-link" to="/search" >Search</Link></li>
        </ul>
        </nav>
    
    )
}

export default NavBar;