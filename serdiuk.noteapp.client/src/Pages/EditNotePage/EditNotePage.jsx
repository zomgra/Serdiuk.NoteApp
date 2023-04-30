import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { editNoteHandler, getNoteById } from '../../utils/Services/NotesService';
import NoteViewEdit from '../../Components/NoteViewEdit/NoteViewEdit';
import BackToHomeButton from '../../Components/BackToHomeButton/BackToHomeButton';

const EditNotePage = () => {

    const [note,setNote] = useState();
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        async function fetchNote() {
            var note = await getNoteById(id);
            setNote(note);
        }
        fetchNote();
    }, [id])

    async function applyEditHandle(idNote,title,details) {
        var newId = await editNoteHandler(idNote,title,details);
        navigate('/');
        id = newId;  
    }

    if(!note)
    return(<>LOADING</>)

    return (
        <div>
            <BackToHomeButton/>
            <NoteViewEdit applyEditHandle={applyEditHandle} note={note}/>
        </div>
    )
}

export default EditNotePage