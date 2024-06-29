const quizzesPerPage = 12;
let currentPage = 1;

const token=localStorage.getItem('token');

const renderQuizzes = (quizzesToRender) => {
    const quizGrid = document.getElementById('quiz-grid');
    quizGrid.innerHTML = '';

    quizzesToRender.forEach(quiz => {
        const col = document.createElement('div');
        col.className = 'col-lg-4 col-md-6 mb-4';

        const randomImageNumber = Math.floor(Math.random() * 10) + 1;
        const imageUrl = `Assets/Images/Quiz/Quiz${randomImageNumber}.jpg`;

        col.innerHTML = `
            <div class="card border-0 shadow-sm">
                <img src="${imageUrl}" class="card-img-top rounded-top quiz-image" alt="${quiz.quizName} Image">
                <div class="card-body">
                    <h5 class="card-title text-center">${quiz.quizName}</h5>
                    <p class="card-text text-center">${quiz.quizDescription}</p>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item"><strong>Number of Questions:</strong> ${quiz.numOfQuestions}</li>
                        <li class="list-group-item"><strong>Points:</strong> ${quiz.totalPoints}</li>
                        <li class="list-group-item"><strong>Time Limit:</strong> ${quiz.timelimit} minutes</li>
                    </ul>
                </div>
                <div class="card-footer bg-white border-top-0 text-right text-center">
                    <button class="btn btn-primary btn-sm">Use Quiz</button>
                </div>
            </div>
        `;

        quizGrid.appendChild(col);
    });
};

//QUIZ IMAGE
const style = document.createElement('style');
style.textContent = `
    .quiz-image {
        width: 100%;
        height: 200px; /* Adjust as per your design requirements */
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
        link.addEventListener('click', function(e) {
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

document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'http://localhost:5273/api/ViewQuiz/GetAllQuizzes';
    fetch(apiUrl, {
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
        quizzes = data;
        console.log(quizzes);
        renderQuizzes(quizzes.slice(0, 3));

        document.getElementById('see-all-btn').addEventListener('click', function() {
            this.style.display = 'none';
            document.getElementById('pagination-container').style.display = 'block';
            renderQuizzes(quizzes.slice(0, quizzesPerPage));
            renderPagination(quizzes.length, quizzesPerPage, 1);
        });
    })
    .catch(error => {
        console.error('Error fetching quizzes:', error);
    });
});
