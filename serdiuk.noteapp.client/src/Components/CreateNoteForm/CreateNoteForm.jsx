import React, { useContext } from 'react'
import { CreateNoteContext } from '../../App'

const CreateNoteForm = () => {


    const createNoteHandler = useContext(CreateNoteContext)

    return (
        <form onSubmit={(e) => {e.preventDefault(); createNoteHandler(e.target.title.value, e.target.details.value) }}>
            <div className="form-group">
                <label className="form-label" htmlFor="titleInput">Title</label>
                <input name='title' type="text" className="form-control" id="titleInput" placeholder="Enter title" />
            </div>
            <div className="form-group">
                <label className="form-label" htmlFor="detailsInput">Details</label>
                <input type="text" name='details' className="form-control" id="detailsInput" placeholder="Enter details" />
            </div>
            <button type="submit" class="btn btn-primary m-3">Submit</button>
        </form>
    )
}

export default CreateNoteForm