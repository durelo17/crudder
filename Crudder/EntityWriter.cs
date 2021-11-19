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
    /// <inheritdoc cref="IEntityWriter"/>
    /// <summary>
    /// Utilise le type de <see cref="DbContext"/> spécifié via le type générique <typeparam name="TContext">TContext</typeparam>.
    /// </summary>
    /// <remarks>
    /// Implémente l'interface <see cref="IEntityWriter"/>.
    /// </remarks>
    public class EntityWriter<TContext> : IEntityWriter where TContext : DbContext, new()
    {
        #region Attributes
        private static readonly ILog _logger = LogManager.GetLogger(typeof(EntityWriter<TContext>));
        #endregion Attributes

        #region Implementation of IEntityWriter
        /// <inheritdoc cref="IEntityWriter"/>
        public virtual T AddOne<T>(T entity) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Add(entity);
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
        public virtual bool AddAll<T>(params T[] entities) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().AddRange(entities);
                    context.SaveChanges();

                    return true;
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

        public virtual bool AddAll<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().AddRange(entities);
                    context.SaveChanges();

                    return true;
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
        public virtual async Task<T> AddOneAsync<T>(T entity) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Add(entity);
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
        public virtual async Task<bool> AddAllAsync<T>(params T[] entities) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().AddRange(entities);
                    await context.SaveChangesAsync();

                    return true;
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
        public virtual async Task<bool> AddAllAsync<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                using (var context = new TContext())
                {
                    context.Set<T>().AddRange(entities);
                    await context.SaveChangesAsync();

                    return true;
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
        #endregion Implementation of IEntityWriter
    }
}