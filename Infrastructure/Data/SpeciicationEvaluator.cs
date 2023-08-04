﻿using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpeciicationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> specification)
        {
            var query = inputQuery.AsQueryable();
            if(specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }
            query = specification.Includes.Aggregate(query,
                (current,include)=>current.Include(include));
            return query;
        }
    }
}
