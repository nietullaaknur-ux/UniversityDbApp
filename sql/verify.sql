USE UniversityDb;
GO
SELECT * FROM dbo.__EFMigrationsHistory;
SELECT * FROM dbo.Departments;
SELECT * FROM dbo.Teachers;
SELECT t.Id, t.FullName, d.Name AS Department
FROM dbo.Teachers AS t
JOIN dbo.Departments AS d ON d.Id = t.DepartmentId;
SELECT name FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.Teachers');
