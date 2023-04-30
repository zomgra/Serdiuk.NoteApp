import React, {useState} from 'react'

const NoteDetailsEdit = ({details}) => {
    const [value, setValue] = useState(details);
    const [editing, setEditing] = useState(false);
  
    const handleInputChange = (event) => {
      setValue(event.target.value);
    };
  
    const handleEditClick = () => {
      setEditing(true);
    };
  
    const handleBlur = () => {
      setEditing(false);
    };

    return (
        <div className="input-group">
            <input
                type="text"
                className="mx-2 form-control"
                value={value}
                name='details'
                onChange={handleInputChange}
                onBlur={handleBlur}
                disabled={!editing}
            />
            <button type='button' className="btn input-group-append">
                <span className="input-group-text" onClick={handleEditClick}>
                <i class="fas fa-pencil-alt fa-sm"></i>
                </span>
            </button>
        </div>
    );
}

export default NoteDetailsEdit