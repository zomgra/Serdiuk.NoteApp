import React from 'react'
import { useNavigate } from 'react-router-dom';


const BackToHomeButton = () => {
    
    const navigate = useNavigate();
  return (
    <button className='btn btn-info m-2' onClick={()=>navigate('/')}>Back to home</button>
  )
}

export default BackToHomeButton