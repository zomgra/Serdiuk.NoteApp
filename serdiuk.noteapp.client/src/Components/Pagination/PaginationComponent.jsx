import React from 'react'

const PaginationComponent = ({ currentPage, totalPages, onPageChange }) => {
    const pages = [];

    // создаем список страниц
    for (let i = 1; i <= totalPages; i++) {
      pages.push(
        <li className={`page-item ${i === currentPage ? "active" : ""}`} key={i}>
          <button className="page-link" onClick={() => onPageChange(i)}>
            {i}
          </button>
        </li>
      );
    }
  
    return (
      <nav aria-label="Page navigation">
        <ul className="pagination">
          <li className={`page-item ${currentPage === 1 ? "disabled" : ""}`}>
            <button
              className="page-link"
              onClick={() => onPageChange(currentPage - 1)}
              tabIndex="-1"
            >
              Previous
            </button>
          </li>
          {pages}
          <li
            className={`page-item ${
              currentPage === totalPages ? "disabled" : ""
            }`}
          >
            <button
              className="page-link"
              onClick={() => onPageChange(currentPage + 1)}
            >
              Next
            </button>
          </li>
        </ul>
      </nav>
    );
}

export default PaginationComponent