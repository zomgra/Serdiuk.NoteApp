import React, {useState} from 'react'

const NoteTitleEdit = ({ title }) => {

    const [value, setValue] = useState(title);
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
                className="form-control mx-2"
                value={value}
                name='title'
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

export default NoteTitleEdit