using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;  // usado para usar o Task, que é para chamar as operações assíncronas
using Microsoft.EntityFrameworkCore; // para usar o .ToListAsync


namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        /* Abaixo é um processamento Síncrono:
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
        */

        //abaixo vamos fazer um processamento Assíncrono:
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();  // await avisa o compilador que a operação é assincrona
        }



    }
}
