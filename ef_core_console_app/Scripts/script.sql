
CREATE VIEW V_Teacher_Subject
AS
SELECT 
    t.Id AS TeacherId,
    t.FirstName,
    t.LastName,
    t.HireDate,
    s.Id AS SubjectId,
    s.Name AS SubjectName,
    s.Description AS SubjectDescription
FROM 
    People t
    INNER JOIN Subjects s ON t.SubjectId = s.Id
GO


CREATE PROCEDURE GetStudentByStudentNumber
    @StudentNumber NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM People p
    WHERE p.StudentNumber = @StudentNumber 
      AND p.Type = 'Student';  -- Use single quotes for string literals
END