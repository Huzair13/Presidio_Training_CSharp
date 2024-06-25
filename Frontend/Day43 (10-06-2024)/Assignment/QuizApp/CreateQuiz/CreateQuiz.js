document.addEventListener('DOMContentLoaded', function() {
    const QuizNameInput = document.getElementById('quizName');
    const QuizDescriptionInput = document.getElementById('quizDescription');
    let currentPage = 1;
    const perPage = 8; 
    let totalQuestions = 0; 
    const token = localStorage.getItem('token');
    let questions = [];
    let selectedQuestions = []; 
    
    //INITIAL FETCH 
    fetchQuestions();

    //VALIDATION -- ON SUBMIT
    const forms = document.querySelectorAll('.needs-validation');
    forms.forEach(form => {
        form.addEventListener('submit', function(event) {
            event.preventDefault(); 

            if (!form.checkValidity()) {
                event.preventDefault(); 
                event.stopPropagation();
            }
            else if (selectedQuestions.length === 0) {
                alert('Please select at least one question.');
                return;
            } 
            else {
                event.preventDefault(); 
                createQuiz();
            }

            form.classList.add('was-validated');
        });
    });

    //VALIDATION ON ENTERING THE INPUT
    const inputs = document.querySelectorAll('input, select, textarea');
    inputs.forEach(input => {
        input.addEventListener('input', function() {
            validateInput(input);
        });
    });

    if(QuizDescriptionInput.addEventListener.value===''){
        validateInput(QuizDescriptionInput);
    }       

    //VALIDATE THE INPUT
    function validateInput(input) {
        if (input.checkValidity()) {
            input.classList.remove('is-invalid');
            input.classList.add('is-valid');
        } else {
            input.classList.remove('is-valid');
            input.classList.add('is-invalid');
        }
    }

    //FECTH QUESTION
    function fetchQuestions() {
        const apiUrl = `http://localhost:5273/api/ViewQuestion/GetAllQuestions`;
    
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
            questions = data;
            totalQuestions = data.total;
            renderQuestions(questions.slice(0,8));
            renderPagination(data.length, perPage, currentPage);
        })
        .catch(error => {
            console.error('Error fetching questions:', error);
        });
    }
    
    //RENDER QUESTIONS
    function renderQuestions(questions) {
        const questionGrid = document.getElementById('questionGrid');
        questionGrid.innerHTML = '';
    
        if (!Array.isArray(questions)) {
            console.error('Invalid questions data:', questions);
            return;
        }
        questions.forEach(question => {
            const questionCard = document.createElement('div');
            questionCard.className = 'question-card';
            const isChecked = selectedQuestions.includes(question.id); // Check if question is selected
            questionCard.innerHTML = `
                <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="question${question.id}" value="${question.id}" ${isChecked ? 'checked' : ''} onchange="updateSelectedQuestions(${question.id}, this.checked)">
                    <label class="form-check-label" for="question${question.id}">${question.questionText}</label>
                </div>
            `;
            questionGrid.appendChild(questionCard);
        });
    }

    //RENDER PAGINATION
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
                renderQuestions(questions.slice(start,end));
                renderPagination(totalQuizzes, quizzesPerPage, currentPage);
            });
        });
    };
    
    //CREATE QUIZ
    function createQuiz() {
        const quizName = QuizNameInput.value;
        const quizDescription = QuizDescriptionInput.value;
        const quizType = document.getElementById('quizType').value;
        const isMultipleAttemptAllowed = document.getElementById('isMultipleAttemptAllowed').checked;
        const timeLimit = parseInt(document.getElementById('timeLimit').value);
        
        console.log(selectedQuestions); 

        //QUIZ JSON DATA
        const quizData = {
            quizName: quizName,
            quizDescription: quizDescription,
            quizType: quizType,
            isMultipleAttemptAllowed: isMultipleAttemptAllowed,
            timeLimit: `00:${timeLimit}:00`,
            questionIds: selectedQuestions
        };

        const apiUrl = 'http://localhost:5273/api/Quiz/AddQuiz';
        fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(quizData)
        })
        .then(response => {
            console.log(quizData);
            console.log(response);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log('Quiz created successfully:', data);
            document.getElementById('quizForm').reset(); 
            selectedQuestions = []; // Clear the selectedQuestions array
            renderQuestions(questions.slice(0, perPage)); // Render first page of questions
            renderPagination(totalQuestions, perPage, currentPage); // Reset pagination if needed
        })
        .catch(error => {
            console.error('Error creating quiz:', error);
        });
    }

    //UPDATE CHECKED QUESTIONS
    window.updateSelectedQuestions = function(questionId, isChecked) {
        if (isChecked) {
            selectedQuestions.push(questionId);
        } else {
            const index = selectedQuestions.indexOf(questionId);
            if (index !== -1) {
                selectedQuestions.splice(index, 1);
            }
        }
    }

});
