import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import {useState, useEffect } from 'react';
import NavBar from './NavBar';
const TransUnitsList =()=> {
  const [list,setList]=useState()
    useEffect(()=>{
      axios.get('https://localhost:7026/api/TransUnit').then(({data})=>setList(data))
    },[])
  
  return (
    <div >
       <NavBar />
      <h1>Trans Units</h1>
      <table className='table'>
        <thead>
          <tr>
          <th>ID</th>
          <th>Target</th>
          <th>Source</th>
          </tr>
        </thead>
        <tbody>
      {list && list.map(transUnit=>(
        <tr key={transUnit.id}>
          <td>{transUnit.id}</td>
          <td>{transUnit.target}</td>
          <td>{transUnit.source}</td>
       </tr>
      ))}
      </tbody>
</table>
      
    </div>
  );
}

export default TransUnitsList;
