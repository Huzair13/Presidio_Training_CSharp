const quizzesPerPage = 6;
let currentPage = 1;

const token = localStorage.getItem('token');
if (!token) {
    window.location.href = '/Home/Home.html'
}


const renderQuizzes = (quizzesToRender) => {
    const quizGrid = document.getElementById('quiz-grid');
    quizGrid.innerHTML = '';

    quizzesToRender.forEach(quiz => {
        const col = document.createElement('div');
        col.className = 'col-lg-4 col-md-6 mb-4';

        const randomImageNumber = Math.floor(Math.random() * 10) + 1;
        const imageUrl = `/Assets/Images/Quiz/Quiz${randomImageNumber}.jpg`;

        col.innerHTML = `
            <div class="card border-0 shadow-lg">
                <img src="${imageUrl}" class="card-img-top rounded-top quiz-image" alt="${quiz.quizName} Image">
                <div class="card-body">
                    <h5 class="card-title text-center">${quiz.quizName}</h5>
                    <p class="card-text text-center">${quiz.quizDescription}</p>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item d-flex flex-wrap flex-column flex-sm-row justify-content-between word-wrap-custom"><strong>Number of Questions:</strong> ${quiz.quizId}</li>
                        <li class="list-group-item d-flex flex-wrap flex-column flex-sm-row justify-content-between word-wrap-custom"><strong>Number of Questions:</strong> ${quiz.numOfQuestions}</li>
                        <li class="list-group-item d-flex flex-wrap flex-column flex-sm-row justify-content-between word-wrap-custom"><strong>Points:</strong> ${quiz.totalPoints}</li>
                        <li class="list-group-item d-flex flex-wrap flex-column flex-sm-row justify-content-between word-wrap-custom"><strong>Time Limit:</strong> ${quiz.timelimit} minutes</li>
                    </ul>
                </div>
                <div class="card-footer bg-white border-top-0 text-right text-center">
                    <button class="btn useQuizButton btn-sm use-quiz-btn" data-quiz-id="${quiz.quizId}">Use Quiz</button>
                </div>
            </div>
        `;

        quizGrid.appendChild(col);
    });
    document.querySelectorAll('.use-quiz-btn').forEach(button => {
        button.addEventListener('click', function () {
            const confirmation = confirm("Are you sure you want to use the Quiz?");
            if (confirmation) {
                const quizId = parseInt(this.getAttribute('data-quiz-id'));
                fetch('http://localhost:5273/api/Quiz/CreateQuizByExistingQuiz', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${token}`
                    },
                    body: JSON.stringify({
                        quizId: quizId
                    })
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        window.location.href = `/UseQuiz/UseQuiz.html?quizID=${data.quizId}`;
                    })
                    .catch(error => {
                        console.error('Error fetching quizzes:', error);
                    });
            }
        });
    });
};

// QUIZ IMAGE
const style = document.createElement('style');
style.textContent = `
    .quiz-image {
        width: 100%;
        height: 200px; 
        object-fit: cover;
    }
`;
document.head.appendChild(style);

const renderPagination = (totalQuizzes, quizzesPerPage, currentPage) => {
    const paginationContainer = document.querySelector('.pagination');
    paginationContainer.innerHTML = '';
    const pageCount = Math.ceil(totalQuizzes / quizzesPerPage);

    if (currentPage > 1) {
        const prevItem = document.createElement('li');
        prevItem.className = 'page-item';
        prevItem.innerHTML = `<a class="page-link" href="#" data-page="${currentPage - 1}">Previous</a>`;
        paginationContainer.appendChild(prevItem);
    }

    const startPage = Math.max(1, currentPage - 1);
    const endPage = Math.min(pageCount, currentPage + 1);

    for (let i = startPage; i <= endPage; i++) {
        const pageItem = document.createElement('li');
        pageItem.className = `page-item ${i === currentPage ? 'active' : ''}`;
        pageItem.innerHTML = `<a class="page-link" href="#" data-page="${i}">${i}</a>`;
        paginationContainer.appendChild(pageItem);
    }

    if (currentPage < pageCount) {
        const nextItem = document.createElement('li');
        nextItem.className = 'page-item';
        nextItem.innerHTML = `<a class="page-link" href="#" data-page="${currentPage + 1}">Next</a>`;
        paginationContainer.appendChild(nextItem);
    }

    document.querySelectorAll('.page-link').forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();
            const page = parseInt(this.getAttribute('data-page'));
            currentPage = page;
            const start = (page - 1) * quizzesPerPage;
            const end = start + quizzesPerPage;
            renderQuizzes(quizzes.slice(start, end));
            renderPagination(totalQuizzes, quizzesPerPage, currentPage);
        });
    });
};

let quizzes = [];

const sortAZBtn = document.getElementById('sort-az');
const sortZABtn = document.getElementById('sort-za');

document.addEventListener('DOMContentLoaded', () => {

    const logoutButton = document.getElementById('logoutbtn');
    const logoutModal = new bootstrap.Modal(document.getElementById('logoutModal'));
    const confirmLogoutButton = document.getElementById('confirmLogoutButton');

    const confirmModal = new bootstrap.Modal(document.getElementById('confirmModal'));
    const confirmButton = document.getElementById('confirmBtn');

    logoutButton.addEventListener('click', function (event) {
        event.preventDefault();
        logoutModal.show();
    });

    confirmLogoutButton.addEventListener('click', function (event) {
        event.preventDefault();
        localStorage.removeItem('token');
        localStorage.removeItem('userID');
        localStorage.removeItem('role');

        window.location.href = '/Login/Login.html';
    });



    const useQuizButton = document.getElementById('useQuizBtn');
    let originalQuizzes = [];
    const apiUrl = 'http://localhost:5273/api/ViewQuiz/GetAllQuizzes';
    fetch(apiUrl, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            originalQuizzes = data;
            quizzes = originalQuizzes.slice(0);
            // console.log(quizzes);
            document.getElementById('pagination-container').style.display = 'block';
            renderQuizzes(quizzes.slice(0, quizzesPerPage));
            renderPagination(quizzes.length, quizzesPerPage, 1);

        })
        .catch(error => {
            console.error('Error fetching quizzes:', error);
        });

    document.getElementById('search-button').addEventListener('click', () => {
        const quizId = document.getElementById('quiz-id-input').value.trim();

        if (quizId === '') {
            quizzes = originalQuizzes.slice(0);
        } else {
            quizzes = originalQuizzes.filter(quiz => quiz.quizId.toString() === quizId);
        }

        currentPage = 1;
        renderQuizzes(quizzes.slice(0, quizzesPerPage));
        renderPagination(quizzes.length, quizzesPerPage, 1);
    });

    document.getElementById('filter-button').addEventListener('click', () => {
        const quizType = document.getElementById('quizType').value;
        const isMultipleAllowed = document.getElementById('isMultipleAllowed').value;

        quizzes = originalQuizzes.filter(quiz => {
            let matchesType = true;
            let matchesMultiple = true;

            if (quizType !== '') {
                matchesType = quiz.quizType === quizType;
            }

            if (isMultipleAllowed !== '') {
                matchesMultiple = quiz.isMultpleAllowed.toString() === isMultipleAllowed;
            }

            return matchesType && matchesMultiple;
        });

        currentPage = 1;
        renderQuizzes(quizzes.slice(0, quizzesPerPage));
        renderPagination(quizzes.length, quizzesPerPage, 1);
    });

    function sortQuizzes(order) {
        if (order === 'az') {
            quizzes.sort((a, b) => a.quizName.toLowerCase().localeCompare(b.quizName.toLowerCase()));
        } else if (order === 'za') {
            quizzes.sort((a, b) => b.quizName.toLowerCase().localeCompare(a.quizName.toLowerCase()));
        }
        currentPage = 1;
        renderQuizzes(quizzes.slice(0, quizzesPerPage));
        renderPagination(quizzes.length, quizzesPerPage, 1);
    }

    sortAZBtn.addEventListener('click', () => {
        sortQuizzes('az');
    });

    sortZABtn.addEventListener('click', () => {
        sortQuizzes('za');
    });
});
