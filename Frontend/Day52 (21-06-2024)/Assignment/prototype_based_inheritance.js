function Person(firstName) {
    this.firstName = firstName;
}

Person.prototype.introduce = function() {
    console.log("Hi, I'm " + this.firstName);
};

function Student(firstName, studentID) {
    Person.call(this, firstName);
    this.studentID = studentID;
}

Student.prototype = Object.create(Person.prototype);

Student.prototype.constructor = Student;

Student.prototype.study = function() {
    console.log(this.firstName + " is Doing Assignment.");
};

let student1 = new Student("Huzair", "101");
student1.introduce(); 
student1.study(); 