import React from 'react'

const NoteView = ({note}) => {
  return (
    <div className="container">
    <div className="row">
      <div className="col">
        <h1>{note.title}</h1>
      </div>
    </div>
    <div className="row">
      <div className="col">
        <p>{note.details}</p>
        <p>Date: {note.dateTime.toLocaleDateString()}</p>
        <p>Time: {note.dateTime.toLocaleTimeString()}</p>
      </div>
    </div>
  </div>
  )
}

export default NoteView