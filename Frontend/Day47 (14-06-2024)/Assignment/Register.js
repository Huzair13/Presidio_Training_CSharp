document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('registrationForm');
    const nameInput = document.getElementById('name');
    const phoneInput = document.getElementById('phone');
    const dobInput = document.getElementById('dob');
    const emailInput = document.getElementById('email');
    const genderInputs = document.querySelectorAll('input[name="gender"]');
    const genderInput = document.getElementById('genderInputDiv');
    const qualificationInputs = document.querySelectorAll('input[name="qualification"]');
    const qualificationInput =document.getElementById('QualificationDiv');
    const professionInput = document.getElementById('profession');
    const formErrors = document.getElementById('formErrors');
  
    const professions = ['Engineer', 'Doctor', 'Teacher','Artist','Lawyer']; 
    const professionsSet = new Set(professions);
  
    // PROFESSION
    professions.forEach(profession => {
      const option = document.createElement('option');
      option.value = profession;
      document.getElementById('professions').appendChild(option);
    });
  
    // SUBMIT BUTTON
    form.addEventListener('submit', function(event) {
      event.preventDefault();
      const isValid = validateForm();
      if (isValid) {
        form.submit();
      } else {
        showFormErrors();
      }
    });
  
    // VALIDATE
    function validateForm() {
      let isValid = true;
      resetErrors();
  
      // NAME
      if (nameInput.value.trim() === '') {
        setError(nameInput, 'Name is required.');
        isValid = false;
      }
  
      // PHONE
      if (phoneInput.value.trim() === '') {
        setError(phoneInput, 'Phone is required.');
        isValid = false;
      } else if (!/^(\+?\d{1,3}[- ]?)?\d{10}$/.test(phoneInput.value.trim())) {
        setError(phoneInput, 'Phone number is invalid.');
        isValid = false;
      }
  
      // DOB
      if (dobInput.value.trim() === '') {
        setError(dobInput, 'Date of Birth is required.');
        isValid = false;
      } else {
        const age = calculateAge(dobInput.value.trim());
        displayAge(age);
      }
  
      // EMAIL
      if (emailInput.value.trim() === '') {
        setError(emailInput, 'Email is required.');
        isValid = false;
      } else if (!isValidEmail(emailInput.value.trim())) {
        setError(emailInput, 'Email is invalid.');
        isValid = false;
      }
  
      // GENDER
      let genderSelected = false;
      var i = 0;
      while (!genderSelected && i < genderInputs.length) {
          if (genderInputs[i].checked) genderSelected = true;
          i++;        
      }
      if(!genderSelected){
        setError(genderInput,"Gender is Required");
        isValid=false;
      }
  
      // QUALIFICATION
      let qualificationSelected = false;
      qualificationInputs.forEach(input => {
        if (input.checked) {
          qualificationSelected = true;
        }
      });
      if (!qualificationSelected) {
        setError(qualificationInput, 'At least one qualification is required.');
        isValid = false;
      }
  
      // PROFESSION
      if (professionInput.value.trim() === '') {
        setError(professionInput, 'Profession is required.');
        isValid = false;
      } else if (!professionsSet.has(professionInput.value.trim())) {
        professionsSet.add(professionInput.value.trim());
        // UPDATE PROFESSION LIST
        const option = document.createElement('option');
        option.value = professionInput.value.trim();
        document.getElementById('professions').appendChild(option);
      }
  
      return isValid;
    }
  
    // CALCULATE DOB
    function calculateAge(dateOfBirth) {
      const dob = new Date(dateOfBirth);
      const today = new Date();
      let age = today.getFullYear() - dob.getFullYear();
      return age;
    }
  
    // DISPLAY AGE
    function displayAge(age) {
      let ageElement = document.getElementById('age');
      if (!ageElement) {
        ageElement = document.createElement('p');
        ageElement.id = 'age';
        ageElement.classList.add('text-gray-500', 'text-l', 'mt-1');
        dobInput.parentElement.appendChild(ageElement);
      }
      ageElement.innerText = `Age: ${age}`;
    }
  
    // SET ERROR
    function setError(input, message) {
      const errorElement = document.getElementById(input.id + 'Error');
      input.classList.add('border', 'border-red-500');
      errorElement.innerText = message;
    }
  
    // RESET ERROR
    function resetErrors() {
      formErrors.innerHTML = '';
      const inputs = form.querySelectorAll('.input-field');
      inputs.forEach(input => {
        input.classList.remove('border', 'border-red-500');
        const errorElement = document.getElementById(input.id + 'Error');
        errorElement.innerText = '';
      });
      genderInput.classList.remove('border', 'border-red-500');
      qualificationInput.classList.remove('border', 'border-red-500');
  
      // REMOVE AGE
      const ageElement = document.getElementById('age');
      if (ageElement) {
        ageElement.remove();
      }
    }
  
    // ON BLUR VALIDATE
    const inputs = form.querySelectorAll('.input-field');
    inputs.forEach(input => {
      input.addEventListener('blur', function() {
        validateForm();
      });
    });

    genderInput.addEventListener('blur', function() {
      validateForm();
    });
    qualificationInput.addEventListener('blur', function() {
      validateForm();
    });
  
    // CONSOLIDATE ERRORS
    function showFormErrors() {
      formErrors.innerHTML = 'Please fix the errors before submitting:';
      const errorElements = form.querySelectorAll('.error-text');
      errorElements.forEach(errorElement => {
        if (errorElement.innerText !== '') {
          formErrors.innerHTML += `<br>${errorElement.innerText}`;
        }
      });
    }
  
    // EMAIL FORMAT
    function isValidEmail(email) {
      return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
    }

  });
  