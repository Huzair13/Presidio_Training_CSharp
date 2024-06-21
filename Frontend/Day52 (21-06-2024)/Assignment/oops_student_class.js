// Base class
class Person {
    constructor(name, age) {
        //ENCAPSULATION
        this._name = name; 
        this._age = age;
    }

    //GETTER
    getName() {
        return this._name;
    }
    getAge() {
        return this._age;
    }

    // SETTER
    setAge(age) {
        this._age = age;
    }
    setName(name) {
        this._name = name;
    }

    //DISPLAY 
    displayDetails() {
        console.log(`Name: ${this._name}, Age: ${this._age}`);
    }
}

//INHERITANCE
class Student extends Person {
    constructor(name, age, studentId) {
        super(name, age); 
        this._studentId = studentId; 
    }

    //GETTER
    getStudentId() {
        return this._studentId;
    }

    //POLYMORPHISM OVERRRIDING
    displayDetails() {
        console.log(`Name: ${this._name}, Age: ${this._age}, Student ID: ${this._studentId}`);
    }

    study() {
        console.log(`${this._name} is Doing Assignment.`);
    }
}


let student1 = new Student("Huzair", 22, "101");
student1.displayDetails(); 
student1.study(); 
