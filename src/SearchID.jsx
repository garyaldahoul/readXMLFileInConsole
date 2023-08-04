import axios from "axios";
import {useState, useEffect } from "react";
import { createAPIEndpoint } from "./api";
import { ENDPOINTS } from "./api";
import NavBar from "./NavBar";
const SearchID =()=>{
    const targetID = 42007;
    const [searchID,setSearchID] = useState("");
    const [result,setResult] = useState("");
    const [message,setMessage] = useState("")
    const [error,setError] = useState("")
    const resultStyle ={
       color:result?.id ==targetID ?"green":"yellow",
       fontSize:"20px",
       padding:"10px",
       margin:"5px",
       border:"1px solid #fff"
    }
  const  handleSubmit =async(e)=>{
        e.preventDefault()
        setMessage("")
        setError("")

        console.log(searchID)
        await axios.get('https://localhost:7026/api/TransUnit/'+searchID)
        .then(({data})=>{
          setMessage(data.id==targetID?"Right Target":"The ID exit, but it is not the required target.")
            setResult(data);

        })
        .catch(err=>{
            setError("Invaild ID...!")
            console.log("Error")})
        .finally(()=>{setSearchID("")})
    }

    return(
        <>
         <NavBar />
        <form onSubmit={()=>handleSubmit}>
            <input 
            id="search"
            type="search" 
            placeholder="Enter ID..." 
            onChange={(e)=>setSearchID(e.target.value)}
            value={searchID}
            />
            <button type="submit" onClick={handleSubmit}>Go</button>

        </form>

        {result && !error &&
       (<div style={resultStyle}> <div>ID : {result.id}</div>
        <div>Target : {result?.target}</div>
        <div>Source : {result.source}</div>
        <div>{message}</div>
        </div>)}
       {error &&
        <div style={{"color":"red","fontSize":"20px"}}>{error}</div>}
        </>
    )
}

export default SearchID;