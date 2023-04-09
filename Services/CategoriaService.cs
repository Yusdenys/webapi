using webapi.Models;

namespace webapi.Services
{
    public class CategoriaService : ICategoryService
    {
        TareasContext context;

        public CategoriaService(TareasContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Categoria> Get()
        {
            return context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            var actualCategory = context.Categorias.Find(id);
            if(actualCategory != null)
            {
                actualCategory.Nombre = categoria.Nombre;
                actualCategory.Descripcion = categoria.Descripcion;
                actualCategory.Peso = categoria.Peso;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var categoria = context.Categorias.Find(id);
            if (categoria != null)
            {
                context.Remove(categoria);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoryService
    {
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);
        Task Update(Guid id, Categoria categoria);
        Task Delete(Guid id);
    }

}


