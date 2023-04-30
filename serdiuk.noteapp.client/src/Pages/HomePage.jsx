import React, { useEffect, useState } from 'react'
import NotesListComponent from '../Components/NotesList/NotesListComponent'
import PaginationComponent from '../Components/Pagination/PaginationComponent'
import { deleteNoteHandler, getAllUserNotes } from '../utils/Services/NotesService';
import CreateNoteButton from '../Components/CreateNoteButton/CreateNoteButton';
import { useNavigate } from 'react-router-dom';

const HomePage = () => {
    const [currentPage, setCurrentPage] = useState(0);
    const [notes, setNotes] = useState([])

    const navigate = useNavigate();

    async function fetchNotes() {
        let notes = await getAllUserNotes(currentPage);
        setNotes(notes)
    }
    useEffect(() => {
        fetchNotes()
    }, [currentPage])

    function handleNoteEdit(id) {
        navigate(`edit/${id}`);
    }

    async function handleNoteDelete(id) {
        // eslint-disable-next-line no-restricted-globals
        var canDelete = confirm("Do you really want to delete note?");
        console.log(canDelete); 
        if(canDelete) {
            await deleteNoteHandler(id)
            .then(id=>fetchNotes());
         }
    }

    function onClickCreateNoteButton() {
        navigate('/create');
    }

    return (
        <div>
            <NotesListComponent handleEditNote={handleNoteEdit} handleNoteDelete={handleNoteDelete} notes={notes} />
            <CreateNoteButton createNoteHandler={onClickCreateNoteButton} />
            <PaginationComponent totalPages={10} currentPage={currentPage} onPageChange={(i) => { setCurrentPage(i) }} />
        </div>
    )
}

export default HomePage