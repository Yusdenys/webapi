using webapi.Models;

namespace webapi.Services
{
    public class TareasService : ITareaServices
    {
        TareasContext context;
        public TareasService (TareasContext tareasContext)
        {
            this.context = tareasContext;
        }

        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            context.Add(tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            var actualTarea = context.Tareas.Find(id);
            if (actualTarea != null)
            {
                actualTarea.Titulo = tarea.Titulo;
                actualTarea.Descripcion = tarea.Descripcion;
                actualTarea.PrioridadTarea = tarea.PrioridadTarea;
                actualTarea.Categoria = tarea.Categoria;
                actualTarea.Resumen = tarea.Resumen;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var tarea = context.Tareas.Find(id);
            if (tarea != null)
            {
                context.Remove(tarea);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITareaServices 
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);
    }
}
