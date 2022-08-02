namespace Pastelaria.Data.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public async Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return await _applicationDbContext.Usuarios
                .AsSingleQuery()
                .Where(x => x.Email.Equals(email))
                .Select(x => new Usuario
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Senha = x.Senha,
                    DataExpiracaoSenha = x.DataExpiracaoSenha,
                    IdUsuarioCadastro = x.IdUsuarioCadastro
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> BuscarAsync()
        {
            return await _applicationDbContext.Usuarios
                .AsSingleQuery()
                .Select(x => new Usuario
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Senha = x.Senha,
                    DataExpiracaoSenha = x.DataExpiracaoSenha,
                    IdUsuarioCadastro = x.IdUsuarioCadastro
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tarefa>> TodasTarefasAsync()
        {
            var query = _applicationDbContext.Tarefas
                .AsSingleQuery()
                .Include(x => x.UsuarioTarefas)
                .AsQueryable();
            return await query.Select(x => new Tarefa
                {
                    Id = x.Id,
                    IdTarefaStatus = x.IdTarefaStatus,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    DataCriacao = x.DataCriacao,
                    DataConclusao = x.DataConclusao,
                    UsuarioTarefas = x.UsuarioTarefas.Select(y => new UsuarioTarefa
                    {
                        IdUsuario = y.IdUsuario,
                        IdTarefa = y.IdTarefa
                    }).ToArray()
                }).ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> BuscarTarefasAsync(int id)
        {
            var query = _applicationDbContext.Tarefas
                .AsSingleQuery()
                .Where(x => x.IdUsuarioCadastro.Equals(id))
                .AsQueryable();
            return await query.Select(x => new Tarefa
                {
                    Id = x.Id,
                    IdTarefaStatus = x.IdTarefaStatus,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    DataCriacao = x.DataCriacao,
                    DataConclusao = x.DataConclusao,
                    IdUsuarioCadastro = x.IdUsuarioCadastro
                }).ToArrayAsync();
        }
    }
}