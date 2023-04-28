import React from 'react'

const CreateNoteButton = ({createNoteHandler}) => {
  return (
    <div>
       <button onClick={createNoteHandler} className='btn btn-lg btn-primary-outline'>Create New Note</button> 
    </div>
  )
}

export default CreateNoteButton