-- CREATE TABLE Visits (
--     VisitID INT IDENTITY(1,1) PRIMARY KEY,
--     SubjectID INT NOT NULL,
--     VisitType NVARCHAR(50) NOT NULL,
--     ScheduledDate DATE NOT NULL,
--     ActualDate DATE,
--     Notes NVARCHAR(MAX),
--     CONSTRAINT FK_Visits_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
-- );

-- INSERT INTO Visits (SubjectID, VisitType, ScheduledDate, ActualDate, Notes)
-- VALUES
-- (1, 'Initial Screening', '2023-10-01', NULL, 'Initial screening visit - no issues noted.'),
-- (1, 'Follow-Up', '2023-11-01', NULL, 'Follow-up visit scheduled post screening.'),
-- (2, 'Initial Screening', '2023-10-02', '2023-10-02', 'Completed on time.'),
-- (2, 'Routine Check', '2023-12-15', NULL, 'End of year routine check.'),
-- (3, 'Initial Screening', '2023-10-03', '2023-10-03', 'Screening completed, requires follow-up.'),
-- (3, 'Follow-Up', '2023-11-15', NULL, 'Follow-up for lab results.');

-- SELECT * FROM dbo.Visits
