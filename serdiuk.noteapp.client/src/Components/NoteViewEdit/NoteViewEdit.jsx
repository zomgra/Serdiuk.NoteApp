import React from 'react'
import NoteDate from '../NoteDate/NoteDate'
import NoteTitleEdit from './NoteTitleEdit'
import NoteDetailsEdit from './NoteDetailsEdit'

const NoteViewEdit = ({ note, applyEditHandle }) => {
    return (
        <div className="container col-3 border border-dark rounded my-3">
            <form onSubmit={(e) => {e.preventDefault(); applyEditHandle(note.id, e.target.title.value, e.target.details.value) }}>
                <div className="row my-2">
                    <div className="col">
                        <NoteTitleEdit title={note.title} applyEditHandle={applyEditHandle} />
                    </div>
                </div>
                <div className="row my-2">
                    <div className="col">
                        <NoteDetailsEdit details={note.details} applyEditHandle={applyEditHandle} />
                    </div>
                </div>
                <div className='row my-2'>
                    <div className="col">
                        <NoteDate createDate={note.createDate} editDate={note.dateTime} isEdit={note.isEdit} />
                    </div>
                </div>
                <div className='row m-3'>
                    <div className='col'>
                        <button type='submit' className='btn btn-success'>Apply</button>
                    </div>
                </div>
            </form>
        </div>
    )
}

export default NoteViewEdit