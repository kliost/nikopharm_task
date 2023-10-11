using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nikopharm_task.Models;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace nikopharm_task.Services
{
    public interface IEmployeeManagerService
    {
        public Task Create(EmployeeModel employee);
        public Task Delete(int Id);
        public Task<EmployeeModel> GetById(int Id);
        public Task Update(EmployeeModel employee);
        public Task<List<EmployeeModel>> GetAll();

    }
    public class EmployeeManagerService : IEmployeeManagerService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeManagerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(EmployeeModel employee)
        {
            try
            {
                _context.employees.Add(employee);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Delete(int Id)
        {
            try
            {
                EmployeeModel employee = _context.employees.FirstOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    _context.employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<EmployeeModel>> GetAll()
        {
            List<EmployeeModel> employees = await _context.employees.ToListAsync();
            return employees;
        }

        public async Task<EmployeeModel> GetById(int Id)
        {
            try
            {
                EmployeeModel? employee = new EmployeeModel();
                employee = await _context.employees.FirstOrDefaultAsync(x => x.Id == Id);

                return employee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(EmployeeModel newEmployee)
        {
            try
            {
                _context.employees.Update(newEmployee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
