using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;   // para usar a função Include

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;           //declaração de dependencia do context do EntityFramework

        public SalesRecordService(SalesWebMvcContext context)   //declaração de dependencia do context do EntityFramework
        {
            _context = context;
        }

        /* Operação Síncrona, depois desse bloco anotado vamos fazer a operação Assíncrona para ficar mais rapido o sistema
        public List<SalesRecord> FindByDate(DateTime? minDate, DateTime? maxDate) //operação de busca, o ? significa opcional
        {
            //construindo objeto iqueryable, que é o objeto que podemos construir as consultas em cima dele
            //a partir do dbcontext do salesrecord
            //essa declaração vai pegar um objeto do tipo db7 para um objeto do tipo iqueryable
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue) //esta testando se foi informado uma data minima, pois era opcional
            {                     // se sim vamos adcionar uma restrição na data minima
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            //return result.ToList();  //nesse ponto já faria a lista, mas vamos fazer abixo um join com outras tabelas

            return result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToList();
        }
        */
        //Operação Assíncrona
        //Em vez de ser uma Lista, vai ser um Task dessa Lista, colocar async na frente do Task, e mudamos o nome da função de FindByDate para FindByDateAsync somente como boa pratica.
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) //operação de busca, o ? significa opcional
        {
            //construindo objeto iqueryable, que é o objeto que podemos construir as consultas em cima dele
            //a partir do dbcontext do salesrecord
            //essa declaração vai pegar um objeto do tipo db7 para um objeto do tipo iqueryable
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue) //esta testando se foi informado uma data minima, pois era opcional
            {                     // se sim vamos adcionar uma restrição na data minima
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            //return result.ToList();  //nesse ponto já faria a lista, mas vamos fazer abixo um join com outras tabelas

            return await result  //Assincrona: colocar a palavra await na frente
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync(); //Assincrona: trocar .ToList por .ToListAsync
        }


    }
}
