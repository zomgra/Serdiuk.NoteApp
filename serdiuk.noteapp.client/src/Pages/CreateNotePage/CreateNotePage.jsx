import React from 'react'
import CreateNoteForm from '../../Components/CreateNoteForm/CreateNoteForm'
import BackToHomeButton from '../../Components/BackToHomeButton/BackToHomeButton'

const CreateNotePage = () => {


    return (
        <div className='m-5 border p-3' style={{maxWidth:'450px', textAlign: 'center',}}>
            <BackToHomeButton/>
            <CreateNoteForm/>
        </div>
    )
}

export default CreateNotePage