using APIdeCrud.Data.Map;
using APIdeCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIdeCrud.Data
{
    //Responsável por gerenciar a conexão com o banco de dados, mapear objetos para tabelas e executar consultas.
    public class SistemaTarefasDBContex : DbContext 
    {
        //Construtor da Classe 
        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options) 
            : base(options) 
        { 
        }

        //Cria as tabelas Usuarios e Tarefa
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            // Chama a implementação da classe base para garantir que configurações padrão sejam aplicadas
            base.OnModelCreating(modelBuilder);
        }
    }
}
