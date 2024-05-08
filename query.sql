CREATE TABLE Subjects (
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    TrialID INT NOT NULL,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    DOB DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    EnrollmentStatus NVARCHAR(20) NOT NULL,
    FOREIGN KEY (TrialID) REFERENCES dbo.Trials(TrialID)
);

INSERT INTO Subjects (TrialID, FirstName, LastName, DOB, Gender, EnrollmentStatus)
VALUES
(3, 'John', 'Doe', '1985-05-15', 'Male', 'Enrolled'),
(3, 'Jane', 'Smith', '1990-11-22', 'Female', 'Screened'),
(4, 'Alice', 'Johnson', '1993-07-30', 'Female', 'Enrolled'),
(4, 'Bob', 'Brown', '1988-01-16', 'Male', 'Completed'),
(5, 'Charlie', 'Davis', '1992-09-11', 'Male', 'Dropped'),
(5, 'Diana', 'Martinez', '1987-03-14', 'Female', 'Enrolled');

SELECT * FROM dbo.Subjects
