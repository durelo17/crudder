using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Crudder.Interfaces;
using log4net;

namespace Crudder
{
    /// <inheritdoc />
    public class EntityUpdater<TContext> : IEntityUpdater where TContext : DbContext, new()
    {
        #region Attributes
        private static readonly ILog _logger = LogManager.GetLogger(typeof(EntityUpdater<TContext>));
        #endregion Attributes

        #region Implementation of IEntityUpdater
        /// <inheritdoc />
        public virtual T Update<T>(T entity) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();

                    return entity;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return entity;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                                                                     .SelectMany(e => e.ValidationErrors)
                                                                     .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        /// <inheritdoc />
        public IEnumerable<T> UpdateAll<T>(params T[] entities) where T : class
        {
            return UpdateAllEntities(entities);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> UpdateAllAsync<T>(params T[] entities) where T : class
        {
            return await UpdateAllEntitiesAsync(entities);
        }

        /// <inheritdoc />
        public IEnumerable<T> UpdateAll<T>(IEnumerable<T> entities) where T : class
        {
            return UpdateAllEntities(entities);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> UpdateAllAsync<T>(IEnumerable<T> entities) where T : class
        {
            return await UpdateAllEntitiesAsync(entities);
        }
        #endregion Implementation of IEntityUpdater

        #region Methods
        private IEnumerable<T> UpdateAllEntities<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                var result = new List<T>();

                using (var context = new TContext())
                {
                    foreach (var entity in entities)
                    {
                        context.Set<T>().Attach(entity);
                        context.Entry(entity).State = EntityState.Modified;

                        result.Add(entity);
                    }

                    context.SaveChanges();

                    return result;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                        .SelectMany(e => e.ValidationErrors)
                        .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }

        private async Task<IEnumerable<T>> UpdateAllEntitiesAsync<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                var result = new List<T>();

                using (var context = new TContext())
                {
                    foreach (var entity in entities)
                    {
                        context.Set<T>().Attach(entity);
                        context.Entry(entity).State = EntityState.Modified;

                        result.Add(entity);
                    }

                    await context.SaveChangesAsync();

                    return result;
                }
            }
            catch (DbEntityValidationException exception)
            {
                string exceptionMessage = string.Join(", ", exception.EntityValidationErrors
                        .SelectMany(e => e.ValidationErrors)
                        .Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n"));

                _logger.Error("Exception caught ! " + exceptionMessage);
                throw;
            }
            catch (Exception exception)
            {
                _logger.Error("Exception caught !", exception);
                throw;
            }
        }
        #endregion Methods
    }
}