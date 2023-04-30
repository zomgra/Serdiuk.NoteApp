import React from 'react'

const NoteDate = ({ editDate, isEdit, createDate }) => {

    console.log(isEdit);
    return (
        <>
          {isEdit ? (
            <p>Last Change Date: {new Date(editDate).toLocaleString('en-US')}</p>
          ) : (
            <p>Created on: {new Date(createDate).toLocaleString('en-US')}</p>
          )}
        </>
      );
}

export default NoteDate