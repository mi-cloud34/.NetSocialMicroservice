﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistance.Repositories;

public interface IRepository<T> : IQuery<T> where T : Entity
{
    //T Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
    //      IIncludableQueryable<T, object>>? include = null, bool enableTracking = true);

    //IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
    //                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    //                     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    //                     int index = 0, int size = 10,
    //                     bool enableTracking = true);

    //IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic,
    //                              Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    //                              int index = 0, int size = 10, bool enableTracking = true);
    T Get(Expression<Func<T, bool>> filter);
    List<T> GetAll(Expression<Func<T, bool>>? filter = null);
    T Add(T entity);
    T Follow(T entity);
    T Unfollow(T entity);
    T Update(T entity);
    T Delete(T entity);
}