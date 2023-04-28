import React from 'react'
import NoteView from '../NoteView/NoteView'

const NotesListComponent = ({notes}) => {

  if(!notes)
  return(<>LOADING</>)

  return (
    <div className='row'>
        {notes.map((note)=><NoteView note={note} key={note.id}/>)}
    </div>
  )
}

export default NotesListComponent