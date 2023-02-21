using Castle.Components.DictionaryAdapter;
using HW_4_3_CodeFirst.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace HW_4_3_CodeFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(var dbContext = new DataBaseContext())
            {
                // 1. Запрос, который объединяет 3 таблицы и обязательно включает LEFT JOIN
                var employee = from emp in dbContext.Employee
                               join office in dbContext.Office
                               on emp.OfficeId equals office.OfficeId into temp
                               from result in temp.DefaultIfEmpty()

                               join emplpr in dbContext.EmployeeProject
                               on emp.EmployeeId equals emplpr.EmployeeId into temp2
                               from result2 in temp2.DefaultIfEmpty()
                               select new
                               {
                                   emp.EmployeeId,
                                   result.OfficeId,
                                   result2.Rate
                               };

                // 2. Запрос, который возвращает разницу между HiredDate и сегодня в днях. Фильтрация должна быть выполнена на сервере.
                var differenceOfDate = dbContext.Employee.AsNoTracking().Select(i => new
                {
                    id = i.EmployeeId,
                    diff = EF.Functions.DateDiffDay(i.HiredDate, DateTime.Now)
                });

                //    3.Запрос, который обновляет 2 сущности.Сделать в одной транзакции

                var transaction = dbContext.Database.BeginTransaction();
                try
                {
                    var client = dbContext.Client.Add(new Client()
                    {
                        CompanyName = "Micro",
                        Location = "Kiyv",
                        FoundedDate = new DateTime(2021, 3, 8),
                        Email = "micro@gmail.com"
                    });
                    dbContext.SaveChanges();

                    var emplyee = dbContext.Employee.Add(new Employee()
                    {
                        FirstName = "Kate",
                        LastName = "Polyakova",
                        HiredDate = new DateTime(2022, 2, 29),
                        DateOfBirth = new DateTime(1999, 6, 7),
                        OfficeId = 1,
                        TitleId = 1,
                        Office = new Office { Location = "Spain", Title = "Limo" },
                        Title = new Title { Name = "HR" }
                    });
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

                //    4.Запрос, который добавляет сущность Employee с Title и Office

                var addEmp = new Employee
                {
                    FirstName = "Alex",
                    LastName = "Ivanov",
                    HiredDate = new DateTime(2022, 1, 7),
                    DateOfBirth = new DateTime(1997, 7, 17),
                    OfficeId = 1,
                    TitleId = 1,
                    Office = new Office { Location = "Spain", Title = "Limo" },
                    Title = new Title { Name = "HR" }
                };
                dbContext.Employee.Add(addEmp);
                dbContext.SaveChanges();

                ////    5.Запрос, который удаляет сущность Employee

                var empl = new Employee { EmployeeId = 1 };
                dbContext.Employee.Remove(empl);
                dbContext.SaveChanges();

                //    6.Запрос, который группирует сотрудников по ролям и возвращает название роли(Title) если оно не содержит ‘a’

                var title = from emp in dbContext.Employee.AsNoTracking()
                             where (!emp.Title.Name.Contains("a"))
                             group emp by emp.Title.Name into e
                             select new { e.Key, count = e.Count() };

            }
        }
    }
}