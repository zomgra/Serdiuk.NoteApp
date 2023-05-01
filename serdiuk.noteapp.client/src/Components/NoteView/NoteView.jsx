import React from 'react'
import NoteDate from '../NoteDate/NoteDate'

const NoteView = ({ note, handleNoteEdit, handleNoteDelete }) => {

  return (
    <div className='card col-5 border border-dark rounded m-3'>
      <div className="container card-body  ">
        <div className="row">
          <div className="col">
            <h1 className='text-center'>
              <p className='card-title'>{note.title} {note.isEdit ? (<i class="fas fa-pencil-alt fa-sm"></i>) : (<></>)}</p>
            </h1>
          </div>
        </div>
        <div className="row">
          <div className="col">
            <p>{note.details}</p>
          </div>
          <div className="col">
            <NoteDate createDate={note.createDate} editDate={note.dateTime} isEdit={note.isEdit} />
          </div>
          <div className='row'>
            <div className='col my-2'>
              <button className='btn btn-warning mb-3 m-2' onClick={() => { handleNoteEdit(note.id) }}>Edit</button>
            </div>
            <div className='col my-2'>
              <button className='btn btn-danger mb-3 m-2' onClick={() => { handleNoteDelete(note.id) }}>Delete</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default NoteView