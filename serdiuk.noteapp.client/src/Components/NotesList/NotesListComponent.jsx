import React from 'react'
import NoteView from '../NoteView/NoteView'

const NotesListComponent = ({notes, handleEditNote, handleNoteDelete}) => {

  if(!notes)
  return(<>LOADING</>)

  return (
    <div className='row'>
      {console.log(notes)}
        {notes.map((note)=><NoteView note={note} key={note.id} handleNoteEdit={handleEditNote} handleNoteDelete={handleNoteDelete}/>)}
    </div>
  )
}

export default NotesListComponent