﻿using CacaCaracteres.Modelo;
using System.Linq.Expressions;

namespace CacaCaracteres.Repositorio;

public interface IGenericoRepositorio<T> where T : Base
{
    void Create(T entity);

    Task<T> WhereFirstAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> GetAllAsync();

    void Delete(T entity);

    void Update(T entity);
}
