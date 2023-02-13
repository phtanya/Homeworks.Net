﻿--------------------------ДОМАШКА----------------------------

----------------------ЗАДАНИЕ №1-----------------------------
--Вывести всю информацию из таблицы Sales.Customer 
-------------------------------------------------------------

SELECT *
  FROM Sales.Customer

----------------------ЗАДАНИЕ №2-----------------------------
--Вывести всю информацию из таблицы Sales.Store отсортированную 
--по Name в алфавитном порядке
-------------------------------------------------------------

SELECT *
  FROM Sales.Store ORDER BY Name

----------------------ЗАДАНИЕ №3-----------------------------
--Вывести из таблицы HumanResources.Employee всю информацию
--о десяти сотрудниках, которые родились позже 1989-09-28
-------------------------------------------------------------

SELECT TOP 10 *
  FROM HumanResources.Employee 
  WHERE BirthDate > '1989-09-28'

----------------------ЗАДАНИЕ №4-----------------------------
--Вывести из таблицы HumanResources.Employee сотрудников
--у которых последний символ LoginID является 0.
--Вывести только NationalIDNumber, LoginID, JobTitle.
--Данные должны быть отсортированы по JobTitle по убиванию
-------------------------------------------------------------

SELECT NationalIDNumber, LoginID, JobTitle
  FROM HumanResources.Employee 
  WHERE LoginID LIKE '%0' 
  ORDER BY JobTitle DESC

----------------------ЗАДАНИЕ №5-----------------------------
--Вывести из таблицы Person.Person всю информацию о записях, которые были 
--обновлены в 2008 году (ModifiedDate) и MiddleName содержит
--значение и Title не содержит значение 
-------------------------------------------------------------

SELECT *
  FROM Person.Person
  WHERE ModifiedDate BETWEEN '2008-01-01' AND '2008-12-31'
  AND MiddleName IS NOT NULL
  AND Title IS NULL

----------------------ЗАДАНИЕ №6-----------------------------
--Вывести название отдела (HumanResources.Department.Name) БЕЗ повторений
--в которых есть сотрудники
--Использовать таблицы HumanResources.EmployeeDepartmentHistory и HumanResources.Department
-------------------------------------------------------------

SELECT DISTINCT d.Name
  FROM HumanResources.EmployeeDepartmentHistory hd 
  JOIN HumanResources.Department d
  ON hd.BusinessEntityID = d.DepartmentID
  WHERE hd.EndDate IS NULL

----------------------ЗАДАНИЕ №7-----------------------------
--Сгрупировать данные из таблицы Sales.SalesPerson по TerritoryID
--и вывести сумму CommissionPct, если она больше 0
-------------------------------------------------------------

SELECT SUM(CommissionPct) as CommissionPctSum
  FROM Sales.SalesPerson
  WHERE CommissionPct > 0
  GROUP BY TerritoryID

----------------------ЗАДАНИЕ №8-----------------------------
--Вывести всю информацию о сотрудниках (HumanResources.Employee) 
--которые имеют самое большое кол-во 
--отпуска (HumanResources.Employee.VacationHours)
-------------------------------------------------------------


SELECT *
  FROM HumanResources.Employee
  WHERE VacationHours in 
  (
  SELECT MAX(VacationHours)
  FROM HumanResources.Employee
  )

----------------------ЗАДАНИЕ №9-----------------------------
--Вывести всю информацию о сотрудниках (HumanResources.Employee) 
--которые имеют позицию (HumanResources.Employee.JobTitle)
--'Sales Representative' или 'Network Administrator' или 'Network Manager'
-------------------------------------------------------------

SELECT *
  FROM HumanResources.Employee
  WHERE JobTitle IN ( 'Sales Representative','Network Administrator','Network Manager')

----------------------ЗАДАНИЕ №10-----------------------------
--Вывести всю информацию о сотрудниках (HumanResources.Employee) и 
--их заказах (Purchasing.PurchaseOrderHeader). ЕСЛИ У СОТРУДНИКА НЕТ
--ЗАКАЗОВ ОН ДОЛЖЕН БЫТЬ ВЫВЕДЕН ТОЖЕ!!!
-------------------------------------------------------------


SELECT *
  FROM HumanResources.Employee e
  LEFT JOIN Purchasing.PurchaseOrderHeader o
  ON e.BusinessEntityID = o.EmployeeID