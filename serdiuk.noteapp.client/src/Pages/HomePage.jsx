import React, { useEffect, useState } from 'react'
import NotesListComponent from '../Components/NotesList/NotesListComponent'
import PaginationComponent from '../Components/Pagination/PaginationComponent'
import { getAllUserNotes } from '../utils/Services/NotesService';
import CreateNoteButton from '../Components/CreateNoteButton/CreateNoteButton';

const HomePage = () => {
    const [currentPage, setCurrentPage] = useState(0);
    const [notes, setNotes] = useState([])

    useEffect(()=>{
        async function fetchNotes(){
            let notes = await getAllUserNotes(currentPage);
            setNotes(notes)
        }
        fetchNotes()
    },[])

    return (
    <div>
        <NotesListComponent notes={notes}/>
        <CreateNoteButton/>
        <PaginationComponent totalPages={10} currentPage={currentPage} onPageChange={(i)=>{setCurrentPage(i)}}/>
    </div>
  )
}

export default HomePage