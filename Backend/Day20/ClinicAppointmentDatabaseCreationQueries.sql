use dbClinicAppointment

create table Doctors (
    Id int constraint pk_doctorsID primary key,
    Name varchar(50) NOT NULL,
    Exp float NOT NULL,
    Qualification varchar(100),
    Specialization varchar(100),
    DateOfBirth date,
    Age as (datediff(year, DateOfBirth, getdate()) -
    case
        when dateadd(year, datediff(year, DateOfBirth, getdate()), DateOfBirth) > getdate() then 1
        else 0
    end)
);


create table Patient (
    id int constraint pk_patientID primary key,
    name varchar(30) not null,
    contactnum char(10) ,
    purpose varchar(100),
    age as (
        datediff(year, dateofbirth, getdate()) -
        case
            when dateadd(year, datediff(year, dateofbirth, getdate()), dateofbirth) > getdate() then 1
            else 0
        end
    ),
    dateofbirth date,
    admitdate date not null default getdate()
);

select * from Patient

create table Appointments (
    DoctorId int constraint fk_doctor references Doctors(id),
    PatientId int constraint fk_patient references Patient(id),
    AppointmentId int constraint pk_appointmentID primary key,
    AppointmentDateTime datetime,
    Purpose varchar(100),
);


sp_help Doctor
sp_help Appointments
sp_help Appointments

select * from Doctors
select * from Patient
select * from Appointments

--DELETE FROM Appointments;

--alter table patient
--alter column id int constraint pk_patientID Primary key;

--drop table Doctors